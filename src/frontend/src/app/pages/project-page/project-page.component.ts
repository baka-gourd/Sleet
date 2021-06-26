import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router'

@Component({
  selector: 'app-project-page',
  templateUrl: './project-page.component.html',
  styleUrls: ['./project-page.component.css']
})
export class ProjectPageComponent implements OnInit {

  constructor(private routerInfo: ActivatedRoute) { }

  ngOnInit(): void {
    this.routerInfo.queryParams.subscribe((param) => {
      this.projectName = param['project'];
      console.log(this.projectName)
    })
  }


  private _projectName!: string;
  public get projectName(): string {
    return this._projectName;
  }
  public set projectName(v: string) {
    this._projectName = v;
  }

}
