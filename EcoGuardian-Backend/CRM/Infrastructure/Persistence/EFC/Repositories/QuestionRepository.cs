using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoGuardian_Backend.CRM.Domain.Model.Aggregates;
using EcoGuardian_Backend.CRM.Domain.Model.ValueObjects;
using EcoGuardian_Backend.CRM.Domain.Repositories;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoGuardian_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoGuardian_Backend.CRM.Infrastructure.Persistence.EFC.Repositories
{
    public class QuestionRepository(AppDbContext context) : BaseRepository<Question>(context), IQuestionRepository
    {
        public async Task<Question> GetQuestionById(int questionId)
        {
            return await context.Set<Question>()
            .Where(q => q.Id == questionId)
            .FirstAsync();
        }

        public async Task<IEnumerable<Question>> GetQuestionsByPlantId(int plantId)
        {
            return await context.Set<Question>()
            .Where(q => q.PlantId == plantId)
            .ToListAsync();
        }


        public async Task<IEnumerable<Question>> GetQuestionsByState(QuestionState questionState)
        {
            return await context.Set<Question>()
                .Where(q => q.State == questionState)
                .ToListAsync();

        }

        public async Task<IEnumerable<Question>> GetQuestionsByUserId(int userId)
        {
            return await context.Set<Question>()
                .Where(q => q.UserId == userId)
                .ToListAsync();
        }

        public Task UpdateAsync(Question question)
        {

            if (question == null)
            {
                throw new ArgumentNullException(nameof(question), "Question cannot be null");
            }

            context.Set<Question>().Update(question);
            return context.SaveChangesAsync();

        }
    }
}