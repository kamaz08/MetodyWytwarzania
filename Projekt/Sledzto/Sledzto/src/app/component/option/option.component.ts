import { Component, Input } from '@angular/core';

import { Option } from './../../models/models'
import { OptionService } from './../../service/option.service'


@Component({
    selector: 'option',
    templateUrl: './option.component.html',
})
export class OptionComponent {
    @Input() Option: Option = null;


}
