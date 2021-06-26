import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ProjectsComponent } from './pages/projects/projects.component';
import { TranslationRulesComponent } from './components/translation-rules/translation-rules.component'
import { WelcomeComponent } from './components/welcome/welcome.component'
import { ProjectPageComponent } from './pages/project-page/project-page.component';

const routes: Routes = [
  {
    path: 'projects', children: [
      { path: 'project', component: ProjectPageComponent },
      { path: '**', component: ProjectsComponent },
    ]
  },
  {
    path: 'home', component: HomeComponent, children: [
      { path: 'welcome', component: WelcomeComponent },
      { path: 'translation-rules', component: TranslationRulesComponent },
      { path: '**', redirectTo: '/home/welcome' },
    ]
  },
  { path: '**', component: WelcomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
