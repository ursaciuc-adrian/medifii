import { Component, OnInit, Input, Inject } from '@angular/core';
import { MAT_BOTTOM_SHEET_DATA } from '@angular/material';

@Component({
  selector: 'bottom-info',
  templateUrl: './bottom-info.component.html',
  styleUrls: ['./bottom-info.component.scss']
})
export class BottomInfoComponent implements OnInit {
  loggedIn;
  constructor(@Inject(MAT_BOTTOM_SHEET_DATA) public data: any) {
    this.loggedIn = data.loggedIn;
   }

  ngOnInit() {
  }

}
