import { Injectable } from '@angular/core';
import { ApiService } from '../shared/http/api.service';
import { Observable } from 'rxjs';
import { BookingRegisterModel } from '../../models/booking/booking-register.model';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor(private apiService: ApiService) { }

  addBooking(model: BookingRegisterModel): Observable<any>{
    const url = "userGuid/[userGuid]/booking";

    return this.apiService.post(url, model);
  }
}
