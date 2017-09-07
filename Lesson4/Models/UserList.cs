using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Lesson4.Models
{
    [XmlRoot("UserList")]
    public class UserList
    {
        [XmlIgnore]
        private static string _tag = "UserList";

        /// <summary>
        /// SessionRessult List
        /// </summary>
        [XmlArray("Users")]
        [XmlArrayItem("User")]
        public List<User> Users = new List<User>();

        public UserList()
        {

        }

        public static UserList Load(string dataPath)
        {
            var serializer = new XmlSerializer(typeof(UserList));
            using (var stream = new FileStream(dataPath, FileMode.Open))
            {
                try
                {
                    return serializer.Deserialize(stream) as UserList;
                }
                catch(InvalidOperationException)
                {
                    return null;   
                }
            }
        }

        public User Check(string email, string password)
        {
            var user = Users.FirstOrDefault(x => (x.Login == email));
            if (user == null)
                return null;

            if (user.Password == password)
                return user;
            return null;
        }

        public void Save(string dataPath)
        {
            var serializer = new XmlSerializer(typeof(UserList));
            using (var stream = new FileStream(dataPath, FileMode.Create))
            {
                serializer.Serialize(stream, this);
            }
        }
    }
}