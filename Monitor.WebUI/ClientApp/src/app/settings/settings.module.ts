import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { AppHttpInterceptor } from "../app.http.interceptor";
import { SettingsComponent } from "./components/settings.component";
import { SettingsService } from "./services/settings.service";
import { SalesTargetPopupComponent } from "./components/sales-target-popup/sales-target-popup.component";
import { DropdownComponent } from "./components/dropdown/dropdown.component";
import { SalesTargetsListComponent } from "./components/sales-targets-list/sales-targets-list.component";

@NgModule({
    declarations: [
        SettingsComponent,
        SalesTargetPopupComponent,
        DropdownComponent,
        SalesTargetsListComponent,
    ],
    imports: [
        HttpClientModule,
        FormsModule,
        CommonModule,
        RouterModule.forChild([
            { path: '', component: SettingsComponent },
        ]),
    ],
    providers: [
        SettingsService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: AppHttpInterceptor,
            multi: true
        }
    ],
})
export class SettingsModule { }
