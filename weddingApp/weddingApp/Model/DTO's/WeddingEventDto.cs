namespace weddingApp.Model.DTO_s
{
    public record WeddingEventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Budget { get; set; }
        public DateTime WeddingDate { get; set; }
        public CoupleDto Couple { get; set; }
        public List<GiftDto> Gifts { get; set; }
        public List<GuestDto> Guests { get; set; }
        public List<ServiceDto> WeddingServices { get; set; }
    }
}
