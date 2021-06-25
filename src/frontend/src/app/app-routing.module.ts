import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProjectsComponent } from './projects/projects.component';
import { TranslationRulesComponent } from './home/translation-rules/translation-rules.component'
import { WelcomeComponent } from './home/welcome/welcome.component'

const routes: Routes = [
  { path: 'projects', component: ProjectsComponent },
  {
    path: 'home', component: HomeComponent, children: [
      { path: '', redirectTo: '/home/welcome', pathMatch: 'full' },
      { path: 'welcome', component: WelcomeComponent },
      { path: 'translation-rules', component: TranslationRulesComponent }
    ]
  },
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: '**', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
