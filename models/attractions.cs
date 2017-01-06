using SQLite;

namespace disneyapp.models
{
    public class attractions
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string name { get; set; }
        public string short_name { get; set; }
        public string permalink { get; set; }


    }
}