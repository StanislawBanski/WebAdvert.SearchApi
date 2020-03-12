using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAdvert.SearchApi.Models;
using WebAdvert.SearchApi.Services;

namespace WebAdvert.SearchApi.Controllers
{
    [Route("search/v1")]
    [ApiController]
    [Produces("application/json")]
    public class Search : ControllerBase
    {
        private readonly ISearchService searchService;
        private readonly ILogger<Search> logger;

        public Search(ISearchService searchService, ILogger<Search> logger)
        {
            this.searchService = searchService;
            this.logger = logger;
        }

        [HttpGet]
        [Route("{keyword}")]
        public async Task<List<AdvertType>> Get(string keyword)
        {
            logger.LogInformation("Search method was called");
            return await searchService.Search(keyword);
        }


    }
}