using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseTrack.Models.DBModels
{
    public class Horse
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Breed { get; set; }
        public String Gender { get; set; }
        public String Color { get; set; }
        public String Age { get; set; }

        private Dictionary<String, String> info;
        public Dictionary<String, String> Info
        {
            get
            {
                if (info != null) { return info; }
                info = new Dictionary<String, String>
                {
                    {"Breed", Breed},
                    {"Gender", Gender },
                    {"Color", Color },
                    {"Age", Age }
                };
                return info;
            }
        }

        //public List<Event> Events { get; set; }
        //public List<String> Photos { get; set; }
        //public List<String> Files { get; set; }
        //public List<Intake> Intakes { get; set; }
        public User Owner { get; set; }
        public int OwnderID { get; set; }
    }
}
