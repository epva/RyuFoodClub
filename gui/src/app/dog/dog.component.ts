import { Component, OnInit } from '@angular/core';
import { Dog } from '../dog';
@Component({
  selector: 'app-dog',
  templateUrl: './dog.component.html',
  styleUrls: ['./dog.component.less']
})
export class DogComponent implements OnInit {
  dog: Dog = {
    id: 1,
    name: 'Ryu'
  };
  constructor() { }

  ngOnInit(): void {
  }

}
