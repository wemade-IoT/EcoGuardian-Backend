using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoGuardian_Backend.CRM.Domain.Model.Aggregates;

namespace EcoGuardian_Backend.CRM.Domain.Services
{
    public interface IAnswerQueryService
    {
        Task<IEnumerable<Answer>> GetAnswersByQuestionId(int questionId);
        Task<IEnumerable<Answer>> GetAnswersBySpecialistId(int userId);
    
    }
}