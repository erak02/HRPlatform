using Microsoft.EntityFrameworkCore;

namespace Intense_HR_Platform.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions options) : base(options)
        {

        }
        public DbSet<JobCandidate> JobCandidates { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<JobCandidateSkill> JobCandidatesSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobCandidate>().HasKey(jc => jc.Id);
            modelBuilder.Entity<Skill>().HasKey(s => s.Id);
            // Configures many-to-many relationship between JobCandidate and Skill through the JobCandidateSkill junction table
            modelBuilder.Entity<JobCandidate>()
                .HasMany(jc => jc.Skills)              
                .WithMany()                             
                .UsingEntity<JobCandidateSkill>(        
                    j => j.HasOne<Skill>().WithMany().HasForeignKey(jcs => jcs.SkillId),
                    j => j.HasOne<JobCandidate>().WithMany().HasForeignKey(jcs => jcs.JobCandidateId),
                    j => j.HasKey(jcs => new { jcs.JobCandidateId, jcs.SkillId }) 
                );

            modelBuilder.Entity<JobCandidate>().HasIndex(jc => jc.Email).IsUnique();
            modelBuilder.Entity<Skill>().HasIndex(s => s.Name).IsUnique();

            modelBuilder.Entity<JobCandidate>().HasData(new JobCandidate { Id = 1, FullName = "Nikola Erak", DateOfBirth = new DateTime(2002, 1, 21), ContactNo = "+381655525711", Email = "eraknikola1@gmail.com" });
            modelBuilder.Entity<JobCandidate>().HasData(new JobCandidate { Id = 2, FullName = "Marko Erak", DateOfBirth = new DateTime(1997, 1, 08), ContactNo = "+381643828232", Email = "markoerak97@gmail.com" });
            modelBuilder.Entity<JobCandidate>().HasData(new JobCandidate { Id = 3, FullName = "Milan Polić", DateOfBirth = new DateTime(2002, 12, 14), ContactNo = "+381605827127", Email = "mikipol14@gmail.com" });
            modelBuilder.Entity<JobCandidate>().HasData(new JobCandidate { Id = 4, FullName = "Marko Marković", DateOfBirth = new DateTime(2001, 08, 28), ContactNo = "+381601593250", Email = "markomarkovic@gmail.com" });
            modelBuilder.Entity<JobCandidate>().HasData(new JobCandidate { Id = 5, FullName = "Petar Petrović", DateOfBirth = new DateTime(2004, 03, 07), ContactNo = "381655525600", Email = "petrovicpetar@gmail.com" });

            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 1, Name = "c#" });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 2, Name = "java" });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 3, Name = "c++" });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 4, Name = "Database design" });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 5, Name = "English language" });
            modelBuilder.Entity<Skill>().HasData(new Skill { Id = 6, Name = "Russian language" });

            modelBuilder.Entity<JobCandidateSkill>().HasData(new JobCandidateSkill { JobCandidateId = 1, SkillId = 1 });
            modelBuilder.Entity<JobCandidateSkill>().HasData(new JobCandidateSkill { JobCandidateId = 1, SkillId = 2 });
            modelBuilder.Entity<JobCandidateSkill>().HasData(new JobCandidateSkill { JobCandidateId = 1, SkillId = 4 });
            modelBuilder.Entity<JobCandidateSkill>().HasData(new JobCandidateSkill { JobCandidateId = 1, SkillId = 5 });
            modelBuilder.Entity<JobCandidateSkill>().HasData(new JobCandidateSkill { JobCandidateId = 2, SkillId = 3 });
            modelBuilder.Entity<JobCandidateSkill>().HasData(new JobCandidateSkill { JobCandidateId = 2, SkillId = 5 });
            modelBuilder.Entity<JobCandidateSkill>().HasData(new JobCandidateSkill { JobCandidateId = 3, SkillId = 3 });
            modelBuilder.Entity<JobCandidateSkill>().HasData(new JobCandidateSkill { JobCandidateId = 3, SkillId = 5 });
            modelBuilder.Entity<JobCandidateSkill>().HasData(new JobCandidateSkill { JobCandidateId = 4, SkillId = 5 });
            modelBuilder.Entity<JobCandidateSkill>().HasData(new JobCandidateSkill { JobCandidateId = 4, SkillId = 6 });
            modelBuilder.Entity<JobCandidateSkill>().HasData(new JobCandidateSkill { JobCandidateId = 5, SkillId = 6 });
        }
    }
}
