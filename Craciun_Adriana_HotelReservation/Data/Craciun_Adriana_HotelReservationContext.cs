using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Craciun_Adriana_HotelReservation.Models;

namespace Craciun_Adriana_HotelReservation.Data
{
    public class Craciun_Adriana_HotelReservationContext : DbContext
    {
        public Craciun_Adriana_HotelReservationContext (DbContextOptions<Craciun_Adriana_HotelReservationContext> options)
            : base(options)
        {
        }

        public DbSet<Craciun_Adriana_HotelReservation.Models.Client> Client { get; set; } = default!;
        public DbSet<Craciun_Adriana_HotelReservation.Models.Hotel> Hotel { get; set; } = default!;
        public DbSet<Craciun_Adriana_HotelReservation.Models.Payment> Payment { get; set; } = default!;
        public DbSet<Craciun_Adriana_HotelReservation.Models.Reservation> Reservation { get; set; } = default!;
        public DbSet<Craciun_Adriana_HotelReservation.Models.Review> Review { get; set; } = default!;
        public DbSet<Craciun_Adriana_HotelReservation.Models.Room> Room { get; set; } = default!;
    }
}
