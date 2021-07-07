import { Component, OnInit, OnDestroy } from '@angular/core';

import { Observable, Subject } from 'rxjs';
import { Store } from '@ngrx/store';
import { takeUntil } from "rxjs/operators";

import * as fromDashboardStore from '../../reducers';
import { ReturnedMonthModel } from '../../models/returned-month';
import { DashboardService } from '../../services/dashboard.service';



@Component({
    selector: 'returned-product',
    templateUrl: './returned-product.component.html',
    styles: []
})

export class ReturnedProduct implements OnInit, OnDestroy {
    

    public returnedMonth$: Observable<ReturnedMonthModel>;
    private destroy$: Subject<boolean> = new Subject<boolean>();

    constructor(
        private _store: Store<fromDashboardStore.State>,
        private _dashboardService: DashboardService
    ) { }

    ngOnInit() {
        this.returnedMonth$ = this._store.select(fromDashboardStore.getDashboardReturnedMonth);

        //this.returnedMonth$ = this._dashboardService.getReturnedMonth();

        this.returnedMonth$.pipe(takeUntil(this.destroy$)).subscribe(item => {
            if (item.autoReturned != undefined) {
                console.log(item);
            }
        });
    }

    ngOnDestroy() {
        this.destroy$.next(true);
        this.destroy$.unsubscribe();
    }

    public getReturnedVD(returnedVD: any): number {
        if (returnedVD == null || returnedVD.vdSuccess == undefined) {
            return 0;
        }

        return this.roundValue((returnedVD.vdReturned / returnedVD.vdSuccess) * 100, 2);
    }

    public getReturned(returnedMonth: any): number {
        if (returnedMonth == null || returnedMonth.orderSuccess == undefined) {
            return 0;
        }

        return this.roundValue((returnedMonth.orderReturned / returnedMonth.orderSuccess) * 100, 2);
    }

    public getAutoReturned(returnedMonth: any): number {
        if (returnedMonth == null || returnedMonth.autoReturned_RetPartRet == undefined || returnedMonth.autoReturned_RetPartRet === 0) {
            return 0;
        }

        return this.roundValue((returnedMonth.autoReturned / returnedMonth.autoReturned_RetPartRet) * 100, 2);
    }


    private roundValue(x: number, n: number) {   
        var m = Math.pow(10, n);    
        return Math.round(x * m) / m;  
    }

}
