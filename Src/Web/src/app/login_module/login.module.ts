import { LoginRoutingModule } from './login-routing.module'
import { LoginComponent } from './pages/login/login.component'
import { NgModule } from '@angular/core'
import { SharedModule } from '../shared/shared.module'

@NgModule({
  declarations: [LoginComponent],
  imports: [LoginRoutingModule, SharedModule],
  providers: [],
  bootstrap: [],
})
export class LoginModule {}
