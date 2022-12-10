using System.Data.SQLite;

namespace TP3.Models

{
    public class Personal_info
    {

        SQLiteConnection database;
        public Personal_info()
        {
            string connectionString = "Data source=.\\database.db;";
            database = new SQLiteConnection(connectionString);
            database.Open();
        }
        public List<Person> GetAllPerson()
        {

            List<Person> persons = new List<Person>();
            using (database)
            {
                SQLiteCommand command = new SQLiteCommand(
                    "SELECT * FROM personal_info", database
                    );
                SQLiteDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        persons.Add(new Person(reader));
                    }
                }
            }
            return persons;
        }
        public Person? GetPerson(int? id)
        {
            Person? person = null;
                using (database)
                {
                    SQLiteCommand command = new SQLiteCommand(
                        $"SELECT * FROM personal_info WHERE id = {id}", database
                        );
                    SQLiteDataReader reader = command.ExecuteReader();
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            person = new Person(reader);
                        }
                    }
            }
            return person;
        }

        internal int GetId(String first_name, String country)
        {
            int id=0;
            using (database)
            {
                SQLiteCommand command = new SQLiteCommand(
                    $"SELECT * FROM personal_info WHERE first_name = '{first_name}' AND country = '{country}'", database
                    );
                SQLiteDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        id = (int)reader["id"];
                    }
                }
            }
            return id;
        }
    }
}
