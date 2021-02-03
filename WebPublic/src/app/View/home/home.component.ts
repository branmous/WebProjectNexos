import { Component, OnInit } from '@angular/core';
import { BookFilterContract } from '../../Contracts/BookFilterContract';
import { BooksRepository, IBooksRepository } from '../../Repository/Auth/BooksRepository';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [BooksRepository],
})
export class HomeComponent implements OnInit {

  private books: BookFilterContract[];

  constructor(private bookRepository: IBooksRepository) { }

  ngOnInit() {
    this.bookRepository.GetFilters("")
    .then(response => {
      if(response.Header.Code == 200){
        this.books = response.Data;
      }
    });
  }

}
