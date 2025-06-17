
using EcoGuardian_Backend.CRM.Domain.Model.Commands;
using EcoGuardian_Backend.CRM.Domain.Model.ValueObjects;
using EcoGuardian_Backend.CRM.Domain.Services;

namespace EcoGuardian_Backend.CRM.Application.Internal.EventHandlers
{
    public class AddedQuestionEventHandler(IQuestionCommandService questionCommandService) : IAddedQuestionEventHandler
    {
        public async Task HandleAnswerAddedAsync(int questionId)
        {
            var command = new UpdateQuestionCommand(questionId, QuestionState.Resolved);

            // Update the question state to Resolved when an answer is added
            await questionCommandService.Handle(command);
            
            Console.WriteLine($"Answer has been registered for Question {questionId}.");
        }

    }
}