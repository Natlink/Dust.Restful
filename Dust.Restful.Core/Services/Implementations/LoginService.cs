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
    public class LoginService : ILoginService
    {
        /*
        private IUserRepository UserRepo;
        private Configuration Config;
        private string DailySalt;
        private ConcurrentDictionary<string, LogedUser> ConnectedUsers;

        public LoginService(IUserRepository userRepo, IConfigurationService config)
        {
            UserRepo = userRepo;
            Config = config.Get();
            ConnectedUsers = new ConcurrentDictionary<string, LogedUser>();
            DailySalt = DateTime.UtcNow+" - "+Config.LoginSalt;
            Console.WriteLine("[V] Login service starting.");
        }

        public LogedUser UserIsConnected(string token)
        {
            if (ConnectedUsers.ContainsKey(token))
            {
                return (ConnectedUsers[token]);
            }
            return null;
        }

        public LogedUser LoginUser(string username, string password, out int errorCode)
        {
            errorCode = 0;
            User u = UserRepo.GetByUsername(username);
            if (u != null && u.Password == password)
            {
                LogedUser l = new LogedUser(u.ID, GenerateToken(username), u.Name, u.AccountLevel, DateTime.UtcNow.AddMinutes(Config.SessionDurationMinute));
                if (ConnectedUsers.TryAdd(l.Token, l))
                {
                    Console.WriteLine("[+] Loged in user: " + l.Name + ", Timeout at: " + l.TimeOut + ", " + l.IsTimeout);
                    return l;
                }
                else if (Config.MultiConnectionAccount && ConnectedUsers.TryGetValue(l.Token, out l))
                {
                    l.TimeOut = DateTime.UtcNow.AddMinutes(Config.SessionDurationMinute);
                    Console.WriteLine("[+] User already connected, allowed: " + l.Name + ", Timeout at: " + l.TimeOut + ", " + l.IsTimeout);
                    return l;
                }
                errorCode = 2;
                Console.WriteLine("[X] User already connected: " + l.Name);
                return null;
            }
            errorCode = 1;
            Console.WriteLine("[X] Bad credentials: "+username+", "+password);
            return null;
        }

        public bool LogoutUser(string token)
        {
            LogedUser u;
            if(ConnectedUsers.ContainsKey(token) && 
                    ConnectedUsers.TryRemove(token, out u))
            {
                Console.WriteLine("[-] Loged out user: " + u.Name);
                return true;
            }
            return false;
        }

        private string GenerateToken(string username)
        {
            string rawData = username+" - "+DailySalt;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        */
        public bool LogoutUser(string token)
        {
            throw new NotImplementedException();
        }
    }
}
