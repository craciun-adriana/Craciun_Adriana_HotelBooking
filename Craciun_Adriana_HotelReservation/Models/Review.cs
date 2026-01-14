namespace Craciun_Adriana_HotelReservation.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int HotelId { get; set; }

        public int Rating { get; set; }
        public string Comment { get; set; }
        public Client? Client { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
