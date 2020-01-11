import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-reserve-product',
  templateUrl: './reserve-product.component.html',
  styleUrls: ['./reserve-product.component.scss']
})
export class ReserveProductComponent implements OnInit {
  private reserveForm: FormGroup = new FormGroup({});
  constructor(public dialogRef: MatDialogRef<ReserveProductComponent>,
    @Inject(MAT_DIALOG_DATA) public data,
    private fb: FormBuilder) { }

  ngOnInit() {
    this.createForm();
  }

  createForm(): void {
    this.reserveForm = this.fb.group({
      quantity: ['', [Validators.required, Validators.min(1)]],
      pickupTime: ['', [Validators.required]]
    });
  }

  get quantity(): AbstractControl {
    return this.reserveForm.get('quantity');
  }

  get pickupTime(): AbstractControl {
    return this.pickupTime.get('pickupTime');
  }

}
