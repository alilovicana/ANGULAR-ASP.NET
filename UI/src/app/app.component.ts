import { Component, OnInit } from '@angular/core';
import { Kontakt } from './models/kontakt.model';
import {KontaktiService} from './service/kontakti.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'kontakti';
  kontakti: Kontakt[]=[];
  kontakt: Kontakt={
    id: '',
    Name:'',
    Surname:'',
    Adress:'',
    Email: '',
    PhoneNumber: '',
    Tag:''
  }

  constructor(private kontaktiService: KontaktiService){

  }
  ngOnInit(): void {
    this.getAllKontakti();
  }

  getAllKontakti(){ 
    this.kontaktiService.getAllKontakti()
    .subscribe(
      response =>{
        this.kontakti=response.map((x : any) => {
          return {
            id: x.id,
            Name: x.name,
            Surname:x.surname,
            Adress:x.adress,
            Email:x.email,
            Tag:x.tag,
            PhoneNumber:x.phoneNumber

          } as Kontakt
        });
      }
    );
  }


  onSubmit(){

    if (this.kontakt.id===''){
      this.kontaktiService.addKontakt(this.kontakt)
      .subscribe(
        response =>{
          this.getAllKontakti();
          this.kontakt ={
            id: '',
            Name:'',
            Surname:'',
            Adress: '',
            Email:'',
            PhoneNumber: '',     
            Tag:''
          }
        }
      );
    }else {
      this.updateKontakt(this.kontakt);
    }

  }
  
  deleteKontakt(id:string){
    this.kontaktiService.deleteKontakt(id)
    .subscribe(
      response=>{
        this.getAllKontakti();
      }
    );
  }

  populateForm(kontakt:Kontakt){
    this.kontakt=kontakt;
  }

  updateKontakt(kontakt:Kontakt){
    this.kontaktiService.updateKontakt(kontakt)
    .subscribe(
      response=>{
        this.getAllKontakti();
      }
    );
  }

}
