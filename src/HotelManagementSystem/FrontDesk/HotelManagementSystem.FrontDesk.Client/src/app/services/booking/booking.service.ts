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

  viewAllBookings(fromDate: string | null, toDate: string | null, status :string | null, pageNumber: Number, pageSize: Number): Observable<any>{

    var params = "";
    if(fromDate != null){
      params += `fromDate=${fromDate}&`
    }
    if(toDate != null){
      params += `toDate=${toDate}&`
    }
    if(status != null){
      params += `status=${status}&`
    }

    params += `pageNumber=${pageNumber}&pageSize=${pageSize}`;

    const url = `userGuid/[userGuid]/bookings?${params}`;

    console.log(url);
    return this.apiService.get(url);
    // return new Observable();
  }
}