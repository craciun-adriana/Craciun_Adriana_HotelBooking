using Craciun_Adriana_HotelReservation.Models;
using Grpc.Net.Client;
using GrpcCustomerLoyalty;
using Microsoft.AspNetCore.Mvc;

namespace Craciun_Adriana_HotelReservation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly GrpcChannel channel;
        public CustomerController()
        {
            channel = GrpcChannel.ForAddress("https://localhost:7035");
        }

        [HttpGet]
        public IActionResult Prediction()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Prediction(int no_bookings_not_canceled, float average_room_price, int no_special_requests, MarketSegmentType market_segment_type)
        {
            var client = new CustomerLoyalty.CustomerLoyaltyClient(channel);
            var request = new LoyaltyRequest
            {
                NoBookingsNotCanceled = no_bookings_not_canceled,
                AverageRoomPrice = average_room_price,
                NoSpecialRequests = no_special_requests,
                MarketSegmentType = market_segment_type.ToString()
            };

            var reply = client.PredictLoyalty(request);
            ViewBag.NoBookingsNotCanceled = no_bookings_not_canceled;
            ViewBag.AverageRoomPrice = average_room_price;
            ViewBag.NoSpecialRequests = no_special_requests;
            ViewBag.MarketSegmentType = market_segment_type;
            ViewBag.IsLoyal = reply.IsLoyalCustomer;
            return View();
        }
    }
}
