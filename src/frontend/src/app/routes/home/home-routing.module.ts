import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TranslationRulesComponent } from 'src/app/components/translation-rules/translation-rules.component';
import { WelcomeComponent } from 'src/app/components/welcome/welcome.component';

const routes: Routes = [
  { path: 'welcome', component: WelcomeComponent },
  { path: 'translation-rules', component: TranslationRulesComponent },
  { path: '**', component: WelcomeComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
