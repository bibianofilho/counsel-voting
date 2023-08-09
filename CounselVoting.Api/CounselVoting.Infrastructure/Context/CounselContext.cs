using CounselVoting.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CounselVoting.Infrastructure.Context
{
    public class CounselContext : DbContext
    {        
        public DbSet<MeasureRuleModel> MeasureRule { get; set; }
        public DbSet<VoteModel> VoteModel { get; set; }

        public CounselContext(DbContextOptions<CounselContext> options) : base(options)
        {

        }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeasureModel>()
                        .HasOne(b => b.MeasureRule)
                        .WithOne(a => a.Measure)
                        .HasForeignKey<MeasureRuleModel>(e => e.MeasureId)
                        .IsRequired();

            modelBuilder.Entity<UserNamesMustVoteToPassModel>()
                        .HasOne(b => b.MeasureRule)
                        .WithMany(a => a.UserNamesMustVoteToPassList)
                        .HasForeignKey(b => b.MeasureRuleId);
        }
    }
}