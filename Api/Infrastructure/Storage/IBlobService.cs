namespace Api.Infrastructure.Storage
{
    internal interface IBlobService
    {
        Task<Guid> UploadAsync(Stream stream, string contentType, CancellationToken cancellationToken = default);
        Task<FileRespone> DowloadAsync(Guid fileId, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid fileId, CancellationToken cancellationToken = default);
    }
}