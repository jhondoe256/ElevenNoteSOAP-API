
using Microsoft.Extensions.Configuration;


namespace ElevenNoteSoapWebAppMvc.Services.CategoryServices
{
    public class CategoryService 
    {
        private readonly IHttpClientFactory _client;
        private readonly IConfiguration _configuration;
        private string _baseUrl;
       
        public CategoryService(IHttpClientFactory client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
            _baseUrl = _configuration["categoryUrl"]!;
        }

       
    }
}
