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
Object.defineProperty(exports, "__esModule", { value: true });
require("rxjs/Rx");
var http_1 = require("@angular/http");
var core_1 = require("@angular/core");
var ApiService = (function () {
    function ApiService(http) {
        this.http = http;
        this.aptUrl = "webservice1.asmx/GetAppointmentsJSON";
    }
    /*   get(onNext: (json: any) => void) {
           
           this.http.get("webservice1.asmx/GetAppointmentsJSON?m=${month}").map(response => response.json()).subscribe(onNext);
          //this.http.get("webservice1.asmx/GetAppointmentsJSON?m=jan").map(response => response.json()).subscribe(onNext);
           
       }*/
    ApiService.prototype.handleError = function (error) {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    };
    ApiService.prototype.getApts = function (month) {
        var url = this.aptUrl + "?m=" + month;
        console.log('url: ' + url);
        return this.http.get(url)
            .toPromise()
            .then(function (response) { return response.json().data; })
            .catch(this.handleError);
    };
    return ApiService;
}());
ApiService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], ApiService);
exports.ApiService = ApiService;
//# sourceMappingURL=api.service.js.map