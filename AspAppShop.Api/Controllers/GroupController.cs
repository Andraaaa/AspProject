using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Groups;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGetGroupsCommand _getCommand;
        private readonly IGetGroupCommand _getOne;
        private readonly ICreateGroupCommand _createCommand;
        private readonly IEditGroupCommand _editCommand;
        private readonly IDeleteGroupCommand _deleteCommand;

        public GroupController(IGetGroupsCommand getCommand, IGetGroupCommand getOne, ICreateGroupCommand createCommand, IEditGroupCommand editCommand, IDeleteGroupCommand deleteCommand)
        {
            _getCommand = getCommand;
            _getOne = getOne;
            _createCommand = createCommand;
            _editCommand = editCommand;
            _deleteCommand = deleteCommand;
        }

        // GET: api/Group
        [HttpGet]
        public IActionResult Get([FromQuery]GroupSearch query) => Ok(_getCommand.Execute(query));
       

        // GET: api/Group/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var groupDto = _getOne.Execute(id);
                return Ok(groupDto);
            }
            catch (EntityNotFound)
            {
                return NotFound();
            }
        }

        // POST: api/Group
        [HttpPost]
        public IActionResult Post([FromBody] GroupDto dto)
        {
            try
            {
                _createCommand.Execute(dto);
                return StatusCode(201);
            }
            catch (EntityNotFound e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Group/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]GroupDto dto)
        {
            dto.GroupId = id;
            try
            {
                _editCommand.Execute(dto);
                return NoContent();
            }
            catch (EntityNotFound e)
            {
                if (e.Message == "Category doesn't exist.")
                {
                    return NotFound(e.Message);
                }

                return UnprocessableEntity(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteCommand.Execute(id);
                return NoContent();
            }
            catch (EntityNotFound e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error has occured.");
            }
        }
    }
}
