import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { reducers } from './redux-store';
import { CookieService } from 'ngx-cookie-service';
import { AuthenticationService } from './shared/services/authentication.service';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

const appRoutes: Routes = [
    { path: 'monitor/:environment', loadChildren: './monitor/monitor.module#MonitorModule' },
    { path: 'dashboard', loadChildren: './dashboard/dashboard.module#DashboardModule' },
    { path: 'login', loadChildren: './login/login.module#LoginModule' },
    { path: 'settings', loadChildren: './settings/settings.module#SettingsModule' }
]

@NgModule({
    declarations: [
        AppComponent,
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot(appRoutes, {
            useHash: false
        }),
        StoreModule.forRoot(reducers),
        EffectsModule.forRoot([]),
        BrowserAnimationsModule,
        ToastrModule.forRoot({
            timeOut: 3000,
            positionClass: 'toast-bottom-right',
            preventDuplicates: false,
            closeButton: true,
            progressBar: true,
            autoDismiss: true
        }),
    ],
    providers: [CookieService, AuthenticationService],
    bootstrap: [AppComponent]
})
export class AppModule { }
