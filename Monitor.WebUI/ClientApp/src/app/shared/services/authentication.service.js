"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var cookie_key_enum_1 = require("../models/cookie-key.enum");
var AuthenticationService = /** @class */ (function () {
    function AuthenticationService(_cookieService) {
        this._cookieService = _cookieService;
    }
    AuthenticationService.prototype.setBearerToken = function (token) {
        var encodedToken = btoa(token);
        this._cookieService.set(cookie_key_enum_1.CookieKey.BearerToken, encodedToken);
    };
    AuthenticationService.prototype.getBearerToken = function () {
        var result = '';
        var token = this._cookieService.get(cookie_key_enum_1.CookieKey.BearerToken);
        if (token) {
            result = atob(token);
        }
        return result;
    };
    AuthenticationService.prototype.isAuthorized = function () {
        var token = this._cookieService.get(cookie_key_enum_1.CookieKey.BearerToken);
        return token ? true : false;
    };
    AuthenticationService = __decorate([
        core_1.Injectable()
    ], AuthenticationService);
    return AuthenticationService;
}());
exports.AuthenticationService = AuthenticationService;
//# sourceMappingURL=authentication.service.js.map