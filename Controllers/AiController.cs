using Microsoft.AspNetCore.Mvc;
using GSTPortal.Services;
using GSTPortal.Models;
using GSTPortal.Interfaces;

namespace GSTPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AiController : ControllerBase
    {
        private readonly IAiSummarizationService _ai;
        public AiController(IAiSummarizationService ai) => _ai = ai;

        [HttpPost("summarize")]
        public async Task<IActionResult> Summarize(AiSummarizeDto dto)
        {
            var summary = await _ai.SummarizeAsync(dto.Title, dto.FullText);
            var judgment = new Judgment
            {
                Title = dto.Title,
                FullText = dto.FullText,
                Summary = summary
            };
            // In full implementation save to DB
            return Ok(new { summary });
        }
    }

    public record AiSummarizeDto(string Title, string FullText);
}