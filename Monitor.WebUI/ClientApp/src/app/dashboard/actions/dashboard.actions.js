"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
//VISITS
exports.GET_VISITS = '[Dashboard] Get visits';
exports.SET_VISITS = '[Dashboard] Set visits';
//DEALS
exports.GET_DEALS = '[Dashboard] Get deals';
exports.SET_DEALS = '[Dashboard] Set deals';
//SALES
exports.GET_SALES = '[Dashboard] Get sales';
exports.SET_SALES = '[Dashboard] Set sales';
//CONVERSION
exports.GET_CONVERSION = '[Dashboard] Get conversion';
exports.SET_CONVERSION = '[Dashboard] Set conversion';
//SUCCESSFULLDEALS
exports.GET_SUCCESSFULLDEALS = '[Dashboard] Get successfulldeals';
exports.SET_SUCCESSFULLDEALS = '[Dashboard] Set successfulldeals';
//LOST CALL RATE
exports.GET_LOSTCALLRATE = '[Dashboard] Get lostcallrate';
exports.SET_LOSTCALLRATE = '[Dashboard] Set lostcallrate';
//RETURNEDMONTH
exports.GET_RETURNEDMONTH = '[Dashboard] Get returnedmonth';
exports.SET_RETURNEDMONTH = '[Dashboard] Set returnedmonth';
var GetVisits = /** @class */ (function () {
    function GetVisits() {
        this.type = exports.GET_VISITS;
    }
    return GetVisits;
}());
exports.GetVisits = GetVisits;
var SetVisits = /** @class */ (function () {
    function SetVisits(payload) {
        this.payload = payload;
        this.type = exports.SET_VISITS;
    }
    return SetVisits;
}());
exports.SetVisits = SetVisits;
var GetDeals = /** @class */ (function () {
    function GetDeals() {
        this.type = exports.GET_DEALS;
    }
    return GetDeals;
}());
exports.GetDeals = GetDeals;
var SetDeals = /** @class */ (function () {
    function SetDeals(payload) {
        this.payload = payload;
        this.type = exports.SET_DEALS;
    }
    return SetDeals;
}());
exports.SetDeals = SetDeals;
var GetSales = /** @class */ (function () {
    function GetSales() {
        this.type = exports.GET_SALES;
    }
    return GetSales;
}());
exports.GetSales = GetSales;
var SetSales = /** @class */ (function () {
    function SetSales(payload) {
        this.payload = payload;
        this.type = exports.SET_SALES;
    }
    return SetSales;
}());
exports.SetSales = SetSales;
var GetConversion = /** @class */ (function () {
    function GetConversion() {
        this.type = exports.GET_CONVERSION;
    }
    return GetConversion;
}());
exports.GetConversion = GetConversion;
var SetConversion = /** @class */ (function () {
    function SetConversion(payload) {
        this.payload = payload;
        this.type = exports.SET_CONVERSION;
    }
    return SetConversion;
}());
exports.SetConversion = SetConversion;
var GetSuccessfullDeals = /** @class */ (function () {
    function GetSuccessfullDeals() {
        this.type = exports.GET_SUCCESSFULLDEALS;
    }
    return GetSuccessfullDeals;
}());
exports.GetSuccessfullDeals = GetSuccessfullDeals;
var SetSuccessfullDeals = /** @class */ (function () {
    function SetSuccessfullDeals(payload) {
        this.payload = payload;
        this.type = exports.SET_SUCCESSFULLDEALS;
    }
    return SetSuccessfullDeals;
}());
exports.SetSuccessfullDeals = SetSuccessfullDeals;
var GetLostCallRate = /** @class */ (function () {
    function GetLostCallRate() {
        this.type = exports.GET_LOSTCALLRATE;
    }
    return GetLostCallRate;
}());
exports.GetLostCallRate = GetLostCallRate;
var SetLostCallRate = /** @class */ (function () {
    function SetLostCallRate(payload) {
        this.payload = payload;
        this.type = exports.SET_LOSTCALLRATE;
    }
    return SetLostCallRate;
}());
exports.SetLostCallRate = SetLostCallRate;
var GetReturnedMonth = /** @class */ (function () {
    function GetReturnedMonth() {
        this.type = exports.GET_RETURNEDMONTH;
    }
    return GetReturnedMonth;
}());
exports.GetReturnedMonth = GetReturnedMonth;
var SetReturnedMonth = /** @class */ (function () {
    function SetReturnedMonth(payload) {
        this.payload = payload;
        this.type = exports.SET_RETURNEDMONTH;
    }
    return SetReturnedMonth;
}());
exports.SetReturnedMonth = SetReturnedMonth;
//# sourceMappingURL=dashboard.actions.js.map