using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoGuardian_Backend.CRM.Domain.Model.Aggregates;
using EcoGuardian_Backend.CRM.Interfaces.Rest.Resources;

namespace EcoGuardian_Backend.CRM.Interfaces.Rest.Transform
{
    public class AnswerResourceFromEntityAssembler
    {
        
        public static AnswerResource FromEntity(Answer answer, Question question)
        {
            if (answer == null || question == null)
            {
                return null;
            }

            return new AnswerResource
            {
                Id = answer.Id,
                QuestionId = answer.QuestionId,
                AnswerText = answer.Content,
                CreatedAt = answer.CreatedAt,
                QuestionTitle = question.Title,
                SpecialistId = answer.SpecialistId
            };
        }

    }
}