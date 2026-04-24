import { Component, inject } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { Auth } from '../../services/auth';

@Component({
  selector: 'app-login',
  imports: [FormsModule, RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  authService = inject(Auth);
  router = inject(Router);
  emailVal: string = '';
  errorMessage: string = '';

  checkUser(form: NgForm) {
    if (form.invalid) {
      form.control.markAllAsTouched();
      return;
    }

    const enteredEmail = form.value.email.trim();
    const enteredPassword = form.value.password.trim();

    this.authService.getUserByEmail(enteredEmail).subscribe((users) => {
      if (users.length > 0) {
        const foundUser = users[0];

        if (foundUser.password === enteredPassword) {
          this.errorMessage = '';
          localStorage.setItem('activeUser', JSON.stringify(foundUser));
          console.log(`Welcome back, ${foundUser.username}!`);
          this.router.navigate(['/']);
        } else {
          this.errorMessage = 'Incorrect password.';
        }
      } else {
        this.errorMessage = 'Account does not exist.';
      }
    });
  }
}
