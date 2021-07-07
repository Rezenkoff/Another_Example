import { Injectable } from "@angular/core";
import { HttpClient} from "@angular/common/http";
import { SalesTargetModel } from "../sales-target.model";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { ApiResponseModel } from "src/app/shared/models/api-response.model";
import { map } from "rxjs/operators";

const API_URL = environment.api_url;

@Injectable()
export class SettingsService {

    constructor(
        private _httpClient: HttpClient
    ) { }

    public getSalesTargets(): Observable<SalesTargetModel[]> {
        return this._httpClient.get<SalesTargetModel[]>(API_URL + 'api/dashboard/get-all-sales-info');
    }

    public saveSalesTarget(model: SalesTargetModel): Observable<boolean> {
        return this._httpClient.post<ApiResponseModel>(API_URL + 'api/dashboard/save-sales-target', model)
            .pipe(map(responseModel => (responseModel as ApiResponseModel).success));
    }
}
