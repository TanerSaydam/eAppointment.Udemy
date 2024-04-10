export class ResultModel<T>{
    data: any;
    errorMessages?: string[]
    isSuccesful:boolean = true;
    statusCode: number = 200;
}