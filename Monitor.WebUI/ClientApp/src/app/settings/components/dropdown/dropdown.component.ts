import { Component, Input, Output, EventEmitter, ChangeDetectionStrategy } from "@angular/core";
import { KeyValue } from "@angular/common";
import { BehaviorSubject } from "rxjs";

@Component({
    selector: 'dropdown',
    templateUrl: './dropdown.component.html',
    styleUrls: ['./dropdown.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class DropdownComponent {
    @Input() placeholder: string = null;
    @Input() options: KeyValue<any, any>[] = [];
    @Input() selectedOptionKey: string = null;
    @Output() onOptionSelect: EventEmitter<KeyValue<any, any>> = new EventEmitter<KeyValue<any, any>>();

    public optionsList$: BehaviorSubject<KeyValue<any, any>[]> = new BehaviorSubject<KeyValue<any, any>[]>([]);
    public dropdownShown: boolean = false;
    public searchString: string = '';
    private _initialList: KeyValue<any, any>[] = [];

    ngOnInit() {
        this._initialList = this.options;
        this.searchString = (this.selectedOptionKey) ? this.selectedOptionKey.toString() : null;
        this.filter();
    }

    public selectValue(option: KeyValue<any, any>): void {
        this.searchString = option.key;
        this.onOptionSelect.emit(option);
        this.hideDropdown();
    }

    public showDropdown(): void {
        this.dropdownShown = true;
    }

    public hideDropdown(): void {
        this.dropdownShown = false;
    }

    public filter(): void {
        if (!this.searchString) {
            this.optionsList$.next(this._initialList);
            return;
        }
        
        const filtered = this._initialList.filter(x => x.key.toString().toLowerCase().includes(this.searchString.toLowerCase()));
        this.optionsList$.next(filtered);
    }
}
