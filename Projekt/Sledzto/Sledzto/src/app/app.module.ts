import { NgModule } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NoConflictStyleCompatibilityMode } from '@angular/material';

import {
    MatTabsModule, MatInputModule, MatCardModule, MatButtonModule, MatToolbarModule, MatProgressSpinnerModule
} from '@angular/material';


import { WebsiteService } from './service/website.service';
import { OptionService } from './service/option.service';

import { AppComponent } from './app.component';
import { WebsiteComponent } from './component/website/website.component';
import { WebsiteListComponent } from './component/website/websitelist.component';
import { OptionComponent } from './component/option/option.component';

@NgModule({
    imports: [
        BrowserModule, HttpClientModule, BrowserAnimationsModule, MatTabsModule, MatInputModule,
        MatCardModule, MatButtonModule, NoConflictStyleCompatibilityMode, MatToolbarModule,
        MatProgressSpinnerModule
    ],
    declarations: [AppComponent, WebsiteComponent, WebsiteListComponent, OptionComponent],
    bootstrap: [AppComponent],
    providers: [
        { provide: APP_BASE_HREF, useValue: '/' },
        WebsiteService, OptionService
    ],
})
export class AppModule { }
