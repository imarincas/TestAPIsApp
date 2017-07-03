using DataAccess.DTO;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement
{
    public class UserController
    {
        public static bool CheckUsername(string username)
        {
            var userRepo = new UsersRepository();
            var user = userRepo.GetUser(username);

            if (username == user.Username)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static UsersDTO LoginUser(string username, string password)
        {
            var userRepo = new UsersRepository();
            var user = userRepo.GetUser(username);

            byte[] data = Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hashedPassword = Encoding.ASCII.GetString(data);

            if (username == user.Username && hashedPassword == user.Password)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public static bool RegisterUser(string username, string password, string firstname, string lastname, string email)
        {
            byte[] data = Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hashedPassword = Encoding.ASCII.GetString(data);

            var user = new UsersDTO
            {
                Username = username,
                Firstname = firstname,
                Lastname = lastname,
                Email = email,
                Password = hashedPassword
            };
            var userRepo = new UsersRepository();
            if (userRepo.InsertUserInDB(user))
            {
                return true;
            }
            else
            {
                return false;

            }
        }
    }
}

