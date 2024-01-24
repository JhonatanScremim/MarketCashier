import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, catchError, map, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private url: string = "http://localhost:5247";

  constructor(
    private http: HttpClient,
    private router: Router
  ) { }

  public sign(payload: { username: string, password: string }): Observable<any>{
    return this.http.post<{token: string}>(`${this.url}/login`, payload).pipe(
      map((res) => {
        localStorage.removeItem('access_token');
        localStorage.setItem('access_token', JSON.stringify(res.token))
        return this.router.navigate(['login']);
      }),
      catchError((err) => {
        console.log(err);
        if(!err.error.isTrusted) return throwError(() => err.error);

        return throwError(() => "Erro interno, por favor tente novamente mais tarde");
      })
    )
  }

  public logout(){
    localStorage.removeItem('access_token');
    return this.router.navigate(['']);
  }
}
