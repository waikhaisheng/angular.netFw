import { Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { ActivatedRoute, Router } from '@angular/router';

import { SmartTableData } from '../../../@core/data/smart-table';
import { retryWhen, delay, tap } from 'rxjs/operators';

@Component({
  selector: 'ngx-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  settings = {
    add: {
      addButtonContent: '<i class="nb-plus"></i>',
      createButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
      confirmCreate: true,
    },
    edit: {
      editButtonContent: '<i class="nb-edit"></i>',
      saveButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
      confirmSave: true,
    },
    delete: {
      deleteButtonContent: '<i class="nb-trash"></i>',
      confirmDelete: true,
    },
    columns: {
      CustomerID: {
        title: 'ID',
        type: 'string',
        editable: false,
      },
      customerName: {
        title: 'Name',
        type: 'string',
      },
      customerPhone: {
        title: 'Phone',
        type: 'string',
      },
      customerEmail: {
        title: 'Email',
        type: 'string',
      },
      customerAddress: {
        title: 'Address',
        type: 'string',
      },
      customerMailingAddress: {
        title: 'Mailing Address',
        type: 'string',
      },
    },
  };

  source: LocalDataSource = new LocalDataSource();

  nbAlertShow: boolean = false;
  nbAlertStatus: string = "";
  nbAlertMsg: string = "";
  private _userToken: string;

  constructor() { }

  ngOnInit(): void {
  }

  onDeleteConfirm(event): void {
    
  }

  onCreateConfirm(event):void {
    
  }

  onEditConfirm(event):void {
    
  }
}
