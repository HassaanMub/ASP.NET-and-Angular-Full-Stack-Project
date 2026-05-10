import { bootstrapApplication } from '@angular/platform-browser';
import { App } from './app/app';
import { appConfig } from './app/app.config';

bootstrapApplication(App, appConfig);


// Old Data
// import { bootstrapApplication } from '@angular/platform-browser';
// import { provideRouter } from '@angular/router';
// import { provideHttpClient } from '@angular/common/http';
// import { RouteReuseStrategy } from '@angular/router';
// import { App } from './app/app';
// import { routes } from './app/app.routes';
// import { appConfig } from './app/app.config';
// import { Component } from '@angular/core';

// bootstrapApplication(App, appConfig);