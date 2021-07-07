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
var rxjs_1 = require("rxjs");
var operators_1 = require("rxjs/operators");
var AppHttpInterceptor = /** @class */ (function () {
    function AppHttpInterceptor(_router, _authService) {
        this._router = _router;
        this._authService = _authService;
        this.getToken();
    }
    AppHttpInterceptor.prototype.intercept = function (req, next) {
        if (this.token) {
            req = req.clone({ setHeaders: { 'Authorization': 'Bearer ' + this.token } });
        }
        return next.handle(req).pipe(operators_1.tap(function (resp) {
            if (resp instanceof http_1.HttpResponse && resp.type != 0) {
                return resp;
            }
        }));
    };
    AppHttpInterceptor.prototype.getToken = function () {
        var bearerToken = this._authService.getBearerToken();
        if (bearerToken) {
            this.token = bearerToken;
        }
    };
    AppHttpInterceptor.prototype.handleError = function (err) {
        if (err instanceof http_1.HttpErrorResponse) {
            if (err.status !== 500) {
                this._router.navigate(['/login']);
            }
        }
        else {
            return rxjs_1.Observable.throw(err);
        }
    };
    AppHttpInterceptor = __decorate([
        core_1.Injectable()
    ], AppHttpInterceptor);
    return AppHttpInterceptor;
}());
exports.AppHttpInterceptor = AppHttpInterceptor;
//# sourceMappingURL=app.http.interceptor.js.map