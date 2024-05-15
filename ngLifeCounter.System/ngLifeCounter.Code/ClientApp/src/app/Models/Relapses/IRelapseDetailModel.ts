export interface RelapseDetailModel {
    eventName: string;
    id: string;
    eventCounterID: string;
    dateString: string;
}

export interface RelapsesDataModel {
    items: RelapseDetailModel[];
    timeUnit: string;
    timeQuantitySinceLastIssue: number;
}