
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
      units: ['meter', 'kilometer', 'centimeter', 'milimeter', 'mile', 'yard', 'foot', 'inch'],
    },
    {
      name: 'Mass',
      units: ['ounce', 'gram', 'kilogram', 'miligram'],
    },
    {
      name: 'Temperature',
      units: ['Celsius', 'Kelvin', 'Fahrenhiet'],
    },
    {
      name: 'Volume',
      units: ['cubicfoot', 'cubicmeter', 'liter', 'cubiccentimeter'],
    },
    {
      name: 'Area',
      units: ['squaremeter', 'squarekilometer', 'squarecentimeter', 'squaremilimeter', 'squaremile', 'squareyard', 'squarefoot', 'squareinch', 'hectare', 'acre'],
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
    this.convertedResult = 0;
    this.inputValue = 0;
  }
  onFromUnitChange() {
    this.selectedToUnit = ''; // Reset the "TO" select value when "FROM" select changes
  }

  convertUnits() {
    this.http.get<any>(`http://localhost:5141/conversion/${this.selectedCategory.toLowerCase()}/${this.selectedFromUnit.toLowerCase()}/${this.selectedToUnit.toLowerCase()}/?value=${this.inputValue}`
    ).subscribe(
      {
        next: data => {
          this.convertedResult = data.success ? (data.data.destinationValue ?? -1) : 0;
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
    }
  }
}
