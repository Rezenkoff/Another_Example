import { Component, EventEmitter, Output, ChangeDetectionStrategy, OnInit, Input } from "@angular/core";
import { KeyValue } from "@angular/common";
import { SalesTargetModel } from "../../sales-target.model";
import { BehaviorSubject } from "rxjs";

@Component({
    selector: 'sales-target-popup',
    templateUrl: './sales-target-popup.component.html',
    styleUrls: ['./sales-target-popup.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class SalesTargetPopupComponent implements OnInit {

    @Input() mode = "add"; //add or edit
    @Input() salesTargetModel: SalesTargetModel = new SalesTargetModel();
    @Output() onPopupClose: EventEmitter<void> = new EventEmitter<void>();
    @Output() onSubmit: EventEmitter<SalesTargetModel> = new EventEmitter<SalesTargetModel>();

    public disableReason$: BehaviorSubject<string> = new BehaviorSubject<string>(null);
    public yearOptions: KeyValue<number, number>[] = [];
    public monthOptions: KeyValue<string, number>[] = [];
    public modelIsValid: boolean = false;
    private _year: number;
    private _month: number;

    ngOnInit() {
        const currentYear = new Date().getFullYear();
        this.yearOptions = this.getRange(currentYear, currentYear + 2);
        this.monthOptions = [
            { key: "Январь", value: 1},
            { key: "Февраль", value: 2},
            { key: "Март", value: 3 },
            { key: "Апрель", value: 4 },
            { key: "Май", value: 5 },
            { key: "Июнь", value: 6 },
            { key: "Июль", value: 7 },
            { key: "Август", value: 8 },
            { key: "Сентябрь", value: 9 },
            { key: "Октябрь", value: 10 },
            { key: "Ноябрь", value: 11 },
            { key: "Декабрь", value: 12 },
        ];
        this.validate();

        const date = new Date();
        this._year = date.getFullYear();
        this._month = date.getMonth() + 1;
    }

    close(): void {
        this.onPopupClose.emit();
    }

    setYear(option: KeyValue<number, number>): void {
        this.salesTargetModel.year = option.value;
        this.validate();
    }

    setMonth(option: KeyValue<number, number>): void {
        this.salesTargetModel.month = option.value;
        this.validate();
    }

    private getRange(from: number, to: number): KeyValue<number, number>[] {
        let result: KeyValue<number, number>[] = [];

        for (let i = from; i <= to; i++) {
            result.push({ key: i, value: i });
        }

        return result;
    }

    public validate(): void {
        this.modelIsValid = false;

        if (!this.salesTargetModel) {            
            this.disableReason$.next("Не указан год, месяц и цель");
            return;
        }

        if (!this.salesTargetModel.year) {
            this.disableReason$.next("Не указан год");
            return;
        }

        if (this.salesTargetModel.year < this._year) {
            this.disableReason$.next("Запрещено менять цели на предыдущие годы");
            return;
        }

        if (!this.salesTargetModel.month || this.salesTargetModel.month < 1 || this.salesTargetModel.month > 12) {
            this.disableReason$.next("Месяц некорректный");
            return;
        }

        if (this.salesTargetModel.year == this._year && this.salesTargetModel.month < this._month) {
            this.disableReason$.next("Запрещено менять цели на предыдущие месяцы");
            return;
        }

        if (!this.salesTargetModel.plannedSalesSumm || this.salesTargetModel.plannedSalesSumm <= 0) {
            this.disableReason$.next("Сумма должна быть положительным числом");
            return;
        }

        this.disableReason$.next(null);
        this.modelIsValid = true;
    }

    public submit(): void {
        this.onSubmit.emit(this.salesTargetModel);
        this.close();
    }
}
