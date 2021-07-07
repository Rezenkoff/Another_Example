"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var session_count_model_1 = require("../models/session-count.model");
var deals_model_1 = require("../models/deals-model");
var rxjs_1 = require("rxjs");
var DashboardComponent = /** @class */ (function () {
    function DashboardComponent(_dashboardService, _detector, ngxLoader) {
        this._dashboardService = _dashboardService;
        this._detector = _detector;
        this.ngxLoader = ngxLoader;
        this._sessionCount = new session_count_model_1.SessionCountModel();
        this._dealsModel = new deals_model_1.DealsModel();
        this.showTooltip = false;
        this.loading = false;
        this.pointerTimer = new rxjs_1.Subscription();
    }
    DashboardComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.startTimer();
        this._dashboardService.getDeals().subscribe(function (result) {
            _this._dealsModel = result;
            _this._detector.detectChanges();
        });
    };
    DashboardComponent.prototype.getDashboardService = function () {
        var _this = this;
        this.ngxLoader.initLoaderData;
        this.ngxLoader.startLoader('loader-01');
        this.ngxLoader.startLoader('loader-02');
        this._dashboardService.getSessionCount().subscribe(function (result) {
            _this._sessionCount = result;
            _this._sessionCount.sessionRatio = Math.round((result.sessionByDay / result.maxSessionCount10Day) * 100);
            _this._detector.detectChanges();
            _this.ngxLoader.stopLoader('loader-01');
            _this.ngxLoader.stopLoader('loader-02');
        });
    };
    DashboardComponent.prototype.ngOnDestroy = function () {
        this.pointerTimer.unsubscribe();
    };
    DashboardComponent.prototype.startTimer = function () {
        var _this = this;
        var source = rxjs_1.timer(0, 600300);
        this.pointerTimer = source.subscribe(function () {
            _this.getDashboardService();
        });
    };
    DashboardComponent.prototype.getRoundPersents = function (persents) {
        return Math.round(persents);
    };
    DashboardComponent.prototype.goToShowTooltip = function () {
        return this.showTooltip;
    };
    DashboardComponent.prototype.chengeShowToolTip = function () {
        this.showTooltip = !this.showTooltip;
    };
    DashboardComponent = __decorate([
        core_1.Component({
            selector: 'dashboard',
            templateUrl: './dashboard.component.html',
            styles: []
        })
    ], DashboardComponent);
    return DashboardComponent;
}());
exports.DashboardComponent = DashboardComponent;
//# sourceMappingURL=dashboard.component.js.map