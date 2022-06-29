import { Component, Input, OnInit } from '@angular/core';
import { LogService } from '../log-service.service';
import { LogDetail } from '../log-summary';

@Component({
  selector: 'app-log-detail-search',
  templateUrl: './log-detail-search.component.html',
  styleUrls: ['./log-detail-search.component.css']
})
export class LogDetailSearchComponent implements OnInit {
  logdetail : LogDetail = {
    id: '',
    requestTime: '',
    request: '',
    responseTime: '',
    response: '',
    duration: ''
  };
  title = 'Request/Response By ID';
  searchid: string = '';
  showloader : boolean = false;
  clicked: boolean = false;
  constructor(public logService : LogService ) { }

  ngOnInit(): void {

  }

  searchClick()
  {
    this.showloader = true;
    if(this.searchid == '')
    {
      this.logdetail = this.logdetail;
      this.showloader = false;
      return;
    }
    this.logService.getLogDetail(this.searchid).subscribe((data: LogDetail)=>{
      this.logdetail = data;
      this.showloader = false;
    })  
  }
}
