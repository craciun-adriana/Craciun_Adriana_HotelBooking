namespace Craciun_Adriana_HotelReservation.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; } 
        public Reservation? Reservation { get; set; }
    }
}
