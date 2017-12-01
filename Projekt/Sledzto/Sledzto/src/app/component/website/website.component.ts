import { Component, Input } from '@angular/core';

import { Website, Option } from './../../models/models'
import { OptionService } from './../../service/option.service'


@Component({
    selector: 'website',
    templateUrl: './website.component.html',
})
export class WebsiteComponent {
    @Input() Website: Website = null;

    public Loading: boolean = true;
    public OptionList: Option[];

    constructor(private _service: OptionService) { }
    ngOnInit() {
        this.GetOptions();
    }

    GetOptions() {
        this._service.GetOptions(this.Website.Id).subscribe(x => this.LoadOptions(x))
    }

    LoadOptions(x: Option[]) {
        this.Loading = false;
        this.OptionList = x;
    }
}
