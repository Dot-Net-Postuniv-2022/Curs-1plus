import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CounterComponent } from './components/counter/counter.component';
import { LoginComponent } from './components/login/login.component';
import { AddComponent } from './components/todo-items/add/add.component';
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
  {
    path: 'todoitems/details/:id',
    component: TodoItemsComponent,
  },
  {
    path: 'todoitems/add',
    component: AddComponent,
  },
  {
    path: 'todoitems/edit/:id',
    component: TodoItemsComponent,
  },
  {
    path: 'auth/login',
    component: LoginComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {

}
