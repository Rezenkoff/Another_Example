import { Component, OnInit, OnDestroy, ChangeDetectorRef } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import * as fromDashboardStore from '../../reducers';
import { async } from 'rxjs/internal/scheduler/async';
import { DashboardService } from '../../services/dashboard.service';
import { SuccessfullDealsModel } from '../../models/succesful-deals.model';
import { ManagerDeals } from '../../models/succesful-deals.model';


@Component({
    selector: 'successful-deals',
    templateUrl: './successful-deals.component.html',
    styles: []
})

export class SuccessfullDeals implements OnInit {

    public isDay: boolean = true;
    public successfullDeals: SuccessfullDealsModel = new SuccessfullDealsModel();
    public progressManagerDay: Array<number> = [];
    public progressManagerMonth: Array<number> = [];

    constructor(
        private _dashboardService: DashboardService,
        private _detector: ChangeDetectorRef
    ) { }

    ngOnInit() {
        this._dashboardService.getSuccessfullDeals().subscribe(result => {
            this.successfullDeals = result;
            this.successfullDeals.managerList.forEach(m => {
                this.progressManagerDay.push(Math.round(m.successfullDealsDay * 100 / m.allDealsDay));
                this.progressManagerMonth.push(Math.round(m.successfullDealsMonth * 100 / m.allDealsMonth));
            });
            this._detector.detectChanges();
        });
    }

    public toogleTime(): void {
        this.isDay = !this.isDay;
    }

    public getStyle(time: string): string {
        if (time == 'day' && this.isDay || time == 'month' && !this.isDay) {
            return 'toogle-button';
        } else {
            return 'toogle-button button-off';
        }
    }
}



