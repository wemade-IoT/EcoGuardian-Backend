using EcoGuardian_Backend.CRM.Application.Internal.OutboundServices;
using EcoGuardian_Backend.CRM.Domain.Model.Aggregates;
using EcoGuardian_Backend.CRM.Domain.Model.Commands;
using EcoGuardian_Backend.CRM.Domain.Repositories;
using EcoGuardian_Backend.CRM.Domain.Services;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.CRM.Application.Internal.CommandServices;

public class QuestionCommandService(IQuestionRepository questionRepository, IUnitOfWork unitOfWork, IExternalUserServiceCRM externalUserService) : IQuestionCommandService
{
    public async Task<Question> Handle(RegisterQuestionCommand command)
    {
        // Check if the user exists before adding the question
        if (!await externalUserService.CheckUserExists(command.UserId))
        {
            throw new BadHttpRequestException($"User with ID {command.UserId} does not exist.");
        }

        // Check if the plant exists
        if (!await externalUserService.CheckPlantExists(command.PlantId))
        {
            throw new BadHttpRequestException($"Plant with ID {command.PlantId} does not exist.");
        }

        var question = new Question(command);
        if(command.ImageUrls != null && command.ImageUrls.Any())
        {
            question.AddImages(command.ImageUrls);
        }
        await questionRepository.AddAsync(question);
        await unitOfWork.CompleteAsync();
        return question;
    }

    public async Task Handle(UpdateQuestionCommand command)
    {
        var question = await questionRepository.GetByIdAsync(command.QuestionId);
        if (question == null)
        {
            throw new BadHttpRequestException($"Question with ID {command.QuestionId} not found.");
        }

        question.UpdateState(command.State);
        questionRepository.Update(question);
        await unitOfWork.CompleteAsync();
    }
}