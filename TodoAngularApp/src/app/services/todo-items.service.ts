import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {API_URL} from '../constants';
import {TodoItem} from '../models/todo-item';

@Injectable({
  providedIn: 'root',
})
export class TodoItemsService {
  constructor(private httpClient: HttpClient) { }

  getTodoItems() {
    return this.httpClient.get<TodoItem[]>(`${API_URL}/todoitems`);
  }

  addTodoItem(todoItem: TodoItem) {
    todoItem.isComplete = (todoItem.isComplete === "true");
    return this.httpClient.post<TodoItem>(`${API_URL}/todoitems`, todoItem);
  }
}
