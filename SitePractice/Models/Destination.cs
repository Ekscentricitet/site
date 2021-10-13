using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SitePractice.Models
{
    /// <summary>
    /// Base class that represents the destinations from the database.
    /// </summary>
    public class Destination
    {
        /// <summary>
        /// The unique ID of the destination.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the destination.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The city in which the destination is located.
        /// TODO: Take into account destinations that are not in any city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// A short description of the destination.
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// A list with all received ratings.
        /// </summary>
        public List<int> Raitings { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize (this);
        }
    }
}
