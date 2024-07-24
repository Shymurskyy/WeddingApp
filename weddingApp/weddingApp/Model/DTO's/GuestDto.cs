namespace weddingApp.Model.DTO_s
{
    public record GuestDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool AccompanyingPerson { get; set; }
        public bool InviteSent { get; set; }
        public int WeddingEventId { get; set; }
    }
}
