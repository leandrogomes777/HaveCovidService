using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HaveCovidService.Models;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace HaveCovidService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly HaveCovidContext _context;

        public UsersController(HaveCovidContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsersItems()
        {
            return await _context.UsersItems.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(long id)
        {
            var users = await _context.UsersItems.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(long id, Users users)
        {
            if (id != users.ID)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            _context.UsersItems.Add(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = users.ID }, users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUsers(long id)
        {
            var users = await _context.UsersItems.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.UsersItems.Remove(users);
            await _context.SaveChangesAsync();

            return users;
        }

        private bool UsersExists(long id)
        {
            return _context.UsersItems.Any(e => e.ID == id);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> ValidateUser(UserLogin user)
        {
            var result = await _context.UsersItems.FirstOrDefaultAsync(x => x.Email == user.Email && x.Password == user.Password);
            if (null != result)
            {
                return CreatedAtAction("ValidateUser", true);
            }
            else
            {
                return CreatedAtAction("ValidateUser", false);
            }

        }
    }
}
