import { Component, OnInit } from '@angular/core';
import { Firms } from '../../entities/entities'
import { SurveyService } from '../../services/survey.service'
@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {
  mainList:Firms[]=[];
  firmlist:Firms[]=[];
  firmCategory:string[]=[
    'All',
    'Company Profile',
    'Overall Firm Demographics',
    'Firm Leadership/Management Demographic Profile',
    'Number of Promotions from Associate to Partner',
    'Lawyers Who Left The Firm',
    'Hires',
    'Lawyers Working Reduced Hours Schedule',
    'Top 10% Highest Compensated Partners',
    'Undertaken Initiatives/Actions'
    ]
  reportType:string[]=[
    'Race vs Role',
    'Race Across the Position',
    'Position Across the Race'
  ]

  async getFirms(){
    this.mainList = <Firms[]> await this.surveySvc.getFirms();
    this.firmlist = this.mainList;
  }


  public barChartOptions:any = {
    scaleShowVerticalLines: false,
    responsive: true
  };
  public barChartLabels:string[] = ['2016','2017','2018'];
  public barChartType:string = 'bar';
  public barChartLegend:boolean = true;
 
  public barChartData:any[] = [
    {data: [5,10,15], label: 'Asian'},
    {data: [15,5,20], label: 'Iba'}
  ];
 
  // events
  // public chartClicked(e:any):void {
  //   console.log(e);
  // }
 
  // public chartHovered(e:any):void {
  //   console.log(e);
  // }
 
  // public randomize():void {
  //   // Only Change 3 values
  //   let data = [
  //     Math.round(Math.random() * 100),
  //     59,
  //     80,
  //     (Math.random() * 100),
  //     56,
  //     (Math.random() * 100),
  //     40];
  //   let clone = JSON.parse(JSON.stringify(this.barChartData));
  //   clone[0].data = data;
  //   this.barChartData = clone;
  //   /**
  //    * (My guess), for Angular to recognize the change in the dataset
  //    * it has to change the dataset variable directly,
  //    * so one way around it, is to clone the data, change it and then
  //    * assign it;
  //    */
  // }
  // firmDemo:string[]=['Equity Partners','Non-Equity Partners','Associates','Counsel','Other Lawyers','Totals']
  // firmDemoassign:string[]=['EquityPartners','NonEquityPartners','Associates','Counsel','OtherLawyers','Totals']

  // items:string[]=
  // [
  //   'African American/Black(not Hispanic/Latino)',
  //   'Hispanic/Latino',
  //   'Alaska Native/American Indian',
  //   'Asian',
  //   'Native Hawaiian/Other Pacific Islander',
  //   'Multiracial',
  //   'White',
  //   'LGBT',
  //   'Disabled',
  //   'Women',
  //   'Men'
  // ]
  constructor(private surveySvc : SurveyService) { }

  async ngOnInit() {
    await this.getFirms();
  }
// lineChart
public lineChartData:Array<any> = [
  {data: [65, 59, 80, 81, 56, 55, 40], label: 'Series A'},
  {data: [28, 48, 40, 19, 86, 27, 90], label: 'Series B'},
  {data: [18, 48, 77, 9, 100, 27, 40], label: 'Series C'}
];
public lineChartLabels:Array<any> = ['January', 'February', 'March', 'April', 'May', 'June', 'July'];
public lineChartOptions:any = {
  responsive: true
};
public lineChartColors:Array<any> = [
  { // grey
    backgroundColor: 'rgba(148,159,177,0.2)',
    borderColor: 'rgba(148,159,177,1)',
    pointBackgroundColor: 'rgba(148,159,177,1)',
    pointBorderColor: '#fff',
    pointHoverBackgroundColor: '#fff',
    pointHoverBorderColor: 'rgba(148,159,177,0.8)'
  },
  { // dark grey
    backgroundColor: 'rgba(77,83,96,0.2)',
    borderColor: 'rgba(77,83,96,1)',
    pointBackgroundColor: 'rgba(77,83,96,1)',
    pointBorderColor: '#fff',
    pointHoverBackgroundColor: '#fff',
    pointHoverBorderColor: 'rgba(77,83,96,1)'
  },
  { // grey
    backgroundColor: 'rgba(148,159,177,0.2)',
    borderColor: 'rgba(148,159,177,1)',
    pointBackgroundColor: 'rgba(148,159,177,1)',
    pointBorderColor: '#fff',
    pointHoverBackgroundColor: '#fff',
    pointHoverBorderColor: 'rgba(148,159,177,0.8)'
  }
];
public lineChartLegend:boolean = true;
public lineChartType:string = 'line';

public randomize():void {
  let _lineChartData:Array<any> = new Array(this.lineChartData.length);
  for (let i = 0; i < this.lineChartData.length; i++) {
    _lineChartData[i] = {data: new Array(this.lineChartData[i].data.length), label: this.lineChartData[i].label};
    for (let j = 0; j < this.lineChartData[i].data.length; j++) {
      _lineChartData[i].data[j] = Math.floor((Math.random() * 100) + 1);
    }
  }
  this.lineChartData = _lineChartData;
}

// events
public chartClicked(e:any):void {
  console.log(e);
}

public chartHovered(e:any):void {
  console.log(e);
}
}

