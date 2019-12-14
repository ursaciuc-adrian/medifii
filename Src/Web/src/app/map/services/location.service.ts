import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  public location: Subject<LocationModel> = new Subject();
  /**
   *
   */
  constructor() {
    this.getLocation();

  }
  private getLocation(): void {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition((position) => {
        const longitude = position.coords.longitude;
        const latitude = position.coords.latitude;
        this.location.next(new LocationModel(latitude, longitude));
        // this.callApi(longitude, latitude);
      });
    } else {
      this.location.error('i am not allowed to do this');
    }
  }
}

export class LocationModel {
  public latitude: number;
  public longitude: number;

  constructor(lat: number, long: number) {
    this.latitude = lat;
    this.longitude = long;
  }
}