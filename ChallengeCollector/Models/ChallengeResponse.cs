namespace ChallengeCollector.Models;

public class ChallengeResponse
{
    public required Guid Id { get; init; }
    public required byte[] ResultFile { get; init; }
    public required long ResultFileSize { get; init; }
    public byte[]? TestFile { get; init; }
    public long? TestFileSize { get; init; }
    public required DateTimeOffset CreatedAtUtc { get; init; }
    public required string Passphrase { get; init; }
    public required string UniqueHandle { get; init; }
}
