import { createSelector, createFeatureSelector } from '@ngrx/store';

import * as fromDashboard from './dashboard.reducers';
import * as fromRoot from '../../redux-store/';

export interface DashboardState {
    dashboard: fromDashboard.State;
}

export interface State extends fromRoot.State {
    'dashboard': DashboardState;
}

export const dashboardReducer = {
    dashboard: fromDashboard.dashboardReducer
};

export const getDashboardMainState = createFeatureSelector<DashboardState>('dashboard');
export const getDashboardState = createSelector(getDashboardMainState, (state: DashboardState) => state.dashboard);

export const getDashboardVisits = createSelector(getDashboardState, fromDashboard.getVisits);
export const getDashboardDeals = createSelector(getDashboardState, fromDashboard.getDeals);
export const getDashboardSales = createSelector(getDashboardState, fromDashboard.getSales);
export const getDashboardConversion = createSelector(getDashboardState, fromDashboard.getConversion);
export const getDashboardSuccessfullDeals = createSelector(getDashboardState, fromDashboard.getSuccessfullDeals);
export const getDashboardLostCallRate = createSelector(getDashboardState, fromDashboard.getLostCallRate);
export const getDashboardReturnedMonth = createSelector(getDashboardState, fromDashboard.getReturnedMonth);
