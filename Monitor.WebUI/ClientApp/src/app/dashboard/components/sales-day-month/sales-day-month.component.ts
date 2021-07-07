import { Component, OnInit, OnDestroy } from '@angular/core';

import { Observable, Subject } from 'rxjs';
import { Store } from '@ngrx/store';
import { takeUntil } from "rxjs/operators";

import * as fromDashboardStore from '../../reducers';

import { SalesByDayAndMonthModel } from '../../models/sales-by-day.model';


@Component({
    selector: 'sales-day-month',
    templateUrl: './sales-day-month.component.html',
    styles: []
})

export class SalesDayMonth implements OnInit, OnDestroy {
    public _salesByDayAndMonth$: Observable<SalesByDayAndMonthModel>;

    public progresSalesDay: number = 0;
    public progresSalesMonth1: number = 0;
    public progresSalesMonth2: number = 0;
    public progresSalesMonth2ForShow: number = 0;
    public progresSalesMonth3: number = 0;
    public isPositive: boolean = true;
    public planOnDayForSale: number = 0;
    public remainingDays: number = 0;
    public factToday: number = 0;

    private daysInMonth: number = this.CountDayOnMonth();
    private showTooltip: boolean = false;
    private destroy$: Subject<boolean> = new Subject<boolean>();

    constructor(
        private _store: Store<fromDashboardStore.State>,
    ) { }

    ngOnInit() {
        this._salesByDayAndMonth$ = this._store.select(fromDashboardStore.getDashboardSales);
        this._salesByDayAndMonth$.pipe(takeUntil(this.destroy$)).subscribe(result => {
            this.planOnDayForSale = Math.round(result.plannedSalesSum / this.daysInMonth);
            this.progresSalesDay = Math.round((result.sumSalesByToday18_Yesterday18 * 100) / this.planOnDayForSale);
            this.progresSalesMonth1 = Math.round((result.sumSalesByMonth * 100) / result.plannedSalesSum);
            this.factToday = this.planOnDayForSale * (new Date().getDate()) - result.sumSalesByMonth;

            if (this.factToday < 0) {
                this.isPositive = true;
            } else {
                this.isPositive = false;
            }

            this.factToday = (this.factToday < 0 ? this.factToday * (-1) : this.factToday)
            this.progresSalesMonth2 = Math.round(this.factToday * 100 / result.plannedSalesSum);
            this.progresSalesMonth2ForShow = (this.isPositive ? this.progresSalesMonth2 : this.progresSalesMonth2 * (-1));
            this.progresSalesMonth3 = 100 - this.progresSalesMonth1 - this.progresSalesMonth2;
            this.remainingDays = this.daysInMonth - (new Date().getDate());
        });
    }

    ngOnDestroy() {
        this.destroy$.next(true);
        this.destroy$.unsubscribe();
    }

    public goToShowTooltip(): boolean {
        return this.showTooltip;
    }

    public chengeShowToolTip(): void {
        this.showTooltip = !this.showTooltip;
    }

    private CountDayOnMonth(): number {
        let year = new Date().getFullYear();
        let month = new Date().getMonth();
        return 33 - new Date(year, month, 33).getDate();
    }
}
