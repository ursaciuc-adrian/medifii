import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './pages/login/login.component';
import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { LoginService } from './services/login.service';

@NgModule({
  declarations: [
    LoginComponent,
  ],
  imports: [
    LoginRoutingModule,
    SharedModule,
  ],
  providers: [
    LoginService
  ],
  bootstrap: []
})
export class LoginModule { }
