import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http'

@Injectable()
export class LoginService {
  private loginEndpoint: string = '/api/auth'

  constructor(private http: HttpClient) {}

  login(model) {
    return this.http.post(`${this.loginEndpoint}/login`, model).toPromise()
  }

  register(model) {
    return this.http.post(`${this.loginEndpoint}/register`, model).toPromise()
  }
}
