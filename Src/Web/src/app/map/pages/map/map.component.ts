import { Component, ViewChild, ElementRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LocationService, LocationModel } from '../../services/location.service';

declare var H: any;

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss']
})
export class MapComponent {

  public places = [];

  @ViewChild('map', { static: true })
  public mapElement: ElementRef;

  constructor(private locationService: LocationService, private http: HttpClient) {
  }

  // tslint:disable-next-line: use-lifecycle-interface
  public ngAfterViewInit() {

    this.locationService.location.subscribe((location: LocationModel) => {

      const platform = new H.service.Platform({
        apikey: 'w96hlfDfHD_OoJsiQquh-LNKDXegwUwowbp7DxWc-EM'
      });

      const defaultLayers = platform.createDefaultLayers();

      const coords = { lat: location.latitude, lng: location.longitude };

      const map = new H.Map(
        document.getElementById('map'),
        defaultLayers.vector.normal.map,
        {
          zoom: 12,
          center: coords
        });


      const url = 'https://places.cit.api.here.com/places/v1/autosuggest?at=' + location.latitude +
        ',' + location.longitude + '&q=catena&app_id=s7scoIp2si9ftvUoMalC&app_code=-PPJRHdWrW9TFQga-2KWxw';
      this.http.get(url).subscribe((result: any) => {
        this.places = result.results;

        this.places.forEach(place => {
          if (place.position !== undefined) {
            const mark = new H.map.Marker({ lat: place.position[0], lng: place.position[1] });
            map.addObject(mark, { icon });
          }

        })
      });

      // tslint:disable-next-line: max-line-length
      const svgMarkup = `<svg width="24" height="24" ' +
      'xmlns="http://www.w3.org/2000/svg">' +
      '<rect stroke="white" fill="#1b468d" x="1" y="1" width="22" ' +
      'height="22" /><text x="12" y="18" font-size="12pt" ' +
      'font-family="Arial" font-weight="bold" text-anchor="middle" ' +
      'fill="white">H</text></svg>'`;

      const icon = new H.map.Icon(svgMarkup);

      const marker = new H.map.Marker(coords);
      map.addObject(marker, { icon });

      const ui = H.ui.UI.createDefault(map, defaultLayers);
    });


  }
}