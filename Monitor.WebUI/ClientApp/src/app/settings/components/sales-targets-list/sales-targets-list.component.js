"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var sales_target_model_1 = require("../../sales-target.model");
var rxjs_1 = require("rxjs");
var SalesTargetsListComponent = /** @class */ (function () {
    function SalesTargetsListComponent(_settingsService) {
        this._settingsService = _settingsService;
        this.salesTargetPopupEnabled$ = new rxjs_1.BehaviorSubject(false);
        this.salesTargets$ = new rxjs_1.BehaviorSubject([]);
        this.selectedModel = new sales_target_model_1.SalesTargetModel();
        this.popupMode = "add";
    }
    SalesTargetsListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._settingsService.getSalesTargets().subscribe(function (targets) { return _this.salesTargets$.next(targets); });
        var date = new Date();
        this._year = date.getFullYear();
        this._month = date.getMonth() + 1;
    };
    SalesTargetsListComponent.prototype.openSalesTargetPopup = function () {
        this.salesTargetPopupEnabled$.next(true);
    };
    SalesTargetsListComponent.prototype.addSalesTargetModel = function () {
        this.popupMode = "add";
        this.selectedModel = new sales_target_model_1.SalesTargetModel();
        this.openSalesTargetPopup();
    };
    SalesTargetsListComponent.prototype.editSalesTargetModel = function (model) {
        this.popupMode = "edit";
        this.selectedModel = model;
        this.openSalesTargetPopup();
    };
    SalesTargetsListComponent.prototype.closeSalesTargetPopup = function () {
        this.selectedModel = new sales_target_model_1.SalesTargetModel();
        this.salesTargetPopupEnabled$.next(false);
    };
    SalesTargetsListComponent.prototype.saveSalesTarget = function (model) {
        var _this = this;
        this._settingsService.saveSalesTarget(model).subscribe(function (result) {
            if (result) {
                _this._settingsService.getSalesTargets().subscribe(function (targets) { return _this.salesTargets$.next(targets); });
            }
            var message = (result) ? "Изменения сохранены" : "Ошибка при сохранении";
            alert(message);
        });
    };
    SalesTargetsListComponent.prototype.editAllowed = function (model) {
        return model.year > this._year ||
            (this._year == model.year && this._month <= model.month);
    };
    SalesTargetsListComponent = __decorate([
        core_1.Component({
            selector: 'sales-targets-list',
            templateUrl: './sales-targets-list.component.html',
            changeDetection: core_1.ChangeDetectionStrategy.OnPush
        })
    ], SalesTargetsListComponent);
    return SalesTargetsListComponent;
}());
exports.SalesTargetsListComponent = SalesTargetsListComponent;
//# sourceMappingURL=sales-targets-list.component.js.map