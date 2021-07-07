"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var rxjs_1 = require("rxjs");
var fromDashboardStore = require("../../reducers");
var operators_1 = require("rxjs/operators");
var AverageCheckComponent = /** @class */ (function () {
    function AverageCheckComponent(_store) {
        this._store = _store;
        this.destroy$ = new rxjs_1.Subject();
    }
    AverageCheckComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._salesByDayAndMonth$ = this._store.select(fromDashboardStore.getDashboardSales);
        this._salesByDayAndMonth$.pipe(operators_1.takeUntil(this.destroy$)).subscribe(function (result) {
            _this.averageCheckByDay = (result.sumSalesByToday18_Yesterday18 / result.countSalesByToday18_Yesterday18).toFixed(2);
            _this.averageCheckByMonth = (result.sumSalesByMonth / result.countSalesByMonth).toFixed(2);
        });
    };
    AverageCheckComponent.prototype.ngOnDestroy = function () {
        this.destroy$.next(true);
        this.destroy$.unsubscribe();
    };
    AverageCheckComponent = __decorate([
        core_1.Component({
            selector: 'average-check',
            templateUrl: './average-check.component.html',
            styles: []
        })
    ], AverageCheckComponent);
    return AverageCheckComponent;
}());
exports.AverageCheckComponent = AverageCheckComponent;
//# sourceMappingURL=average-check.component.js.map