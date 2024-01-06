import { Component, OnDestroy } from '@angular/core';
import { Route, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AddCategoryRequest } from 'src/app/Model/category-request-model';
import { CategoryServiceService } from 'src/app/services/category.service.service';

@Component({
  selector: 'app-addcategory',
  templateUrl: './addcategory.component.html',
  styleUrls: ['./addcategory.component.css']
})
export class AddcategoryComponent implements OnDestroy {
  private addCategorySubscription? : Subscription;

  model: AddCategoryRequest;
  constructor(private categoryservice :CategoryServiceService, 
    private  router :Router){
    this.model= {
      name : '',
      urlHandle : ''
    }
  }
  onFromSubmit(){
    this.addCategorySubscription=  this.categoryservice.addCategory(this.model).subscribe({
      next : (response) =>{
        this.router.navigateByUrl('/admin/categories');
      }
    })
  }

  ngOnDestroy(): void {
    this.addCategorySubscription?.unsubscribe();
  }
}
