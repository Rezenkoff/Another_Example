import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { LoginModel } from "../models/login.model";
import { TokenResponse } from "../models/token-responce.model";
import { map } from "rxjs/operators";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";

@Injectable()
export class LoginService {

    constructor(private _http: HttpClient) { }

    public login(loginModel: LoginModel): Observable<TokenResponse> {
        const url: string = environment.login_url;

        return this._http.post(url, loginModel).pipe(
            map((resp: any) => {
                var data = resp as TokenResponse;
                return data;
            })
        );
    }
}
