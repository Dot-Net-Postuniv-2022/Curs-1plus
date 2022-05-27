using TodoApi.DTOs;
using TodoApi.Models;

namespace TodoApi.Mappers;

public static class TodoItemMappers
{
    public static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
        new()
        {
            Id = todoItem.Id,
            Name = todoItem.Name,
            Description = todoItem.Description,
            IsComplete = todoItem.IsComplete,
            TodoSubItems = todoItem.TodoSubItems?.Select(si => TodoSubItemMappers.SubItemToDTO(si)).ToList()
        };

    public static TodoItem DTOToItem(TodoItemDTO todoItemDTO) =>
        new TodoItem
        {
            Name = todoItemDTO.Name,
            Description = todoItemDTO.Description,
            IsComplete = todoItemDTO.IsComplete,
            TodoSubItems = todoItemDTO.TodoSubItems?.Select(subItemDto => TodoSubItemMappers.DTOToSubItem(subItemDto)).ToList(),
        };
}