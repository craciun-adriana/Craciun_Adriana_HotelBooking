namespace Craciun_Adriana_HotelReservation.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string RoomNumber { get; set; }
        public RoomType RoomType { get; set; } // Single, Double, Suite
        public int Capacity { get; set; }
        public decimal BasePricePerNight { get; set; }
        public Hotel? Hotel { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }

        public string RoomInfo => $"{Hotel?.Name} - {RoomNumber}";
    }
}
