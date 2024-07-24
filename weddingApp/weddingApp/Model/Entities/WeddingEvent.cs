using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weddingApp.Model.Entities
{
    public class WeddingEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Budget { get; set; }
        public DateTime WeddingDate { get; set; }
        public Couple Couple { get; set; }
        public List<Gift> Gifts { get; set; }
        public List<Guest> Guests { get; set; }
        public List<WeddingService> WeddingServices { get; set; }
    }
}
