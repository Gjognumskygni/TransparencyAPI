using Application.Features.MemberOfParliamentFeatures.Commands;
using Application.Features.MemberOfParliamentFeatures.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiVersion("1.0")]
    public class MemberOfParliamentController : BaseAPIController
    {
        /// <summary>
        /// Creates a New MemberOfParliament.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateMemberOfParliamentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Gets all MemberOfParliaments.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllMemberOfParliamentsQuery()));
        }

        /// <summary>
        /// Gets MemberOfParliament Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetMemberOfParliamentByIdQuery { Id = id }));
        }

        /// <summary>
        /// Deletes MemberOfParliament Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteMemberOfParliamentByIdCommand { Id = id }));
        }

        /// <summary>
        /// Updates the MemberOfParliament Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateMemberOfParliamentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
