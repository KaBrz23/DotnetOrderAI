using Google.Cloud.Firestore;
using Microsoft.ML.Data;

namespace DotnetOrderAI.Models
{
    [FirestoreData]
    public class SentimentData
    {
        [FirestoreProperty]
        [LoadColumn(0)]
        public string? Text { get; set; }
        [FirestoreProperty]
        [LoadColumn(1)]
        public bool Sentiment { get; set; }// true = positivo
    }

    public class SentimentPrediction : SentimentData
    {
        [FirestoreProperty]
        [ColumnName("PredictionLabel")]
        public bool Prediction { get; set; }
        [FirestoreProperty]
        public float Probability { get; set; }
        [FirestoreProperty]
        public float[] Score { get; set; }
    }
}
