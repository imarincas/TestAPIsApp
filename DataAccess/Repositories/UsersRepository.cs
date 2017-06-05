using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DTO;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public UsersDTO GetUser(string username)
        {
            using (var con = new SqlConnection(Config.ConnectionStings.AppDatabase))
            {
                var cmd = new SqlCommand("SELECT * FROM users where username=@username", con);
                cmd.Parameters.Add(new SqlParameter("username", username));
                con.Open();
                var dataReader = cmd.ExecuteReader();
                var userEntry = new UsersDTO();

                while (dataReader.Read())
                {
                        userEntry.Id = int.Parse(dataReader["id"].ToString());
                        userEntry.Username = dataReader["username"].ToString();
                        userEntry.Password = dataReader["password"].ToString();
                }

                return userEntry;
            }
        }
    }
}
