import { Component, OnInit, ViewChild } from "@angular/core";
import { AuthService } from "src/app/core/services/auth.service";
import { ProductService } from "src/app/core/services/product.service.service";

//Materials
import { MatTable, MatTableModule } from "@angular/material/table";
import { MatDialog } from "@angular/material/dialog";
import { ModalCreateComponent } from "../../shared/modal-create/modal-create.component";

export interface ProductElement {
  id: number;
  name: string;
  brand: string;
  price: number;
  barCode: number;
}

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"],
})
export class HomeComponent implements OnInit {
  @ViewChild(MatTable)
  table!: MatTable<any>;

  displayedColumns: string[] = ["id", "name", "price", "barcode", "actions"];
  dataSource: any[] = [];
  currentPage: number = 1;
  pageSize: number = 5;

  constructor(
    private authService: AuthService,
    private productService: ProductService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.loadProducts();
  }

  openDialog(model: ProductElement | null): void {
    const dialogRef = this.dialog.open(ModalCreateComponent, {
      data:
        model === null
          ? {
              id: null,
              name: "",
              brand: "",
              price: null,
              barCode: null,
            }
          : {
              id: model.id,
              name: model.name,
              brand: model.brand,
              price: model.price,
              barCode: model.barCode,
            },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result !== undefined) {
        if (this.dataSource.map((x) => x.id).includes(result.id)) {
          this.dataSource[result.id - 1] = result;
        } else {
          this.productService.createProduct(result).subscribe((data: ProductElement) => {
            this.dataSource.push(result);
            this.table.renderRows(); //Irá renderizar novamente a tabela após inserir o novo produto na lista
          })
        }
      }
    });
  }

  loadProducts(): void {
    this.productService.getProducts(this.currentPage, this.pageSize).subscribe({
      next: (data) => {
        console.log(data.items);
        this.dataSource = data.items;
        // Aqui você pode também atualizar as informações de paginação, como total de páginas, etc.
      },
      error: (error) => {
        console.error("There was an error!", error);
      },
    });
  }

  deleteElement(id: number): void {
    this.dataSource = this.dataSource.filter((x) => x.id !== id);
  }

  editElement(element: ProductElement): void {
    this.openDialog(element);
  }
}
