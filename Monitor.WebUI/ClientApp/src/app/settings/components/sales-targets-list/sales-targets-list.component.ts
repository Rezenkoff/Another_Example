import { Component, OnInit, ChangeDetectionStrategy } from "@angular/core";
import { SalesTargetModel } from "../../sales-target.model";
import { BehaviorSubject } from "rxjs";
import { SettingsService } from "../../services/settings.service";

@Component({
    selector: 'sales-targets-list',
    templateUrl: './sales-targets-list.component.html',
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class SalesTargetsListComponent implements OnInit {

    public salesTargetPopupEnabled$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
    public salesTargets$: BehaviorSubject<SalesTargetModel[]> = new BehaviorSubject<SalesTargetModel[]>([]);
    public selectedModel: SalesTargetModel = new SalesTargetModel();
    public popupMode: string = "add";
    private _year: number;
    private _month: number;

    constructor(
        private _settingsService: SettingsService,
    ) { }

    ngOnInit() {
        this._settingsService.getSalesTargets().subscribe(targets => this.salesTargets$.next(targets));
        const date = new Date();
        this._year = date.getFullYear();
        this._month = date.getMonth() + 1;
    }

    private openSalesTargetPopup(): void {
        this.salesTargetPopupEnabled$.next(true);
    }

    public addSalesTargetModel(): void {
        this.popupMode = "add";
        this.selectedModel = new SalesTargetModel();
        this.openSalesTargetPopup();
    }

    public editSalesTargetModel(model: SalesTargetModel): void {
        this.popupMode = "edit";
        this.selectedModel = model;
        this.openSalesTargetPopup();
    }

    public closeSalesTargetPopup(): void {
        this.selectedModel = new SalesTargetModel();
        this.salesTargetPopupEnabled$.next(false);
    }

    public saveSalesTarget(model: SalesTargetModel): void {
        this._settingsService.saveSalesTarget(model).subscribe(result => {
            if (result) {
                this._settingsService.getSalesTargets().subscribe(targets => this.salesTargets$.next(targets));
            }
            const message = (result) ? "Изменения сохранены" : "Ошибка при сохранении";
            alert(message);
        });
    }

    public editAllowed(model: SalesTargetModel): boolean {
        return model.year > this._year ||
            (this._year == model.year && this._month <= model.month);
    }
}
