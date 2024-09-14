using Zigot.Core.Contracts.Global;

namespace Zigot.Core.Domain.Abstractions.Provider.Bucket
{
    public interface IBucketProvider
    {
        Task CreateBucketAsync(string bucketName, BucketLifeTime bucketLifetime, TimeSpan? retentionPeriod = null);
        Task UploadFileAsync(string bucketName, string objectName, Stream data);
        Task DeleteFileAsync(string bucketName, string objectName);
        Task<Stream> GetFileAsync(string bucketName, string objectName);
        Task<IEnumerable<string>> ListFilesAsync(string bucketName);
    }
}
