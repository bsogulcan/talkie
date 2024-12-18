using Channel.Domain.Channels;
using Microsoft.EntityFrameworkCore;

namespace Channel.Infrastructure.EntityFrameworkCore;

public class ChannelDbContext : DbContext
{
    public DbSet<Domain.Channels.Channel> Channels { get; set; }

    public ChannelDbContext(DbContextOptions<ChannelDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Channels.Channel>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
        });

        // modelBuilder.Entity<UserWithRole>().HasNoKey();
    }
}