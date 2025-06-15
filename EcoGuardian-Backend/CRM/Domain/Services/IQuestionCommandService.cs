using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoGuardian_Backend.CRM.Domain.Model.Aggregates;
using EcoGuardian_Backend.CRM.Domain.Model.Commands;

namespace EcoGuardian_Backend.CRM.Domain.Services
{
    public interface IQuestionCommandService
    {
        Task<Question> Handle(RegisterQuestionCommand command);

        Task Handle(UpdateQuestionCommand command);

    }



}