import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import * as fromDashboardStore from '../../reducers';
import { ConversionModel } from '../../models/lead-conversion.model';


@Component({
    selector: 'lead-conversion',
    templateUrl: './lead-conversion.component.html',
    styles: []
})

export class LeadConversion implements OnInit  {

    public _conversionModel$: Observable<ConversionModel>;
    public conversionDay: number = 0;
    public conversionMonth: number = 0;


    constructor(
        private _store: Store<fromDashboardStore.State>
    ) {}

    ngOnInit() {
        this._conversionModel$ = this._store.select(fromDashboardStore.getDashboardConversion);

        this._conversionModel$.pipe().subscribe(item => {
            this.conversionDay = (item.allDealsDay == 0 ? 0 : Math.round(item.succesfulDealsDay / item.allDealsDay * 100 * 100) / 100);
            this.conversionMonth = (item.allDealsMonth == 0 ? 0 : Math.round(item.succesfulDealsMonth / item.allDealsMonth * 100 * 100) / 100);
        });

    }
}
   
