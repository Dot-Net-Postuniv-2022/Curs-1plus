import {Component, OnInit} from '@angular/core';
import {TodoItem} from 'src/app/models/todo-item';
import {TodoItemsService} from 'src/app/services/todo-items.service';

@Component({
  selector: 'app-todo-items',
  templateUrl: './todo-items.component.html',
  styleUrls: ['./todo-items.component.scss'],
})
export class TodoItemsComponent implements OnInit {
  todoItems: TodoItem[] = [];
  newTodoItem: TodoItem = {};

  constructor(private todoItemsService: TodoItemsService) { }

  ngOnInit(): void {
    this.todoItemsService.getTodoItems().subscribe((todoItems) => {
      this.todoItems = todoItems;
      console.log('got the data' + this.todoItems[0]);
    });
  }

  addTodoItem() {
    this.todoItemsService.addTodoItem(this.newTodoItem).subscribe((todoItem) => {
      this.todoItems.push(todoItem);
      this.newTodoItem = {};
    });
  }
}
