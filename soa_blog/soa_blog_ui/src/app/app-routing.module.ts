import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryListComponent } from './features/category/category-list/category-list.component';
import { AddcategoryComponent } from './features/category/addcategory/addcategory.component';
import { EditCategoryComponent } from './features/category/edit-category/edit-category.component';

const routes: Routes = [
  {
    path:"admin/categories",
    component:CategoryListComponent
  },
  {
    path:"admim/addcategory",
    component:AddcategoryComponent
  },
  {
    path : "admin/editcategory/:id",
    component : EditCategoryComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }