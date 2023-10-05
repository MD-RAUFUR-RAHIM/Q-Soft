import { Injectable } from '@angular/core';
import { GetCategoryRequest } from '../models/get-category.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class GetCategoryService {

  
  constructor(private http: HttpClient) { }
  addCategory(model: GetCategoryRequest):Observable<void>
  {
     return this.http.post<void>('https://localhost:7103/api/Categories',model);
  }

}
