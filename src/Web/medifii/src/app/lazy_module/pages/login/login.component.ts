import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'login-page',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  title = 'medifii';
  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

}
