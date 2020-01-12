import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RequestsRoutingModule } from './requests.routing.module';
import { SharedModule } from '../shared/shared.module';
import { ConfirmDialogComponent } from '../shared/components/confirm-dialog/confirm-dialog.component';
import { ResolveRequest } from './pages/resolve-request/resolve-request.component';

@NgModule({
  declarations: [
      ResolveRequest
  ],
  imports: [
    CommonModule,
    SharedModule,
    RequestsRoutingModule,    
  ],
  entryComponents: [
    ConfirmDialogComponent
  ]
})
export class RequestsModule { }
