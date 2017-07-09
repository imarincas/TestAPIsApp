using DataAccess.DTO;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class ResultsRepository : IResultsRepository
    {

        public bool InsertTestcaseInDB(TestsDTO testcase)
        {
            using (var con = new SqlConnection(Config.ConnectionStings.AppDatabase))
            {
                var cmd = new SqlCommand("INSERT INTO TESTCASES VALUES ( @request, @response, @userId, @procTime, @uri,@header, @servicename);", con);

                cmd.Parameters.Add(new SqlParameter("procTime", testcase.ProcessingTime));
                cmd.Parameters.Add(new SqlParameter("request", testcase.Request));
                cmd.Parameters.Add(new SqlParameter("response", testcase.Response));
                cmd.Parameters.Add(new SqlParameter("userId", testcase.UserId));
                cmd.Parameters.Add(new SqlParameter("uri", testcase.Uri));
                cmd.Parameters.Add(new SqlParameter("header", testcase.ServiceName));
                cmd.Parameters.Add(new SqlParameter("servicename", testcase.ServiceName));

                con.Open();
                var dataReader = cmd.ExecuteNonQuery();

                if (dataReader > 0) return true;
                else return false;
            }
        }

        public List<TestsDTO> GetResults(UserDTO user)
        {
            var resultsList = new List<TestsDTO>();
            using (var con = new SqlConnection(Config.ConnectionStings.AppDatabase))
            {
                var cmd = new SqlCommand("SELECT * FROM TESTCASES where Userid=@userId", con);
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
                        Uri=dataReader["Uri"].ToString(),
                        ServiceName=dataReader["ServiceName"].ToString()
                    };
                    resultsList.Add(resultEntry);
                }
                return resultsList;
            }
        }

        public List<string> GetServicename()
        {
            var serviceList = new List<string>();
            using (var con = new SqlConnection(Config.ConnectionStings.AppDatabase))
            {
                var cmd = new SqlCommand("SELECT DISTINCT ServiceName FROM TESTCASES", con);
                con.Open();
                var dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    serviceList.Add(dataReader["ServiceName"].ToString());
                }
                return serviceList; 
            }
        }
    }
}
