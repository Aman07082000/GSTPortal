using GSTPortal.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using GSTPortal.Models;

namespace GSTPortal.Services
{
    public class OpenAiSummarizationService : IAiSummarizationService
    {
        private readonly IConfiguration _config;
        public OpenAiSummarizationService(IConfiguration config) => _config = config;

        public async Task<string> SummarizeAsync(string title, string fullText)
        {
            // Placeholder: call OpenAI/Azure here.
            // Example: send `fullText` to the model and return its summary.
            // Keep this SKETCH until you add an HTTP client & API key.
            await Task.Delay(50);
            var shortSummary = $"[AI SUMMARY for '{title}'] {(fullText?.Length > 250 ? fullText.Substring(0, 240) + "..." : fullText)}";
            return shortSummary;
        }
    }
}