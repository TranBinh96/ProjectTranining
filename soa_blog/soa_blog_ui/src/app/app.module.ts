import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './core/components/navbar/navbar.component';
import { CategoryListComponent } from './features/category/category-list/category-list.component';
import { AddcategoryComponent } from './features/category/addcategory/addcategory.component';
import { FormsModule } from '@angular/forms';
import{HttpClientModule} from '@angular/common/http';
import { EditCategoryComponent } from './features/category/edit-category/edit-category.component';
import { DeleteCategoryComponent } from './features/category/delete-category/delete-category.component';
import { BlogpostListComponent } from './features/blogpost/blogpost-list/blogpost-list.component';
import { BlogpostAddComponent } from './features/blogpost/blogpost-add/blogpost-add.component'

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CategoryListComponent,
    AddcategoryComponent,
    EditCategoryComponent,
    DeleteCategoryComponent,
    BlogpostListComponent,
    BlogpostAddComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
