using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreWebApi.Models;
using AspNetCoreWebApi.Data;
using AspNetCoreWebApi.Dtos;

namespace AspNetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoDbContext _context;

        public TodoItemsController(TodoDbContext context)
        {
            _context = context;
        }

        private bool TodoItemExists(long id)
        {
            return _context.TodoItem.Any(e => e.Id == id);
        }

        private static TodoItemDto ItemToDTO(TodoItem todoItem) =>
        new TodoItemDto
        {
            Id = todoItem.Id,
            Name = todoItem.Name,
            IsComplete = todoItem.IsComplete
        };

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetTodoItem()
        {
            return await _context.TodoItem.Select(x => ItemToDTO(x)).ToListAsync();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDto>> GetTodoItem(long id)
        {
            var todoItem = await _context.TodoItem.FindAsync(id);

            if (todoItem == null)
                return NotFound();

            return ItemToDTO(todoItem);
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItemDto todoItemDto)
        {
            if (id != todoItemDto.Id)
                return BadRequest();

            var todoItem = await _context.TodoItem.FindAsync(id);
            if (todoItem == null)
                return NotFound();

            todoItem.Name = todoItemDto.Name;
            todoItem.IsComplete = todoItemDto.IsComplete;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItemDto>> PostTodoItem(TodoItemDto todoItemDto)
        {
            var todoItem = new TodoItem
            {
                IsComplete = todoItemDto.IsComplete,
                Name = todoItemDto.Name
            };

            _context.TodoItem.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem),
                new { id = todoItem.Id }, ItemToDTO(todoItem));
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItem.FindAsync(id);
            if (todoItem == null)
                return NotFound();

            _context.TodoItem.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
