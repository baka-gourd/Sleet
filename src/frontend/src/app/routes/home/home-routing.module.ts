import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TranslationRulesComponent } from 'src/app/components/translation-rules/translation-rules.component';
import { WelcomeComponent } from '../../components/welcome/welcome.component';
import { HomeComponent } from '../../pages/home/home.component';

const routes: Routes = [
  { path: 'welcome', component: WelcomeComponent },
  { path: 'translation-rules', component: TranslationRulesComponent },
  { path: '**', component: HomeComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
