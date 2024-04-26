import { Component, Inject, OnInit } from "@angular/core";
import { ProductElement } from "../../pages/home/home.component";

import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";

@Component({
  selector: "app-modal-create",
  templateUrl: "./modal-create.component.html",
  styleUrls: ["./modal-create.component.scss"],
})
export class ModalCreateComponent implements OnInit {
  model!: ProductElement;
  isChange!: boolean;

  constructor(
    public dialogRef: MatDialogRef<ModalCreateComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ProductElement
  ) {}

  ngOnInit(): void {
    if (this.data.id != null) {
      this.isChange = true;
    } else {
      this.isChange = false;
    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
