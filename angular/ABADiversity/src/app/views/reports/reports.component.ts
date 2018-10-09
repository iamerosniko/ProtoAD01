import { Component, OnInit } from '@angular/core';
import { CompanyProfiles,Firms,Years,FirmDemographics } from '../../entities/entities';
import { SurveyService } from '../../services/survey.service';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { isNumber } from 'util'; 

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {
  mainList:Firms[]=[];
  firmList:Firms[]=[];
  firmCategory:string[]=[
    'All',
    'Overall Firm Demographics',
    'Firm Leadership/Management Demographic Profile',
    'Number of Promotions from Associate to Partner',
    'Lawyers Who Left The Firm',
    'Hires',
    'Lawyers Working Reduced Hours Schedule',
    'Top 10% Highest Compensated Partners',
    'Undertaken Initiatives/Actions'
    ]
  firmCategoryMode:number[]=[]
  reportType:string[]=[
    'Race vs Role',
    'Race Across the Position',
    'Position Across the Race'
  ]
  reportTypeRaceVsRole:string[]=[
    'Equity Partners',
    'Non-Equity Partners',
    'Associates',
    'Counsel',
    'Other Lawyers',
    'Total'
  ]
  items:string[]=
  [
    'African American/Black(not Hispanic/Latino)',
    'Hispanic/Latino',
    'Alaska Native/American Indian',
    'Asian',
    'Native Hawaiian/Other Pacific Islander',
    'Multiracial',
    'White',
    'LGBT',
    'Disabled',
    'Women',
    'Men'
  ]
  selectedFirm:string="0";
  selectedFirmID:string="0";
  selectedFirmData:string[]=[];
  selectedCategory:string="0";
  selectedCategoryMode:number=0;
  selectedBaseSurveyYear:string;
  baseSurveyYear:string="";
  selectedTopSurveyYear:string;
  topSurveyYear:string="";
  selectedReportType:string="0";
  years:Years[]=[];
  rate:string[]=[""];

  topSurveyYearTest:string[]=["2016"];
  baseSurveyYearTest:string[]=["2017"];

  myForm: FormGroup;
  firmDemographics:FirmDemographics[]=[]
  firmDemoassign:string[]=['EquityPartners','NonEquityPartners','Associates','Counsel','OtherLawyers','Totals']

  async getFirms(){
    this.mainList = <Firms[]> await this.surveySvc.getFirms();
    this.firmList = this.mainList;
  }
  updateCategoryMode(){
    // console.log(this.selectedCategory)
    if (this.selectedCategory == "Overall Firm Demographics"){
      this.selectedCategoryMode = 2
    } 
    if (this.selectedCategory == "Firm Leadership/Management Demographic Profile"){
      this.selectedCategoryMode = 3
    } 
    if (this.selectedCategory == "Number of Promotions from Associate to Partner"){
      this.selectedCategoryMode = 4
    }
    if (this.selectedCategory == "Lawyers Who Left The Firm"){
      this.selectedCategoryMode = 5
    }
    if (this.selectedCategory == "Hires"){
      this.selectedCategoryMode = 6
    }
    if (this.selectedCategory == "Lawyers Working Reduced Hours Schedule"){
      this.selectedCategoryMode = 7
    }
    if (this.selectedCategory == "Top 10% Highest Compensated Partners"){
      this.selectedCategoryMode = 8
    }
    if (this.selectedCategory == "Undertaken Initiatives/Actions"){
      this.selectedCategoryMode = 9
    }
    console.log(this.selectedCategoryMode)
  }
  async updateSelectedFirm(){
    console.log("meme")
    this.selectedFirmID = this.selectedFirm  
    console.log(this.selectedFirm)
    console.log(this.selectedFirmID)
    console.log(this.selectedCategoryMode)
    this.selectedFirmData = await this.surveySvc.getSurveys(this.selectedFirm);
    console.log(this.selectedFirmData)
    // this.selectedFirmData = this.selectedFirmData.forEach()
    console.log("uyou")
    this.updateSelectedBaseSurveyYear(this.selectedFirmID)
  }
  async updateSelectedBaseSurveyYear(firmID:string){
    // this.selectedFirm = firmID
    var companyProfiles =<CompanyProfiles[]> await this.surveySvc.getYears(firmID);
    this.years=await [];
    companyProfiles.forEach(async element => {
      this.years.push(
        {
          companyProfileID : element.companyProfileID,
          year : this.getYear(element.datecomp)
          // push to different array
        })
    });
  }
  getYear(dateComp : any):number{
    var a =  new Date(dateComp).getFullYear();
    return a;
  }
  async updateBaseSurveyYear(){
    this.baseSurveyYear = await this.surveySvc.getSurvey(this.selectedBaseSurveyYear,this.selectedCategoryMode);
    console.log(this.baseSurveyYear)
  }
  async updateTopSurveyYear(){
    this.topSurveyYear = await this.surveySvc.getSurvey(this.selectedTopSurveyYear,this.selectedCategoryMode);
    console.log(this.topSurveyYear)
  }
  genReport(){
    console.log("genReport")
    console.log("Firm ID")
    console.log(this.selectedFirmID)
    console.log("Category Mode")
    console.log(this.selectedCategoryMode+ "" + this.selectedCategory)
    console.log("Report Type")
    console.log(this.selectedReportType)
    console.log("Base Survey Year")
    console.log(this.selectedBaseSurveyYear)
    console.log("Top Survey Year")
    console.log(this.selectedTopSurveyYear)
  }
  initializeForm(){
    this.myForm = this.fb.group
    ({
      regions: this.fb.array([]),
    })
    this.addRow();
    // this.updateChildFormToParent.emit(this.myForm)

    this.myForm.valueChanges.subscribe(()=>{
      // this.updateChildFormToParent.emit(this.myForm)
      const control = <FormArray>this.myForm.controls['regions'];
      for(var i =0;i<control.length;i++){
        const demographics =<FormGroup> control.at(i);

        // this.firmDemoassign.forEach(element => {
        //   if(element!='Totals'){
        //     if(demographics.controls[element].invalid){
        //       demographics.controls[element].setValue(0)
        //     }
        //   }
        // });


      }
    })
  }
  addRow(){
    //1.get the value of formarray that has name regions
    // this.myForm = this.fb.group({
    //   regions: this.fb.array([])    < -- eto un
    // })
    const control = <FormArray>this.myForm.controls['regions'];

    //2.since walang laman ung nakuha nyang formarray.. lalagyan nya un syempre
    
    //loop items to element 
    //ung items un ung mga name sa unang column ng form na ginawa ko 
    this.items.forEach(element => {
      control.push(this.initItems(element));
    });
    
  }
  initItems(name:string): FormGroup{
    var fd = this.firmDemographics.find(x=>x.regionName==name);
      return this.fb.group({
        // 'companyProfileID': [this.companyProfileID,Validators.required],
        // firmDemographicID:[UUID.UUID(),Validators.required],
        regionName:[name],
        'EquityPartners':[fd.equityPartners],
        'NonEquityPartners': [fd.nonEquityPartners],
        'Associates': [fd.associates],
        'Counsel': [fd.counsel],
        'OtherLawyers': [fd.otherLawyers],
      });
    
    // Here, we make the form for each day
  }
  compute(index : number){
    const control = <FormArray>this.myForm.controls['regions'];
    const formb=<FormGroup>control.at(index)
    var value:number=0;
   
      this.firmDemoassign.forEach(element => {
        if(element!='Totals'){
          var a =+formb.controls[element].value
       
          value=value + ((a==null)||!isNumber(a)?0:a)
        }
      });
    return value;
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
  constructor(private surveySvc : SurveyService,  private fb:FormBuilder) { }

  async ngOnInit() {
    await this.getFirms();
    this.initializeForm()
  }
// lineChart
public lineChartData:Array<any> = [
  {data: [28, 25], label: '2017'},
  {data: [30, 48], label: '2018'}
];
public lineChartLabels:Array<any> = ['2017','2018'];
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

