import { Component, Input } from '@angular/core';
import { DomSanitizer, SafeResourceUrl, SafeUrl } from '@angular/platform-browser';

import { WebsiteMenu } from './../../models/models'
import { OptionService } from './../../service/option.service'


@Component({
    selector: 'website',
    templateUrl: './website.component.html',
})
export class WebsiteComponent {
    @Input() WebsiteMenu: WebsiteMenu = null;
    @Input() OptionId: Number = null;
    SaveUrl: SafeUrl;

    constructor(private _sanitizer: DomSanitizer) { }

    ngOnInit() {
        this.SaveUrl = this._sanitizer.bypassSecurityTrustResourceUrl(this.WebsiteMenu.Url.toString());
    }
}
//this.WebsiteMenu.Url.toString()