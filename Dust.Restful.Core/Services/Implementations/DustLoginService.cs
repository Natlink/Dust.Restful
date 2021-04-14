﻿using Dust.Restful.Core.Models;
using Dust.Restful.Core.Repositories.Interfaces;
using Dust.Restful.Core.Services.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dust.Restful.Core.Services.Implementations
{
    public class DustLoginService<T> : ILoginService<T> where T : DustUserModel, new()
    {
        private DustUserRepository<T> UserRepo;

        private Configuration Config;
        private string DailySalt;
        private ConcurrentDictionary<string, T> ConnectedUsers;

        public DustLoginService(DustUserRepository<T> userRepo, IConfigurationService<Configuration> config)
        {
            UserRepo = userRepo;
            Config = config.Get();
            ConnectedUsers = new ConcurrentDictionary<string, T>();
            DailySalt = DateTime.UtcNow + " - "; //+Config.LoginSalt;
            Console.WriteLine("[V] Login service starting.");
        }

        public T UserIsConnected(string token)
        {
            if (ConnectedUsers.ContainsKey(token))
            {
                return (ConnectedUsers[token]);
            }
            return null;
        }

        public T LoginUser(string username, string password, out int errorCode)
        {
            errorCode = 0;
            T u = UserRepo.GetByUsername(username);
            if (u != null && u.Password == password)
            {
                u.Token = GenerateToken(username);
                foreach(T uu in ConnectedUsers.Values)
                {
                    if(uu.ID == u.ID)
                    {
                        if (!LogoutUser(uu.Token))
                        {
                            errorCode = 3;
                            Console.WriteLine("[X] User already connected, can't remove him: " + u.Login);
                        }
                        break;
                    }
                }
                if (ConnectedUsers.TryAdd(u.Token, u))
                {
                    Console.WriteLine("[+] Loged in user: " + u.Login );
                    return u;
                }
                errorCode = 2;
                Console.WriteLine("[X] Error happened, can't add user: " + u.Login);
                return null;
            }
            errorCode = 1;
            Console.WriteLine("[X] Bad credentials: "+username+", "+password);
            return null;
        }

        public bool LogoutUser(string token)
        {
            T u;
            if(ConnectedUsers.ContainsKey(token) && 
                    ConnectedUsers.TryRemove(token, out u))
            {
                Console.WriteLine("[-] Loged out user: " + u.Login);
                return true;
            }
            return false;
        }

        private string GenerateToken(string username)
        {
            string rawData = username+" - "+DateTime.UtcNow+" - "+DailySalt;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}