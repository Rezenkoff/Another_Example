import { Component, OnInit, OnDestroy } from '@angular/core';

import { timer, Subscription, Observable } from 'rxjs';
import { Store } from '@ngrx/store';

import * as fromDashboardStore from '../reducers';
import * as actions from '../actions/dashboard.actions';

import { NgxUiLoaderService } from 'ngx-ui-loader';
import { DashboardSignalrService } from '../services/dashboard-signalr.service';

import { SessionCountModel } from '../models/session-count.model';
import { DealsModel } from '../models/deals-model';

@Component({
    selector: 'dashboard',
    templateUrl: './dashboard.component.html',
    styles: []
})

export class DashboardComponent implements OnInit, OnDestroy {

    public _sessionCount$: Observable<SessionCountModel>;
    public _dealsModel$: Observable<DealsModel>;
    private showTooltip: boolean = false;
    public loading: boolean = false;
    private pointerTimer: Subscription = new Subscription();

    constructor(
        private _ngxLoader: NgxUiLoaderService,
        private _dashboardSignarService: DashboardSignalrService,
        private _store: Store<fromDashboardStore.State>,
    ) { }

    ngOnInit() {
        this.startTimer();

        this._sessionCount$ = this._store.select(fromDashboardStore.getDashboardVisits);
        this._dealsModel$ = this._store.select(fromDashboardStore.getDashboardDeals);

        this._dashboardSignarService.startListening();
        this.initializeLoaders();
    }

    ngOnDestroy() {
        this.pointerTimer.unsubscribe();
        this._dashboardSignarService.stopListen();
    }

    public getRoundPersents(persents) {
        return Math.round(persents);
    }

    public goToShowTooltip(): boolean {
        return this.showTooltip;
    }

    public chengeShowToolTip(): void {
        this.showTooltip = !this.showTooltip;
    }


    private startTimer(): void {
        const source = timer(0, 300000);
        this.pointerTimer = source.subscribe(() => {
            this._store.dispatch(new actions.GetVisits());
            this._store.dispatch(new actions.GetDeals());
            this._store.dispatch(new actions.GetSales());
            this._store.dispatch(new actions.GetConversion());
            this._store.dispatch(new actions.GetLostCallRate());
            this._store.dispatch(new actions.GetReturnedMonth());
        });
    }

    private initializeLoaders() {
        this._ngxLoader.initLoaderData;
        this._ngxLoader.startLoader('visits-by-day');
        this._ngxLoader.startLoader('visits-by-month');
    }
}
