import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { RouterModule } from '@angular/router';
import { IBooksRepository, BooksRepository } from './Repository/Auth/BooksRepository';

import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './View/home/home.component';
import { HeaderComponent } from './View/Auth/header/header.component';
import { MenuComponent } from './View/Auth/menu/menu.component';
import { AccessRoutesService } from './Domain/Auth/AccessRoutesService';
import { StorageService } from './Domain/Auth/StorageService';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    MenuComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    { provide: IBooksRepository, useClass: BooksRepository },
    AccessRoutesService,
    StorageService
  ],
  bootstrap: [AppComponent],
  exports: [RouterModule]
})
export class AppModule { }
