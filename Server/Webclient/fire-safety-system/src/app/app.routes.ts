import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'dashboard' },
  { path: 'dashboard', loadChildren: () => import('./pages/dashboard/dashboard.routes').then(m => m.DASHBOARD_ROUTES) },
  { path: 'applications', loadChildren: () => import('./pages/applications/applications.routes').then(m => m.APPLICATIONS_ROUTES) },
  { path: 'inspections', loadChildren: () => import('./pages/inspections/inspections.routes').then(m => m.INSPECTIONS_ROUTES) },
  { path: 'complaints', loadChildren: () => import('./pages/complaints/complaints.routes').then(m => m.COMPLAINTS_ROUTES) }
];
