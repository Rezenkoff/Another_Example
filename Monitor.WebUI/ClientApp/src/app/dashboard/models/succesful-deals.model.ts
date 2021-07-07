export class SuccessfullDealsModel {
    public managerList: Array<ManagerDeals> = [];
}

export class ManagerDeals {
    public idCrm: number = 0;
    public name: string = '';
    public successfullDealsDay: number = 0;
    public successfullDealsDayMoney: number = 0;
    public allDealsDay: number = 0;
    public successfullDealsMonth: number = 0;
    public successfullDealsMonthMoney: number = 0;
    public allDealsMonth: number = 0;
    public photoUrl: string = '';
}
