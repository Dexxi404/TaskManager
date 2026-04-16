using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.GenricInterface;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IGenericRepository<ToDoTask> _toDoTask;
        public TaskController(IGenericRepository<ToDoTask> toDoTask)
        {
            _toDoTask = toDoTask;

        }

        [HttpGet]
        [Route("GetAllTask")]
        public async Task<IActionResult> GetAllTask() {
            try
            {
                var tasks=await _toDoTask.GetAllAsync();
                return Ok(tasks);
            }
            catch (Exception ex) { 
                return StatusCode(500,ex.Message);
            }
        }

        [HttpGet]
        [Route("GetById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                var tasks = await _toDoTask.GetByIdAsync(Id);
                if (tasks == null)
                {
                    return NotFound();
                }

                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
