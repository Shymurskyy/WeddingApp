namespace weddingApp.Model.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WeddingServiceId { get; set; }
        public WeddingService WeddingService { get; set; }
    }
}
