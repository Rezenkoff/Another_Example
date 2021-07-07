import { Component, OnInit, ViewChild } from "@angular/core";
import { LoginService } from "../services/login.service";
import { LoginModel } from "../models/login.model";
import { TokenResponse } from "../models/token-responce.model";
import { UserRole } from "../models/user-role.enum";
import { AuthenticationService } from "../../shared/services/authentication.service";
import { Router } from "@angular/router";

@Component({
    selector: 'login-form',
    templateUrl: './login.component.html',
    styles: []
})
export class LoginComponent implements OnInit{

    public isLoginning: boolean = false;

    public loginModel: LoginModel = new LoginModel();

    @ViewChild("loginInput") loginInput;
    @ViewChild("passwordInput") passwordInput;

    constructor(private _loginService: LoginService, private _authService: AuthenticationService, private _router: Router) { }

    ngOnInit() {
        this.loginInput.nativeElement.focus();
    }

    public login() {
        this._loginService.login(this.loginModel).subscribe(result => {
            this.setUserData(result);
            this._router.navigate(['/dashboard']);
        });
    }

    public onLoginInput() {
        if (this.loginModel.phone.length === 10) {
            this.passwordInput.nativeElement.focus();
        }
    }

    private setUserData(data: TokenResponse) {
        if (data.userData.role == UserRole.Admin) {
            this._authService.setBearerToken(data.access_token);
        }
    }
}
