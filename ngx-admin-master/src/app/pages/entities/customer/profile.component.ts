import { Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';

import { retryWhen, delay, tap } from 'rxjs/operators';
import { CustomerService } from '../../../@core/services/customer.service';
import { NgAlertStatusEnum } from '../../../@core/enums/ng-alert-status-enum';

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
      Id: {
        title: 'ID',
        type: 'string',
        editable: false,
        hide: true,
      },
      Name: {
        title: 'Name',
        type: 'string',
      },
      Phone: {
        title: 'Phone',
        type: 'string',
      },
      Email: {
        title: 'Email',
        type: 'string',
      },
      Address: {
        title: 'Address',
        type: 'string',
      },
      MailingAddress: {
        title: 'Mailing Address',
        type: 'string',
      },
    },
  };

  source: LocalDataSource = new LocalDataSource();

  nbAlertShow: boolean = false;
  nbAlertStatus: string = "";
  nbAlertMsg: string = "";

  constructor(private _customerService: CustomerService) { }

  ngOnInit(): void {
    this._customerService.getCustomerProfile()
    .pipe(
      retryWhen(errors =>
        errors.pipe(
          delay(10000),
          tap(errorStatus => {
            if (!errorStatus.includes('504')) {
              throw errorStatus;
            }
          })
        )
      ))
    .subscribe((data: any) => {
      let rdata: any[] = data.Result;
      this.source.load(rdata);
      this.showAlert(NgAlertStatusEnum.success, "Data loaded.", 2000);
    },
    err => {
      this.showAlert(NgAlertStatusEnum.danger, err, 5000);
    });
  }

  onCreateConfirm(event):void {
    if (window.confirm('Are you sure you want to add?')) {
      this._customerService.save(event.newData).subscribe((data: any) => {
        this.showAlert(NgAlertStatusEnum.success, "Data created.", 2000);
        event.confirm.resolve();
      },
      err => {
        this.showAlert(NgAlertStatusEnum.danger, err, 5000);
      });
    } else {
      event.confirm.reject();
    }
  }

  onEditConfirm(event):void {
    if (window.confirm('Are you sure you want to edit?')) {
      let newData = event.newData;
      newData.shipperID = event.data.Id;
      this._customerService.edit(newData).subscribe((data: any) => {
        this.showAlert(NgAlertStatusEnum.success, "Data edited.", 2000);
        event.confirm.resolve();
      },
      err => {
        this.showAlert(NgAlertStatusEnum.danger, err, 5000);
      });
    } else {
      event.confirm.reject();
    }
  }

  onDeleteConfirm(event): void {
    if (window.confirm('Are you sure you want to delete?')) {
      this._customerService.delete(event.data.Id).subscribe((data: any) => {
        this.showAlert(NgAlertStatusEnum.warning, "Data deleted.", 2000);
        event.confirm.resolve();
      },
      err => {
        this.showAlert(NgAlertStatusEnum.danger, err, 5000);
      });
    } else {
      event.confirm.reject();
    }
  }
  private showAlert(nbAlertStatus: NgAlertStatusEnum, msg: any, timeout: number): void{
    this.nbAlertShow = true;
    this.nbAlertStatus = NgAlertStatusEnum[nbAlertStatus];
    this.nbAlertMsg = msg;
    setTimeout(() => {
      this.nbAlertShow = false;
    }, timeout);
  }
}
