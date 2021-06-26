import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProjectPageComponent } from '../../pages/project-page/project-page.component';
import { ProjectsComponent } from '../../pages/projects/projects.component';

const routes: Routes = [
  { path: 'project', component: ProjectPageComponent },
  { path: '**', component: ProjectsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProjectsRoutingModule { }
