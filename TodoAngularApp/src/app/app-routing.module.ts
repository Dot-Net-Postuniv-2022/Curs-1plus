import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CounterComponent } from './components/counter/counter.component';
import { TodoItemsComponent } from './components/todo-items/todo-items.component';

const routes: Routes = [
  {
    path: 'counter',
    component: CounterComponent,
  },
  {
    path: 'todoitems',
    component: TodoItemsComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {

}
