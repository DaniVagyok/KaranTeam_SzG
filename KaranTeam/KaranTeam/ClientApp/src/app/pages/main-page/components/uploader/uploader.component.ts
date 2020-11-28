import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'karanteam-uploader',
  templateUrl: './uploader.component.html',
  styleUrls: ['./uploader.component.scss']
})
export class UploaderComponent implements OnInit {

  fileName: string;
  shopItemUploadForm: FormGroup = new FormGroup({
    title: new FormControl(''),
    description: new FormControl(''),
    imageFile: new FormControl(null),
  });
  constructor(
    public dialogRef: MatDialogRef<UploaderComponent>,
  ) { }

  ngOnInit(): void {
  }

  uploadFile(files: FileList): void {
    if (files.length === 0) {
      return;
    }
    this.fileName = files.item(0).name;
    this.shopItemUploadForm.controls.imageFile.setValue(files.item(0));
  }

  save(): void {
    this.dialogRef.close(this.shopItemUploadForm.value);
  }

  close(): void {
    this.dialogRef.close();
  }
}
