import { Injectable } from "@angular/core";
import { CookieService } from "ngx-cookie-service";
import { CookieKey } from "../models/cookie-key.enum";

@Injectable()
export class AuthenticationService {

    constructor(private _cookieService: CookieService) { }

    public setBearerToken(token: string) {
        let encodedToken = btoa(token);
        this._cookieService.set(CookieKey.BearerToken, encodedToken);
    }

    public getBearerToken() {
        let result = '';
        let token = this._cookieService.get(CookieKey.BearerToken);
        if (token) {
            result = atob(token);
        }
        return result;
    }

    public isAuthorized() {
        let token = this._cookieService.get(CookieKey.BearerToken);
        return token ? true : false;
    }
}
