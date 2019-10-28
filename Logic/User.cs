using System;
using ILayer;

namespace Logic
{
    public class User : IUserDAL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public bool Gender { get; set; }

        public User()
        {

        }

        public User(int id, string name, int age, int weight, int height, bool gender)
        {
            Id = id;
            Name = name;
            Age = age;
            Weight = weight;
            Height = height;
            Gender = gender;
        }

        public void Update(string name)
        {
            throw new NotImplementedException();
        }
    }
}
