import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormControl, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { UserService } from 'src/app/services/api/user.service';



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',

  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private fb: UntypedFormBuilder, private userService: UserService, private router: Router) {}

  validateForm!: UntypedFormGroup;

  registerForm: any = {
    firstName: '',
    secondName: '',
    username: '',
    password: '',
    email: ''
  }

  submitForm(): void {
    if (this.validateForm.valid) {
      const formData = this.validateForm.value;
      this.userService.register(formData).then(
        (res:any) => {
          console.log(res);
          this.router.navigate(['/profile'])
        },
        (err:any) => {
          console.log(err);
        }
      )
    } else {
      Object.values(this.validateForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }

  updateConfirmValidator(): void {
    /** wait for refresh value */
    Promise.resolve().then(() => this.validateForm.controls['checkPassword'].updateValueAndValidity());
  }

  confirmationValidator = (control: UntypedFormControl): { [s: string]: boolean } => {
    if (!control.value) {
      return { required: true };
    } else if (control.value !== this.validateForm.controls['password'].value) {
      return { confirm: true, error: true };
    }
    return {};
  };

  getCaptcha(e: MouseEvent): void {
    e.preventDefault();
  }

  ngOnInit(): void {
    this.validateForm = this.fb.group({
      email: [null, [Validators.email, Validators.required]],
      password: [null, [Validators.required]],
      checkPassword: [null, [Validators.required, this.confirmationValidator]],
      username: [null, [Validators.required]],
      firstName: [null, [Validators.required]],
      secondName: [null,[Validators.required]]
    });
  }

  registerBtn(): void{
    if(this.validateForm.valid){
      const formData = this.validateForm.value;
      
      this.userService.register(formData);
      
    }
  }
}
