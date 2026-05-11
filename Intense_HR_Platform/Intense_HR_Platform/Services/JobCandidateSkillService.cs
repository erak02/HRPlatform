using Intense_HR_Platform.Models;
using Microsoft.EntityFrameworkCore;


namespace Intense_HR_Platform.Services
{
    public class JobCandidateSkillService : IJobCandidateSkillService
    {
        private readonly ApplicationDbContext _context;
        public JobCandidateSkillService(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public string AddJobCandidate(AddJobCandidateRequest request)
        {
            request.FullName = request.FullName.Trim();

            if (_context.JobCandidates.Any(jc => jc.Email.ToLower() == request.Email.ToLower()))
            {
                return "That job candidate already exists!";
            }

            JobCandidate candidate = new JobCandidate
            {
                FullName = request.FullName,
                DateOfBirth = request.DateOfBirth,
                ContactNo = request.ContactNo,
                Email = request.Email
            };

            _context.JobCandidates.Add(candidate);
            _context.SaveChanges();

            return "Job candidate successfully added!";
        }


        public string AddSkills(Skill skill)
        {
            skill.Name = skill.Name.Trim();

            if(_context.Skills.Any(s => s.Name.ToLower() == skill.Name.ToLower()))
            {
                return "That skill already exists!";
            }

            _context.Skills.Add(skill);
            _context.SaveChanges();

            return "Skill successfully added!";
        }

        public string UpdateJobCandidateWithSkill(int jobCandidateId, string skillName)
        {
            skillName = skillName.Trim();

            if(!_context.JobCandidates.Any(jc => jc.Id == jobCandidateId))
            {
                return "That job candidate does not exist!";
            }
            else if(!_context.Skills.Any(s => s.Name.ToLower() == skillName.ToLower()))
            {
                return "That skill does not exist!";
            }

            Skill skill = _context.Skills.FirstOrDefault(s => s.Name.ToLower() == skillName.ToLower());

            if(_context.JobCandidatesSkills.Any(jcs => (jcs.JobCandidateId == jobCandidateId) && jcs.SkillId == skill.Id))
            {
                return "Candidate already has that skill!";
            }

            JobCandidateSkill jobCandidateSkill = new JobCandidateSkill();
            jobCandidateSkill.JobCandidateId = jobCandidateId;
            jobCandidateSkill.SkillId = skill.Id;

            _context.JobCandidatesSkills.Add(jobCandidateSkill);
            _context.SaveChanges();

            return "Skill successfully added to candidate!";
        }

        public string RemoveSkillFromJobCandidate(int jobCandidateId, string skillName)
        {
            skillName = skillName.Trim();

            if (!_context.JobCandidates.Any(jc => jc.Id == jobCandidateId))
            {
                return "That job candidate does not exist!";
            }
            else if(!_context.Skills.Any(s => s.Name.ToLower() == skillName.ToLower()))
            {
                return "That skill does not exist!";
            }

            Skill skill = _context.Skills.FirstOrDefault(s => s.Name.ToLower() == skillName.ToLower());

            if (_context.JobCandidatesSkills.Any(jcs => jcs.JobCandidateId == jobCandidateId && jcs.SkillId == skill.Id))
            {
                JobCandidateSkill jobCandidateSkill = _context.JobCandidatesSkills.FirstOrDefault(jcs => jcs.JobCandidateId == jobCandidateId && jcs.SkillId == skill.Id);

                _context.JobCandidatesSkills.Remove(jobCandidateSkill);
                _context.SaveChanges();

                return "Skill successfully deleted from candidate!";
            }
            return "Candidate does not have that skill!";
        }

        public string RemoveJobCandidate(int jobCandidateId)
        {
            if(!_context.JobCandidates.Any(jc => jc.Id == jobCandidateId))
            {
                return "That job candidate does not exist!";
            }

            //Remove candidate's skills before deleting the candidate
            List<JobCandidateSkill> jobCandidateSkills = _context.JobCandidatesSkills.Where(jcs => jcs.JobCandidateId == jobCandidateId).ToList();
            _context.JobCandidatesSkills.RemoveRange(jobCandidateSkills);

            JobCandidate jobCandidate = _context.JobCandidates.FirstOrDefault(jc => jc.Id == jobCandidateId);

            _context.JobCandidates.Remove(jobCandidate);
            _context.SaveChanges();

            return "Job candidate successfully deleted!";
        }

        public List<JobCandidate> SearchCandidate(string? jobCandidate, List<string>? skill)
        {
            if(jobCandidate == null && (skill == null || skill.Count == 0))
            {
                return _context.JobCandidates.Include(jc => jc.Skills).ToList();
            }
            else if(jobCandidate != null && (skill == null || skill.Count == 0))
            {
                jobCandidate = jobCandidate.Trim();
                List<JobCandidate> jobCandidates = _context.JobCandidates.Where(jc => jc.FullName.ToLower().Contains(jobCandidate.ToLower())).Include(jc => jc.Skills).ToList();
                return jobCandidates;
            }
            else if(jobCandidate == null && skill != null)
            {
                List<string> skillLower = skill.Select(s => s.ToLower()).ToList();
                List<int> skillIds = _context.Skills.Where(s => skillLower.Contains(s.Name.ToLower())).Select(s => s.Id).ToList();
                List<int> jobCandidateId = _context.JobCandidatesSkills.Where(jcs => skillIds.Contains(jcs.SkillId)).Select(jcs => jcs.JobCandidateId).ToList();
                List<int> finalJobCandidateId = jobCandidateId.GroupBy(id => id).Where(g => g.Count() == skillIds.Count).Select(g => g.Key).ToList();
                List<JobCandidate> finalJobCandidate = _context.JobCandidates.Where(jc => finalJobCandidateId.Contains(jc.Id)).Include(jc => jc.Skills).ToList();
                return finalJobCandidate;
            }
            else if(jobCandidate != null && skill != null)
            {
                List<string> skillLower = skill.Select(s => s.ToLower()).ToList();
                jobCandidate = jobCandidate.Trim();
                List<int> skillIds = _context.Skills.Where(s => skillLower.Contains(s.Name.ToLower())).Select(s => s.Id).ToList();
                List<int> jobCandidateId = _context.JobCandidates.Where(jc => jc.FullName.ToLower().Contains(jobCandidate.ToLower())).Select(jc => jc.Id).ToList();
                List<JobCandidateSkill> jobCandidateSkill = _context.JobCandidatesSkills.Where(jcs => skillIds.Contains(jcs.SkillId) && jobCandidateId.Contains(jcs.JobCandidateId)).ToList();
                List<int> finalJobCandidateId = jobCandidateSkill.Select(jcs => jcs.JobCandidateId).GroupBy(id => id).Where(g => g.Count() == skillIds.Count).Select(g => g.Key).ToList();
                List<JobCandidate> finalJobCandidate = _context.JobCandidates.Where(jc => finalJobCandidateId.Contains(jc.Id)).Include(jc => jc.Skills).ToList();
                return finalJobCandidate;
            }

                return new List<JobCandidate>();
        }
    }
}
