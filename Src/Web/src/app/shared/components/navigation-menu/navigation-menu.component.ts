import { Component, OnInit } from '@angular/core'
import { LoginService } from '../../services/login.service'

@Component({
  selector: 'app-navigation-menu',
  templateUrl: './navigation-menu.component.html',
  styleUrls: ['./navigation-menu.component.scss'],
})
export class NavigationMenuComponent implements OnInit {
  loggedIn
  constructor(private loginService: LoginService) {
    this.loggedIn = loginService.isAuthenticated();
  }

  ngOnInit() {}

  logout(): void {
    this.loginService.logout();
  }
}
