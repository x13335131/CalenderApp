import { Component } from '@angular/core'
//import { Http } from '@angular/http';
import { Http, Response } from '@angular/http'
import { Injectable } from '@angular/core'
import 'rxjs/add/operator/map' 
import  appointment 
@Component({
    selector: 'my-app',
    templateUrl: 'app.component.html',
    styleUrls: ['app.component.css'],
    moduleId: module.id
})

//@Injectable()
//export class HTTPTestService {
//        constructor (private http: Http){
//    }
//        getCurrentTime() {
//            return this.http.get('http://date.jsontest.com')
//                .map(res => res.json());
//        }
//}
export class AppComponent  {

    
    onClick(m: any) {
     }
        //description array
        extraAptInfo: Array<desc>;

        // onSelect function
        onSelect(o:any) {
            console.log('inside onSelect');
            //TESTING: for getting appointment object
            console.log("appointment object = " + o.id, o.description, o.date, o.time, o.organizer, o.attendees);

            this.extraAptInfo = [ //sets description info with selected object
                new desc(o.date, o.description, o.organizer, this.swap(o.attendees))
            ]

        }

        //swap function-this replaces comma with li tag in attendees
        swap(attendee:any) {
            var input = attendee;
            var fields = input.split(',');
            console.log(fields.length);
            //TESTING: printing new attendee without commas
            console.log("attendee" + attendee);
            var attend: any[];
            attend = [];

            for (var i = 0; i < fields.length; i++) {
                attend.push(fields[i]);
                console.log('push= ' + attend[i]);
            }
            
            console.log(attend);
            return attend; //return this array back to desc object

        }
    }



export class desc {

    descDate: string;
    descDescription: string;
    descOrganizer: string;
    descAttendees: Object;

    constructor(descDate: string, descDescription: string, descOrganizer: string, descAttendees: Object) {

        this.descDate = descDate;
        this.descDescription = descDescription;
        this.descOrganizer = descOrganizer;
        this.descAttendees = descAttendees;
    }
}
