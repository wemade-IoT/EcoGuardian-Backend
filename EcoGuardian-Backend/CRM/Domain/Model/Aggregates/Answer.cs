using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoGuardian_Backend.CRM.Domain.Model.Commands;

namespace EcoGuardian_Backend.CRM.Domain.Model.Aggregates
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int SpecialistId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        // Constructor
        public Answer()
        {

        }

        public Answer(RegisterAnswerCommand command)
        {
            QuestionId = command.QuestionId;
            Content = command.AnswerText;
            SpecialistId = command.SpecialistId;
            CreatedAt = DateTime.UtcNow;
        }

    }
}