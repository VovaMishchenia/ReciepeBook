using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReciepeBook.View.UserClient
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
    }
    [Serializable]
    public class Cuisine
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    [Serializable]
    public class ReciepeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    [Serializable]
    public class Reciepe
    {
        public int Id { get; set; }
        public string ReciepeName { get; set; }
        public string Ingredients { get; set; }
        public string PhotoPath { get; set; }
        public string Instruction { get; set; }
        public int CookingTime { get; set; }
        public int Calories { get; set; }
        public int Raiting { get; set; }
        public Cuisine Cuisine { get; set; }
        public ReciepeType ReciepeType { get; set; }
    }
    [Serializable]
    public class Message
    {
        public int Id { get; set; }
        public User FromUser { get; set; }
        public Reciepe Reciepe { get; set; }
        public string Text { get; set; }

    }
    [Serializable]
    public class Friend
    {
        public int FriendId { get; set; }
        public int Friend1Id { get; set; }
        public User User { get; set; }
        public User User1 { get; set; }
    }
}
