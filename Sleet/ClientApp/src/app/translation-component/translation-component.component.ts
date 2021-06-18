import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-translation-component',
  templateUrl: './translation-component.component.html',
  styleUrls: ['./translation-component.component.css']
})
export class TranslationComponentComponent implements OnInit {
  @Input() CardName: string;
  @Input() CardContent: string;

  ngOnInit(): void {}
}
