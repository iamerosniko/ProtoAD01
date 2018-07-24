import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css']
})
export class SideNavComponent implements OnInit {

  constructor() { }
  
  ngOnInit() {
  //reactiveforms na ang laman ng forms na ito ay forms na kamukha ng nasa bawat component
  // return this.fb.group({
  //   region:[name],
  //   'firmDemographics':[0,Validators.required],
  //   'tab2': [0,Validators.required ],
  //   'tab3': [0, Validators.required ],
  //   'tab4': [0,Validators.required ],
  //   'tab5': [0,Validators.required],
  // });
  }

}
