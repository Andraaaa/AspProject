using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.User;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGetUsersCommand _getCommand;
        private readonly IGetUserCommand _getOne;
        private readonly ICreateUserCommand _createCommand;
        private readonly IEditUserCommand _editCommand;
        private readonly IDeleteUserCommand _deleteCommand;

        public UserController(IGetUsersCommand getCommand, IGetUserCommand getOne, ICreateUserCommand createCommand, IEditUserCommand editCommand, IDeleteUserCommand deleteCommand)
        {
            _getCommand = getCommand;
            _getOne = getOne;
            _createCommand = createCommand;
            _editCommand = editCommand;
            _deleteCommand = deleteCommand;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult Get([FromQuery]UserSearch search)
        {
            var users = _getCommand.Execute(search);
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var userDto = _getOne.Execute(id);
                return Ok(userDto);
            }
            catch (EntityNotFound)
            {
                return NotFound();
            }
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] UserDto dto)
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

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDto dto)
        {
            dto.UserId = id;
            try
            {
                _editCommand.Execute(dto);
                return NoContent();
            }
            catch (EntityNotFound e)
            {
                if (e.Message == "User doesn't exist.")
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
