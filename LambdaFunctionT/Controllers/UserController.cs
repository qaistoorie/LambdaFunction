using LambdaFunctionT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LambdaFunctionT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EntitiesContext _context;

        public UserController(EntitiesContext contxt)
        {
            _context = contxt;
        }

        [HttpGet]
        public async Task<List<User>> GetAsync()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<User> GetAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.ID == id);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(User request)
        {
            await _context.AddAsync(request);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PostAsync(int id, User request)
        {
            var model = await _context.Users.FirstOrDefaultAsync(user => user.ID == id);
            if (model != null)
            {
                model.Email = request.Email;
                model.Username = request.Username;
            }
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
