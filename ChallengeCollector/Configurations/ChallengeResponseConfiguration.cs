using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ChallengeCollector.Models;

namespace ChallengeCollector.Configurations;
public class ChallengeResponseConfiguration : IEntityTypeConfiguration<ChallengeResponse>
{
    public void Configure(EntityTypeBuilder<ChallengeResponse> builder)
    {
        builder.ToTable("challenge_response");

        builder.Property(a => a.UniqueHandle).HasMaxLength(200);
        builder.Property(a => a.Passphrase).HasMaxLength(200);

        builder.HasIndex(a => a.UniqueHandle);
    }
}
