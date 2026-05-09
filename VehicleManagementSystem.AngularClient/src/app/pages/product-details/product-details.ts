import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Vehicle } from '../../models/vehicle';
import { VehicleService } from '../../services/vehicle';

@Component({
  selector: 'app-product-details',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './product-details.html',
  styleUrls: ['./product-details.css']
})
export class ProductDetails implements OnInit {

  // vehicle?: Vehicle;
  vehicle: Vehicle | null = null;

  constructor(
    private route: ActivatedRoute,
    private vehicleService: VehicleService,
    private cdr: ChangeDetectorRef
  ) {}
  ngOnInit(): void {

  this.route.paramMap.subscribe(params => {

    const id = Number(params.get('id'));

    this.vehicle = null;

    this.vehicleService.getVehicleById(id).subscribe(data => {

      this.vehicle = data;

      this.cdr.detectChanges(); // 🔥 FORCE UI REFRESH

    });

  });

}
}
//   ngOnInit(): void {
//   this.route.paramMap.subscribe(params => {
//     const id = Number(params.get('id'));
//     console.log("NEW ROUTE ID:", id);
//     this.vehicle = null; // IMPORTANT reset state
//     this.vehicleService.getVehicleById(id).subscribe(data => {
//       this.vehicle = data;
//       console.log("LOADED VEHICLE:", data);
//     });
//   });
// }
  // ngOnInit(): void {
  //   this.route.paramMap.subscribe(params => {
  //     const id = Number(params.get('id'));
  //     this.vehicleService.getVehicleById(id).subscribe(data => {
  //       this.vehicle = data;
  //     });
  //   });
  // }
  // ngOnInit(): void {
  //   const id = Number(this.route.snapshot.paramMap.get('id'));
  //   this.vehicleService.getVehicleById(id).subscribe(data => {
  //     console.log("All vehicles:", data);
  //     console.log("Route ID:", id);
  //     this.vehicle = data;
  //     console.log("Selected vehicle:", this.vehicle);
  //   });
  // }
// this.vehicleService.getVehicles().subscribe(data => {
//   this.vehicle = data.find(v => Number(v.id) === id);
// });