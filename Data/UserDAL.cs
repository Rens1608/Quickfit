using System;
using ILayer;
using System.Data.SqlClient;
using DataLayer;
using Models;
using System.Collections.Generic;

namespace Data
{
    public class UserDAL : IUserDAL, IUserContainerDAL
    {
        public void Add(UserModel user, string connectionstring)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                string query = @"insert into [Users] (Name,Password,Age,Weight,Height, Gender) values (@Name, @Password, @Age, @Weight, @Height, @Gender)";
                SqlCommand qry = new SqlCommand(query, connection);
                qry.Parameters.Add("@Name", System.Data.SqlDbType.VarChar);
                qry.Parameters["@Name"].Value = user.Name;
                qry.Parameters.Add("@Password", System.Data.SqlDbType.VarChar);
                qry.Parameters["@Password"].Value = user.Password;
                qry.Parameters.Add("@Age", System.Data.SqlDbType.Int);
                qry.Parameters["@Age"].Value = user.Age;
                qry.Parameters.Add("@Weight", System.Data.SqlDbType.Int);
                qry.Parameters["@Weight"].Value = user.Weight;
                qry.Parameters.Add("@Height", System.Data.SqlDbType.Int);
                qry.Parameters["@Height"].Value = user.Height;
                qry.Parameters.Add("@Gender", System.Data.SqlDbType.VarChar);
                qry.Parameters["@Gender"].Value = user.Gender;
                qry.ExecuteNonQuery();
            }
        }

        public void Delete(int id, string connectionstring)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                string query = @"Delete from [Users] where UserId = @Id";
                SqlCommand qry = new SqlCommand(query, connection);
                qry.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                qry.Parameters["@Id"].Value = id;
                qry.ExecuteNonQuery();
            }
        }

        public void UpdateUser(int id, string name, int age, int weight, int height, string gender, string connectionstring)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var query = @"update Users set Name = @Name, Age = @Age, Weight = @Weight, Height = @Height, Gender = @Gender where UserId = @Id";
                using (SqlCommand qry = new SqlCommand(query, connection))
                {
                    qry.Parameters.Add("@Name", System.Data.SqlDbType.VarChar);
                    qry.Parameters["@Name"].Value = name;
                    qry.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                    qry.Parameters["@Id"].Value = id;
                    qry.Parameters.Add("@Age", System.Data.SqlDbType.Int);
                    qry.Parameters["@Age"].Value = age;
                    qry.Parameters.Add("@Weight", System.Data.SqlDbType.Int);
                    qry.Parameters["@Weight"].Value = weight;
                    qry.Parameters.Add("@Height", System.Data.SqlDbType.Int);
                    qry.Parameters["@Height"].Value = height;
                    qry.Parameters.Add("@Gender", System.Data.SqlDbType.VarChar);
                    qry.Parameters["@Gender"].Value = gender;
                    qry.ExecuteNonQuery();
                }
            }
        }

        public UserModel LogIn(string name, string password, string connectionstring)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    SqlCommand qry = new SqlCommand()
                    {
                        CommandText = "SELECT * FROM [dbo].[Users] WHERE [Name] = @Name and [Password] = @Password",
                        Connection = connection
                    };
                    qry.Parameters.Add("@Name", System.Data.SqlDbType.VarChar);
                    qry.Parameters["@Name"].Value = name;
                    qry.Parameters.Add("@Password", System.Data.SqlDbType.VarChar);
                    qry.Parameters["@Password"].Value = password;
                    using (SqlDataReader userReader = qry.ExecuteReader())
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
        public UserModel FindById(int id, string connectionstring)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                    connection.Open();
                    SqlCommand qry = new SqlCommand()
                    {
                        CommandText = "SELECT * FROM [dbo].[Users] WHERE [UserId] = @Id",
                        Connection = connection
                    };
                    qry.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                    qry.Parameters["@Id"].Value = id;
                    using (SqlDataReader userReader = qry.ExecuteReader())
                    {
                        userReader.Read();
                        return new UserModel(Convert.ToInt32(userReader["UserId"]), userReader["Password"].ToString(), userReader["Name"].ToString(), Convert.ToInt32(userReader["Age"]), Convert.ToInt32(userReader["Weight"]), Convert.ToInt32(userReader["Height"]), userReader["Gender"].ToString());
                    }
            }
        }
        public List<UserModel> GetAll(string connectionstring)
        {
            List<UserModel> tempUsers = new List<UserModel>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand dataCommand = new SqlCommand()
                {
                    CommandText = "SELECT * FROM Users",
                    Connection = connection
                };
                using (SqlDataReader exerciseReader = dataCommand.ExecuteReader())
                {
                    while (exerciseReader.Read())
                    {
                        UserModel tempUser = new UserModel(Convert.ToInt32(exerciseReader["UserId"]), exerciseReader["Name"].ToString(), exerciseReader["Password"].ToString(), Convert.ToInt32(exerciseReader["Age"]), Convert.ToInt32(exerciseReader["Weight"]), Convert.ToInt32(exerciseReader["Height"]), exerciseReader["Gender"].ToString());
                        tempUsers.Add(tempUser);
                    }
                    exerciseReader.Close();
                    return tempUsers;
                }
            }
        }
    }
}
