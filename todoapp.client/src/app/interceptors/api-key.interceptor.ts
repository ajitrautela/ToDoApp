import { HttpInterceptorFn } from '@angular/common/http';

export const apiKeyInterceptor: HttpInterceptorFn = (req, next) => {
  // For this demo, we're using a hardcoded API key to authenticate requests to the backend API.
  // In a real application, you would typically retrieve this key from a secure storage or environment variable.
  const apiKey = '6CBxzdYcEgNDrRhMbDpkBF7e4d4Kib46dwL9ZE5egiL0iL5Y3dzREUBSUYVUwUkN';

  const cloned = req.clone({
    setHeaders: {
      'x-api-token': apiKey
    }
  });

  return next(cloned);
};
