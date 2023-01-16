using SQLite;
using SQLiteNetExtensions.Attributes;
namespace ProiectTry.Models
{
    public class Echipament
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Denumire { get; set; }
        public string Producator { get; set; }
        [OneToMany]
        public List<ListEchipament> ListEchipamente { get; set; }
    }
}
