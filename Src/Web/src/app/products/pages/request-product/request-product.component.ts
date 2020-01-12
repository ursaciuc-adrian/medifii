import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { ProductsService } from '../../services/products/products.service';
import { MatSnackBar, MatDialogRef } from '@angular/material';
import { PharmacyService } from 'src/app/shared/services/pharmacy.service';

@Component({
  selector: 'app-request-product',
  templateUrl: './request-product.component.html',
  styleUrls: ['./request-product.component.scss']
})
export class RequestProductComponent implements OnInit {
  private requestForm: FormGroup = new FormGroup({});
  pharmacies = [];
  constructor(private fb: FormBuilder, private productsService: ProductsService, private snackBar: MatSnackBar, private pharmacyService: PharmacyService, private dialogRef: MatDialogRef<RequestProductComponent>) { 
    this.pharmacyService.getAllPharmacies().then((rsp: any)=>{
      this.pharmacies = rsp
    })
  }

  ngOnInit() {
    this.createForm();
  }

  createForm(): void {
    this.requestForm = this.fb.group({
      pharmacyId: ['',[Validators.required]],
      name: ['', [Validators.required]],
      quantity: ['', [Validators.required, Validators.min(1)]],
    });
  }

  submit(): void {
    this.productsService.addRequest(this.requestForm.value).then((rsp)=>{
      this.showMessage('Request added succesfully!');
      this.dialogRef.close();
    },(err)=>{
      this.showMessage('Something went wrong.');
    });
  }

  get name(): AbstractControl {
    return this.requestForm.get('name');
  }

  get quantity(): AbstractControl {
    return this.requestForm.get('quantity');
  }

  showMessage(message): void {
    this.snackBar.open(message, 'x', {
      duration: 2000,
      verticalPosition: 'top',
      horizontalPosition: 'right',
    })
  }

}
