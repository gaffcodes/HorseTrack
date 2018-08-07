using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HorseTrack.Models.DBModels;

namespace HorseTrack.Models.Cards
{
    public class ListCard
    {
        public Dictionary<String, String> Items { get; set; }

        public ListCard(Dictionary<String, String> List)
        {
            Items = List;
        }
    }
}
