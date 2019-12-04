using System;
using ILayer;
using System.Data.SqlClient;
using DataLayer;
using Models;

namespace Data
{
    public class UserDAL : IUserDAL, IUserContainerDAL
    {
        public void Add(UserModel user)
        {
            using (SqlConnection connection = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                connection.Open();
                string query = @"insert into [Users] (Name,Password,Age,Weight,Height, Gender) values ('" + user.Name + "','" + user.Password + "','" +
                user.Age + "','" + user.Weight + "','" + user.Height + "','" + user.Gender + "')";
                SqlCommand qry = new SqlCommand(query, connection);
                qry.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                connection.Open();
                string query = @"Delete from [Users] where UserId = '" + id + "'";
                SqlCommand qry = new SqlCommand(query, connection);
                qry.ExecuteNonQuery();
            }
        }

        public void UpdateUser(int id, string name, int age, int weight, int height, string gender)
        {
            using(SqlConnection conn = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                conn.Open();
                var query = @"update Users set Name ='" + name + "', Age ='" + age + "', Weight ='" + weight + "', Height ='" + height + "', Gender ='" + gender + "' where UserId = '" + id + "'";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public UserModel LogIn(string name, string password)
        {
            using (SqlConnection connection = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                try
                {
                    connection.Open();
                    SqlCommand dataCommand = new SqlCommand()
                    {
                        CommandText = "SELECT * FROM [dbo].[Users] WHERE [Name] = '" + name + "' and [Password] = '" + password + "'",
                        Connection = connection
                    };
                    using (SqlDataReader userReader = dataCommand.ExecuteReader())
                    {
                        userReader.Read();
                        return new UserModel(Convert.ToInt32(userReader["UserId"]), userReader["Password"].ToString(), userReader["Name"].ToString(), Convert.ToInt32(userReader["Age"]), Convert.ToInt32(userReader["Weight"]), Convert.ToInt32(userReader["Height"]), userReader["Gender"].ToString());
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
        public UserModel FindById(int id)
        {
            using (SqlConnection connection = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                try
                {
                    connection.Open();
                    SqlCommand dataCommand = new SqlCommand()
                    {
                        CommandText = "SELECT * FROM [dbo].[Users] WHERE [UserId] = '" + id + "'",
                        Connection = connection
                    };
                    using (SqlDataReader userReader = dataCommand.ExecuteReader())
                    {
                        userReader.Read();
                        return new UserModel(Convert.ToInt32(userReader["UserId"]), userReader["Password"].ToString(), userReader["Name"].ToString(), Convert.ToInt32(userReader["Age"]), Convert.ToInt32(userReader["Weight"]), Convert.ToInt32(userReader["Height"]), userReader["Gender"].ToString());
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
