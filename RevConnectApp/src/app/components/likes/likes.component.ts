import { Component, OnInit, Input } from '@angular/core';
import { Like } from 'src/app/Interfaces/Like';

@Component({
  selector: 'app-likes',
  templateUrl: './likes.component.html',
  styleUrls: ['./likes.component.css']
})
export class LikesComponent implements OnInit {
  @Input() postLikes!:Like[];

  constructor() { }

  ngOnInit(): void {
  }

}
