export class ResponseContract<T> {
    Header: HeaderContract;
    Data: T;
}

export class HeaderContract {
    Code: number;
    Message: string;
}