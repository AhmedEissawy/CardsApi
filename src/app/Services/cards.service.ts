import { Card } from './../Models/card.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CardsService {

  baseUrl ="https://localhost:44337/api/Card";

  constructor(private http:HttpClient) { }

  getCards():Observable<Card[]>{
     return  this.http.get<Card[]>(this.baseUrl);
  }

  addCards(card:Card):Observable<Card>{
     return  this.http.post<Card>(this.baseUrl,card)
  }

  deleteCard(id:number):Observable<Card>{
   return this.http.delete<Card>(this.baseUrl +'/'+id)
  }

  updateCard(card:Card):Observable<Card>{
    return this.http.put<Card>(this.baseUrl +'/'+ card.id , card)
  }

}
