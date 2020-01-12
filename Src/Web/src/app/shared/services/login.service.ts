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
    if (authResult) {
      localStorage.setItem('id_token', authResult.token)
    } else {
      localStorage.setItem('normal_user', 'true')
    }
    window.location.reload()
  }

  logout() {
    localStorage.removeItem('id_token')
    localStorage.removeItem('normal_user')
    window.location.reload()
  }

  isAuthenticated() {
    return localStorage.getItem('id_token') != null
      ? true
      : localStorage.getItem('normal_user') != null
      ? 2
      : false
  }
}
