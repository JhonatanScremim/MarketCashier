import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/guard/auth.guard';

const routes: Routes = [
  {
    path: 'login',
    loadChildren: () => import('./core/components/auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: '',
    canActivateChild: [AuthGuard],
    loadChildren: () => import('./components/components.module').then((m) => m.ComponentsModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
