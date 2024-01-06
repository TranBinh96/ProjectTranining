import { Injectable } from '@angular/core';
import { AddCategoryRequest } from '../Model/category-request-model';
import { Observable, Observer } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { CategoryResponse } from '../Model/category-response-model';
import { environment } from 'src/environments/environment';
import { UpdateCategory } from '../Model/update-category-model';

@Injectable({
  providedIn: 'root'
})
export class CategoryServiceService {

  constructor(private http: HttpClient) { }

  addCategory(model:AddCategoryRequest):Observable<void>{
     return  this.http.post<void>(`${environment.apiBaseUrl}/api/Categories`,model);
  }

  getAllCategory() : Observable<CategoryResponse[]>{
      return this.http.get<CategoryResponse[]>(`${environment.apiBaseUrl}/api/Categories`);
  }

  getByIdCategory(id:string) :Observable<CategoryResponse>{
    return this.http.get<CategoryResponse>(`${environment.apiBaseUrl}/api/Categories/${id}`);
  }
  updateCategory(id : string,model:UpdateCategory)
  :Observable<void>{
    return  this.http.put<void>(`${environment.apiBaseUrl}/api/Categories/${id}`,model);
 }

}
