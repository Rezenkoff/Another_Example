import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpErrorResponse, HttpResponse, HttpRequest, HttpHandler, HttpEvent } from "@angular/common/http";
import { Router } from "@angular/router";
import { Observable, of } from "rxjs";
import { AuthenticationService } from "./shared/services/authentication.service";
import { catchError, tap } from 'rxjs/operators';

@Injectable()
export class AppHttpInterceptor implements HttpInterceptor {
    private token: string;

    constructor(private _router: Router, private _authService: AuthenticationService) {
        this.getToken();
    }

    public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (this.token) {
            req = req.clone({ setHeaders: { 'Authorization': 'Bearer ' + this.token } });
        }

        return next.handle(req).pipe(
            tap(resp => {
                if (resp instanceof HttpResponse && resp.type != 0) {
                    return resp;
                }
            }),
            catchError(this.handleError)
        );
    }

    private getToken() {
        let bearerToken = this._authService.getBearerToken();
        if (bearerToken) {
            this.token = bearerToken;
        }
    }

    private handleError(err: Response) {
        if (err instanceof HttpErrorResponse) {
            if (err.status !== 500) {
                window.location.href = '/login';
                //this._router.navigate(['/login']);
            }
        }
        else {
            return Observable.throw(err);
        }
    }
}
