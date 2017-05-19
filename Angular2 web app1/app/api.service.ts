import "rxjs/Rx"
import { Http } from "@angular/http";
import { Injectable } from "@angular/core";
import { AppComponent} from "./app.component"
@Injectable()
export class ApiService {
    constructor(private http: Http) { }

    get(onNext: (json: any) => void) {

            this.http.get("webservice1.asmx/GetAppointmentsJSON").map(response => response.json()).subscribe(onNext);
            // this.http.get("webservice1.asmx/GetAppointmentsJSON?m=jan").map(response => response.json()).subscribe(onNext);
        
    }
}