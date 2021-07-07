import { Component, OnInit, OnDestroy } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { Store } from "@ngrx/store";

import * as fromDashboardStore from '../../reducers';

import { SalesByDayAndMonthModel } from "../../models/sales-by-day.model";
import { takeUntil } from "rxjs/operators";

@Component({
    selector: 'average-check',
    templateUrl: './average-check.component.html',
    styles: []
})
export class AverageCheckComponent implements OnInit, OnDestroy {

    public _salesByDayAndMonth$: Observable<SalesByDayAndMonthModel>;

    public averageCheckByDay: string;
    public averageCheckByMonth: string;

    private destroy$: Subject<boolean> = new Subject<boolean>();

    constructor(private _store: Store<fromDashboardStore.State>, ) { }

    ngOnInit() {
        this._salesByDayAndMonth$ = this._store.select(fromDashboardStore.getDashboardSales);
        this._salesByDayAndMonth$.pipe(takeUntil(this.destroy$)).subscribe(result => {
            this.averageCheckByDay = (result.sumSalesByToday18_Yesterday18 / result.countSalesByToday18_Yesterday18).toFixed(2);
            this.averageCheckByMonth = (result.sumSalesByMonth / result.countSalesByMonth).toFixed(2);
        });
    }

    ngOnDestroy() {
        this.destroy$.next(true);
        this.destroy$.unsubscribe();
    }
}
