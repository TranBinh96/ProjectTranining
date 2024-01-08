import { Injectable } from '@angular/core';
import { Observable, Observer } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

import { Categories } from '../Model/categories';
import { CategoryRequest } from '../Model/categoryReponse';

@Injectable({
  providedIn: 'root'
})
export class CategoryServiceService {

  constructor(private http: HttpClient) { }

  addCategory(model:CategoryRequest):Observable<void>{
     return  this.http.post<void>(`${environment.apiBaseUrl}/api/Categories`,model);
  }

  getAllCategory() : Observable<Categories[]>{
      return this.http.get<Categories[]>(`${environment.apiBaseUrl}/api/Categories`);
  }

  getByIdCategory(id:string) :Observable<Categories>{
    return this.http.get<Categories>(`${environment.apiBaseUrl}/api/Categories/${id}`);
  }

  updateCategory(id : string,updateCategory:CategoryRequest):Observable<Categories>{
    return  this.http.put<Categories>(`${environment.apiBaseUrl}/api/Categories/${id}`,updateCategory);
  }
  
  deleteCategory(id : string):Observable<Categories>{
    return  this.http.delete<Categories>(`${environment.apiBaseUrl}/api/Categories/${id}`);
  }

}
