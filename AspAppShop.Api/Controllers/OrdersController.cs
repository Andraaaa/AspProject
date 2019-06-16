using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.Orders;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ICreateOrderCommand _createOrder;
        private readonly IGetOrderCommand _getOne;
        private readonly IGetOrdersCommand _getCommand;
        private readonly IEditOrderCommand _editCommand;
        private readonly IDeleteOrderCommand _deleteCommand;

        public OrdersController(ICreateOrderCommand createOrder, IGetOrderCommand getOne, IGetOrdersCommand getCommand, IEditOrderCommand editCommand, IDeleteOrderCommand deleteCommand)
        {
            _createOrder = createOrder;
            _getOne = getOne;
            _getCommand = getCommand;
            _editCommand = editCommand;
            _deleteCommand = deleteCommand;
        }



        // GET: api/Orders
        [HttpGet]
        public IActionResult Get([FromQuery]OrderSearch search)
        {
            var result = _getCommand.Execute(search);
            return Ok(result);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return null;
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult Post([FromBody] OrderDto dto)
        {
            try
            {
                _createOrder.Execute(dto);
                return StatusCode(201);
            }
            catch(EntityNotFound e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]OrderDto dto)
        {
            dto.OrderId = id;
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
