import { Injectable } from '@angular/core';
import { ApiService } from '../shared/http/api.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  constructor(private apiService: ApiService) { }

  getRoomTypes(): Observable<any>{
    const url = "userGuid/[userGuid]/roomTypes";

    return this.apiService.get(url);
  }

  getAllRooms(roomTypeId: string): Observable<any>{
    const url = "userGuid/[userGuid]/rooms?roomTypeId="+roomTypeId;

    return this.apiService.get(url);
  }
}
