import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { TodoItem } from 'src/app/models/todo-item';
import { TodoItemsService } from 'src/app/services/todo-items.service';

@Component({
  selector: 'app-todo-items',
  templateUrl: './todo-items.component.html',
  styleUrls: ['./todo-items.component.scss'],
})
export class TodoItemsComponent implements OnInit {
  newTodoItem: TodoItem = { isComplete: false };

  displayedColumns: string[] = ['todo', 'todo_desc', 'completed', 'operations'];
  dataSource: TodoItem[] = [];

  constructor(private todoItemsService: TodoItemsService) { }

  ngOnInit(): void {
    this.todoItemsService.getTodoItems().subscribe((todoItems) => {
      this.dataSource = todoItems;
    });
  }

  addTodoItem() {
    this.todoItemsService.addTodoItem(this.newTodoItem).subscribe((todoItem) => {
      this.dataSource = [...this.dataSource, todoItem];
      this.newTodoItem = {};
    });
  }

  deleteTodoItem(todoItem: TodoItem) {
    this.todoItemsService.deleteTodoItem(todoItem).subscribe(() => {
      this.dataSource = this.dataSource.filter((item) => item.id !== todoItem.id);
    });
  }

  updateTodoItem(todoItem: TodoItem) {
    this.todoItemsService.updateTodoItem(todoItem).subscribe(() => {
      todoItem.isEditing = false;
      this.dataSource = this.dataSource.map((item) => (item.id === todoItem.id ? todoItem : item));
    });
  }
}
