import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { PostFormComponent } from '../../../UI/src/app/post-form/post-form.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { PostsService } from '../posts.service';

@NgModule({
  declarations: [
    AppComponent,
    PostFormComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    CommonModule
  ],
  providers: [PostsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
