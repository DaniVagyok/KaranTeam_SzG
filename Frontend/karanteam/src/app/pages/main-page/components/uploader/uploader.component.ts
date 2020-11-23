import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'karanteam-uploader',
  templateUrl: './uploader.component.html',
  styleUrls: ['./uploader.component.scss']
})
export class UploaderComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<UploaderComponent>,
  ) { }

  ngOnInit(): void {
  }

}
