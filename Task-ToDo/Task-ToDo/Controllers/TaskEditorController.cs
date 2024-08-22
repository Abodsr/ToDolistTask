using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Task_ToDo.Data;
using Task_ToDo.models;

using Microsoft.EntityFrameworkCore;
using System.Data.Entity;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task_ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskEditorController : ControllerBase
    {
        public AppDbContext Context = new AppDbContext();
        // GET: api/<TaskEditorController>
        [HttpGet]
        public async Task<List<ToDoTask>> Index(int userId)
        {
            
            if (userId == 0)
            {
                return new List<ToDoTask>();
            }

            
            var tasks = await Context.Tasks.Where(t => t.UserId == userId).ToListAsync();

            return tasks;
        }



        // POST api/<TaskEditorController>
        [HttpPost("create")]
        public async Task<IActionResult> Create(int userid,string name, string description)
        {
            
            if (userid == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var task = new ToDoTask
            {
                Name = name,
                Description = description,
                IsCompleted = false,
                UserId = userid
            };

            Context.Tasks.Add(task);
            Context.SaveChangesAsync();

            return Ok("Task had been added");
        }



        // PUT api/<TaskEditorController>/5

        [HttpPut("complete/{id}")]
        public async Task<IActionResult> Complete(int userid, string nameofTask, [FromBody]ToDoTask task)
        {
            var result =  Context.Tasks.FirstOrDefault(x => x.UserId == userid && x.Name == nameofTask);
            if (result == null)
            {
                return NotFound();
            }
            result.Name =task.Name;
            result.Description = task.Description;
            result.IsCompleted = task.IsCompleted;
           
            await Context.SaveChangesAsync();

            return Ok("Done");
            
        }
        [HttpDelete("{id},{NameOfTask}")]
       public async Task<ActionResult<ToDoTask>> Delete_User(int id,string NameOfTask)
        {
            var result = Context.Tasks.FirstOrDefault(x => x.Name== NameOfTask && x.User.UserId ==id);
            try
            {
                Context.Tasks.Remove(result);
                Context.SaveChanges();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
            return Ok("Done");
        }
    }
}
