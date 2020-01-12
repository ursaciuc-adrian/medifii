import { Component, OnInit } from '@angular/core'
import { LoginService } from '../../services/login.service'
import { MatBottomSheet } from '@angular/material';
import { BottomInfoComponent } from '../bottom-info/bottom-info.component';

@Component({
  selector: 'app-navigation-menu',
  templateUrl: './navigation-menu.component.html',
  styleUrls: ['./navigation-menu.component.scss'],
})
export class NavigationMenuComponent implements OnInit {
  loggedIn
  constructor(private loginService: LoginService, private bottomSheet: MatBottomSheet) {
    this.loggedIn = loginService.isAuthenticated();
  }

  ngOnInit() {}

  logout(): void {
    this.loginService.logout();
  }

  openInfo(){
    this.bottomSheet.open(BottomInfoComponent, { data: { loggedIn: this.loggedIn }});
  }
}
