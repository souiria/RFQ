using System;
using System.Linq;
using System.Net.Http;

namespace Common.UX.Api.Exceptions
{
    public class ServiceApiException : Exception
    {

        public ServiceApiException(HttpResponseMessage response, ExceptionResponse inner) : base(ConvertResponseToMessage(response, inner), inner)
        {

        }

        private static string ConvertResponseToMessage(HttpResponseMessage response, ExceptionResponse inner)
        {
            var text= $"Service Api failed to complete request to {response.RequestMessage.RequestUri.Segments.Last()}";
            if (inner != null)
            {
                text += $": {{ {inner.ExceptionType}: '{inner.ExceptionMessage}' }}.";
            }

            text += ".";
            return text;
        }
    }
}
