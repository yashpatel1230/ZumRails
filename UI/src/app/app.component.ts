import { Component } from '@angular/core';
import { PostsService } from '../posts.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})


export class AppComponent {

  posts: any[] = [];
  constructor(private postsService: PostsService) { }

  async getPosts(params: { tags: string, sortBy: string, direction: string }) {
    const { tags, sortBy, direction } = params;
    this.postsService.getPosts(tags, sortBy, direction)
    .subscribe(posts => this.posts = posts);
  }
}