using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Task_ToDo.Data;
using Task_ToDo.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task_ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class login_RegistarController1 : ControllerBase
    {
        public AppDbContext Context = new AppDbContext();
    

        // GET api/<loginController1>/5
        [HttpGet("Login")]
        public async Task<ActionResult<User>> Get(string user, string UserPass)
        {
            var result =  Context.Users.Where(x=>x.UserName==user&&x.UserPassword==UserPass);
            if (result == null) { return BadRequest("valid info"); }
            
            return Created ("login sucsessfuly",result);
            
        }

        // POST api/<loginController1>
        [HttpPost]
        public async Task<ActionResult<User>> Register_NewUser([FromBody] User user)
        {
            try {
            Context.Users.Add(user);
                Context.SaveChanges();
                return Created("DONE",user);
                
            } catch (Exception ex) { 
            
            
            return BadRequest(ex.Message);
            }
            
        }

        // PUT api/<loginController1>/5
        [HttpPut("{username},{password}")]
        public async Task<ActionResult<User>> Edit_user(string username , string password, [FromBody] User user)
        {
            var result = Context.Users.FirstOrDefault(x=>x.UserName==username&&x.UserPassword==password);
            try
            {
                result.UserName = user.UserName;
                result.UserPassword = user.UserPassword;
                Context.SaveChanges();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
            if (result == null) return NotFound("Valid info");
            return Ok("Done");
        }

        // DELETE api/<loginController1>/5
        [HttpDelete("{username},{password}")]
        public async Task<ActionResult<User>> Delete_User(string username, string password)
        {
            var result = Context.Users.FirstOrDefault(x => x.UserName == username && x.UserPassword == password);
            if (result == null) {return NotFound(); }
            try
            {
                Context.Users.Remove(result);
                Context.SaveChanges();
            }catch(Exception ex) { return BadRequest(ex.Message); }
            return Ok("Done");
        }
    }
}
