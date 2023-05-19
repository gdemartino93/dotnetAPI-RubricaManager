import { CanActivateFn } from '@angular/router';

export const adminGuard: CanActivateFn = (route, state) => {
 const token = localStorage.getItem('token');
 return token ? true : false;
};
