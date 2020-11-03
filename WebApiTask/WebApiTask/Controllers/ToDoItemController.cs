using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebApiTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoItemController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly GetOptions _getOptions = new GetOptions();
        public ToDoItemController(IRepository repository,  IConfiguration configuration)
        {
            _repository = repository;
            configuration.Bind("GetOptions", _getOptions);
        }

        /// <summary>
        /// Query all ToDoItem 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<List<ToDoItem>>> QueryallAsync()
        {
            var list = await _repository.QueryAllAsync();
            return Ok(list);
        }

        /// <summary>
        /// Query ToDoItem by Id 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ToDoItem>>> GetSpecifiedAsync(
            long id)
        {
            var list = await _repository.QueryAsync(id);
            return Ok(list.Where(item => item.Id == id));
        }

        /// <summary>
        /// Create a ToDoItem 
        /// </summary>
        /// <remarks>
        /// In remarks, we can document some detail information
        /// </remarks>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ToDoItem>> UpsertAsync(
            [Required] ToDoItem model)
        {
             await _repository.UpsertAsync( model);
            var item = await _repository.GetAsync(model.Id);
            if (item == null)
                return new ObjectResult(500) { };
            return Ok(item);
        }
    }
}
