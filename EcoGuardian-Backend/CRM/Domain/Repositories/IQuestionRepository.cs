using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoGuardian_Backend.CRM.Domain.Model.Aggregates;
using EcoGuardian_Backend.CRM.Domain.Model.ValueObjects;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.CRM.Domain.Repositories
{
    public interface IQuestionRepository : IBaseRepository<Question>
    {
        Task<IEnumerable<Question>> GetQuestionsByPlantId(int plantId);

        Task<IEnumerable<Question>> GetQuestionsByUserId(int userId);

        Task<IEnumerable<Question>> GetQuestionsByState(QuestionState questionState);

        Task<Question?> GetQuestionById(int questionId);
        Task UpdateAsync(Question question);

        Task<IEnumerable<Question>> GetAllQuestions();

    }
}

