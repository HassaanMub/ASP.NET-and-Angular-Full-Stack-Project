import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { Vehicle } from '../../models/vehicle';

@Component({
  selector: 'app-vehicle-list',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './vehicle-list.html',
  styleUrls: ['./vehicle-list.css']
})
export class VehicleList {
  @Input() vehicles: Vehicle[] = [];
  @Input() viewMode: 'grid' | 'list' = 'grid';
}