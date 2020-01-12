import { Component, OnInit } from '@angular/core'
import { ProductsService } from 'src/app/products/services/products/products.service'
import { MatTableDataSource } from '@angular/material';
@Component({
  selector: 'resolve-request',
  templateUrl: './resolve-request.component.html',
  styleUrls: ['./resolve-request.component.scss'],
})
export class ResolveRequest implements OnInit {
  requests;
  dataSource
  constructor(private productsService: ProductsService) {}

  ngOnInit() {
    this.setDataSource()
  }

  setDataSource(): void {
    this.productsService.getAllRequests().subscribe(
      (requests: any) => {
        console.log(requests);
        
        this.dataSource = new MatTableDataSource<any>(requests)
      },
      () => this.productsService.showMessage('An error occured!')
    )
  }

  search(searchValue: string) {
    this.dataSource.filter = searchValue.trim().toLowerCase()
  }
}
