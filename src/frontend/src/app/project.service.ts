import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Project } from 'src/services/openapi';
const PROJECTS:Project[]=[
  {name:"1"},
  {name:"114"},
  {name:"514"},
  {name:"810"},
  {name:"1919"},
  {name:"170001"},
  {name:"54943"},
  {name:"nmsl"},
  {name:"厚礼蟹"},
  {name:"fuck"},
  {name:"bull shit"},
  {name:"ohhhhhhhhhh"}
];
@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  constructor() { }

  getProjects():Observable<Project[]>{
    return of(PROJECTS);
  }
}
