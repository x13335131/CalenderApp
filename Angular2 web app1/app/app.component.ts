import { Component } from "@angular/core";
import { ApiService } from "./api.service";

@Component({
    selector: 'my-app',
    templateUrl: 'app.component.html',
    styleUrls: ['app.component.css'],
    moduleId: module.id,
    providers: [ApiService]
})

export class AppComponent {
    isLoading: boolean = false;
    //description array
    appointments: Array<appointment>;
    extraAptInfo: Array<desc>;
    constructor(private service: ApiService) { }

    onClick(m: any) {
        this.isLoading = true;
        this.service.get(json => {
            if (json) {
                this.appointments = json;
                this.isLoading = false;
            }
        });
    }

    // onSelect function
    onSelect(o: appointment) {
        console.log('inside onSelect');
        //TESTING: for getting appointment object
        console.log("appointment object = " + o.id, o.description, o.date, o.time, o.organizer, o.attendees);

        this.extraAptInfo = [ //sets description info with selected object
            new desc(o.date, o.description, o.organizer, this.swap(o.attendees))
        ]

    }

    //swap function-this replaces comma with li tag in attendees
    swap(attendee: any) {
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

    descDate: Date;
    descDescription: string;
    descOrganizer: string;
    descAttendees: Array<string>;

    constructor(descDate: Date, descDescription: string, descOrganizer: string, descAttendees: Array<string>) {

        this.descDate = descDate;
        this.descDescription = descDescription;
        this.descOrganizer = descOrganizer;
        this.descAttendees = descAttendees;
    }
}
export class appointment {
    attendees: string;
    date: Date;
    description: string;
    id: number;
    organizer: string;
    time: string;
}