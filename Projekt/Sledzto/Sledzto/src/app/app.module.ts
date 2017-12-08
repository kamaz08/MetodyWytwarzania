import { NgModule } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NoConflictStyleCompatibilityMode } from '@angular/material';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



import {
    MatTabsModule, MatInputModule, MatCardModule, MatButtonModule, MatToolbarModule, MatProgressSpinnerModule, MatDialogModule
} from '@angular/material';


import { WebsiteService } from './service/website.service';
import { OptionService } from './service/option.service';
import { HistoryService } from './service/history.service';
import { UserService } from './service/user.service';

import { AppComponent } from './app.component';
import { PageComponent } from './component/page/page.component';
import { WebsiteComponent } from './component/website/website.component';
import { OptionComponent } from './component/option/option.component';
import { HistoryComponent } from './component/history/history.component';

@NgModule({
    imports: [
        BrowserModule, HttpClientModule, BrowserAnimationsModule, MatTabsModule, MatInputModule,
        MatCardModule, MatButtonModule, NoConflictStyleCompatibilityMode, MatToolbarModule,
        MatProgressSpinnerModule, MatDialogModule, FormsModule, ReactiveFormsModule
    ],
    exports: [],
    declarations: [AppComponent, PageComponent, WebsiteComponent, OptionComponent, HistoryComponent],
    bootstrap: [AppComponent],
    providers: [
        { provide: APP_BASE_HREF, useValue: '/' },
        WebsiteService, OptionService, HistoryService, UserService
    ],
})
export class AppModule { }
