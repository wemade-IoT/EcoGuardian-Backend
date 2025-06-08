using EcoGuardian_Backend.CRM.Domain.Model.Commands;
using EcoGuardian_Backend.CRM.Domain.Model.ValueObjects;

namespace EcoGuardian_Backend.CRM.Domain.Model.Aggregates;

public class Question
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    public int UserId { get; set; }
    public int PlantId { get; set; }
    public QuestionState State { get; set; } = QuestionState.InProcess;

    public Question()
    {
    }

    public Question(RegisterQuestionCommand command)
    {
        Title = command.Title;
        Content = command.Content;
        UserId = command.UserId;
        PlantId = command.PlantId;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateState(QuestionState newState)
    {
        State = newState;
        UpdatedAt = DateTime.UtcNow;
    }
}
