import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router'
import * as cp from 'src/services/openapi/models/Component';
import { ComponentsService } from '../../contacts/components/components.service';

@Component({
  selector: 'app-project-page',
  templateUrl: './project-page.component.html',
  styleUrls: ['./project-page.component.css']
})
export class ProjectPageComponent implements OnInit {
  public projectName!: string;
  components: cp.Component[] = [];
  filtered: cp.Component[] = [];
  searchText = new FormControl('')
  constructor(private routerInfo: ActivatedRoute, private projectService: ComponentsService) { }

  ngOnInit(): void {
    this.routerInfo.queryParams.subscribe(param => this.projectName = param['project']);
    this.getComponents();
    this.searchText.valueChanges.subscribe(() => {
      this.filtered = this.components.filter(project => {
        return project.name?.indexOf(this.searchText.value) !== -1;
      });
    })
  }

  getComponents(): void {
    this.projectService.getComponents().subscribe((project) => {
      this.components = project;
      this.filtered = project;
    })
  }
}
