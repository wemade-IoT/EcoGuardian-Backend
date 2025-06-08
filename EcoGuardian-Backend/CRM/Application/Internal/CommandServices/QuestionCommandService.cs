using EcoGuardian_Backend.CRM.Domain.Model.Aggregates;
using EcoGuardian_Backend.CRM.Domain.Model.Commands;
using EcoGuardian_Backend.CRM.Domain.Model.ValueObjects;
using EcoGuardian_Backend.CRM.Domain.Repositories;
using EcoGuardian_Backend.CRM.Domain.Services;
using EcoGuardian_Backend.Shared.Domain.Repositories;

namespace EcoGuardian_Backend.CRM.Application.Internal.CommandServices;

public class QuestionCommandService(IQuestionRepository questionRepository, IUnitOfWork unitOfWork) : IQuestionCommandService
{
    public async Task Handle(RegisterQuestionCommand command)
    {
        var question = new Question(command);
        await questionRepository.AddAsync(question);
        await unitOfWork.CompleteAsync();
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

    public async Task UpdateQuestionStateToAnsweredAsync(int questionId)
    {
        var question = await questionRepository.GetByIdAsync(questionId);
        if (question != null)
        {
            question.UpdateState(QuestionState.Resolved);
            questionRepository.Update(question);
            await unitOfWork.CompleteAsync();
        }
    }
}