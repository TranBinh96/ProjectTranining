import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Categories } from 'src/app/Model/categories';
import { CategoryRequest } from 'src/app/Model/categoryReponse';
import { CategoryServiceService } from 'src/app/services/category.service.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {

    categories$?:  Observable<Categories[]>;
    constructor(private categoryServiceService :CategoryServiceService){
    }
    ngOnInit(): void {
      this.categories$= this.categoryServiceService.getAllCategory();
    }

}
