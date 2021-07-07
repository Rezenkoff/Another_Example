"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var dashboard_component_1 = require("./components/dashboard.component");
var router_1 = require("@angular/router");
var dashboard_service_1 = require("./services/dashboard.service");
var common_1 = require("@angular/common");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/common/http");
var app_http_interceptor_1 = require("../app.http.interceptor");
var DashboardModule = /** @class */ (function () {
    function DashboardModule() {
    }
    DashboardModule = __decorate([
        core_1.NgModule({
            declarations: [
                dashboard_component_1.DashboardComponent
            ],
            imports: [
                http_1.HttpClientModule,
                forms_1.FormsModule,
                common_1.CommonModule,
                router_1.RouterModule.forChild([
                    { path: '', component: dashboard_component_1.DashboardComponent },
                    { path: 'dashboard', component: dashboard_component_1.DashboardComponent },
                    { path: '**', redirectTo: '' },
                ]),
            ],
            providers: [
                dashboard_service_1.DashboardService,
                {
                    provide: http_1.HTTP_INTERCEPTORS,
                    useClass: app_http_interceptor_1.AppHttpInterceptor,
                    multi: true
                }
            ],
        })
    ], DashboardModule);
    return DashboardModule;
}());
exports.DashboardModule = DashboardModule;
//# sourceMappingURL=dashboard.module.js.map