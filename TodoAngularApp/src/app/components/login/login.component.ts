import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private _snackBar: MatSnackBar, private authService: AuthenticationService) { }

  loginForm = this.formBuilder.group({
    email: ['', [Validators.required]],
    password: ['', [Validators.minLength(6)]],
    username: ['', [Validators.required]],
  });
  get email() { return this.loginForm.get('email'); }
  get password() { return this.loginForm.get('password'); }
  get username() { return this.loginForm.get('username'); }


  onLoginClicked() {
    this.authService.login(this.loginForm.value).subscribe((tokenObj) => {
      localStorage.setItem('token', tokenObj.token);
      this._snackBar.open("Login successful!", "Ok", {
        verticalPosition: 'top',
        duration: 6 * 1000,
      });

      this.loginForm.reset();
    }, (error) => {

      console.log(error);
      this._snackBar.open("Login failed: " + error.error, "Ok", {
        verticalPosition: 'top',
        duration: 6 * 1000,
      });
    });
  }

  ngOnInit(): void {
  }

}
