"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/common/http");
var forms_1 = require("@angular/forms");
var common_1 = require("@angular/common");
var router_1 = require("@angular/router");
var login_service_1 = require("./services/login.service");
var login_component_1 = require("./components/login.component");
var LoginModule = /** @class */ (function () {
    function LoginModule() {
    }
    LoginModule = __decorate([
        core_1.NgModule({
            declarations: [
                login_component_1.LoginComponent,
            ],
            imports: [
                http_1.HttpClientModule,
                forms_1.FormsModule,
                common_1.CommonModule,
                router_1.RouterModule.forChild([
                    { path: '', component: login_component_1.LoginComponent },
                    { path: 'login', component: login_component_1.LoginComponent },
                    { path: '**', redirectTo: '' },
                ]),
            ],
            providers: [login_service_1.LoginService],
        })
    ], LoginModule);
    return LoginModule;
}());
exports.LoginModule = LoginModule;
//# sourceMappingURL=login.module.js.map