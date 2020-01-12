import { Component, ViewEncapsulation } from '@angular/core'
import { FormControl, Validators, NgForm } from '@angular/forms'
import { MatSnackBar } from '@angular/material'
import { HttpErrorResponse } from '@angular/common/http'
import { PharmacyService } from 'src/app/shared/services/pharmacy.service'
import { LoginService } from 'src/app/shared/services/login.service'

@Component({
  selector: 'login-page',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class LoginComponent {
  pharmacies = []

  constructor(
    private loginService: LoginService,
    private pharmacyService: PharmacyService,
    private _snackBar: MatSnackBar
  ) {
    this.pharmacyService.getAllPharmacies().then((rsp: any) => {
      this.pharmacies = rsp
    })
  }

  login = (form: NgForm) => {
    this.loginService
      .login(form.value)
      .then((rsp: any) => {
        if (rsp.token) {
          this.loginService.setSession(rsp)
        }else{
          this.showMessage('Something went wrong. Incorrect username or password.')
        }
      })
      .catch((err: HttpErrorResponse) => {
        this.showMessage(err.error.title)
        Object.keys(err.error.errors).forEach(key => {
          let currKey
          Object.keys(form.controls).forEach(controlkey => {
            if (
              controlkey.toLowerCase() == key.toLowerCase() ||
              key.toLowerCase().includes(controlkey.toLowerCase())
            ) {
              currKey = controlkey
            }
          })
          ;(form.controls[currKey] as any).apiErrors = []
          ;(form.controls[currKey] as any).setErrors('api', true)
          err.error.errors[key].forEach(error => {
            ;(form.controls[currKey] as any).apiErrors.push(error)
          })
        })
      })
  }

  register = (form: NgForm) => {
    this.loginService
      .register(form.value)
      .then(rsp => {
        console.log(rsp)
      })
      .catch((err: HttpErrorResponse) => {
        this.showMessage(err.error.title)
        Object.keys(err.error.errors).forEach(key => {
          let currKey
          Object.keys(form.controls).forEach(controlkey => {
            if (
              controlkey.toLowerCase() == key.toLowerCase() ||
              key.toLowerCase().includes(controlkey.toLowerCase())
            ) {
              currKey = controlkey
            }
          })
          ;(form.controls[currKey] as any).apiErrors = []
          ;(form.controls[currKey] as any).setErrors('api', true)
          err.error.errors[key].forEach(error => {
            ;(form.controls[currKey] as any).apiErrors.push(error)
          })
        })
      })
  }

  showMessage(message): void {
    this._snackBar.open(message, 'x', {
      duration: 2000,
      verticalPosition: 'top',
      horizontalPosition: 'right',
    })
  }
}
