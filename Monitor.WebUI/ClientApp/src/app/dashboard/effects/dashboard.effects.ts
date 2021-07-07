import { Injectable } from "@angular/core";

import { Actions, Effect } from "@ngrx/effects";
import { Action } from '@ngrx/store';
import { Observable } from "rxjs";
import { switchMap } from "rxjs/operators";

import { DashboardService } from "../services/dashboard.service";

import * as dashboardActions from '../actions/dashboard.actions';

import { SessionCountModel } from "../models/session-count.model";
import { DealsModel } from "../models/deals-model";
import { SalesByDayAndMonthModel } from "../models/sales-by-day.model";
import { ConversionModel } from "../models/lead-conversion.model";
import { SuccessfullDealsModel } from "../models/succesful-deals.model";
import { LostCallRateModel } from "../models/lost-call-rate.model";
import { ReturnedMonthModel } from "../models/returned-month";


@Injectable()
export class DashboardEffects {

    @Effect()
    getVisits$: Observable<Action> = this.actions$.ofType(dashboardActions.GET_VISITS).pipe(
        switchMap((action: dashboardActions.GetVisits) => {
            return this._dashboardService.getSessionCount().pipe(
                switchMap((result: SessionCountModel) => [
                    new dashboardActions.SetVisits({ visits: result })
                ])
            )
        })
    );

    @Effect()
    getDeals$: Observable<Action> = this.actions$.ofType(dashboardActions.GET_DEALS).pipe(
        switchMap((action: dashboardActions.GetDeals) => {
            return this._dashboardService.getDeals().pipe(
                switchMap((result: DealsModel) => [
                    new dashboardActions.SetDeals({ deals: result })
                ])
            )
        })
    );

    @Effect()
    getSales$: Observable<Action> = this.actions$.ofType(dashboardActions.GET_SALES).pipe(
        switchMap((action: dashboardActions.GetSales) => {
            return this._dashboardService.getSalesByDayAndMonth().pipe(
                switchMap((result: SalesByDayAndMonthModel) => [
                    new dashboardActions.SetSales({ sales: result })
                ])
            )
        })
    );

    @Effect()
    getConversion$: Observable<Action> = this.actions$.ofType(dashboardActions.GET_CONVERSION).pipe(
        switchMap((action: dashboardActions.GetConversion) => {
            return this._dashboardService.getConversion().pipe(
                switchMap((result: ConversionModel) => [
                    new dashboardActions.SetConversion({ conversion: result })
                ])
            )
        })
    );

    @Effect()
    getSuccessfullDeals$: Observable<Action> = this.actions$.ofType(dashboardActions.GET_SUCCESSFULLDEALS).pipe(
        switchMap((action: dashboardActions.GetSuccessfullDeals) => {
            return this._dashboardService.getSuccessfullDeals().pipe(
                switchMap((result: SuccessfullDealsModel) => [
                    new dashboardActions.SetSuccessfullDeals({ successfulldeals: result })
                ])
            )
        })
    );

    @Effect()
    getLostCallRate$: Observable<Action> = this.actions$.ofType(dashboardActions.GET_LOSTCALLRATE).pipe(
        switchMap((action: dashboardActions.GetLostCallRate) => {
            return this._dashboardService.getLostCallRate().pipe(
                switchMap((result: LostCallRateModel) => [
                    new dashboardActions.SetLostCallRate({ lostCallRate: result })
                ])
            )
        })
    );

    @Effect()
    getReturnedMonth$: Observable<Action> = this.actions$.ofType(dashboardActions.GET_RETURNEDMONTH).pipe(
        switchMap((action: dashboardActions.GetReturnedMonth) => {
            return this._dashboardService.getReturnedMonth().pipe(
                switchMap((result: ReturnedMonthModel) => [
                    new dashboardActions.SetReturnedMonth({ returnedmonth: result })
                ])
            )
        })
    );

    constructor(private actions$: Actions, private _dashboardService: DashboardService) { }
}
