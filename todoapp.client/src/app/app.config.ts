import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { apiKeyInterceptor } from './interceptors/api-key.interceptor';

export const appConfig: ApplicationConfig = {
  providers: [provideZoneChangeDetection(),
    provideRouter([]),
    provideHttpClient(
      withInterceptors([apiKeyInterceptor])
    )],
};
