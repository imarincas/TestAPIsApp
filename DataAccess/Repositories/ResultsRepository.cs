using DataAccess.DTO;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class ResultsRepository : IResultsRepository
    {

        public bool InsertResultInDB(TestsDTO result)
        {
            using (var con = new SqlConnection(Config.ConnectionStings.AppDatabase))
            {
                var cmd = new SqlCommand("INSERT INTO TResults VALUES ( @request, @response, @userId, @procTime, @uri);", con);

                cmd.Parameters.Add(new SqlParameter("procTime", result.ProcessingTime));
                cmd.Parameters.Add(new SqlParameter("request", result.Request));
                cmd.Parameters.Add(new SqlParameter("response", result.Response));
                cmd.Parameters.Add(new SqlParameter("userId", result.UserId));
                cmd.Parameters.Add(new SqlParameter("uri", result.Uri));

                con.Open();
                var dataReader = cmd.ExecuteNonQuery();

                if (dataReader > 0) return true;
                else return false;
            }
        }

        public List<TestsDTO> GetResults(UsersDTO user)
        {
            var resultsList = new List<TestsDTO>();
            using (var con = new SqlConnection(Config.ConnectionStings.AppDatabase))
            {
                var cmd = new SqlCommand("SELECT * FROM Results where Userid=@userId", con);
                cmd.Parameters.Add(new SqlParameter("userId", user.Id));

                con.Open();
                var dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    var resultEntry = new TestsDTO()
                    {
                        Id = int.Parse(dataReader["id"].ToString()),
                        ProcessingTime = TimeSpan.Parse(dataReader["ProcessingTime"].ToString()),
                        Request = dataReader["request"].ToString(),
                        Response = dataReader["request"].ToString(),
                        UserId=int.Parse(dataReader["userId"].ToString()),
                        Uri=dataReader["Uri"].ToString()
                    };
                    resultsList.Add(resultEntry);
                }
                return resultsList;
            }
        }
    }
}
