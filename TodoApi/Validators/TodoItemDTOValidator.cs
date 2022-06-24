using FluentValidation;
using TodoApi.DTOs;

namespace TodoApi.Validators;

public class TodoItemDTOValidator : AbstractValidator<TodoItemDTO>
{
    public TodoItemDTOValidator()
    {
        RuleFor(item => item.Name).NotEmpty();
        RuleFor(item => item.Name).MinimumLength(3);
    }
}
