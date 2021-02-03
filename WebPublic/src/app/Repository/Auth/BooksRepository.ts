import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ResponseContract } from '../../Contracts/Auth/ResponseContract';
import { environment } from '../../../environments/environment';
import { BookFilterContract } from 'src/app/Contracts/BookFilterContract';


export abstract class IBooksRepository{
    abstract GetFilters(filter:any): Promise<ResponseContract<Array<BookFilterContract>>>;
}

@Injectable()
export class BooksRepository implements IBooksRepository {

    baseUrl: string = environment.BaseUrl;
    GetBooks = "/api/books/GetBooks?filter=";
    headers = new HttpHeaders({'Content-Type': 'application/json'});


    constructor(private http: HttpClient) { }
    GetFilters(filter: any): Promise<ResponseContract<Array<BookFilterContract>>> {
        return this.http.get(this.baseUrl + this.GetBooks + filter, {
            headers: this.headers
         })
        .toPromise().then(response =>{
            return response as ResponseContract<Array<BookFilterContract>>
        });
    }    
}