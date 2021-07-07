import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { SessionCountModel } from "../models/session-count.model";
import { map } from "rxjs/operators";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { DealsModel } from "../models/deals-model";
import { SalesByDayAndMonthModel } from "../models/sales-by-day.model";
import { ConversionModel } from "../models/lead-conversion.model";
import { SuccessfullDealsModel } from "../models/succesful-deals.model";
import { LostCallRateModel } from "../models/lost-call-rate.model";
import { ReturnedMonthModel } from "../models/returned-month";

const API_URL = environment.api_url;

@Injectable()
export class DashboardService {

    constructor(private _http: HttpClient) { }

    public getSessionCount(): Observable<SessionCountModel> {
        return this._http.get(API_URL + 'api/dashboard/get-visits').pipe(map((data: SessionCountModel) => {
            return data;
        }));
    }

    public getDeals(): Observable<DealsModel> {
        return this._http.get(API_URL + 'api/dashboard/get-deals').pipe(map((data: DealsModel) => {
            return data;
        }));
    }

    public getSalesByDayAndMonth(): Observable<SalesByDayAndMonthModel> {
        return this._http.get(API_URL + 'api/dashboard/get-sales-byday').pipe(map((data: SalesByDayAndMonthModel) => {
            return data;
        }));
    }

    public getConversion(): Observable<ConversionModel> {
        return this._http.get(API_URL + 'api/dashboard/get-conversion').pipe(map((data: ConversionModel) => {
            return data;
        }));
    }

    public getSuccessfullDeals(): Observable<SuccessfullDealsModel> {
        return this._http.get(API_URL + 'api/dashboard/get-succesful-deals').pipe(map((data: SuccessfullDealsModel) => {
            return data;           
        }));
    }

    public getLostCallRate(): Observable<LostCallRateModel> {
        return this._http.get(API_URL + 'api/dashboard/lost-call-rate').pipe(map((data: LostCallRateModel) => {
            return data;
        }));
    }

    public getReturnedMonth(): Observable<ReturnedMonthModel> {
        return this._http.get(API_URL + 'api/dashboard/get-returnedmonth').pipe(map((data: ReturnedMonthModel) => {
            return data;
        }));
    }
}
