using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_access_layer
{

    public class DbHelper
    {
        static public User_reciepeEntities userContext = new User_reciepeEntities();

        static public void AddUser(User user)
        {
            userContext.User.Add(user);
            userContext.SaveChanges();
        }
        static public User Login(string email, string password)
        {
            User user = (from item in userContext.User
                         where item.Email == email && item.Password == password
                         select item).FirstOrDefault();


            return user;
        }
        static public List<Message> GetMessages(string email)
        {
            List<Message> messages = (from item in userContext.Message
                                      where item.User1.Email == email
                                      select item).ToList();
            return messages;
        }
        static public void DeleteMessage(int id)
        {
            Message message = (from item in userContext.Message
                               where item.Id == id
                               select item).First();
            if (message != null)
            {
                userContext.Message.Remove(message);
                userContext.SaveChanges();
            }

        }
        static public int IsUser(string email)
        {
            User user = (from item in userContext.User
                         where item.Email == email
                         select item).FirstOrDefault();
            if (user != null)
                return user.Id;
            else
                return -1;
        }

        static public int AddReciepe(Reciepe reciepe)
        {
            Reciepe temp = (from item in userContext.Reciepe
                            where reciepe.ReciepeName == item.ReciepeName
                            select item).FirstOrDefault();
            if (temp == null)
            {
                userContext.Reciepe.Add(reciepe);
                userContext.SaveChanges();
                int id = (from item in userContext.Reciepe
                          where reciepe.ReciepeName == item.ReciepeName
                          select item.Id).First();
                return id;
            }
            else
                return temp.Id;
        }
        static public void AddMessage(int fromId, int toId, int reciepeId, string message)
        {
            Message message1 = new Message()
            {
                FromId = fromId,
                ToId = toId,
                ReciepeId = reciepeId,
                MessageString = message
            };
            userContext.Message.Add(message1);
            userContext.SaveChanges();
        }
        static public void AddFriend(int userId1, int userId2)
        {
            userContext.Friend.Add(new Friend()
            {
                friend1 = userId1,
                friend2 = userId2
            });
            userContext.SaveChanges();
        }
        static public List<Friend> GetFriends(string email)
        {
            List<Friend> friends = (from item in userContext.Friend
                                    where item.User.Email == email
                                    select item).ToList();
            return friends;
        }
        static public void DeleteFriend(int userId)
        {
            Friend friend = (from item in userContext.Friend
                             where item.friend2 == userId
                             select item).First();
            userContext.Friend.Remove(friend);
            userContext.SaveChanges();
        }
        static public bool IsFriendship(int userId1, int userId2)
        {
            Friend friend = (from item in userContext.Friend
                             where item.friend1 == userId1
                             && item.friend2 == userId2
                             select item).FirstOrDefault();
            if (friend == null)
                return false;
            else
                return true;
        }
    
    }
}
