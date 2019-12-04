using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public string Gender { get; set; }
        public string LoginErrorMessage { get; set; }

        public UserModel(int id, string password, string name, int age, int weight, int height, string gender)
        {
            Id = id;
            Name = name;
            Password = password;
            Age = age;
            Weight = weight;
            Height = height;
            Gender = gender;
        }

        public UserModel(string name, string password, int age, int weight, int height, string gender)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Height = height;
            Gender = gender;
        }

        public UserModel()
        {

        }
    }
}
