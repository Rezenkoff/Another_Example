import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';

import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

import { environment } from '../../../environments/environment';

import { ToastrService } from 'ngx-toastr';

import * as fromDashboardStore from '../reducers';
import * as actions from '../actions/dashboard.actions';

import { OnCrmNewDealModel } from '../models/on-crm-new-deal.model';


const API_URL = environment.api_url;

@Injectable({
    providedIn: 'root',
})
export class DashboardSignalrService {

    private hubConnection: HubConnection;

    constructor(private toastr: ToastrService, private _store: Store<fromDashboardStore.State>,) { }

    public startListening(): void {
        if (this.hubConnection) {
            return;
        }

        this.hubConnection = new HubConnectionBuilder()
            .withUrl(API_URL + 'notify')
            .build();

        this.hubConnection.on("DashboardNotify", (data: OnCrmNewDealModel) => {
            this.toastr.info('Создан заказ на сумму ' + data.orderSum);
            this._store.dispatch(new actions.GetDeals());
            this._store.dispatch(new actions.GetSales());
        });

        this.hubConnection
            .start()
            .then(() => { console.log('Connection started!') })
            .catch(err => console.log('Error while establishing connection'));
    }

    public stopListen(): void {
        if (this.hubConnection) {
            this.hubConnection.stop();
        }
    }
}
