using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCSHARP
{
    class Notification
    {
        static int Id = 0;
        public Notification()
        {
            ID = Id++;
        }
        public Notification(string content,string time,string username)
        {
            Content = content;
            Time = time;
            Username = username;
        }

        public Notification(string time,string username)
        {
            Time = time;
            Username = username;
        }
        public int ID { get; set; }
        public string Content { get; set; }
        public string Time { get; set; }
        public string Username { get; set; }
        

        public override string ToString()
        {
            return $"ID : {ID}\nFrom username : {Username}\nContent : {Content}\nDate Time : {Time}";
        }

    }
}
