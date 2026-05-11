using Intense_HR_Platform.Models;

namespace Intense_HR_Platform.Services
{
    public interface IJobCandidateSkillService
    {
        public string AddJobCandidate(AddJobCandidateRequest jobCandidate);
        public string AddSkills(Skill skill);
        // Using Job candidates IDs instead of names to avoid conflicts with duplicate candidate names
        public string UpdateJobCandidateWithSkill(int jobCandidateId, string skillName);
        public string RemoveSkillFromJobCandidate(int JobCandidateId, string skillName);
        public string RemoveJobCandidate(int JobCandidateId);
        public List<JobCandidate> SearchCandidate(string? jobCandidate, List<string>? skill);
    }
}
