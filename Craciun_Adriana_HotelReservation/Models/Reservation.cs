namespace Craciun_Adriana_HotelReservation.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public float TotalPrice { get; set; }
        public ReservationStatus Status { get; set; }
        public string? SpecialRequests { get; set; }
        public MarketSegmentType MarketSegment { get; set; }
        public Client? Client { get; set; }
        public Room? Room { get; set; }
    }

}
