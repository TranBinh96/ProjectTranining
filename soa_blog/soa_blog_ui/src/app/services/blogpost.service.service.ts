import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BlogPost } from '../Model/blostPost';
import { Observable, Observer } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BlogPostResponse } from '../Model/blogPostReponse';

@Injectable({
  providedIn: 'root'
})
export class BlogpostServiceService {

  constructor(private http : HttpClient) { }
  getBlogPostAll():Observable<BlogPostResponse[]>{
    return this.http.get<BlogPostResponse[]>(`${environment.apiBaseUrl}/api/PostBlog`);    
  }

  addBlogPost(model : BlogPost):Observable<void>{
    return this.http.post<void>(`${environment.apiBaseUrl}/api/PostBlog`,model);
  }

  addEditBlogPost(id:string , model:BlogPost):Observable<BlogPost>{
    return  this.http.put<BlogPostResponse>(`${environment.apiBaseUrl}/api/PostBlog/${id}`,model);
  }

  getByIdBlogPost(id :string):Observable<BlogPostResponse>{
    return this.http.get<BlogPostResponse> (`${environment.apiBaseUrl}/api/PostBlog/${id}`);
  }
  deleteByIdBlog(id:string):Observable<BlogPostResponse>{
    return this.http.delete<BlogPostResponse>(`${environment.apiBaseUrl}/api/PostBlog/${id}`);
  }
}
