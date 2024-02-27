import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Post } from './post';

@Injectable({
  providedIn: 'root'
})
export class PostsService {
  private baseUrl = 'https://localhost:7022/posts';

  constructor(private http: HttpClient) { }

  getPosts(tags: string, sortBy: string, direction: string): Observable<Post[]> {
    const url = `${this.baseUrl}?tags=${tags}&sortBy=${sortBy}&direction=${direction}`;
    return this.http.get<Post[]>(url);
  }
}
