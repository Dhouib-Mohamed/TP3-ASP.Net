using System.Data.SQLite;
using System.Diagnostics;

namespace TP3.Models
{
    public class Person
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string image { get; set; }
        public string country { get; set; }
        public Person(SQLiteDataReader reader)
        {
            this.id = (int)reader["id"];
            this.firstName = (string)reader["first_name"];
            this.lastName = (string)reader["last_name"];
            this.email = (string)reader["email"];
            this.image = (string)reader["image"];
            this.country = (string)reader["country"];
        }

    }
}
