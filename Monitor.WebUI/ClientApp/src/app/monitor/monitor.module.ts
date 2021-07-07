import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ChecksListComponent } from './components/checks-list.component';
import { CheckComponent } from './components/check.component';
import { MonitorEffects } from './effects/monitor.effects';
import { monitorReducer } from './reducers';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { CheckTooltipComponent } from './components/check-tooltip/check-tooltip.component';
import { AppHttpInterceptor } from '../app.http.interceptor';
import { MonitorService } from './services/monitor.service';

@NgModule({
    declarations: [
        ChecksListComponent,
        CheckComponent,
        CheckTooltipComponent,
    ],
    imports: [
        HttpClientModule,
        FormsModule,
        CommonModule,
        RouterModule.forChild([
            { path: 'checks', component: ChecksListComponent },
        ]),
        StoreModule.forFeature('monitor', monitorReducer),
        EffectsModule.forFeature([MonitorEffects]),
    ],
    providers: [
        MonitorService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: AppHttpInterceptor,
            multi: true
        },
    ]
})
export class MonitorModule { }
