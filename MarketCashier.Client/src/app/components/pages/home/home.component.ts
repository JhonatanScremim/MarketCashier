import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';

//Materials
import {MatTableModule} from '@angular/material/table';

export interface PeriodicElement {
  name: string;
  position: number;
  price: number;
  barcode: number;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468},
  {position: 1, name: 'Arroz', price: 1.50, barcode: 1532468}
];

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent implements OnInit {

  displayedColumns: string[] = ['position', 'name', 'price', 'barcode', 'actions'];
  dataSource = ELEMENT_DATA;

  constructor(
    private authService: AuthService
  ) { }

  ngOnInit(): void {
  }

}
