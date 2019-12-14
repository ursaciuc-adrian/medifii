import { ScraperService } from './../../services/scraper.service';
import { Component } from '@angular/core';

@Component({
  selector: 'home-page',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  title = 'medifii';
  meds;

  constructor(private scraperService: ScraperService) {
    this.scraperService.getMeds().then(rsp => {
      this.meds = rsp;
      console.log(this.meds);
      
    })
  }
}
