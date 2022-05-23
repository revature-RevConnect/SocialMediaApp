import { Component, OnInit, Input } from '@angular/core';
import { Comment } from 'src/app/Interfaces/Comment';

@Component({
  selector: 'app-commentfeed',
  templateUrl: './commentfeed.component.html',
  styleUrls: ['./commentfeed.component.css']
})
export class CommentfeedComponent implements OnInit {
  showComments!:boolean;
  @Input() comments!:Comment[];

  constructor() { }

  ngOnInit(): void {
  }

}
