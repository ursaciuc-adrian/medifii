import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { PharmacyService } from 'src/app/shared/services/pharmacy.service';

@Component({
  selector: 'app-reserve-product',
  templateUrl: './reserve-product.component.html',
  styleUrls: ['./reserve-product.component.scss']
})
export class ReserveProductComponent implements OnInit {
  private reserveForm: FormGroup = new FormGroup({});
  public pharmacies = [];
  constructor(public dialogRef: MatDialogRef<ReserveProductComponent>,
    @Inject(MAT_DIALOG_DATA) public data,
    private fb: FormBuilder, private pharmacyService: PharmacyService) {
    this.pharmacyService.getAllPharmacies().then((rsp: any) => {
      this.pharmacies = rsp
    })
  }

  ngOnInit() {
    this.createForm();
  }

  createForm(): void {
    this.reserveForm = this.fb.group({
      pharmacyId: ['', [Validators.required]],
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

  public submit() {
    console.log(this.reserveForm.value);

    this.dialogRef.close(this.reserveForm.value);
  }

}
