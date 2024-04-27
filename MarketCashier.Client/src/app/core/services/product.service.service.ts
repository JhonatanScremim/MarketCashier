import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ProductElement } from "src/app/components/pages/home/home.component";

@Injectable({
  providedIn: "root",
})
export class ProductService {
  private url: string = "http://localhost:5247";

  constructor(private http: HttpClient) {}

  getProducts(page: number, pageSize: number): Observable<any> {
    const token = localStorage.getItem("access_token");
    const header = new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });

    return this.http.get<any>(
      `${this.url}/get-paginated?PageNumber=${page}&PageSize=${pageSize}`,
      { headers: header }
    );
  }

  createProduct(model: ProductElement): Observable<any> {
    const token = localStorage.getItem("access_token");
    const header = new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });

    return this.http.post<any>(`${this.url}/create`, model, { headers: header });
  }
}
