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

  setSession(authResult) {
    localStorage.setItem('id_token', authResult.token)
    window.location.reload()
  }

  logout() {
    localStorage.removeItem('id_token')
    window.location.reload()
  }

  isAuthenticated() {
    return localStorage.getItem('id_token') != null ? true : false
  }
}
