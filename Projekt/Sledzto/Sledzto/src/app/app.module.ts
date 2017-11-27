import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {FormsModule} from '@angular/forms';
import {HttpModule} from '@angular/http';

import {AppComponent} from './app.component';
import {routing} from './app.routing';

import {MainComponent} from './main/index';
import {ChoicesComponent} from './choices/index';

import {Ng2CarouselamosModule} from 'ng2-carouselamos';
import {HttpClientModule} from '@angular/common/http';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    Ng2CarouselamosModule,
    HttpClientModule,
    routing
  ],
  declarations: [
    MainComponent,
    AppComponent,
    ChoicesComponent,
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})

export class AppModule {
}
