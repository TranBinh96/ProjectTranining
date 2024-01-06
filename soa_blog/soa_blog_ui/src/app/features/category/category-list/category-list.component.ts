import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryResponse } from 'src/app/Model/category-response-model';
import { CategoryServiceService } from 'src/app/services/category.service.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {

    categoryResponse$?:  Observable<CategoryResponse[]>;

    constructor(private categoryServiceService :CategoryServiceService){

    }
    ngOnInit(): void {
      this.categoryResponse$= this.categoryServiceService.getAllCategory();
    }

}
