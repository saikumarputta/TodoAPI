using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TODOAPI.Data;
using TODOAPI.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TodoItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TodoItems
        [HttpGet]
        public IEnumerable<TodoItems> GettodoItems()
        {
            return _context.todoItems;
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoItems([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todoItems = await _context.todoItems.FindAsync(id);

            if (todoItems == null)
            {
                return NotFound();
            }

            return Ok(todoItems);
        }

        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItems([FromRoute] long id, [FromBody] TodoItems todoItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todoItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemsExists(id))
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

        // POST: api/TodoItems
        [HttpPost]
        public async Task<IActionResult> PostTodoItems([FromBody] TodoItems todoItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.todoItems.Add(todoItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoItems", new { id = todoItems.Id }, todoItems);
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItems([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todoItems = await _context.todoItems.FindAsync(id);
            if (todoItems == null)
            {
                return NotFound();
            }

            _context.todoItems.Remove(todoItems);
            await _context.SaveChangesAsync();

            return Ok(todoItems);
        }

        private bool TodoItemsExists(long id)
        {
            return _context.todoItems.Any(e => e.Id == id);
        }
    }
}