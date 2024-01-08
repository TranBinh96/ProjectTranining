import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BlogPostResponse } from 'src/app/Model/blogPostReponse';
import { BlogpostServiceService } from 'src/app/services/blogpost.service.service';

@Component({
  selector: 'app-blogpost-list',
  templateUrl: './blogpost-list.component.html',
  styleUrls: ['./blogpost-list.component.css']
})
export class BlogpostListComponent implements OnInit{

  blogPosts$?: Observable<BlogPostResponse[]>;
  constructor(private service : BlogpostServiceService){
  }
  ngOnInit(): void {
    this.blogPosts$= this.service.getBlogPostAll();
  }

}


