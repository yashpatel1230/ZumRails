import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-post-form',
  templateUrl: './post-form.component.html',
  styleUrls: ['./post-form.component.css']
})
export class PostFormComponent {

  tags: string = '';
  sortBy: string = '';
  direction: string = '';

  @Output() formSubmit = new EventEmitter<{ tags: string, sortBy: string, direction: string }>();

  onSubmit(): void {
    this.formSubmit.emit({ tags: this.tags, sortBy: this.sortBy, direction: this.direction });
  }
}
