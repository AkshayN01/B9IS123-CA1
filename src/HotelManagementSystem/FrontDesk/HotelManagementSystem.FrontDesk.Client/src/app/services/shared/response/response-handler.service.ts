import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class ResponseHandlerService {

  constructor(private matSnackBar: MatSnackBar) { }

  checkResponse(response: string){
    if(response.length == 0)
      this.openSnachBar('Invalid Response');

    var res = JSON.parse(JSON.stringify(response));
    console.log(res);
    if(res.meta.retVal != 1)
      this.openSnachBar(res.meta.message);
    console.log(res.data);
    return res.data;
  }

  openSnachBar(message:string){
    this.matSnackBar.open(message, 'Close', {
      panelClass: ['bg-danger']
    });
  }
}
