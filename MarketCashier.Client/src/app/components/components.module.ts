import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Routing
import { ComponentsRoutingModule } from './components-routing.module';

//Pages
import { HomeComponent } from './pages/home/home.component';
import { HeaderComponent } from './shared/header/header.component';

@NgModule({
  declarations: [
    HomeComponent,
    HeaderComponent
  ],
  imports: [
    CommonModule,
    ComponentsRoutingModule
  ]
})
export class ComponentsModule { }
