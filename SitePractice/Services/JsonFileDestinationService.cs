using Microsoft.AspNetCore.Hosting;
using SitePractice.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace SitePractice.Services
{
    
    public class JsonFileDestinationService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        /// <summary>
        /// The name and the location of the JSON database.
        /// </summary>
        public string JsonFileName
        {
            get { return Path.Combine(
                WebHostEnvironment.WebRootPath, "data", "Destinations.json"); }
        }

        public JsonFileDestinationService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Gets all destinations from the JSON database.
        /// </summary>
        /// <returns>A list with the destinations as <see cref="Destination"/> object.</returns>
        public List<Destination> GetDestinations()
        {
            using (var fileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<List<Destination>>(fileReader.ReadToEnd());
            }
        }

        /// <summary>
        /// Adds a rating for a Destination into the JSON database.
        /// </summary>
        /// <param name="destinationId">The ID of the destination to be rated.</param>
        /// <param name="rating">The rating.</param>
        /// <remarks>
        /// The current implementation is highly inneficient 
        /// since it gets and deletes the whole data to update a single entry.
        /// </remarks>
        public void AddRating(string destinationId, int rating)
        {
            var destinations = GetDestinations();
            var destination = destinations.First(destination => destination.Id == destinationId);

            if (destination.Raitings == null)
                destination.Raitings = new List<int>() { rating };
            else
                destination.Raitings.Add(rating);

            // Escapes an issue where the Cyrillic is not written properly.
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(destinations, options);
            File.WriteAllText(JsonFileName, json);
        }
    }
}
