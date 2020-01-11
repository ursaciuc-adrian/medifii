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
      quantity: ['', [Validators.required, Validators.min(1)]],
    });
  }

  submit(): void {
    console.log(this.requestForm.value);
  }

  get name(): AbstractControl {
    return this.requestForm.get('name');
  }

  get quantity(): AbstractControl {
    return this.requestForm.get('quantity');
  }

}
