import "rxjs/Rx"
import { Http } from "@angular/http";
import { Injectable } from "@angular/core";
import { AppComponent } from "./app.component";
import { appointment } from "./app.component";
@Injectable()
export class ApiService {
    aptUrl: string = "webservice1.asmx/GetAppointmentsJSON";
    constructor(private http: Http) { }
  
 /*   get(onNext: (json: any) => void) {
        
        this.http.get("webservice1.asmx/GetAppointmentsJSON?m=${month}").map(response => response.json()).subscribe(onNext);
       //this.http.get("webservice1.asmx/GetAppointmentsJSON?m=jan").map(response => response.json()).subscribe(onNext);
        
    }*/
    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); 
        return Promise.reject(error.message || error);
    }
    getApts(): Promise<appointment[]> {
        return this.http.get(this.aptUrl)
            .toPromise()
            .then(response => response.json().data as appointment[])
            .catch(this.handleError);
    }
    getApt(month : string): Promise<appointment> {
        const url = `${this.aptUrl}?m=${month}`;
        console.log('url: '+url);
        return this.http.get(url)
            .toPromise()
            .then(response => response.json().data as appointment)
            .catch(this.handleError);
    }

}