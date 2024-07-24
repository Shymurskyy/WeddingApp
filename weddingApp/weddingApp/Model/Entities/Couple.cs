using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weddingApp.Model.Entities
{
    public class Couple
    {
        public int Id { get; set; }
        public string BrideName { get; set; }
        public string GroomName { get; set; }
        public int WeddingEventId { get; set; }
        public WeddingEvent WeddingEvent { get; set; }
    }
}
