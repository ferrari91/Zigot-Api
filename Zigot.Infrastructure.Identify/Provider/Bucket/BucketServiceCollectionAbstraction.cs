using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zigot.Core.Domain.Abstractions;
using Zigot.Core.Domain.Abstractions.Provider.Bucket;

namespace Zigot.Infrastructure.Identity.Provider.Bucket
{
    public class BucketServiceCollectionAbstraction : ServiceCollectionAbstraction
    {
        public override void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BucketConfiguration>(opt =>
            {
                var minioSettings = configuration.GetSection("MinioSettings").Get<BucketConfiguration>() ??
                throw new ArgumentNullException(nameof(BucketConfiguration));

                opt.AccessKey = minioSettings.AccessKey;
                opt.SecretKey = minioSettings.SecretKey;
                opt.Endpoint = minioSettings.Endpoint;
            });

            services.AddTransient<IBucketProvider, BucketProvider>();
        }
    }
}
