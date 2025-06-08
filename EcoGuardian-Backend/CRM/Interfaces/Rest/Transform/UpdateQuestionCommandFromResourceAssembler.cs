using EcoGuardian_Backend.CRM.Domain.Model.Commands;
using EcoGuardian_Backend.CRM.Domain.Model.ValueObjects;
using EcoGuardian_Backend.CRM.Interfaces.Rest.Resources;

namespace EcoGuardian_Backend.CRM.Interfaces.Rest.Transform
{    public class UpdateQuestionCommandFromResourceAssembler
    {        public static UpdateQuestionCommand ToCommandFromResource(
            UpdateQuestionStatusResource resource)
        {
            // Direct cast since QuestionState enum has explicit int values (1,2,3)
            var questionState = Enum.IsDefined(typeof(QuestionState), resource.Status)
                ? (QuestionState)resource.Status
                : QuestionState.InProcess;
            
            return new UpdateQuestionCommand(
                QuestionId: resource.QuestionId,
                State: questionState
            );
        }
    }
}