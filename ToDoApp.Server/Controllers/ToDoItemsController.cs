using Microsoft.AspNetCore.Mvc;
using ToDoApp.Server.Business.Contracts;
using ToDoApp.Server.Business.Dtos;

namespace ToDoApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoItemsController : ControllerBase
    {
        private readonly IToDoAppService _toDoAppService;
        private readonly ILogger<ToDoItemsController> _logger;

        public ToDoItemsController(IToDoAppService toDoAppService, ILogger<ToDoItemsController> logger)
        {
            _toDoAppService = toDoAppService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoItemDto>>> GetToDoItems()
        {
            try
            {
                var toDoItems = await _toDoAppService.GetAllToDoItemsAsync();
                return Ok(toDoItems);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving ToDo items.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving ToDo items.");

            }
        }

        [HttpGet]
        [Route("id:Guid")]
        public async Task<ActionResult<ToDoItemDto>> GetToDoItemById(Guid id)
        {
            try
            {
                var toDoItem = await _toDoAppService.GetToDoItemByIdAsync(id);
                if (toDoItem == null)
                    return NotFound();

                return Ok(toDoItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving ToDo item with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while retrieving ToDo item with ID {id}.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItemDto>> PostToDoItem([FromBody] ToDoItemDto todoItem)
        {
            try
            {
                var addedItem = await _toDoAppService.AddToDoItemAsync(todoItem);

                return CreatedAtAction(nameof(GetToDoItemById), new { id = addedItem.Id }, addedItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new ToDo item.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding a new ToDo item.");
            }
        }

        public async Task<ActionResult> DeleteToDoItems(Guid id)
        {
            try
            {
                await _toDoAppService.DeleteToDoItemAsync(id);
                return Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while removing ToDo item with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while removing ToDo item with ID {id}.");
            }
        }
    }
}
