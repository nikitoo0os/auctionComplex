import { Component, OnInit } from '@angular/core';
import {
  UntypedFormBuilder,
  UntypedFormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/api/user.service';
import { setCookie } from 'src/app/utils/cookie-utils';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  constructor(
    private fb: UntypedFormBuilder,
    private userService: UserService,
    private router: Router
  ) {}

  validateForm!: UntypedFormGroup;

  submitForm(): void {
    if (this.validateForm.valid) {
      const formData = this.validateForm.value;
      this.userService.login(formData).then(
        (res: any) => {
          this.router.navigate(['/login/confirm']);
        },
        (err: any) => {
          console.log('Ошибка');
          console.log(err);
        }
      );
    } else {
      Object.values(this.validateForm.controls).forEach((control) => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }

  ngOnInit(): void {
    if(localStorage.getItem('token') != null){
      this.router.navigateByUrl('/profile');
    }

    this.validateForm = this.fb.group({
      usernameOrEmail: [null, [Validators.required]],
      password: [null, [Validators.required]],
      // remember: [true]
    });


  }
}
