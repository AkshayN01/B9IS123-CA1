import { Injectable, inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class RoomService {
    apiurl = ''

    constructor(private http: HttpClient) {}

    getAvailableRooms(roomTypeID: number) { 
        const url = '${this.apiurl}/room?roomTypeID=${roomTypeID}';
        return this.http.get(url);
    }

    assignRoom(roomDetails: any) {
        const url = `${this.apiUrl}/booking/${roomDetails.bookingId}/room`;
        return this.http.post(url, roomDetails);
      }
    
      declineBooking(bookingId: number, reason: string) {
        const url = `${this.apiUrl}/booking/${bookingId}/decline`;
        return this.http.post(url, { reason });
      }
}