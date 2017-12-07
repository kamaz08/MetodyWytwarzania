import { Component, Input } from '@angular/core';

import { History } from './../../models/models'
import { HistoryService } from './../../service/history.service'


@Component({
    selector: 'history',
    templateUrl: './history.component.html',
})
export class HistoryComponent {
    @Input() HistoryList: History[] = null;

    List: History[] = [];

    ngOnChanges() {
        this.List = this.HistoryList;
    }
}
