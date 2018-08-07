using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseTrack.Models.Cards
{
    public class SelectorCard
    {
        public String Title { get; set; }
        public List<String> Filters { get; set; }
        public ListCard Items { get; set; }

        public SelectorCard(String Title, List<String> Filters, ListCard Items)
        {
            this.Title = Title;
            this.Filters = Filters;
            this.Items = Items;
        }
    }
}
