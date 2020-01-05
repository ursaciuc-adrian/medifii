import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-request-product',
  templateUrl: './request-product.component.html',
  styleUrls: ['./request-product.component.scss']
})
export class RequestProductComponent implements OnInit {
  private requestForm: FormGroup = new FormGroup({});
  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.createForm();
  }

  createForm(): void {
    this.requestForm = this.fb.group({
      name: ['', [Validators.required]],
      phoneNumber: ['', [Validators.required, Validators.pattern(/^(\+4|)?(07[0-8]{1}[0-9]{1}|02[0-9]{2}|03[0-9]{2}){1}?(\s|\.|\-)?([0-9]{3}(\s|\.|\-|)){2}$/)]],
      deliveryAddress: ['', [Validators.required]],
      billingAdress: ['', [Validators.required]]
    });
  }

  submit(): void {
    console.log(this.requestForm.value);
  }

  get name(): AbstractControl {
    return this.requestForm.get('name');
  }

  get phoneNumber(): AbstractControl {
    return this.requestForm.get('phoneNumber');
  }

  get deliveryAddress(): AbstractControl {
    return this.requestForm.get('deliveryAddress');
  }

  get billingAddress(): AbstractControl {
    return this.requestForm.get('billingAddress');
  }

}
