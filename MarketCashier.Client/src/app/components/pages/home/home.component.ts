import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';

//Materials
import {MatTable, MatTableModule} from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { ModalCreateComponent } from '../../shared/modal-create/modal-create.component';

export interface ProductElement {
  id: number;
  name: string;
  brand: string;
  price: number;
  barcode: number;
}

const ELEMENT_DATA: ProductElement[] = [
  {id: 1, name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {id: 2, name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {id: 3, name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {id: 4, name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {id: 5, name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {id: 6, name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {id: 7, name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {id: 8, name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {id: 1, name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {id: 1, name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {id: 1, name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {id: 1, name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {id: 1, name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {id: 1, name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {id: 1, name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {id: 1, name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {id: 1, name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {id: 1, name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468},
  {id: 1, name: 'Arroz', brand: 'Buriti', price: 1.50, barcode: 1532468}
];

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})

export class HomeComponent implements OnInit {

  @ViewChild(MatTable)
  table!: MatTable<any>;

  displayedColumns: string[] = ['id', 'name', 'price', 'barcode', 'actions'];
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
        id: null,
        name: '',
        brand: '',
        price: null,
        barcode: null
      } : {
        id: model.id,
        name: model.name,
        brand: model.brand,
        price: model.price,
        barcode: model.barcode
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result !== undefined){
        if (this.dataSource.map(x => x.id).includes(result.id)){
          this.dataSource[result.id - 1] = result;
        }
        else{
          this.dataSource.push(result);
        }
        this.table.renderRows(); //Irá renderizar novamente a tabela após inserir o novo produto na lista
      }
    });
  }

  deleteElement(id: number): void{
    this.dataSource = this.dataSource.filter(x => x.id !== id);
  }

  editElement(element: ProductElement): void{
    this.openDialog(element);
  }

}
