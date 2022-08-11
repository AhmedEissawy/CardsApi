import { Card } from './Models/card.model';
import { CardsService } from './Services/cards.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  cards : Card[] = [];

  card : Card = {
    id:0,
    name:'',
    number:'',
    expireMonth : 0,
    expireYear: 0,
    cvc:0
  };

  constructor(private CardsService:CardsService) {
    this.getAllCards()

  }

  getAllCards(){
    this.CardsService.getCards().subscribe(data => {
      this.cards = data;
     });
  }

  save(){
    if(this.card.id === 0){

      this.CardsService.addCards(this.card).subscribe(response => {
        this.getAllCards();
        this.card={
          id:0,
          name:'',
          number:'',
          expireMonth : 0,
          expireYear: 0,
          cvc:0
        }

      });
    }
    this.updateCard(this.card)


  }

  deleteCard(id:number){
     this.CardsService.deleteCard(id).subscribe(reponse=>{
      this.getAllCards();
     });
  }

  populate(item:Card){
     this.card =item;
  }

  updateCard(card:Card){
     this.CardsService.updateCard(card).subscribe(response=>{this.getAllCards()})
  }
}
