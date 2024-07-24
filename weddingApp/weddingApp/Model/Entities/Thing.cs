namespace weddingApp.Model.Entities
{
    public class Thing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Gift>? Gift { get; set; }
    }
}
