import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { VehicleList } from '../../components/vehicle-list/vehicle-list';

import { Vehicle } from '../../models/vehicle';
import { VehicleService } from '../../services/vehicle';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule, FormsModule, VehicleList],
  templateUrl: './products.html',
  styleUrls: ['./products.css']
})
export class Products implements OnInit {

  vehicles: Vehicle[] = [];
  filteredVehicles: Vehicle[] = [];
  viewMode: 'grid' | 'list' = 'grid';
  brandFilter: string = '';
  modelFilter: string = '';
  fuelFilter: string = '';
  colorFilter: string = '';
  minYear: number | null = null;
  maxYear: number | null = null;
  minPrice: number | null = null;
  maxPrice: number | null = null;
  minMileage: number | null = null;
  maxMileage: number | null = null;

  constructor(private vehicleService: VehicleService, private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.vehicleService.getVehicles().subscribe(data => {
      this.vehicles = data;
      this.filteredVehicles = data;
      this.cdr.detectChanges();
    });

  }

  applyFilters(): void {
    this.filteredVehicles = this.vehicles.filter(vehicle => {
      const brandMatch = vehicle.brand.toLowerCase().includes(this.brandFilter.toLowerCase());
      const modelMatch = vehicle.model.toLowerCase().includes(this.modelFilter.toLowerCase());
      const fuelMatch = vehicle.fuelType.toLowerCase().includes(this.fuelFilter.toLowerCase());
      const colorMatch = vehicle.color.toLowerCase().includes(this.colorFilter.toLowerCase());
      const minYearMatch = this.minYear === null || vehicle.year >= this.minYear;
      const maxYearMatch = this.maxYear === null || vehicle.year <= this.maxYear;
      const minPriceMatch = this.minPrice === null || vehicle.price >= this.minPrice;
      const maxPriceMatch = this.maxPrice === null || vehicle.price <= this.maxPrice;
      const minMileageMatch = this.minMileage === null || vehicle.mileage >= this.minMileage;
      const maxMileageMatch = this.maxMileage === null || vehicle.mileage <= this.maxMileage;
      return (
        brandMatch &&
        modelMatch &&
        fuelMatch &&
        colorMatch &&
        minYearMatch &&
        maxYearMatch &&
        minPriceMatch &&
        maxPriceMatch &&
        minMileageMatch &&
        maxMileageMatch
      );
    });
  }
  setGridView(): void { this.viewMode = 'grid'; }
  setListView(): void { this.viewMode = 'list'; }
}

// import { Component } from '@angular/core';
// import { CommonModule } from '@angular/common';

// import { VehicleList } from '../../components/vehicle-list/vehicle-list';

// @Component({
//   selector: 'app-products',
//   standalone: true,
//   imports: [CommonModule, VehicleList],
//   templateUrl: './products.html',
//   styleUrls: ['./products.css']
// })
// export class Products {

// }