using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoGuardian_Backend.CRM.Domain.Model.ValueObjects;

namespace EcoGuardian_Backend.CRM.Domain.Model.Commands;

public record UpdateQuestionCommand(int QuestionId, QuestionState State);
