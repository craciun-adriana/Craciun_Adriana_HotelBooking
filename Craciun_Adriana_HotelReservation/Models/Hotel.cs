using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Craciun_Adriana_HotelReservation.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Stars { get; set; } // 1–5
        public string Description { get; set; }
        public ICollection<Room>? Rooms { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
