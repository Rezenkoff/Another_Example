"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var common_1 = require("@angular/common");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/common/http");
var app_http_interceptor_1 = require("../app.http.interceptor");
var settings_component_1 = require("./components/settings.component");
var settings_service_1 = require("./services/settings.service");
var sales_target_popup_component_1 = require("./components/sales-target-popup/sales-target-popup.component");
var dropdown_component_1 = require("./components/dropdown/dropdown.component");
var sales_targets_list_component_1 = require("./components/sales-targets-list/sales-targets-list.component");
var SettingsModule = /** @class */ (function () {
    function SettingsModule() {
    }
    SettingsModule = __decorate([
        core_1.NgModule({
            declarations: [
                settings_component_1.SettingsComponent,
                sales_target_popup_component_1.SalesTargetPopupComponent,
                dropdown_component_1.DropdownComponent,
                sales_targets_list_component_1.SalesTargetsListComponent,
            ],
            imports: [
                http_1.HttpClientModule,
                forms_1.FormsModule,
                common_1.CommonModule,
                router_1.RouterModule.forChild([
                    { path: '', component: settings_component_1.SettingsComponent },
                ]),
            ],
            providers: [
                settings_service_1.SettingsService,
                {
                    provide: http_1.HTTP_INTERCEPTORS,
                    useClass: app_http_interceptor_1.AppHttpInterceptor,
                    multi: true
                }
            ],
        })
    ], SettingsModule);
    return SettingsModule;
}());
exports.SettingsModule = SettingsModule;
//# sourceMappingURL=settings.module.js.map