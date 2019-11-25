using System;

namespace Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public string Gender { get; set; }

        public UserModel(int id, string name, int age, int weight, int height, string gender)
        {
            Id = id;
            Name = name;
            Age = age;
            Weight = weight;
            Height = height;
            Gender = gender;
        }

        public UserModel(string name, int age, int weight, int height, string gender)
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
