using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoGuardian_Backend.CRM.Interfaces.Rest.Resources
{
    public record AnswerResource
    {
        public int Id { get; set; }
        public int SpecialistId { get; set; }
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public string AnswerText { get; set; }
        public DateTime CreatedAt { get; set; }
       
    }
}