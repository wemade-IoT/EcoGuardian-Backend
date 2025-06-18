using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoGuardian_Backend.CRM.Domain.Services
{
    public interface IAddedQuestionEventHandler
    {
        Task HandleAnswerAddedAsync(int questionId);

    }
}