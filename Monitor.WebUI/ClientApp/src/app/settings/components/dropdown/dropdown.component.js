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
var DropdownComponent = /** @class */ (function () {
    function DropdownComponent() {
        this.placeholder = null;
        this.options = [];
        this.selectedOptionKey = null;
        this.onOptionSelect = new core_1.EventEmitter();
        this.optionsList$ = new rxjs_1.BehaviorSubject([]);
        this.dropdownShown = false;
        this.searchString = '';
        this._initialList = [];
    }
    DropdownComponent.prototype.ngOnInit = function () {
        this._initialList = this.options;
        this.searchString = (this.selectedOptionKey) ? this.selectedOptionKey.toString() : null;
        this.filter();
    };
    DropdownComponent.prototype.selectValue = function (option) {
        this.searchString = option.key;
        this.onOptionSelect.emit(option);
        this.hideDropdown();
    };
    DropdownComponent.prototype.showDropdown = function () {
        this.dropdownShown = true;
    };
    DropdownComponent.prototype.hideDropdown = function () {
        this.dropdownShown = false;
    };
    DropdownComponent.prototype.filter = function () {
        var _this = this;
        if (!this.searchString) {
            this.optionsList$.next(this._initialList);
            return;
        }
        var filtered = this._initialList.filter(function (x) { return x.key.toString().toLowerCase().includes(_this.searchString.toLowerCase()); });
        this.optionsList$.next(filtered);
    };
    __decorate([
        core_1.Input()
    ], DropdownComponent.prototype, "placeholder", void 0);
    __decorate([
        core_1.Input()
    ], DropdownComponent.prototype, "options", void 0);
    __decorate([
        core_1.Input()
    ], DropdownComponent.prototype, "selectedOptionKey", void 0);
    __decorate([
        core_1.Output()
    ], DropdownComponent.prototype, "onOptionSelect", void 0);
    DropdownComponent = __decorate([
        core_1.Component({
            selector: 'dropdown',
            templateUrl: './dropdown.component.html',
            styleUrls: ['./dropdown.component.css'],
            changeDetection: core_1.ChangeDetectionStrategy.OnPush
        })
    ], DropdownComponent);
    return DropdownComponent;
}());
exports.DropdownComponent = DropdownComponent;
//# sourceMappingURL=dropdown.component.js.map