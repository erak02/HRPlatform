using Intense_HR_Platform.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Intense_HR_Platform.Models;

namespace Intense_HR_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCandidateSkillController : ControllerBase
    {
        private readonly IJobCandidateSkillService jobCandidateSkillService;

        public JobCandidateSkillController(IJobCandidateSkillService jobCandidateSkillService)
        {
            this.jobCandidateSkillService = jobCandidateSkillService;
        }

        [HttpPost]
        [Route("AddJobCandidate")]
        public string AddJobCandidate(AddJobCandidateRequest request)
        {
            return jobCandidateSkillService.AddJobCandidate(request);
        }

        [HttpPost]
        [Route("AddSkills")]
        public string AddSkills(Skill skill)
        {
            return jobCandidateSkillService.AddSkills(skill);
        }

        [HttpPatch]
        [Route("UpdateJobCandidateWithSkill")]
        public string UpdateJobCandidateWithSkill(int jobCandidateId, string skillName)
        {
            return jobCandidateSkillService.UpdateJobCandidateWithSkill(jobCandidateId, skillName);
        }

        [HttpDelete]
        [Route("RemoveSkillFromJobCandidate")]
        public string RemoveSkillFromJobCandidate(int jobCandidateId, string skillName)
        {
            return jobCandidateSkillService.RemoveSkillFromJobCandidate(jobCandidateId, skillName);
        }

        [HttpDelete]
        [Route("RemoveCandidate")]
        public string RemoveCandidate(int jobCandidateId)
        {
            return jobCandidateSkillService.RemoveJobCandidate(jobCandidateId);
        }

        [HttpGet]
        [Route("SearchCandidate")]
        public List<JobCandidate> SearchCandidate([FromQuery] string? jobCandidate,[FromQuery] List<string>? skill)
        {
            return jobCandidateSkillService.SearchCandidate(jobCandidate, skill);
        }

    }
}
