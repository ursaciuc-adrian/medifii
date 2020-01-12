import { ScraperService } from './../../services/scraper.service';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'home-page',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  title = 'medifii';
  meds;

  constructor(private scraperService: ScraperService, private router: Router) {
    this.scraperService.getMeds().then(rsp => {
      this.meds = rsp;
      console.log(this.meds);

    })
  }

  public navigateToMap(): void {
    this.router.navigate(['/map']);

  }
}
