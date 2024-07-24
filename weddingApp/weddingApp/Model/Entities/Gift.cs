using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weddingApp.Model.Entities
{
    public class Gift
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool IsPurchased { get; set; }
        public int WeddingEventID { get; set; }
        public int ThingId { get; set; }
        public Thing Thing { get; set; }
        public WeddingEvent WeddingEvent { get; set; }
    }

}
