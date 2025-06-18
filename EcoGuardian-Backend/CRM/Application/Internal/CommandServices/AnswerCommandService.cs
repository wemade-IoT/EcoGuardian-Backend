using EcoGuardian_Backend.CRM.Application.Internal.OutboundServices;
using EcoGuardian_Backend.CRM.Domain.Model.Aggregates;
using EcoGuardian_Backend.CRM.Domain.Model.Commands;
using EcoGuardian_Backend.CRM.Domain.Repositories;
using EcoGuardian_Backend.CRM.Domain.Services;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.CRM.Application.Internal.CommandServices;

public class AnswerCommandService(
    IAnswerRepository answerRepository, 
    IUnitOfWork unitOfWork,
    IAddedQuestionEventHandler eventHandler, IExternalUserServiceCRM externalUserService) : IAnswerCommandService
{
    public async Task Handle(RegisterAnswerCommand command)
    {
        var answer = new Answer(command);
        // Check if the user exists before adding the answer
        if (!await externalUserService.CheckUserExists(command.SpecialistId))
        {
            throw new BadHttpRequestException($"User with ID {command.SpecialistId} does not exist.");
        }
        await answerRepository.AddAsync(answer);
        await unitOfWork.CompleteAsync();
        
        //Update the question state to Resolved when an answer is added
        await eventHandler.HandleAnswerAddedAsync(command.QuestionId);
    }

}