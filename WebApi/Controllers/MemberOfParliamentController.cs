using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberOfParliamentController : ControllerBase
    {
        private readonly IMemberOfParliamentService _memberOfParliamentService;

        public MemberOfParliamentController(IMemberOfParliamentService memberOfParliamentService)
        {
            _memberOfParliamentService = memberOfParliamentService;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            MemberOfParliament member = await _memberOfParliamentService.GetByIdAsync(id);

            if (member is null)
                return BadRequest($"No Member of parliament found with id: {id}");

            return Ok(member);
        }
    }
}
