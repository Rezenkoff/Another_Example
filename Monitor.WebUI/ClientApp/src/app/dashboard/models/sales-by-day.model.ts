export class SalesByDayAndMonthModel {
    public countSalesByToday18_Yesterday18: number;
    public sumSalesByToday18_Yesterday18: number;
    public plannedSalesSum: number;
    public sumSalesByMonth: number;
    public countSalesByMonth: number;

    constructor() {
        this.countSalesByToday18_Yesterday18 = 0;
        this.sumSalesByToday18_Yesterday18 = 0;
        this.plannedSalesSum = 0;
        this.sumSalesByMonth = 0;
        this.countSalesByMonth = 0;
    }
}
