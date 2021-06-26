import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Project } from 'src/services/openapi';
import { ProjectsService } from '../contact/projects/projects.service';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent implements OnInit {
  projects: Project[] = []
  filtered: Project[] = []
  searchText = new FormControl('')
  constructor(private projectService: ProjectsService) { }

  ngOnInit(): void {
    this.getProjects()
    this.searchText.valueChanges.subscribe(() => {
      this.filtered = this.projects.filter(project => {
        return project.name?.indexOf(this.searchText.value) !== -1;
      });
    })
  }

  getProjects(): void {
    this.projectService.getProjects().subscribe(projects => {
      this.projects = projects;
      this.filtered = this.projects
    });
  }
}
