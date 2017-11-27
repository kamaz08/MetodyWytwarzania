import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';

import { NgModel } from '@angular/forms';

@Component({
  moduleId: module.id,
  templateUrl: 'choices.component.html',
  styleUrls: [ './choices.component.css' ]
})

export class ChoicesComponent implements OnInit {
  pages: string[];
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    // HTTP request:
    this.http.get('/api/items').subscribe(data => {
      this.pages = data['pages'];
    });
  }

  follow(mail: string) {
    // const req = this.http.post('/api/items/add', mail, this.pages.filter(pages => pages.selected).forEach(pages => {pages.SelectedId}));
    // req.subscribe();
  }

}
