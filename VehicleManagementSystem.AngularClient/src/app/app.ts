import { Component } from '@angular/core';

import { RouterOutlet, RouterLink } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {

}

// import { Component } from '@angular/core';
// import { CommonModule } from '@angular/common';

// import { VehicleList } from './components/vehicle-list/vehicle-list';

// @Component({
//   selector: 'app-root',
//   standalone: true,
//   imports: [CommonModule, VehicleList],
//   templateUrl: './app.html',
//   styleUrl: './app.css'
// })
// export class App {
// }