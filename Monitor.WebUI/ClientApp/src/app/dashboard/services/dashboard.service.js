"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var operators_1 = require("rxjs/operators");
var environment_1 = require("../../../environments/environment");
var API_URL = environment_1.environment.api_url;
var DashboardService = /** @class */ (function () {
    function DashboardService(_http) {
        this._http = _http;
    }
    DashboardService.prototype.getSessionCount = function () {
        return this._http.get(API_URL + 'api/dashboard/get-visits').pipe(operators_1.map(function (data) {
            return data;
        }));
    };
    DashboardService.prototype.getDeals = function () {
        return this._http.get(API_URL + 'api/dashboard/get-deals').pipe(operators_1.map(function (data) {
            return data;
        }));
    };
    DashboardService = __decorate([
        core_1.Injectable()
    ], DashboardService);
    return DashboardService;
}());
exports.DashboardService = DashboardService;
//# sourceMappingURL=dashboard.service.js.map