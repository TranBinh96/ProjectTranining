import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Categories } from 'src/app/Model/categories';
import { CategoryRequest } from 'src/app/Model/categoryReponse';
import { CategoryServiceService } from 'src/app/services/category.service.service';

@Component({
  selector: 'app-delete-category',
  templateUrl: './delete-category.component.html',
  styleUrls: ['./delete-category.component.css']
})
export class DeleteCategoryComponent  implements OnInit ,OnDestroy {

  id: string | null =null;
  paramsSubscription?: Subscription;
  deleteSubscription?: Subscription;
  category?: Categories;

  constructor(private categoryServiceService : CategoryServiceService, private router :ActivatedRoute,private  routers :Router){
    
  }

  onDeleteFromSubmit(){
    const categoryRequest  :CategoryRequest ={
      name : this.category?.name ?? '',
      urlHandle : this.category?.urlHandle ?? ''
    }
    if(this.id){
      this.deleteSubscription  = this.categoryServiceService.deleteCategory(this.id).subscribe({
        next : (response) =>{
            this.routers.navigateByUrl("/admin/categories")
        }
      });      
    }
  }

  ngOnInit(): void {
    this.paramsSubscription = this.router.paramMap.subscribe({
      next :(params: { get: (arg0: string) => string | null; })=>{
        this.id = params.get('id');
      }
    });

    if(this.id){
      this.categoryServiceService.getByIdCategory(this.id).subscribe({
        next : (response: Categories | undefined)=>{
          this.category = response;
        }
      })
    }     
  }
  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
    this.deleteSubscription?.unsubscribe();
  }
}
