import { NgModule } from "@angular/core";
import { DashboardComponent } from "./components/dashboard.component";
import { RouterModule } from "@angular/router";
import { DashboardService } from "./services/dashboard.service";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { AppHttpInterceptor } from "../app.http.interceptor";
import { NgxUiLoaderModule } from 'ngx-ui-loader';
import { SalesDayMonth } from "./components/sales-day-month/sales-day-month.component";
import { LeadConversion } from "./components/lead-conversion/lead-conversion.component";
import { SuccessfullDeals } from "./components/successful-deals/successful-deals.component";
import { DashboardSignalrService } from "./services/dashboard-signalr.service";
import { DashboardEffects } from "./effects/dashboard.effects";
import { EffectsModule } from "@ngrx/effects";
import { StoreModule } from "@ngrx/store";
import { dashboardReducer } from "./reducers";
import { LostCallRateComponent } from "./components/lost-call-rate/lost-call-rate.component";
import { AverageCheckComponent } from "./components/average-check/average-check.component";
import { ReturnedProduct } from "./components/returned_product/returned-product.component";

@NgModule({
    declarations: [
        DashboardComponent,
        SalesDayMonth,
        LeadConversion,
        SuccessfullDeals,
        LostCallRateComponent,
        AverageCheckComponent,
        ReturnedProduct
    ],
    imports: [
        HttpClientModule,
        FormsModule,
        NgxUiLoaderModule,
        CommonModule,
        RouterModule.forChild([
            { path: '', component: DashboardComponent },
            { path: 'dashboard', component: DashboardComponent },
            { path: '**', redirectTo: '' },
        ]),
        StoreModule.forFeature('dashboard', dashboardReducer),
        EffectsModule.forFeature([DashboardEffects]),
    ],
    providers: [
        DashboardSignalrService,
        DashboardService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: AppHttpInterceptor,
            multi: true
        }],
})
export class DashboardModule { }
