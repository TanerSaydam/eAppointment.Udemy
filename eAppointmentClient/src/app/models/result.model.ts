export class ResultModel<T>{
    data?: T;
    errorMessages?: string[]
    isSuccesful:boolean = true;
    statusCode: number = 200;
}