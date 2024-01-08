import { Component, OnDestroy } from '@angular/core';
import { Route, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { BlogPost } from 'src/app/Model/blostPost';
import { BlogpostServiceService } from 'src/app/services/blogpost.service.service';

@Component({
  selector: 'app-blogpost-add',
  templateUrl: './blogpost-add.component.html',
  styleUrls: ['./blogpost-add.component.css']
})
export class BlogpostAddComponent implements OnDestroy{

  addBlogSubscription  ?: Subscription
  model:BlogPost;

  constructor(private blogpostServiceService : BlogpostServiceService, private router : Router){
    this.model ={
      title:'',
      shortDescription :'',
      content : '',
      featuredImageUrl : '',
      urlHandle:'',
      publishedDate : new Date(),
      author:'',
      isVisible : true 
    }
  }
  
  onFormSubmit():void{
    this.addBlogSubscription =this.blogpostServiceService.addBlogPost(this.model).subscribe({
          next :(response)=>{
            this.router.navigateByUrl("admin/blogposts");
          }
      });
  }

  ngOnDestroy(): void {
    this.addBlogSubscription?.unsubscribe();
  }


}
