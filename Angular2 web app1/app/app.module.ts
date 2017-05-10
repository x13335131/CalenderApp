import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { ApiService } from './api.service';
import { AppComponent } from './app.component';

@NgModule({
    imports: [BrowserModule, HttpModule],
    providers: [ApiService],
    declarations: [AppComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }
