using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.Categories;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using AspAppShop.DataAccess;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace AspAppShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
       

        private readonly IGetCategoriesCommand _getCommand;
        private readonly IGetCategoryCommand _getOneCommand;
        private readonly ICreateCategoryCommand _createCommand;
        private readonly IEditCategoryCommand _editCategory;
        private readonly IDeleteCategoryCommand _deleteCategory;

        public CategoryController(IGetCategoriesCommand getCommand, IGetCategoryCommand getOneCommand, ICreateCategoryCommand createCommand, IEditCategoryCommand editCategory, IDeleteCategoryCommand deleteCategory)
        {
            _getCommand = getCommand;
            _getOneCommand = getOneCommand;
            _createCommand = createCommand;
            _editCategory = editCategory;
            _deleteCategory = deleteCategory;
        }





        // GET api/values
        [HttpGet]
        public IActionResult Get([FromQuery]CategorySearch query) => Ok(_getCommand.Execute(query));

        // GET api/category/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
        
            try
            {
                var categoryDto = _getOneCommand.Execute(id);
                return Ok(categoryDto);
            }
            catch(EntityNotFound)
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] CategoryDto dto)
        {
            try
            {
                _createCommand.Execute(dto);
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

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryDto dto)
        {
             dto.CategoryId = id;
            try
            {
                _editCategory.Execute(dto);
                return NoContent();
            }
            catch(EntityNotFound e)
            {
                if (e.Message == "Category doesn't exist.")
                {
                    return NotFound(e.Message);
                }

                return UnprocessableEntity(e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteCategory.Execute(id);
                return NoContent();
            }
            catch(EntityNotFound e)
            {
                return NotFound(e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500, "An error has occured.");
            }

        }
    }
}
