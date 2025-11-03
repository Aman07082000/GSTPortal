using System;
namespace GSTPortal.Interfaces
{
	public interface IAiSummarizationService
	{
            Task<string> SummarizeAsync(string title, string fullText);
    }
}


