using ApiFirstProj.Common;
using ApiFirstProj.DTO;
using ApiFirstProj.Entities;
using ApiFirstProj.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ApiFirstProj.Services
{
    public class SubjectServices : ISubjectServices
    {
        private readonly ICommonRepo<Subject> _commonRepo;
        private readonly IProfessorServices _professorServices;

        public SubjectServices(ICommonRepo<Subject> commonRepo, IProfessorServices professorServices)
        {
            _commonRepo = commonRepo;
            _professorServices = professorServices;
        }

        public async Task<SubjectResponse> AddSubjectAsync(SubjectAddRequest subject)
        {
            if (subject == null) { throw new ArgumentNullException("Subject details are empty!", nameof(subject)); }

            var response = await _commonRepo.CreateAsync(subject.ToSubject());

            var professor = await _professorServices.GetProfessorViaIdAsync(subject.ProfessorId);
            if (professor == null) {return null;}

            return new SubjectResponse
            {
                Id = response.Id,
                Name = response.Name,
                Description = response.Description,
                ProfessorName = professor.Name
            };

        }

        public async Task<bool> DeleteSubjectViaIdAsync(Guid id)
        {
            var subject = await _commonRepo.GetAsync(s => s.Id == id);
            if (subject == null) { throw new ArgumentException("Subject ID not found", nameof(subject)); }

            bool response = await _commonRepo.DeleteViaIdAsync(subject.Id);
            if (!response) { throw new Exception($"Error deleting Subject {subject.Id}"); }

            return response;
        }

        public async Task<ICollection<SubjectResponse>> GetAllSubjects()
        {
            var response = await _commonRepo.GetAllAsync(null, query => query
            .Include(p => p.Professor)
            .Include(s => s.StudentSubjects)
                .ThenInclude(s => s.Student)
            );

            return response.Select(temp => temp.ToSubjectRespose()).ToList();
        }

        public async Task<SubjectResponse> GetSubjectViaIdAsync(Guid id)
        {
            var response = await _commonRepo.GetAsync(s => s.Id == id, query => query
            .Include(p => p.Professor)
            .Include(s => s.StudentSubjects));

            return response.ToSubjectRespose();
        }

        public async Task<SubjectResponse> UpdateSubjectViaIdAsync(Guid id, SubjectUpdateRequest request)
        {
            var subject = await _commonRepo.GetAsync(s => s.Id == id, query => query
            .Include(p => p.Professor)
                .ThenInclude(s => s.Subjects)
                    .ThenInclude(s => s.StudentSubjects)
            .Include(s => s.StudentSubjects));
            if (subject == null) { return null; }

            subject.Description = request.Description;
            subject.ProfessorId = request.ProfessorId;

            var response = await _commonRepo.UpdateAsync(subject, d => d.Description, p => p.ProfessorId);

            return response.ToSubjectRespose();
        }
    }
}
