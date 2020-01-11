import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navigation-menu',
  templateUrl: './navigation-menu.component.html',
  styleUrls: ['./navigation-menu.component.scss']
})
export class NavigationMenuComponent implements OnInit {
  constructor() { }

  ngOnInit() {
  }

  isAuthenticated(): boolean {
    return true;
  }

  logout(): void {
    console.log('Should log out!');
  }
}
