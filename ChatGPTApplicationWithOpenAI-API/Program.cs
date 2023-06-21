using ChatGPTApplicationWithOpenAI_API;
using ChatGPTApplicationWithOpenAI_API.Services;
using OpenAI.Extensions;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
       
        //OpenAIService fonksiyonuyla bu servisin bütün instancelerini veya service sýnýflarýný uygulayamaya entegere etmiþ olduk.
        services.AddOpenAIService(settings => settings.ApiKey = "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");
        services.AddHostedService<Worker>();
        //services.AddHostedService<OpenAICompletionService>();
        services.AddHostedService<OpenAIImageService>();
    })
    .Build();

await host.RunAsync();
