import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Subscription } from 'rxjs';
import { Categories } from 'src/app/Model/categories';
import { CategoryRequest } from 'src/app/Model/categoryReponse';
import { CategoryServiceService } from 'src/app/services/category.service.service';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent implements OnInit ,OnDestroy{

  id: string | null =null;
  paramsSubscription?: Subscription;
  editSubscription?: Subscription;
  category?: Categories;
  
  constructor(private categoryServiceService : CategoryServiceService, private router :ActivatedRoute,private  routers :Router){

  }
  onEditFromSubmit():void{
      const categoryRequest  : CategoryRequest ={
        name : this.category?.name ?? '',
        urlHandle : this.category?.urlHandle ?? ''
      }
    if(this.id){
      this.categoryServiceService.updateCategory(this.id,categoryRequest).subscribe({
        next : (response) =>{
            this.routers.navigateByUrl("/admin/categories")
        }
      });    
    }
  }
  ngOnInit(): void {
    this.editSubscription = this.paramsSubscription = this.router.paramMap.subscribe({
      next :(params)=>{
        this.id = params.get('id');
      }
    });
    if(this.id){
      this.categoryServiceService.getByIdCategory(this.id).subscribe({
        next : (response)=>{
          this.category = response;
        }
      });
    }
  }
  ngOnDestroy(): void {
    this.paramsSubscription?.unsubscribe();
    this.editSubscription?.unsubscribe();
  }
}
