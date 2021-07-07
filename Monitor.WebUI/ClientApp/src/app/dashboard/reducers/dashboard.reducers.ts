import * as dashboard from "../actions/dashboard.actions";

import { SessionCountModel } from "../models/session-count.model";
import { DealsModel } from "../models/deals-model";
import { SalesByDayAndMonthModel } from "../models/sales-by-day.model";
import { ConversionModel } from "../models/lead-conversion.model";
import { SuccessfullDealsModel } from "../models/succesful-deals.model";
import { LostCallRateModel } from "../models/lost-call-rate.model";
import { ReturnedMonthModel } from "../models/returned-month";

export interface State {
    visits: SessionCountModel,
    deals: DealsModel,
    sales: SalesByDayAndMonthModel,
    conversion: ConversionModel,
    successfulldeals: SuccessfullDealsModel,
    lostCallRate: LostCallRateModel,
    returnedmonth: ReturnedMonthModel
}

const initialState: State = {
    visits: new SessionCountModel(),
    deals: new DealsModel(),
    sales: new SalesByDayAndMonthModel(),
    conversion: new ConversionModel(),
    successfulldeals: new SuccessfullDealsModel(),
    lostCallRate: new LostCallRateModel(),
    returnedmonth: new ReturnedMonthModel()
}

export function dashboardReducer(state = initialState, action: dashboard.Actions): State {

    switch (action.type) {

        //VISITS
        case dashboard.GET_VISITS: {
            state.visits.loading = true;
            return { ...state };
        }

        case dashboard.SET_VISITS: {
            const visitsModel = action.payload.visits;
            return {
                ...state,
                visits: new SessionCountModel(visitsModel.sessionByDay, visitsModel.sessionByMonth, visitsModel.sessionByDayWeekAgo)
            }
        }

        //DEALS
        case dashboard.SET_DEALS: {
            const deals = action.payload.deals;
            return {
                ...state,
                deals: deals
            }
        }

        //SALES
        case dashboard.SET_SALES: {
            const sales = action.payload.sales;
            return {
                ...state,
                sales: sales
            }
        }

        //CONVERSION
        case dashboard.SET_CONVERSION: {
            const conversion = action.payload.conversion;
            return {
                ...state,
                conversion: conversion
            }
        }

        //SUCCESSFULLDEALS
        case dashboard.SET_SUCCESSFULLDEALS: {
            const successfulldeals = action.payload.successfulldeals;
            return {
                ...state,
                successfulldeals: successfulldeals
            }
        }

        //LOST CALL RATE 
        case dashboard.SET_LOSTCALLRATE: {
            const lostCallRate = action.payload.lostCallRate;
            return {
                ...state,
                lostCallRate: lostCallRate
            }
        }

        //RETURNEDMONTH
        case dashboard.SET_RETURNEDMONTH: {
            const returnedmonth = action.payload.returnedmonth;
            return {
                ...state,
                returnedmonth: returnedmonth
            }
        }

        default: {
            return state;
        }
    }
}

export const getVisits = (state: State) => state.visits;
export const getDeals = (state: State) => state.deals;
export const getSales = (state: State) => state.sales;
export const getConversion = (state: State) => state.conversion;
export const getSuccessfullDeals = (state: State) => state.successfulldeals;
export const getLostCallRate = (state: State) => state.lostCallRate;
export const getReturnedMonth = (state: State) => state.returnedmonth;
