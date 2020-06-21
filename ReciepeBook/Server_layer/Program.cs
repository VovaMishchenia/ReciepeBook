
using Data_access_layer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Server_layer
{
    public class Program
    {
        DbHelper dbHelper = new DbHelper();
        static void Main(string[] args)
        {
            const int port = 2020;
            const int CommandSize = 2;
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
            server.Start();
            while (true)
            {
                Console.WriteLine("Wait");
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected");
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] commandResponce = new byte[CommandSize];
                    stream.Read(commandResponce, 0, CommandSize);
                    string command = Encoding.UTF8.GetString(commandResponce);
                    switch (command)
                    {
                        case "CU":
                            Console.WriteLine("->Creating user");
                            CreateUser(stream);
                            break;
                        case "LU":
                            Console.WriteLine("->Login user");
                            LoginUser(stream);
                            break;
                        case "GM":
                            Console.WriteLine("->Get messages");
                            GetMessages(stream);
                            break;
                        case "DM":
                            Console.WriteLine("->Delete message");
                            DeleteMessage(stream);
                            break;
                        case "AM":
                            Console.WriteLine("->Add new message");
                            AddMessage(stream);
                            break;
                        case "AF":
                            Console.WriteLine("->Add new friendship");
                            AddFriend(stream);
                            break;
                        case "GF":
                            Console.WriteLine("->Get friend list");
                            GetFriends(stream);
                            break;
                        case "DF":
                            Console.WriteLine("->Delete friendship");
                            Deletefriend(stream);
                            break;

                    }
                }
            }
        }

        private static void Deletefriend(NetworkStream stream)
        {
            const int BufferSize = 5;
            byte[] commandResponce = new byte[BufferSize];
            stream.Read(commandResponce, 0, BufferSize);
            string id = Encoding.UTF8.GetString(commandResponce);
            DbHelper.DeleteFriend(Convert.ToInt32(id));
            Console.WriteLine("->Friendship was deleted");
        }

        private static void GetFriends(NetworkStream stream)
        {
            const int BufferSize = 128;
            byte[] commandResponce = new byte[BufferSize];
            stream.Read(commandResponce, 0, BufferSize);
            string email = Encoding.UTF8.GetString(commandResponce);
            List<Friend> friends = new List<Friend>();
            foreach (var item in DbHelper.GetFriends(email))
            {
                friends.Add(new Friend()
                {
                    Friend1Id = (int)item.friend2,
                    FriendId = (int)item.friend1,
                    User = new User()
                    {
                        Id=item.User.Id,
                        Name=item.User.Name,
                        Surname=item.User.Surname,
                        Email=item.User.Email,
                        PhoneNumber=item.User.PhoneNumber,
                        Password=item.User.Password
                    },
                    User1=new User()
                    {
                        Id = item.User1.Id,
                        Name = item.User1.Name,
                        Surname = item.User1.Surname,
                        Email = item.User1.Email,
                        PhoneNumber = item.User1.PhoneNumber,
                        Password = item.User1.Password
                    }
                });
            }
            stream.Flush();
            XmlSerializer xmlSerializer = new XmlSerializer(friends.GetType());
            xmlSerializer.Serialize(stream, friends);
            Console.WriteLine("->Friends list was sent");

        }

        private static void AddFriend(NetworkStream stream)
        {
            const int BufferSize = 128;
            byte[] commandResponce = new byte[BufferSize];
            stream.Read(commandResponce, 0, BufferSize);
            string email = Encoding.UTF8.GetString(commandResponce);
            int userId = DbHelper.IsUser(email);
            stream.Write(Encoding.UTF8.GetBytes(userId.ToString()), 0, userId.ToString().Length);
            if (userId >= 0)
            {
                commandResponce = new byte[BufferSize];
                stream.Read(commandResponce, 0, BufferSize);
                string FromEmail = (Encoding.UTF8.GetString(commandResponce));
                int FromId = DbHelper.IsUser(FromEmail);
                bool isFriendship = DbHelper.IsFriendship(FromId, userId);
                if (!isFriendship)
                {
                    DbHelper.AddFriend(FromId, userId);
                    Console.WriteLine($"->Added new friend: {email} to user:{FromEmail}");
                }

            }
        }

        private static void AddMessage(NetworkStream stream)
        {
            int reciepeId;
            const int BufferSize = 128;
            byte[] commandResponce = new byte[BufferSize];
            stream.Read(commandResponce, 0, BufferSize);

            string email = Encoding.UTF8.GetString(commandResponce);
            int userId = DbHelper.IsUser(email);
            stream.Write(Encoding.UTF8.GetBytes(userId.ToString()), 0, userId.ToString().Length);
            Thread.Sleep(100);
            if (userId >= 0)
            {
                const int BufferSize2 = 3000;
                //XmlSerializer xml = new XmlSerializer(typeof(Reciepe));
                //Reciepe reciepe = (Reciepe)xml.Deserialize(stream);

                int countBytes = 0; 
                string text = "";
                int size = 0;
                    commandResponce = new byte[BufferSize2];
                do
                {
                    countBytes = stream.Read(commandResponce, 0, 1000);
                    
                    text += Encoding.UTF8.GetString(commandResponce, 0, countBytes);
                } while (countBytes > 0);

              
                Console.WriteLine(text.Length);
                Thread.Sleep(100);

                Reciepe reciepe = JsonConvert.DeserializeObject<Reciepe>(text);


                reciepeId = DbHelper.AddReciepe(new Data_access_layer.Reciepe()
                {
                    ReciepeName = reciepe.ReciepeName,
                    Ingredients = reciepe.Ingredients,
                    PhotoPath = reciepe.PhotoPath,
                    Instruction = reciepe.Instruction,
                    TypeId = reciepe.ReciepeType.Id,
                    CuisineId = reciepe.Cuisine.Id,
                    CookingTime = reciepe.CookingTime,
                    Rating = reciepe.Raiting,
                    Calories = reciepe.Calories,

                });
                commandResponce = new byte[BufferSize];
                stream.Read(commandResponce, 0, BufferSize);
                string FromEmail = (Encoding.UTF8.GetString(commandResponce));
                int FromId = DbHelper.IsUser(FromEmail);
                commandResponce = new byte[1024];
                Thread.Sleep(100);

                stream.Read(commandResponce, 0, 1024);
                string message = Encoding.UTF8.GetString(commandResponce);
                DbHelper.AddMessage(FromId, userId, reciepeId, message);
                Console.WriteLine("->New Message added");
            }                 
        }

        private static void AddMessage2(NetworkStream stream)
        {
            int reciepeId;
            const int BufferSize = 128;
            byte[] commandResponce = new byte[BufferSize];
            stream.Read(commandResponce, 0, BufferSize);

            string email = Encoding.UTF8.GetString(commandResponce);

            commandResponce = new byte[BufferSize];
            stream.Read(commandResponce, 0, BufferSize);

            string userEmail= Encoding.UTF8.GetString(commandResponce);

            const int MessageSize = 1000;
            commandResponce = new byte[MessageSize];
            stream.Read(commandResponce, 0, MessageSize);

            string message = Encoding.UTF8.GetString(commandResponce);

            XmlSerializer xml = new XmlSerializer(typeof(Reciepe));
            Reciepe reciepe = (Reciepe)xml.Deserialize(stream);

            int userId = DbHelper.IsUser(email);

            if (userId >= 0)
            {
                reciepeId = DbHelper.AddReciepe(new Data_access_layer.Reciepe()
                {
                    ReciepeName = reciepe.ReciepeName,
                    Ingredients = reciepe.Ingredients,
                    PhotoPath = reciepe.PhotoPath,
                    Instruction = reciepe.Instruction,
                    TypeId = reciepe.ReciepeType.Id,
                    CuisineId = reciepe.Cuisine.Id,
                    CookingTime = reciepe.CookingTime,
                    Rating = reciepe.Raiting,
                    Calories = reciepe.Calories,

                });
                int FromId = DbHelper.IsUser(userEmail);
                DbHelper.AddMessage(FromId, userId, reciepeId, message);
                Console.WriteLine("->New Message added");
            }
        }

        private static void DeleteMessage(NetworkStream stream)
        {
            const int BufferSize = 5;
            byte[] commandResponce = new byte[BufferSize];
            stream.Read(commandResponce, 0, BufferSize);
            string id = Encoding.UTF8.GetString(commandResponce);
            DbHelper.DeleteMessage(Convert.ToInt32(id));
            Console.WriteLine($"->Message with id:{id} was deleted");
        }

        private static void GetMessages(NetworkStream stream)
        {
            const int BufferSize = 128;
            byte[] commandResponce = new byte[BufferSize];
            stream.Read(commandResponce, 0, BufferSize);
            string email = Encoding.UTF8.GetString(commandResponce);
            Thread.Sleep(50);
            List<Data_access_layer.Message> messages = DbHelper.GetMessages(email);
            stream.Flush();
            Thread.Sleep(100);
            List<Message> messagesToSend = new List<Message>();
            foreach (var item in messages)
            {
                messagesToSend.Add(new Message()
                {
                    Id = item.Id,
                    FromUser = new User()
                    {
                        Email = item.User.Email,
                        Password = item.User.Password,
                        Name = item.User.Email,
                        Surname = item.User.Surname,
                        PhoneNumber = item.User.PhoneNumber
                    },
                    Reciepe = new Reciepe()
                    {
                        Id = item.Reciepe.Id,
                        ReciepeName = item.Reciepe.ReciepeName,
                        Ingredients = item.Reciepe.Ingredients,
                        PhotoPath = item.Reciepe.PhotoPath,
                        Instruction = item.Reciepe.Instruction,
                        CookingTime = item.Reciepe.CookingTime,
                        Calories = item.Reciepe.Calories,
                        Raiting = (int)item.Reciepe.Rating,


                        Cuisine = new Cuisine()
                        {
                            Name = item.Reciepe.Cuisine.CuisineName,
                            Id = (int)item.Reciepe.CuisineId
                        },

                        ReciepeType = new ReciepeType()
                        {
                            Name = item.Reciepe.ReciepeType.TypeName,
                            Id = (int)item.Reciepe.TypeId
                        }
                    },
                    Text = item.MessageString
                }); ;
            }
            XmlSerializer xmlSerializer = new XmlSerializer(messagesToSend.GetType());
            xmlSerializer.Serialize(stream, messagesToSend);
            Console.WriteLine("->Messages was sent");

        }

        private static void LoginUser(NetworkStream stream)
        {
            const int BufferSize = 128;
            byte[] commandResponce = new byte[BufferSize];
            stream.Read(commandResponce, 0, BufferSize);
            string email = Encoding.UTF8.GetString(commandResponce);
            Thread.Sleep(50);
            commandResponce = new byte[BufferSize];
            stream.Read(commandResponce, 0, BufferSize);
            string password = Encoding.UTF8.GetString(commandResponce);
            stream.Flush();
            Thread.Sleep(100);
            Data_access_layer.User userData = DbHelper.Login(email, password);
            if (userData != null)
            {
                User user = new User()
                {
                    Id = userData.Id,
                    Email = userData.Email,
                    Password = userData.Password,
                    Name = userData.Name,
                    PhoneNumber = userData.PhoneNumber,
                    Surname = userData.Surname

                };
                XmlSerializer xmlSerializer = new XmlSerializer(user.GetType());
                xmlSerializer.Serialize(stream, user);
                Console.WriteLine($"-> user: {user.Email} was loggined ");
            }
            else
            {
                User user = new User()
                {
                    Email = "none",
                    Password = "none",
                };
                XmlSerializer xmlSerializer = new XmlSerializer(user.GetType());
                xmlSerializer.Serialize(stream, user);
                Console.WriteLine($"-> user wasn't loggined ");
            }
        }

        private static void CreateUser(NetworkStream stream)
        {
            XmlSerializer xml = new XmlSerializer(typeof(User));
            User user = (User)xml.Deserialize(stream);
            DbHelper.AddUser(new Data_access_layer.User()
            {
                Email = user.Email,
                Password = user.Password,
                Name = user.Name,
                Surname = user.Surname,
                PhoneNumber = user.PhoneNumber
            });
            Console.WriteLine($"->New user: {user.Email} was added");
        }
    }
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
