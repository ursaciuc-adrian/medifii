import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './pages/login/login.component';
import { NgModule } from '@angular/core';
import { SignupComponent } from './pages/signup/signup.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    LoginComponent,
    SignupComponent
  ],
  imports: [
    LoginRoutingModule,
    SharedModule,
  ],
  providers: [],
  bootstrap: []
})
export class LoginModule { }
