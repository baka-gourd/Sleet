import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ProjectsComponent } from './pages/projects/projects.component';
import { TranslationRulesComponent } from './components/translation-rules/translation-rules.component'
import { WelcomeComponent } from './components/welcome/welcome.component'
import { ProjectPageComponent } from './pages/project-page/project-page.component';

const routes: Routes = [
  { path: 'projects', loadChildren: () => import('./routes/projects/projects.module').then(m => m.ProjectsModule) },
  {
    path: 'home', children: [
      { path: 'welcome', component: WelcomeComponent },
      { path: 'translation-rules', component: TranslationRulesComponent },
      { path: '**', component: WelcomeComponent },
    ]
  },
  { path: '**', component: WelcomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
