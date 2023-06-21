using OpenAI.Interfaces;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels.ResponseModels;
using OpenAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTApplicationWithOpenAI_API.Services
{
    public class OpenAICompletionService : BackgroundService
    {
       
        readonly IOpenAIService _openAIService;

        //IOpenAIService interfacei referansıyla ilgili servisi constructor üzerinden inject ederiz.
        public OpenAICompletionService(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //Worker service bir konsol uygulaması olduğu için her soruda yeniden başlatmak istemiyoruz. Sorumuzun cevabını aldıktan sonra bir sonraki soruya while döngüsü ile geçebilmeliyiz.
            while (true)
            {
                Console.Write("::");
                // _openAIService üzerinden Completionsa gidip yeni bir Completions oluşturuyoruz.
                CompletionCreateResponse result = await _openAIService.Completions.CreateCompletion(new CompletionCreateRequest()
                {
                    Prompt = Console.ReadLine(),
                    MaxTokens = 500,
                }, Models.TextDavinciV3);
                Console.WriteLine(result.Choices[0].Text);
            }
        }
    }
}

