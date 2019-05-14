using System;
using System.Runtime.Serialization;

namespace web_calculator_api.Domain
{
    [Serializable]
    internal class CannnotEvaluateEpressionException : Exception
    {
        public CannnotEvaluateEpressionException()
        {
        }

        public CannnotEvaluateEpressionException(string message) : base(message)
        {
        }

        public CannnotEvaluateEpressionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CannnotEvaluateEpressionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}