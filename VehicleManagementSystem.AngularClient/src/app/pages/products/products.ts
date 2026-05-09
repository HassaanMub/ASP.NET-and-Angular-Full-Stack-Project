import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VehicleList } from '../../components/vehicle-list/vehicle-list';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule, VehicleList],
  templateUrl: './products.html',
  styleUrls: ['./products.css']
})
export class Products {

}