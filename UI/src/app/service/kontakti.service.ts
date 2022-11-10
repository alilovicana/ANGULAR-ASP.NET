import { HttpClient } from '@angular/common/http'; 
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Kontakt } from '../models/kontakt.model';

@Injectable({
  providedIn: 'root'
})
export class KontaktiService {
  baseUrl='https://localhost:7183/api/kontakti';

  

  constructor(private http: HttpClient) {

   }

  // get all cards
  getAllKontakti(): Observable<Kontakt[]> {
    return this.http.get<Kontakt[]>(this.baseUrl);
  }

  addKontakt(kontakt:Kontakt): Observable<Kontakt>{
    kontakt.id='00000000-0000-0000-0000-000000000000';
    return this.http.post<Kontakt>(this.baseUrl, kontakt);
    
  }

  deleteKontakt(id:string): Observable<Kontakt>{
    return this.http.delete<Kontakt>(this.baseUrl+'/'+id);
  }

  updateKontakt(kontakt:Kontakt): Observable<Kontakt>{
    return this.http.put<Kontakt>(this.baseUrl+'/'+kontakt.id,kontakt);
  }

}
