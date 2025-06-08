using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoGuardian_Backend.CRM.Domain.Model.Aggregates;
using EcoGuardian_Backend.CRM.Domain.Model.ValueObjects;
using EcoGuardian_Backend.CRM.Interfaces.Rest.Resources;

namespace EcoGuardian_Backend.CRM.Interfaces.Rest.Transform
{    public class QuestionResourceFromEntityAssembler
    {
        public static QuestionResource ToResourceFromEntity(Question question)
        {
            return new QuestionResource
            {
                QuestionId = question.Id,
                Title = question.Title,
                Content = question.Content,
                Status = ParseQuestionStateToString(question.State),
                CreatedAt = question.CreatedAt,
                PlantId = question.PlantId, 
            };
        }

        private static string ParseQuestionStateToString(QuestionState state)
        {
            return state switch
            {
                QuestionState.InProcess => "In Process",
                QuestionState.Resolved => "Resolved",
                QuestionState.Closed => "Closed",
                _ => "In Process"
            };
        }
    }
}