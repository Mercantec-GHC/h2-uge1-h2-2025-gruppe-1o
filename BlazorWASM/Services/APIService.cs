using System.Text.Json;
using BlazorWASM.Models;

namespace BlazorWASM.Services
{
    /// <summary>
    /// Service class for making API calls to external services
    /// </summary>
    public class APIService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://opgaver.mercantec.tech/api";

        public APIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Fetches the Astronomy Picture of the Day from NASA's APOD API
        /// </summary>
        /// <param name="apiKey">The NASA API key for authentication</param>
        /// <returns>ApodData object containing the daily astronomy picture and information</returns>
        public async Task<ApodData?> GetNasaApodAsync(string apiKey)
        {
            try
            {
                // Construct the request URL with the API key
                var requestUrl = $"https://api.nasa.gov/planetary/apod?api_key={apiKey}";
                
                // Make the HTTP GET request
                var response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    return JsonSerializer.Deserialize<ApodData>(jsonString, options);
                }
                else
                {
                    Console.WriteLine($"NASA APOD API request failed with status: {response.StatusCode}");
                    return null;
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"HTTP error when fetching NASA APOD: {httpEx.Message}");
                return null;
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON deserialization error: {jsonEx.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error when fetching NASA APOD: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Gets backend status for compatibility with existing BackendStatus component
        /// </summary>
        public async Task<BackendStatus?> GetBackendStatusAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/Status/all");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    return JsonSerializer.Deserialize<BackendStatus>(jsonString, options);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl ved tjek af backend status: {ex.Message}");
                return null;
            }
        }
    }

    /// <summary>
    /// Backend status response model
    /// </summary>
    public class BackendStatus
    {
        public ServerStatus? Server { get; set; }
        public DatabaseStatus? MongoDB { get; set; }
        public DatabaseStatus? PostgreSQL { get; set; }
        public DateTime Timestamp { get; set; }
    }

    /// <summary>
    /// Server status model
    /// </summary>
    public class ServerStatus
    {
        public string Status { get; set; } = string.Empty;
    }

    /// <summary>
    /// Database status model
    /// </summary>
    public class DatabaseStatus
    {
        public string Status { get; set; } = string.Empty;
        public string? Database { get; set; }
        public string? Error { get; set; }
        public bool IsError { get; set; }
    }
}
