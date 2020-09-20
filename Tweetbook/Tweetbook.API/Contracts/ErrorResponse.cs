using System.Collections.Generic;

namespace Tweetbook.API.Contracts
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
