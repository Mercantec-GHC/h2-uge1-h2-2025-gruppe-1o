using System.Text.Json.Serialization;

namespace BlazorWASM.Models
{
    /// <summary>
    /// Model class representing the JSON data returned from NASA's Astronomy Picture of the Day (APOD) API
    /// </summary>
    public class ApodData
    {
        /// <summary>
        /// The date of the APOD image
        /// </summary>
        [JsonPropertyName("date")]
        public string Date { get; set; } = string.Empty;

        /// <summary>
        /// The explanation/description of the astronomical image or phenomenon
        /// </summary>
        [JsonPropertyName("explanation")]
        public string Explanation { get; set; } = string.Empty;

        /// <summary>
        /// The URL for the high-definition version of the image
        /// </summary>
        [JsonPropertyName("hdurl")]
        public string? HdUrl { get; set; }

        /// <summary>
        /// The media type - typically "image" or "video"
        /// </summary>
        [JsonPropertyName("media_type")]
        public string MediaType { get; set; } = string.Empty;

        /// <summary>
        /// The service version of the API
        /// </summary>
        [JsonPropertyName("service_version")]
        public string ServiceVersion { get; set; } = string.Empty;

        /// <summary>
        /// The title of the APOD
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// The URL for the standard version of the image
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
    }
}
