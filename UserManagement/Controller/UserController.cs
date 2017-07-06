using AppManagement.Models;
using DataAccess.DTO;
using DataAccess.Repositories;
using System.Text;

namespace AppManagement.Controller
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
        public static bool CheckUser(User user)
        {
            var userRepo = new UsersRepository();
            var userDTO = userRepo.GetUser(user.Username);

            if (user.Username == userDTO.Username )
            {
                if (user.Id == userDTO.Id)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public static User LoginUser(string username, string password)
        {
            var userRepo = new UsersRepository();
            var user = userRepo.GetUser(username);

            byte[] data = Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hashedPassword = Encoding.ASCII.GetString(data);

            if (username == user.Username && hashedPassword == user.Password)
            {
                return new User {
                Username=user.Username,
                Password=user.Password,
                Firstname=user.Firstname,
                Lastname=user.Lastname,
                Id=user.Id,
                Email=user.Email};
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

            var user = new UserDTO
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

        public static bool UpdateUser(User user)
        {
            var userDTO = new UserDTO
            {
                Username = user.Username,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Password = user.Password,
                Id=user.Id
            };
            var userRepo = new UsersRepository();
            if (userRepo.UpdateUserDetails(userDTO))
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

