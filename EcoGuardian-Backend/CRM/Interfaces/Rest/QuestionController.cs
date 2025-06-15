using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoGuardian_Backend.CRM.Domain.Model.Commands;
using EcoGuardian_Backend.CRM.Domain.Services;
using EcoGuardian_Backend.CRM.Interfaces.Rest.Resources;
using EcoGuardian_Backend.CRM.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Mvc;

namespace EcoGuardian_Backend.CRM.Interfaces.Rest
{
    [ApiController]
    [ProducesResponseType(500)]
    [Route("api/v1/[controller]")]
 public class QuestionController(
        IQuestionCommandService questionCommandService, 
        IQuestionQueryService questionQueryService, 
        IAnswerCommandService answerCommandService, 
        IAnswerQueryService answerQueryService, 
        IAddedQuestionEventHandler addedQuestionEventHandler) : ControllerBase
        {

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RegisterQuestion([FromBody] RegisterQuestionCommand command)
        {
            var question = await questionCommandService.Handle(command);
            var questionResource = QuestionResourceFromEntityAssembler.ToResourceFromEntity(question);
            return Ok(questionResource);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateQuestion([FromBody] UpdateQuestionCommand command)
        {
            await questionCommandService.Handle(command);
            var question = await questionQueryService.GetQuestionById(command.QuestionId);
            var updatedQuestion = QuestionResourceFromEntityAssembler.ToResourceFromEntity(question);
            return Ok(updatedQuestion);
        }

        [HttpGet("{questionId:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetQuestionById(int questionId)
        {
            var question = await questionQueryService.GetQuestionById(questionId);
            if (question == null)
            {
                return NotFound();
            }
            var questionResource = QuestionResourceFromEntityAssembler.ToResourceFromEntity(question);

            return Ok(questionResource);
        }


        [HttpGet("{questionId:int}/answers")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAnswersByQuestionId(int questionId)
        {
            var answers = await answerQueryService.GetAnswersByQuestionId(questionId);
            var question = await questionQueryService.GetQuestionById(questionId);
            if (answers == null || !answers.Any() || question == null)
            {
                return NotFound();
            }
            var answersResource = answers.Select(answer => AnswerResourceFromEntityAssembler.FromEntity(answer, question)).ToList();
            return Ok(answersResource);
        }

        [HttpPost("{questionId:int}/answers")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RegisterAnswer(int questionId, [FromBody] RegisterAnswerResource resource)
        {
             var command = RegisterAnswerCommandFromResourceAssembler.toCommandFromResource(resource,questionId);
    
            await answerCommandService.Handle(command);
            await addedQuestionEventHandler.HandleAnswerAddedAsync(questionId);
            
            var answer = await answerQueryService.GetAnswersByQuestionId(questionId);
    
            var question = await questionQueryService.GetQuestionById(questionId);
            if (answer == null || !answer.Any() || question == null)
            {
                return NotFound();
            }
            var answersResource = answer.Select(answer => AnswerResourceFromEntityAssembler.FromEntity(answer, question)).ToList();
            return Ok(answersResource);
        }
    }
}