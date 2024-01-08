import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryListComponent } from './features/category/category-list/category-list.component';
import { AddcategoryComponent } from './features/category/addcategory/addcategory.component';
import { EditCategoryComponent } from './features/category/edit-category/edit-category.component';
import { DeleteCategoryComponent } from './features/category/delete-category/delete-category.component';
import { BlogpostListComponent } from './features/blogpost/blogpost-list/blogpost-list.component';
import { BlogpostAddComponent } from './features/blogpost/blogpost-add/blogpost-add.component';

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
  },
  {
    path : "admin/deletecategory/:id",
    component : DeleteCategoryComponent
  },{
    path : "admin/blogposts",
    component: BlogpostListComponent
  },
  {
    path : "admin/addblogpost",
    component: BlogpostAddComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
