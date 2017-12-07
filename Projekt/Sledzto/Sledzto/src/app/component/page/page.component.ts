import { Component } from '@angular/core';

import { WebsiteMenu } from './../../models/models'
import { WebsiteService } from './../../service/website.service'


@Component({
    selector: 'page',
    templateUrl: './page.component.html',
})
export class PageComponent {
    WebsiteList: WebsiteMenu[] = null;
    public Loading: boolean = true;

    public childWeb: WebsiteMenu = null;
    public childOptionId: Number = null;

    constructor(private _service: WebsiteService) { }
    ngOnInit() {
        this.GetWebsiteList();
    }


    GetWebsiteList() {
        this.Loading = true;
        this._service.GetListWebstite().subscribe(x => this.SetWebsiteList(x));
    }

    SetWebsiteList(data: WebsiteMenu[]) {
        this.Loading = false;
        this.WebsiteList = data;
    }

    ChangePage(page: WebsiteMenu, optionId: Number) {
        this.childWeb = page;
        this.childOptionId = optionId;
    }

}
