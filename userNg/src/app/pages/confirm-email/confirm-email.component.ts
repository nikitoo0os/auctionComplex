import { Component, OnInit } from '@angular/core';
import {
  UntypedFormBuilder,
  UntypedFormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { AppComponent } from 'src/app/app.component';
import { UserService } from 'src/app/services/api/user.service';

@Component({
  selector: 'app-confirm-email',
  templateUrl: './confirm-email.component.html',
  styleUrls: ['./confirm-email.component.scss'],
})
export class ConfirmEmailComponent implements OnInit {
  validateForm!: UntypedFormGroup;

  constructor(
    private fb: UntypedFormBuilder,
    private userService: UserService,
    private appComponent: AppComponent,
    private router: Router
  ) {
  }

  submitForm(): void {
    if (this.validateForm.valid) {
      const formData = this.validateForm.value;
      this.userService.confirmLogin(formData).then(
        (res: any) => {
          console.log(res);
          localStorage.setItem('token', res.data.token);
          this.router.navigate(['/profile']);
          this.appComponent.refreshData();
        },
        (err: any) => {
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
    this.validateForm = this.fb.group({
      confirmCode: [null, [Validators.required]],
    });
  }
}
