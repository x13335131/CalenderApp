"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
require('rxjs/add/operator/map');
var AppComponent = (function () {
    function AppComponent() {
    }
    AppComponent.prototype.onClick = function (m) {
    };
    // onSelect function
    AppComponent.prototype.onSelect = function (o) {
        console.log('inside onSelect');
        //TESTING: for getting appointment object
        console.log("appointment object = " + o.id, o.description, o.date, o.time, o.organizer, o.attendees);
        this.extraAptInfo = [
            new desc(o.date, o.description, o.organizer, this.swap(o.attendees))
        ];
    };
    //swap function-this replaces comma with li tag in attendees
    AppComponent.prototype.swap = function (attendee) {
        var input = attendee;
        var fields = input.split(',');
        console.log(fields.length);
        //TESTING: printing new attendee without commas
        console.log("attendee" + attendee);
        var attend;
        attend = [];
        for (var i = 0; i < fields.length; i++) {
            attend.push(fields[i]);
            console.log('push= ' + attend[i]);
        }
        console.log(attend);
        return attend; //return this array back to desc object
    };
    AppComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            templateUrl: 'app.component.html',
            styleUrls: ['app.component.css'],
            moduleId: module.id
        }), 
        __metadata('design:paramtypes', [])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
var desc = (function () {
    function desc(descDate, descDescription, descOrganizer, descAttendees) {
        this.descDate = descDate;
        this.descDescription = descDescription;
        this.descOrganizer = descOrganizer;
        this.descAttendees = descAttendees;
    }
    return desc;
}());
exports.desc = desc;
//# sourceMappingURL=app.component.js.map