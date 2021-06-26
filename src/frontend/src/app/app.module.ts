import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProjectComponent } from './components/project/project.component';
import { ProjectsComponent } from './pages/projects/projects.component';
import { HomeComponent } from './pages/home/home.component';
import { NavComponent } from './components/nav/nav.component';
import { TranslationRulesComponent } from './components/translation-rules/translation-rules.component';
import { WelcomeComponent } from './components/welcome/welcome.component';
import { ProjectPageComponent } from './pages/project-page/project-page.component';

@NgModule({
  declarations: [AppComponent, ProjectComponent, ProjectsComponent, HomeComponent, NavComponent, TranslationRulesComponent, WelcomeComponent, ProjectPageComponent],
  imports: [BrowserModule, AppRoutingModule, FormsModule, ReactiveFormsModule],
  providers: [],
  bootstrap: [AppComponent, NavComponent],
})
export class AppModule { }
