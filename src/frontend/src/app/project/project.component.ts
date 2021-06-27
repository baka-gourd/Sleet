import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }


  @Input() name:string = "";

  @Input()
  public get content(): string {
    return this._content;
  }
  private _content!: string;
  public set content(v: string) {
    this._content = v;
  }

  @Input()
  public get imageUrl(): string {
    return this._imageUrl;
  }
  private _imageUrl!: string;
  public set imageUrl(v: string) {
    this._imageUrl = v;
  }

  @Input()
  public get translatedPersent(): number {
    if (this._translatedPersent === undefined) {
      this.translatedPersent = 0;
    }
    return this._translatedPersent;
  }
  private _translatedPersent!: number;
  public set translatedPersent(v: number) {
    this._translatedPersent = v;
  }

  @Input()
  public get suggestionCount(): number {
    if (this._suggestionCount === undefined) {
      this.suggestionCount = 0;
    }
    return this._suggestionCount;
  }
  private _suggestionCount!: number;
  public set suggestionCount(v: number) {
    this._suggestionCount = v;
  }

}
