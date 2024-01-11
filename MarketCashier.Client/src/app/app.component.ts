import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `<a [routerLink]="['login']">login</a>
  <router-outlet></router-outlet>
  `,
})
export class AppComponent {

}
