using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseTrack.Models.DBModels
{
    public class User
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String[] Address { get; set; }

        private Dictionary<String, String> info;
        public Dictionary<String, String> Info
        {
            get
            {
                if (info != null) { return info; }
                info = new Dictionary<String, String>
                {
                    {"Phone", Phone },
                    {"Email", Email },
                    {"Address1", Address[0] },
                    {"Address2", Address[1] },
                    {"Address3", Address[2] },
                };
                return info;
            }
        }

        //public List<Event> Events { get; set; }
        //public List<Bill> Bills { get; set; }
        public List<Horse> Horses { get; set; }
    }
}
