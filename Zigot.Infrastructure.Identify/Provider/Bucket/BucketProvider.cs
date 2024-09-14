using Microsoft.Extensions.Options;
using Minio;
using Minio.ApiEndpoints;
using Minio.DataModel;
using Minio.DataModel.Args;
using Minio.DataModel.ILM;
using Zigot.Core.Contracts.Global;
using Zigot.Core.Domain.Abstractions.Provider.Bucket;

namespace Zigot.Infrastructure.Identity.Provider.Bucket
{
    public class BucketProvider : IBucketProvider
    {
        private readonly IMinioClient _minioClient;

        public BucketProvider(IOptions<BucketConfiguration> options)
        {
            var settings = options.Value;
            _minioClient = new MinioClient()
                            .WithEndpoint(settings.Endpoint)
                            .WithCredentials(settings.AccessKey, settings.SecretKey)
                            .Build();
        }

        public async Task CreateBucketAsync(string bucketName, BucketLifeTime bucketLifetime, TimeSpan? retentionPeriod = null)
        {
            bool bucketExists = await _minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucketName));
            if (!bucketExists)
            {
                await _minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucketName));

                if (bucketLifetime == BucketLifeTime.Temporary && retentionPeriod.HasValue)
                {
                    var lifecycleConfig = new LifecycleConfiguration();

                    var rule = new LifecycleRule
                    {
                        ID = "ExpireRule",
                        Status = "Enabled",
                        Filter = new RuleFilter(),
                        Expiration = new Expiration
                        {
                            Days = (int)retentionPeriod.Value.TotalDays
                        }
                    };

                    lifecycleConfig.Rules = new System.Collections.ObjectModel.Collection<LifecycleRule>() { rule };

                    var lifecycleArgs = new SetBucketLifecycleArgs()
                        .WithBucket(bucketName)
                        .WithLifecycleConfiguration(lifecycleConfig);

                    await _minioClient.SetBucketLifecycleAsync(lifecycleArgs);
                }
            }
        }

        public async Task UploadFileAsync(string bucketName, string objectName, Stream data)
        {
            await _minioClient.PutObjectAsync(new PutObjectArgs()
                .WithBucket(bucketName)
                .WithObject(objectName)
                .WithStreamData(data)
                .WithObjectSize(data.Length));
        }

        public async Task DeleteFileAsync(string bucketName, string objectName)
        {
            await _minioClient.RemoveObjectAsync(new RemoveObjectArgs().WithBucket(bucketName).WithObject(objectName));
        }

        public async Task<Stream> GetFileAsync(string bucketName, string objectName)
        {
            MemoryStream memoryStream = new MemoryStream();
            await _minioClient.GetObjectAsync(new GetObjectArgs()
                .WithBucket(bucketName)
                .WithObject(objectName)
                .WithCallbackStream(stream => stream.CopyTo(memoryStream)));

            memoryStream.Seek(0, SeekOrigin.Begin);
            return memoryStream;
        }

        public async Task<IEnumerable<string>> ListFilesAsync(string bucketName)
        {
            var files = new List<string>();
            IObservable<Item> observable = _minioClient.ListObjectsAsync(new ListObjectsArgs().WithBucket(bucketName));

            await foreach (var item in observable.ToAsyncEnumerable())
                files.Add(item.Key);

            return files;
        }
    }
}
