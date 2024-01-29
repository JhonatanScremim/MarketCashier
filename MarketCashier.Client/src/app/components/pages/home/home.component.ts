import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';

//Materials
import {MatTable, MatTableModule} from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { ModalCreateComponent } from '../../shared/modal-create/modal-create.component';

export interface ProductElement {
  name: string;
  brand: string;
  price: number;
  barcode: number;
}

const ELEMENT_DATA: ProductElement[] = [
  {name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468}
];

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent implements OnInit {

  @ViewChild(MatTable)
  table!: MatTable<any>;

  displayedColumns: string[] = ['position', 'name', 'price', 'barcode', 'actions'];
  dataSource = ELEMENT_DATA;

  constructor(
    private authService: AuthService,
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
  }

  openDialog(model: ProductElement | null): void{
    const dialogRef = this.dialog.open(ModalCreateComponent, {
      data: model === null ? {
        name: '',
        brand: '',
        price: null,
        barcode: null
      } : model
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result !== undefined){
        this.dataSource.push(result);
        this.table.renderRows(); //Irá renderizar novamente a tabela após inserir o novo produto na lista
      }
    });
  }

}
