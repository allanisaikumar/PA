import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

// search module
import { Ng2SearchPipeModule } from 'ng2-search-filter';

import { AppComponent } from './app.component';
import { LogSummaryComponent } from './log-summary/log-summary.component';
import { LogDetailSearchComponent } from './log-detail-search/log-detail-search.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  imports:      [ BrowserModule, FormsModule, Ng2SearchPipeModule, HttpClientModule ],
  declarations: [ AppComponent, LogSummaryComponent, LogDetailSearchComponent ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
