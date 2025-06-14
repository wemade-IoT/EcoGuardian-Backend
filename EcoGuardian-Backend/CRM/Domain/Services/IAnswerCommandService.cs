using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoGuardian_Backend.CRM.Domain.Model.Commands;

namespace EcoGuardian_Backend.CRM.Domain.Services
{
    public interface IAnswerCommandService
    {
        Task Handle(RegisterAnswerCommand command);
    }
}