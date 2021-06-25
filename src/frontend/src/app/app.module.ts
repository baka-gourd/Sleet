import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProjectComponent } from './projects/project/project.component';
import { ProjectsComponent } from './projects/projects.component';
import { HomeComponent } from './home/home.component';
import { NavComponent } from './nav/nav.component';
import { TranslationRulesComponent } from './home/translation-rules/translation-rules.component';
import { WelcomeComponent } from './home/welcome/welcome.component';

@NgModule({
  declarations: [AppComponent, ProjectComponent, ProjectsComponent, HomeComponent, NavComponent, TranslationRulesComponent, WelcomeComponent],
  imports: [BrowserModule, AppRoutingModule, FormsModule, ReactiveFormsModule],
  providers: [],
  bootstrap: [AppComponent, NavComponent],
})
export class AppModule { }
