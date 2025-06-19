using ApiFirstProj.Common;
using ApiFirstProj.DTO;
using ApiFirstProj.Entities;
using ApiFirstProj.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ApiFirstProj.Services
{
    public class ProfessorServices : IProfessorServices
    {
        private readonly ICommonRepo<Professor> _commonRepo;

        public ProfessorServices(ICommonRepo<Professor> commonRepo)
        {
            _commonRepo = commonRepo;
        }

        public async Task<ProfessorResponse> AddProfessorAsync(ProfessorAddRequest professor)
        {
            if (professor == null) { throw new ArgumentNullException("Student details are empty!", nameof(professor)); }

            var response = await _commonRepo.CreateAsync(professor.ToProfessor());

            return response.ToProfessorResponse();
        }

        public async Task<bool> DeleteProfessorViaIdAsync(Guid id)
        {
            var professor = await _commonRepo.GetAsync(s => s.Id == id);
            if (professor == null) return false;

            bool response = await _commonRepo.DeleteViaIdAsync(professor.Id);
            if (!response) { throw new Exception($"Error deleting Professor {professor.Id}"); }

            return response;
        }

        public async Task<ICollection<ProfessorResponse>> GetAllProfessors()
        {
            var response = await _commonRepo.GetAllAsync(null, query => query
            .Include(s => s.Subjects)
                .ThenInclude(ss => ss.StudentSubjects)
                );

            if (response == null) { return null; }

            return response.Select(p => p.ToProfessorResponse()).ToList();
        }

        public async Task<ProfessorResponse> GetProfessorViaIdAsync(Guid id)
        {
            var response = await _commonRepo.GetAsync(p => p.Id == id, query => query
            .Include(s => s.Subjects)
                .ThenInclude(ss => ss.StudentSubjects));

            if (response == null) { return null; }
            return response.ToProfessorResponse();
        }

        public async Task<ProfessorResponse> UpdateProfessorViaIdAsync(Guid id, ProfessorUpdateRequest request)
        {
            var professor = await _commonRepo.GetAsync(p => p.Id == id, query => query
            .Include(s => s.Subjects)
                .ThenInclude(ss => ss.StudentSubjects));
            if (professor == null) { return null; }

            professor.Name = request.Name;

            var response = await _commonRepo.UpdateAsync(professor, n => n.Name);

            return response.ToProfessorResponse();
        }
    }
}
