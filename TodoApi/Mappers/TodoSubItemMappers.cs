using TodoApi.DTOs;
using TodoApi.Models;

namespace TodoApi.Mappers;

public static class TodoSubItemMappers
{
    public static TodoSubItemDTO SubItemToDTO(TodoSubItem todoItem) =>
        new()
        {
            Id = todoItem.Id,
            Description = todoItem.Description,
            Priority = todoItem.Priority,
            IsComplete = todoItem.IsComplete
        };


    public static TodoSubItem DTOToSubItem(TodoSubItemDTO todoSubItemDTO) =>
        new TodoSubItem
        {
            Description = todoSubItemDTO.Description,
            IsComplete = todoSubItemDTO.IsComplete,
            Priority = todoSubItemDTO.Priority,
        };
}