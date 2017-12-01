import { Component } from '@angular/core';

import { Website } from './../../models/models'
import { WebsiteService } from './../../service/website.service'


@Component({
    selector: 'websitelist',
    templateUrl: './websitelist.component.html',
})
export class WebsiteListComponent {
    public Loading: boolean = true;
    public WebsiteList: Website[];

    constructor(private _service: WebsiteService) { }
    ngOnInit() {
        this.GetWebsite();
    }

    GetWebsite() {
        this._service.GetWebsite().subscribe(x => this.LoadWebsite(x))
    }

    LoadWebsite(x: Website[]) {
        this.Loading = false;
        this.WebsiteList = x;
    }

}
