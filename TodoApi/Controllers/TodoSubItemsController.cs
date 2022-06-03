#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.DTOs;
using TodoApi.Mappers;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TodoSubItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoSubItemsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/TodoSubItems
        [HttpGet("{todoItemId}")]
        public async Task<ActionResult<IEnumerable<TodoSubItemDTO>>> GetTodoSubItems(long todoItemId)
        {
            return await _context.TodoSubItems
                .Where(si => si.Parent.Id == todoItemId)
                .Select(si => TodoSubItemMappers.SubItemToDTO(si))
                .ToListAsync();
        }

        // // GET: api/TodoItems/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
        // {
        //     var todoItem = await _context.TodoItems.FindAsync(id);

        //     if (todoItem == null)
        //     {
        //         return NotFound();
        //     }

        //     return ItemToDTO(todoItem);
        // }

        // // PUT: api/TodoItems/5
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> UpdateTodoItem(long id, TodoItemDTO todoItemDTO)
        // {
        //     if (id != todoItemDTO.Id)
        //     {
        //         return BadRequest();
        //     }

        //     // _context.Entry(todoItemDTO).State = EntityState.Modified;
        //     var todoItem = await _context.TodoItems.FindAsync(id);
        //     if (todoItem == null)
        //     {
        //         return NotFound();
        //     }

        //     todoItem.Name = todoItemDTO.Name;
        //     todoItem.IsComplete = todoItemDTO.IsComplete;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!TodoItemExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // // POST: api/TodoItems
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<TodoItemDTO>> AddTodoItem(TodoItemDTO todoItemDTO)
        // {
        //     var todoItem = new TodoItem
        //     {
        //         Name = todoItemDTO.Name,
        //         Description = todoItemDTO.Description,
        //         IsComplete = todoItemDTO.IsComplete
        //     };
        //     _context.TodoItems.Add(todoItem);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction(nameof(GetTodoItem), new { id = todoItemDTO.Id }, ItemToDTO(todoItem));
        // }

        // // DELETE: api/TodoItems/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteTodoItem(long id)
        // {
        //     var todoItem = await _context.TodoItems.FindAsync(id);
        //     if (todoItem == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.TodoItems.Remove(todoItem);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool TodoItemExists(long id)
        // {
        //     return _context.TodoItems.Any(e => e.Id == id);
        // }

    }
}
