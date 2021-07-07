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
var SalesTargetPopupComponent = /** @class */ (function () {
    function SalesTargetPopupComponent() {
        this.mode = "add"; //add or edit
        this.salesTargetModel = new sales_target_model_1.SalesTargetModel();
        this.onPopupClose = new core_1.EventEmitter();
        this.onSubmit = new core_1.EventEmitter();
        this.disableReason$ = new rxjs_1.BehaviorSubject(null);
        this.yearOptions = [];
        this.monthOptions = [];
        this.modelIsValid = false;
    }
    SalesTargetPopupComponent.prototype.ngOnInit = function () {
        var currentYear = new Date().getFullYear();
        this.yearOptions = this.getRange(currentYear, currentYear + 2);
        this.monthOptions = [
            { key: "Январь", value: 1 },
            { key: "Февраль", value: 2 },
            { key: "Март", value: 3 },
            { key: "Апрель", value: 4 },
            { key: "Май", value: 5 },
            { key: "Июнь", value: 6 },
            { key: "Июль", value: 7 },
            { key: "Август", value: 8 },
            { key: "Сентябрь", value: 9 },
            { key: "Октябрь", value: 10 },
            { key: "Ноябрь", value: 11 },
            { key: "Декабрь", value: 12 },
        ];
        this.validate();
        var date = new Date();
        this._year = date.getFullYear();
        this._month = date.getMonth() + 1;
    };
    SalesTargetPopupComponent.prototype.close = function () {
        this.onPopupClose.emit();
    };
    SalesTargetPopupComponent.prototype.setYear = function (option) {
        this.salesTargetModel.year = option.value;
        this.validate();
    };
    SalesTargetPopupComponent.prototype.setMonth = function (option) {
        this.salesTargetModel.month = option.value;
        this.validate();
    };
    SalesTargetPopupComponent.prototype.getRange = function (from, to) {
        var result = [];
        for (var i = from; i <= to; i++) {
            result.push({ key: i, value: i });
        }
        return result;
    };
    SalesTargetPopupComponent.prototype.validate = function () {
        this.modelIsValid = false;
        if (!this.salesTargetModel) {
            this.disableReason$.next("Не указан год, месяц и цель");
            return;
        }
        if (!this.salesTargetModel.year) {
            this.disableReason$.next("Не указан год");
            return;
        }
        if (this.salesTargetModel.year < this._year) {
            this.disableReason$.next("Запрещено менять цели на предыдущие годы");
            return;
        }
        if (!this.salesTargetModel.month || this.salesTargetModel.month < 1 || this.salesTargetModel.month > 12) {
            this.disableReason$.next("Месяц некорректный");
            return;
        }
        if (this.salesTargetModel.year == this._year && this.salesTargetModel.month < this._month) {
            this.disableReason$.next("Запрещено менять цели на предыдущие месяцы");
            return;
        }
        if (!this.salesTargetModel.plannedSalesSumm || this.salesTargetModel.plannedSalesSumm <= 0) {
            this.disableReason$.next("Сумма должна быть положительным числом");
            return;
        }
        this.disableReason$.next(null);
        this.modelIsValid = true;
    };
    SalesTargetPopupComponent.prototype.submit = function () {
        this.onSubmit.emit(this.salesTargetModel);
        this.close();
    };
    __decorate([
        core_1.Input()
    ], SalesTargetPopupComponent.prototype, "mode", void 0);
    __decorate([
        core_1.Input()
    ], SalesTargetPopupComponent.prototype, "salesTargetModel", void 0);
    __decorate([
        core_1.Output()
    ], SalesTargetPopupComponent.prototype, "onPopupClose", void 0);
    __decorate([
        core_1.Output()
    ], SalesTargetPopupComponent.prototype, "onSubmit", void 0);
    SalesTargetPopupComponent = __decorate([
        core_1.Component({
            selector: 'sales-target-popup',
            templateUrl: './sales-target-popup.component.html',
            styleUrls: ['./sales-target-popup.component.css'],
            changeDetection: core_1.ChangeDetectionStrategy.OnPush
        })
    ], SalesTargetPopupComponent);
    return SalesTargetPopupComponent;
}());
exports.SalesTargetPopupComponent = SalesTargetPopupComponent;
//# sourceMappingURL=sales-target-popup.component.js.map