import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Routing
import { ComponentsRoutingModule } from './components-routing.module';

//Pages
import { HomeComponent } from './pages/home/home.component';
import { HeaderComponent } from './shared/header/header.component';
import { FooterComponent } from './shared/footer/footer.component';

//Materials
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTableModule} from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';


@NgModule({
  declarations: [
    HomeComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    ComponentsRoutingModule,
    MatToolbarModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule
  ]
})
export class ComponentsModule { }
