using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json.Linq;

namespace azure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslatorController : Controller
    {
        [HttpGet]
        [Route("/translator")]
        public IActionResult Translator()
        {
            return View();
        }

        [HttpPost]
        [Route("/translator")]
        public async Task<IActionResult> TranslatorResults()
        {
            // Read the values from the form
            string originalText = Request.Query.ContainsKey("text") ? Request.Query["text"].ToString() : "";
            string targetLanguage = Request.Query.ContainsKey("language") ? Request.Query["language"].ToString() : "";

            // Load the values from environment variablesvar config =
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();
            string key = config["AI_SERVICES_KEY"] ?? throw new InvalidOperationException("AI_SERVICES_KEY environment variable is not set.");
            string endpoint = config["TRANSLATOR_ENDPOINT"] ?? throw new InvalidOperationException("TRANSLATOR_ENDPOINT environment variable is not set.");
            string location = config["LOCATION"] ?? throw new InvalidOperationException("LOCATION environment variable is not set.");

            // Indicate that we want to translate and the API version (3.0) and the target language
            string path = "/translate?api-version=3.0";
            // Add the target language parameter
            string targetLanguageParameter = "&to=" + targetLanguage;
            // Create the full URL
            string constructedUrl = endpoint + path + targetLanguageParameter;

            // Set up the header information, which includes our subscription key
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Region", location);
                //client.DefaultRequestHeaders.Add("Content-type", "application/json");
                client.DefaultRequestHeaders.Add("X-ClientTraceId", Guid.NewGuid().ToString());

                // Set up the body of the request
                var body = new[] { new { text = originalText } };
                var content = new StringContent(JArray.FromObject(body).ToString(), Encoding.UTF8, "application/json");

                try
                {
                    // Make the request
                    var response = await client.PostAsync(constructedUrl, content);
                    response.EnsureSuccessStatusCode(); // Raise an exception for HTTP errors

                    // Parse the JSON response
                    var result = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JArray.Parse(result);
                    string translatedText = jsonResponse?[0]?["translations"]?[0]?["text"]?.ToString() ?? "Translation not available";

                    ViewData["TranslatedText"] = translatedText;
                }
                catch (HttpRequestException e)
                {
                    // Handle any request exceptions
                    ViewData["TranslatedText"] = $"An error occurred: {e.Message}";
                }
                catch (Exception e)
                {
                    // Handle any other exceptions
                    ViewData["TranslatedText"] = $"An unexpected error occurred: {e.Message}";
                }
            }

            return View();
        }
    }
}