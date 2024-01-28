import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Routing
import { ComponentsRoutingModule } from './components-routing.module';

//Pages
import { HomeComponent } from './pages/home/home.component';

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    ComponentsRoutingModule
  ]
})
export class ComponentsModule { }
