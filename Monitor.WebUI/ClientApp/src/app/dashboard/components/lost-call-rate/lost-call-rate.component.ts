import { Component, OnInit, OnDestroy } from "@angular/core";
import { Store } from "@ngrx/store";
import * as fromDashboardStore from '../../reducers';
import { Observable, Subject } from "rxjs";
import { LostCallRateModel } from "../../models/lost-call-rate.model";
import { takeUntil } from "rxjs/operators";


@Component({
    selector: 'lost-call-rate',
    templateUrl: './lost-call-rate.component.html',
    styles: []
})
export class LostCallRateComponent implements OnInit, OnDestroy {

    public lostCallRate$: Observable<LostCallRateModel>;
    public isShowTooltip: boolean = false;
    private destroy$: Subject<boolean> = new Subject<boolean>();

    constructor(private _store: Store<fromDashboardStore.State>) {

    }

    ngOnInit() {
        this.lostCallRate$ = this._store.select(fromDashboardStore.getDashboardLostCallRate);
        this.lostCallRate$.pipe(takeUntil(this.destroy$)).subscribe(result => {
        });
    }

    ngOnDestroy() {
        this.destroy$.next(true);
        this.destroy$.unsubscribe();
    }

    public changeTooltipShowing() {
        this.isShowTooltip = !this.isShowTooltip;
    }
}
