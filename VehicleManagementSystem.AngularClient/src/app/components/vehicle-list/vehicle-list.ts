import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { Vehicle } from '../../models/vehicle';
import { VehicleService } from '../../services/vehicle';

@Component({
  selector: 'app-vehicle-list',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './vehicle-list.html',
  styleUrls: ['./vehicle-list.css']
})
export class VehicleList implements OnInit {
  vehicles: Vehicle[] = [];
  constructor(
    private vehicleService: VehicleService,
    private cdr: ChangeDetectorRef
  ) {}
  ngOnInit(): void {
    console.log("VehicleList Loaded");
    this.loadVehicles();
  }
  loadVehicles(): void {
    this.vehicleService.getVehicles().subscribe({
      next: (data) => {
        console.log("DATA RECEIVED:", data);
        this.vehicles = data;
        this.cdr.detectChanges();
      },
      error: (err) => {
        console.error(err);
      }
    });
  }
}