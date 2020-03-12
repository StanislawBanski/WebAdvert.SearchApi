using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;
using WebAdvert.SearchApi.Services;

namespace SearchApi.HealthChecks
{
    public class ElasticSearchHealthChecks: IHealthCheck
    {
        private readonly ISearchService searchService;

        public ElasticSearchHealthChecks(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var isAlive = await searchService.CheckHealthAsync();

            return isAlive ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy();
        }
    }
}