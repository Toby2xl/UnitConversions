// // import { Component } from '@angular/core';

// @Component({
//   selector: 'app-root',
//   templateUrl: './app.component.html',
//   styleUrls: ['./app.component.css']
// })
// export class AppComponent {
//   title = 'conversion-app';
// }

import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

interface UnitCategory {
  name: string;
  units: string[];
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent  implements OnInit {

  constructor(private http: HttpClient) {}
  ngOnInit() {
    this.selectedCategory = '';
    this.selectedFromUnit = '';
    this.selectedToUnit = ''; // Clear the "TO" select value initially
  }


  title: string = 'Unit Converter';
  selectedCategory: string = '';
  selectedFromUnit: string = '';
  selectedToUnit: string = '';
  inputValue: number|undefined ;
  outputResult: string = '';
  convertedResult: number = 0;
  units: UnitCategory[] = [
    {
      name: 'Length',
      units: ['in', 'cm', 'm', 'mm'],
    },
    {
      name: 'Mass',
      units: ['Kilogram', 'Miligram', 'Tonne', 'Gramme'],
    },
    {
      name: 'Temperature',
      units: ['Celcius', 'Kelvin', 'Fahrenhiet'],
    },
    {
      name: 'Volume',
      units: ['mm3', 'cm3'],
    },
    {
      name: 'Area',
      units: ['mm2', 'cm2'],
    },
  ];

  get selectedCategoryUnits(): string[] {
    const category = this.units.find(
      (unitCategory) => unitCategory.name === this.selectedCategory
    );
    return category ? category.units : [];
  }

  onCategoryChange() {
    this.selectedFromUnit = '';
    this.selectedToUnit = '';
  }
  onFromUnitChange() {
    this.selectedToUnit = ''; // Reset the "TO" select value when "FROM" select changes
  }

  convertUnits() {
    this.http.get<any>(`http://localhost:5141/api/conversion/${this.selectedCategory}/${this.selectedFromUnit}/${this.selectedToUnit}/?value=${this.inputValue}`
    ).subscribe(
      {
        next: data => {
          this.convertedResult = data;
        }
      }
    );
  }


  convert() {
    if(this.inputValue === 0 ||
      this.inputValue === null ||
      this.selectedFromUnit === "" ||
      this.selectedToUnit === ""
      ) {
      this.outputResult =  "Check Your inputs again!"
    }else{
      this.convertUnits();
      this.outputResult =  `${this.inputValue}${this.selectedFromUnit} to ${this.selectedToUnit} is ${this.convertedResult}${this.selectedToUnit}`
    }
  }
}
