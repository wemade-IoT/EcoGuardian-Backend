using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoGuardian_Backend.CRM.Domain.Model.Commands;
using EcoGuardian_Backend.CRM.Interfaces.Rest.Resources;

namespace EcoGuardian_Backend.CRM.Interfaces.Rest.Transform;

    public class RegisterQuestionCommandFromResourceAssembler
    {
        public static RegisterQuestionCommand ToCommandFromResource(
           RegisterQuestionResource resource)
        {
            return new RegisterQuestionCommand(
                Title: resource.Title,
                Content: resource.QuestionText,
                UserId: resource.UserId,
                PlantId: resource.PlantId
            );
        }
    }
