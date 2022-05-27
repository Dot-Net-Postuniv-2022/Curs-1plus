import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TodoItemsService } from 'src/app/services/todo-items.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss']
})
export class AddComponent implements OnInit {

  nums = [1, 2, 3];

  constructor(private formBuilder: FormBuilder, private todoItemsService: TodoItemsService, private _snackBar: MatSnackBar) { }


  ngOnInit(): void {
  }

  todoItemForm = this.formBuilder.group({
    name: ['', [Validators.required, Validators.minLength(3)]],
    description: ['', [Validators.required]],
    isComplete: [false],
    //todoSubItems: this.formBuilder.array([])
  });

  get name() { return this.todoItemForm.get('name'); }
  get description() { return this.todoItemForm.get('description'); }
  get isComplete() { return this.todoItemForm.get('isComplete'); }

  onSubmit() {
    this.todoItemsService.addTodoItem(this.todoItemForm.value).subscribe((todoItem) => {
      this._snackBar.open("Added successfully!", "Ok", {
        verticalPosition: 'top',
        duration: 6 * 1000,
      });

      this.todoItemForm.reset();
    });
  }

  // Cu titlu de exemplu vizual pentru cerinta de bonus din saptamana 5 - NU este functional.
  newSubactivity() {
    this.nums.push(this.nums.length + 1);
  }

  deleteSubactivity(index: number) {
    this.nums.splice(index, 1);
  }
}
