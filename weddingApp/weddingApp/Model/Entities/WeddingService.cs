using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weddingApp.Model.Entities
{
    public class WeddingService
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Number { get; set; }
        public bool Done { get; set; }
        public Service Service { get; set; }
        public int WeddingEventId { get; set; }
        public WeddingEvent WeddingEvent { get; set; }
    }
}
