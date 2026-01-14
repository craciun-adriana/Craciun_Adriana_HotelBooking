using Microsoft.ML.Data;

namespace GrpcCustomerLoyalty.Models
{
    public class CustomerLoyaltyData
    {
        [LoadColumn(12)]
        [ColumnName(@"market_segment_type")]
        public string Market_segment_type { get; set; }

        [LoadColumn(13)]
        [ColumnName(@"repeated_guest")]
        public float Repeated_guest { get; set; }

        [LoadColumn(15)]
        [ColumnName(@"no_of_previous_bookings_not_canceled")]
        public float No_of_previous_bookings_not_canceled { get; set; }

        [LoadColumn(16)]
        [ColumnName(@"avg_price_per_room")]
        public float Avg_price_per_room { get; set; }

        [LoadColumn(17)]
        [ColumnName(@"no_of_special_requests")]
        public float No_of_special_requests { get; set; }
    }
}
