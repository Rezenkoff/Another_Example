"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var login_model_1 = require("../models/login.model");
var user_role_enum_1 = require("../models/user-role.enum");
var LoginComponent = /** @class */ (function () {
    function LoginComponent(_loginService, _authService, _router) {
        this._loginService = _loginService;
        this._authService = _authService;
        this._router = _router;
        this.isLoginning = false;
        this.loginModel = new login_model_1.LoginModel();
    }
    LoginComponent.prototype.login = function () {
        var _this = this;
        this._loginService.login(this.loginModel).subscribe(function (result) {
            _this.setUserData(result);
            _this._router.navigate(['/dashboard']);
        });
    };
    LoginComponent.prototype.setUserData = function (data) {
        if (data.userData.role == user_role_enum_1.UserRole.Admin) {
            this._authService.setBearerToken(data.access_token);
        }
    };
    LoginComponent = __decorate([
        core_1.Component({
            selector: 'login-form',
            templateUrl: './login.component.html',
            styles: []
        })
    ], LoginComponent);
    return LoginComponent;
}());
exports.LoginComponent = LoginComponent;
//# sourceMappingURL=login.component.js.map