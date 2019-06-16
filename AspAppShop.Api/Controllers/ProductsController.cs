using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Helpers;
using Application;
using Application.Commands;
using Application.Commands.Products;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using AspAppShop.DataAccess;
using EfCommands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGetProductsCommand _command;
        private readonly IGetProductCommand _getOne;
        private readonly ICreateProductCommand _createCommand;
        private readonly IEditProductCommand _editCommand;
        private readonly IDeleteProductCommand _deleteCommand;
        private readonly LoggedUser _user;

        public ProductsController(IGetProductsCommand command, IGetProductCommand getOne, ICreateProductCommand createCommand, IEditProductCommand editCommand, IDeleteProductCommand deleteCommand, LoggedUser user)
        {
            _command = command;
            _getOne = getOne;
            _createCommand = createCommand;
            _editCommand = editCommand;
            _deleteCommand = deleteCommand;
            _user = user;
        }





        [LoggedIn]
        // GET: api/Products
        [HttpGet]
        public IActionResult Get([FromQuery]ProductSearch search)
        {
            var result = _command.Execute(search);
            return Ok(result);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var productDto = _getOne.Execute(id);
                return Ok(productDto);
            }
            catch (EntityNotFound)
            {
                return NotFound();
            }
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody] ProductDto dto)
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

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductDto dto)
        {
            dto.ProductId = id;
            try
            {
                _editCommand.Execute(dto);
                return NoContent();
            }
            catch (EntityNotFound e)
            {
                if (e.Message == "Product doesn't exist.")
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
