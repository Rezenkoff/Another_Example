import { Action } from '@ngrx/store';
import { SessionCountModel } from '../models/session-count.model';
import { DealsModel } from '../models/deals-model';
import { SalesByDayAndMonthModel } from "../models/sales-by-day.model";
import { ConversionModel } from '../models/lead-conversion.model';
import { SuccessfullDealsModel } from '../models/succesful-deals.model';
import { LostCallRateModel } from '../models/lost-call-rate.model';
import { ReturnedMonthModel } from '../models/returned-month';

//VISITS
export const GET_VISITS = '[Dashboard] Get visits';
export const SET_VISITS = '[Dashboard] Set visits';
//DEALS
export const GET_DEALS = '[Dashboard] Get deals';
export const SET_DEALS = '[Dashboard] Set deals';
//SALES
export const GET_SALES = '[Dashboard] Get sales';
export const SET_SALES = '[Dashboard] Set sales';
//CONVERSION
export const GET_CONVERSION = '[Dashboard] Get conversion';
export const SET_CONVERSION = '[Dashboard] Set conversion';
//SUCCESSFULLDEALS
export const GET_SUCCESSFULLDEALS = '[Dashboard] Get successfulldeals';
export const SET_SUCCESSFULLDEALS = '[Dashboard] Set successfulldeals';
//LOST CALL RATE
export const GET_LOSTCALLRATE = '[Dashboard] Get lostcallrate';
export const SET_LOSTCALLRATE = '[Dashboard] Set lostcallrate';
//RETURNEDMONTH
export const GET_RETURNEDMONTH = '[Dashboard] Get returnedmonth';
export const SET_RETURNEDMONTH = '[Dashboard] Set returnedmonth';

export class GetVisits implements Action { //VISITS
    readonly type = GET_VISITS;

    constructor() { }
}

export class SetVisits implements Action { //VISITS
    readonly type = SET_VISITS;

    constructor(public payload: { visits: SessionCountModel }) { }
}

export class GetDeals implements Action { //DEALS
    readonly type = GET_DEALS;

    constructor() { }
}

export class SetDeals implements Action { //DEALS
    readonly type = SET_DEALS;

    constructor(public payload: { deals: DealsModel }) { }
}

export class GetSales implements Action { //SALES
    readonly type = GET_SALES;

    constructor() { }
}

export class SetSales implements Action { //SALES
    readonly type = SET_SALES;

    constructor(public payload: { sales: SalesByDayAndMonthModel }) { }
}

export class GetConversion implements Action { //CONVERSION
    readonly type = GET_CONVERSION;

    constructor() { }
}

export class SetConversion implements Action { //CONVERSION
    readonly type = SET_CONVERSION;

    constructor(public payload: { conversion: ConversionModel }) { }
}

export class GetSuccessfullDeals implements Action { //SUCCESSFULLDEALS
    readonly type = GET_SUCCESSFULLDEALS;

    constructor() { }
}

export class SetSuccessfullDeals implements Action { //SUCCESSFULLDEALS
    readonly type = SET_SUCCESSFULLDEALS;

    constructor(public payload: { successfulldeals: SuccessfullDealsModel }) { }
}

export class GetLostCallRate implements Action { //LOST CALL RATE
    readonly type = GET_LOSTCALLRATE;

    constructor() { }
}

export class SetLostCallRate implements Action { //LOST CALL RATE
    readonly type = SET_LOSTCALLRATE;

    constructor(public payload: { lostCallRate: LostCallRateModel }) { }
}

export class GetReturnedMonth implements Action { //RETURNEDMONTH
    readonly type = GET_RETURNEDMONTH;

    constructor() { }
}

export class SetReturnedMonth implements Action { //RETURNEDMONTH
    readonly type = SET_RETURNEDMONTH;

    constructor(public payload: { returnedmonth: ReturnedMonthModel }) { }
}

export type Actions =
    GetVisits
    | SetVisits
    | GetDeals
    | SetDeals
    | GetSales
    | SetSales
    | GetConversion
    | SetConversion
    | GetSuccessfullDeals
    | SetSuccessfullDeals
    | GetLostCallRate
    | SetLostCallRate
    | GetReturnedMonth
    | SetReturnedMonth
    ;
