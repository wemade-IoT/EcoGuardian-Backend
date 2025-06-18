using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoGuardian_Backend.CRM.Domain.Model.Aggregates;
using EcoGuardian_Backend.CRM.Domain.Repositories;
using EcoGuardian_Backend.CRM.Domain.Services;

namespace EcoGuardian_Backend.CRM.Application.Internal.QueryServices
{
    public class AnswerQueryService(IAnswerRepository answerRepository) : IAnswerQueryService
    {
        public async Task<IEnumerable<Answer>> GetAnswersByQuestionId(int questionId)
        {

            var answers = await answerRepository.GetAnswersByQuestionId(questionId);
            if (answers == null || !answers.Any())
            {
                throw new KeyNotFoundException($"No answers found for question ID {questionId}");
            }
            return answers;

        }

        public async Task<IEnumerable<Answer>> GetAnswersBySpecialistId(int userId)
        {

            var answers = await answerRepository.GetAnswersBySpecialistId(userId);
            if (answers == null || !answers.Any())
            {
                throw new KeyNotFoundException($"No answers found for specialist ID {userId}");
            }
            return answers;

        }
    }
}