import {Component, OnInit} from '@angular/core';
import {Router, ActivatedRoute} from '@angular/router';


@Component({
  moduleId: module.id,
  templateUrl: 'main.component.html',
  styleUrls: ['./main.component.css']
})

export class MainComponent {
  model: any = {};
  loading = false;
  returnUrl: string;
  items: Array<any> = [];

  constructor(private route: ActivatedRoute,
              private router: Router,
              ) {
    this.items = [
      { name: 'assets/images/pic2.jpeg' },
      { name: 'assets/images/pic3.jpeg' },
      { name: 'assets/images/pic2.jpeg' },
      { name: 'assets/images/pic3.jpeg' },
    ];
  }
}
