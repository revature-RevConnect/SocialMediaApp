import { Component, OnInit,Input } from '@angular/core';
import { Post } from 'src/app/Interfaces/Post';

@Component({
  selector: 'app-postfeed',
  templateUrl: './postfeed.component.html',
  styleUrls: ['./postfeed.component.css']
})
export class PostfeedComponent implements OnInit {
  @Input()posts!:Post[];
  @Input() authID!:any;

  constructor() { }

  ngOnInit(): void {
  }

}
