using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoGuardian_Backend.CRM.Application.Internal.CommandServices;
using EcoGuardian_Backend.CRM.Domain.Model.Commands;
using EcoGuardian_Backend.CRM.Domain.Model.ValueObjects;
using EcoGuardian_Backend.CRM.Domain.Services;

namespace EcoGuardian_Backend.CRM.Application.Internal.EventHandlers
{
    public class AddedQuestionEventHandler(IQuestionCommandService questionCommandService) : IAddedQuestionEventHandler
    // 🎯 Cambiar QuestionCommandService por IQuestionCommandService
    {
        public async Task HandleAnswerAddedAsync(int questionId)
        {
            var command = new UpdateQuestionCommand(questionId, QuestionState.Resolved);
            await questionCommandService.Handle(command);
            
            Console.WriteLine($"Answer has been registered for Question {questionId}.");
        }

    }
}