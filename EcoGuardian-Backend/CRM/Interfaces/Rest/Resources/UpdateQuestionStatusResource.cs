using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoGuardian_Backend.CRM.Interfaces.Rest.Resources;
    public record UpdateQuestionStatusResource(
        int QuestionId,
        int Status
    );
