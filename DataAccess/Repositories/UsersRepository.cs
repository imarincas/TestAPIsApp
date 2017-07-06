using DataAccess.Interfaces;
using DataAccess.DTO;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        public UserDTO GetUser(string username)
        {
            using (var con = new SqlConnection(Config.ConnectionStings.AppDatabase))
            {
                var cmd = new SqlCommand("SELECT * FROM users where username=@username", con);
                cmd.Parameters.Add(new SqlParameter("username", username));
                con.Open();
                var dataReader = cmd.ExecuteReader();
                var userEntry = new UserDTO();

                while (dataReader.Read())
                {
                    userEntry.Id = int.Parse(dataReader["id"].ToString());
                    userEntry.Username = dataReader["username"].ToString();
                    userEntry.Password = dataReader["password"].ToString();
                    userEntry.Firstname = dataReader["firstname"].ToString();
                    userEntry.Lastname = dataReader["lastname"].ToString();
                    userEntry.Email = dataReader["email"].ToString();
                }

                return userEntry;
            }
        }

        public bool InsertUserInDB(UserDTO user)
        {
            using (var con = new SqlConnection(Config.ConnectionStings.AppDatabase))
            {
                var cmd = new SqlCommand("INSERT INTO USERS VALUES (@username, @password, @firstname, @lastname, @email);", con);

                cmd.Parameters.Add(new SqlParameter("username", user.Username));
                cmd.Parameters.Add(new SqlParameter("password", user.Password));
                cmd.Parameters.Add(new SqlParameter("firstname", user.Firstname));
                cmd.Parameters.Add(new SqlParameter("lastname", user.Lastname));
                cmd.Parameters.Add(new SqlParameter("email", user.Email));

                con.Open();
                var dataReader = cmd.ExecuteNonQuery();

                if (dataReader > 0) return true;
                else return false;
            }
        }

        public bool UpdateUserDetails(UserDTO user)
        {
            using (var con = new SqlConnection(Config.ConnectionStings.AppDatabase))
            {
                var cmd = new SqlCommand("UPDATE USERS SET USERNAME=@username, PASSWORD=@password, FIRSTNAME=@firstname, LASTNAME=@lastname, EMAIL=@email WHERE ID=@id", con);

                cmd.Parameters.Add(new SqlParameter("username", user.Username));
                cmd.Parameters.Add(new SqlParameter("password", user.Password));
                cmd.Parameters.Add(new SqlParameter("firstname", user.Firstname));
                cmd.Parameters.Add(new SqlParameter("lastname", user.Lastname));
                cmd.Parameters.Add(new SqlParameter("email", user.Email));
                cmd.Parameters.Add(new SqlParameter("id", user.Id));

                con.Open();
                var dataReader = cmd.ExecuteNonQuery();

                if (dataReader > 0) return true;
                else return false;
            }
        }
    }
}
