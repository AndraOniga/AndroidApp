using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ProiectTry.Models
{
    public class ListEchipament
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(EchipamentAlpin))]
        public int EchipamentAlpinID { get; set; }
        public int EchipamentID { get; set; }
    }
}
