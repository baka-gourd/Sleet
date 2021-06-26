import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TranslationRulesComponent } from './components/translation-rules/translation-rules.component'
import { WelcomeComponent } from './components/welcome/welcome.component'

const routes: Routes = [
  { path: 'projects', loadChildren: () => import('./routes/projects/projects.module').then(m => m.ProjectsModule) },
  { path: 'home', loadChildren: () => import('./routes/home/home.module').then(m => m.HomeModule) },
  { path: '**', component: WelcomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
