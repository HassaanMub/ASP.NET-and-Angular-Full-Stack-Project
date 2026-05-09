import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { RouteReuseStrategy } from '@angular/router';
import { App } from './app/app';
import { routes } from './app/app.routes';
import { appConfig } from './app/app.config';

bootstrapApplication(App, appConfig);
// bootstrapApplication(App, {
//   providers: [
//     provideRouter(routes),
//     provideHttpClient()
//   ]
// });

// import { bootstrapApplication } from '@angular/platform-browser';
// import { App } from './app/app';
// import { provideHttpClient } from '@angular/common/http';

// bootstrapApplication(App, {
//   providers: [provideHttpClient()]
// });