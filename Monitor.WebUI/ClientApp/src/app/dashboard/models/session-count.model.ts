export class SessionCountModel {
    public sessionByDay: number;
    public sessionByMonth: number;
    public sessionByDayWeekAgo: number;
    public sessionRatio: number;
    public loading: boolean;
 
    constructor(sbd?: number, sbm?: number, sbdwa?:number) {
        this.sessionByDay = sbd;
        this.sessionByMonth = sbm;
        this.sessionByDayWeekAgo = sbdwa;
        this.sessionRatio = Math.round((sbd / sbdwa) * 100);
        this.loading = false;
    }
}
