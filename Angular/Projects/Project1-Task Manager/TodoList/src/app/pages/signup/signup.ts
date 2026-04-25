import { Component, inject } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router, RouterLink } from '@angular/router'; // 🚨 1. Import RouterLink
import { Auth } from '../../services/auth';
import { User } from '../../types';

function noSpace(control: AbstractControl) {
  if (typeof control.value === 'string' && control.value.includes(' ')) {
    return { nospace: true };
  } else {
    return null;
  }
}

function MismatchPassword(control: AbstractControl) {
  const pass = control.get('password')?.value;
  const confirm = control.get('confirm')?.value;
  if (!pass || !confirm) return null;
  return pass === confirm ? null : { MismatchPassword: true };
}

@Component({
  selector: 'app-signup',
  // 🚨 2. Add RouterLink here
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './signup.html',
  styleUrl: './signup.css',
})
export class Signup {
  authService = inject(Auth);
  errorMessage: string = '';
  router = inject(Router);

  form = new FormGroup(
    {
      username: new FormControl('', [Validators.required, noSpace]),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(5)]),
      confirm: new FormControl('', [Validators.required, Validators.minLength(5)]),
    },
    {
      validators: MismatchPassword,
    },
  );

  handleSignup() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const newUser: User = {
      email: this.form.value.email!.trim(),
      username: this.form.value.username!.trim(),
      password: this.form.value.password!.trim(),
    };

    this.authService.getUserByEmail(newUser.email!).subscribe((users) => {
      if (users.length > 0) {
        this.errorMessage = 'This email already exists';
      } else {
        this.authService.registerUser(newUser).subscribe((createdUser) => {
          localStorage.setItem('activeUser', JSON.stringify(createdUser));

          this.router.navigate(['/home']);

          this.form.reset();
        });
      }
    });
  }
}
