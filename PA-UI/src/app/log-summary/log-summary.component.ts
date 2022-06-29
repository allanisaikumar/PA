import { Component, OnInit } from '@angular/core';
import { LogService } from '../log-service.service';
import { LogSummary } from '../log-summary';

@Component({
  selector: 'app-log-summary',
  templateUrl: './log-summary.component.html',
  styleUrls: ['./log-summary.component.css']
})
export class LogSummaryComponent implements OnInit {
  logSummary: LogSummary[] = [];
  title = 'API Request Summary';
  searchText: string = '';
  dataLoaded : boolean = false;
  constructor(public logService : LogService) { }

  ngOnInit(): void {
    this.logService.getSummary().subscribe((data: LogSummary[])=>{
      this.logSummary = data;
      this.dataLoaded = true;
    })  
  }
}
