import { Component, OnInit } from '@angular/core'
import { ProductsService } from 'src/app/products/services/products/products.service'
import { MatTableDataSource } from '@angular/material';

export class Request {
public pharmacyId: string
public productName: string
public resolvedStatus: boolean
public quantity: number;
  constructor(pharmacyId: string, productName: string, resolvedStatus: boolean, quantity: number, deliveryOptions: string, availability: string, id?: number, description?: string) {
      this.pharmacyId = pharmacyId;
      this.productName = productName;
      this.resolvedStatus = resolvedStatus;
      this.quantity = quantity;
  }
}


@Component({
  selector: 'resolve-request',
  templateUrl: './resolve-request.component.html',
  styleUrls: ['./resolve-request.component.scss'],
})
export class ResolveRequest implements OnInit {
  requests;
  dataSource: MatTableDataSource<Request>;
  private displayedColumns: string[] = ['productName', 'quantity', 'resolvedStatus','actions',]
  constructor(private productsService: ProductsService) {}

  ngOnInit() {
    this.setDataSource()
  }

  setDataSource(): void {
    this.productsService.getAllRequests().subscribe(
      (requests: any) => {
        console.log(requests);
        
        this.dataSource = new MatTableDataSource<Request>(requests)
      },
      () => this.productsService.showMessage('An error occured!')
    )
  }

  search(searchValue: string) {
    this.dataSource.filter = searchValue.trim().toLowerCase()
  }

  resolve(id){
    this.productsService.resolveRequest(id).then((rsp)=>{
      this.productsService.showMessage('Request resolved succesfully!')
    },(err)=>{
      this.productsService.showMessage('Something went wrong.')
    })
  }
}
