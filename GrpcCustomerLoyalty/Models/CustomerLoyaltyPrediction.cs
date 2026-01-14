using Microsoft.ML.Data;

namespace GrpcCustomerLoyalty.Models
{
    public class CustomerLoyaltyPrediction
    {
        [ColumnName(@"market_segment_type")]
        public float[] Market_segment_type { get; set; }

        [ColumnName(@"repeated_guest")]
        public uint Repeated_guest { get; set; }

        [ColumnName(@"no_of_previous_bookings_not_canceled")]
        public float No_of_previous_bookings_not_canceled { get; set; }

        [ColumnName(@"avg_price_per_room")]
        public float Avg_price_per_room { get; set; }

        [ColumnName(@"no_of_special_requests")]
        public float No_of_special_requests { get; set; }

        [ColumnName(@"Features")]
        public float[] Features { get; set; }

        [ColumnName(@"PredictedLabel")]
        public float PredictedLabel { get; set; }

        [ColumnName(@"Score")]
        public float[] Score { get; set; }
    }
}
