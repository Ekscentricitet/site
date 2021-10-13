using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SitePractice.Models
{
    /// <summary>
    /// The data that is expected inside the body of a Rate POST request.
    /// </summary>
    public class RatingRequest
    {
        /// <summary>
        /// The ID of the destination that is being rated.
        /// </summary>
        /// 
        public string DestinationId { get; set; }
        /// <summary>
        /// The rating from 1 to 10.
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Empty constructor that allows the JSON serializer to populate the object.
        /// </summary>
        public RatingRequest()
        {

        }

        public override string ToString()
        {
            return JsonSerializer.Serialize (this);
        }
    }
}
