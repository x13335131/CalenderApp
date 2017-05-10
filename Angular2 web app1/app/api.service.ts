import "rxjs/Rx"
import { Http } from "@angular/http";
import { Injectable } from "@angular/core";
import { AppComponent } from "./app.component";
@Injectable()
export class ApiService {
    mth:string = '';
    constructor(private http: Http) { }

    getMonth(month: string) {
        
        this.mth=month;
        console.log('mth:'+this.mth);
        return this.http.get( "WebService1.asmx/GetAppointmentsJSON" ).map(response => response.json());

    }
}