import { Component, Input } from '@angular/core';
import { DomSanitizer, SafeResourceUrl, SafeUrl } from '@angular/platform-browser';

import { WebsiteMenu, Option, History } from './../../models/models'
import { OptionService } from './../../service/option.service'
import { HistoryService } from './../../service/history.service'
import { UserService } from './../../service/user.service'
import { MatDialogRef } from "@angular/material/dialog";
import { FormControl, Validators } from '@angular/forms';


@Component({
    selector: 'website',
    templateUrl: './website.component.html',
})
export class WebsiteComponent {
    @Input() WebsiteMenu: WebsiteMenu = null;
    @Input() OptionId: Number = null;
    SaveUrl: SafeUrl;
    currentTab: Number = 0;
    Option: Option = null;
    public Loading0: boolean = true;
    public Loading1: boolean = true;
    History: History[] = [];
    email = new FormControl('', [Validators.required, Validators.email]);

    getErrorMessage() {
        return this.email.hasError('required') ? 'Podaj adres' :
            this.email.hasError('email') ? 'Nie poprawny adres' : '';
    }
    Sub() {
        if (this.getErrorMessage() == '')
            this._serviceUser.Subscribe(this.OptionId, this.email.value).subscribe();

    }

    constructor(private _sanitizer: DomSanitizer, private _serviceOpt: OptionService, private _serviceHis: HistoryService, private _serviceUser: UserService) { }

    ngOnInit() {

    }

    ngOnChanges() {
        this.LoadSpecyficData(this.currentTab);
    }

    tabChanged = (tabChangeEvent: any): void => {
        this.currentTab = tabChangeEvent;
        this.LoadSpecyficData(this.currentTab);

    }

    LoadSpecyficData(tab: Number) {
        switch (tab) {
            case 0:
                this.getOption(this.OptionId);
                break;
            case 1:
                this.getHistory(this.OptionId);
                break;
            case 2:
                this.SaveUrl = this._sanitizer.bypassSecurityTrustResourceUrl(this.WebsiteMenu.Url.toString());
                break;
        }
    }

    getOption(id: Number) {
        this.Loading0 = true;
        this._serviceOpt.GetOption(this.OptionId).subscribe(x => {
            this.Loading0 = false;
            this.Option = x;
        });
    }

    getHistory(optionId: Number) {
        this.Loading1 = true;
        this.History = [];
        this._serviceHis.GetHistory(optionId).subscribe(x => {
            this.Loading1 = false;
            this.History = x;
        });
    }

}
