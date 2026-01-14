

using Grpc.Core;
using GrpcCustomerLoyalty.Models;
using Microsoft.ML;

namespace GrpcCustomerLoyalty.Services
{
    public class CustomerLoyaltyService : CustomerLoyalty.CustomerLoyaltyBase
    {
        private readonly PredictionEngine<CustomerLoyaltyData, CustomerLoyaltyPrediction> _predictionEngine;
        public CustomerLoyaltyService()
        {
            var mlContext = new MLContext();
            string mlModelPath = "MLCustomerLoyalty.mlnet";
            ITransformer mlModel = mlContext.Model.Load(mlModelPath, out _);
            _predictionEngine = mlContext.Model.CreatePredictionEngine<CustomerLoyaltyData, CustomerLoyaltyPrediction>(mlModel);
        }
        public override Task<LoyaltyReply> PredictLoyalty(LoyaltyRequest request, ServerCallContext context)
        {
            var input = new CustomerLoyaltyData
            {
                No_of_previous_bookings_not_canceled = request.NoBookingsNotCanceled,
                Avg_price_per_room = request.AverageRoomPrice,
                No_of_special_requests = request.NoSpecialRequests,
                Market_segment_type = request.MarketSegmentType,
            };
            var prediction = _predictionEngine.Predict(input);
            var isLoyal = prediction.Score[1] > prediction.Score[0];
            var reply = new LoyaltyReply
            {
                IsLoyalCustomer = isLoyal,
            };
            return Task.FromResult(reply);
        }
    }
}