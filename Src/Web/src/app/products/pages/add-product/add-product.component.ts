import { Component, OnInit, ViewChild, NgZone, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, AbstractControl } from '@angular/forms';
import { CdkTextareaAutosize } from '@angular/cdk/text-field';
import { take } from 'rxjs/operators';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss']
})
export class AddProductComponent implements OnInit {
  @ViewChild('autosize', { static: false }) autosize: CdkTextareaAutosize;
  private productForm: FormGroup = new FormGroup({});
  private deliverySelections: string[] = ['Courier', 'Personal pickup', 'Easybox'];
  constructor(public dialogRef: MatDialogRef<AddProductComponent>,
    @Inject(MAT_DIALOG_DATA) public data,
    private fb: FormBuilder,
    private _ngZone: NgZone) { }

  ngOnInit() {
    this.createForm();
  }

  createForm(): void {
    this.productForm = this.fb.group({
      name: ['', [Validators.required]],
      description: ['', [Validators.maxLength(200)]],
      price: ['', [Validators.required, Validators.min(0)]],
      expiryDate: ['', [Validators.required, this.dateValidator.bind(this)]],
      quantity: ['', [Validators.required, Validators.min(1)]],
      deliveryOptions: ['', [Validators.required]],
      availability: ['', [Validators.required]]
    });
  }

  submit(): void {
    this.dialogRef.close(this.productForm.value);
  }

  get name(): AbstractControl {
    return this.productForm.get('name');
  }
  get description(): AbstractControl {
    return this.productForm.get('description');
  }
  get price(): AbstractControl {
    return this.productForm.get('price');
  }
  get expiryDate(): AbstractControl {
    return this.productForm.get('expiryDate');
  }
  get quantity(): AbstractControl {
    return this.productForm.get('quantity');
  }
  get deliveryOptions(): AbstractControl {
    return this.productForm.get('deliveryOptions');
  }
  get availability(): AbstractControl {
    return this.productForm.get('availability');
  }

  private dateValidator(control: AbstractControl): { previousDate: true } {
    return control.value < new Date() ? { previousDate: true } : null;
  }
  private triggerResize() {
    this._ngZone.onStable.pipe(take(1))
      .subscribe(() => this.autosize.resizeToFitContent(true));
  }

}
