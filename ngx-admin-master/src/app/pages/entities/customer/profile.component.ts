import { Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';

import { retryWhen, delay, tap } from 'rxjs/operators';
import { CustomerService } from '../../../@core/services/customer.service';
import { NgAlertStatusEnum } from '../../../@core/enums/ng-alert-status-enum';

@Component({
  selector: 'ngx-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
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
  nbAlertStatus: string = '';
  nbAlertMsg: string = '';

  dangerTimeout: number = 10000;
  successTimeout: number = 2000;
  warningTimeout: number = 30000;

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
          }),
        ),
      ))
    .subscribe((data: any) => {
      const rdata: any[] = data.Result;
      this.source.load(rdata);
      this.showAlert(NgAlertStatusEnum.success, 'Data loaded.', this.successTimeout);
    },
    err => {
      this.showAlert(NgAlertStatusEnum.danger, err, this.dangerTimeout);
    });
  }

  onCreateConfirm(event): void {
    if (window.confirm('Are you sure you want to add?')) {
      let returnMsg = '';
      if (event.newData === null) {
        returnMsg = returnMsg + '[Insert data empty]';
      }
      if (event.newData.Id === '') {
        returnMsg = returnMsg + '[Id empty]';
      }
      if (event.newData.Email === '') {
        returnMsg = returnMsg + '[Email empty]';
      }
      if (event.newData.Address === '') {
        returnMsg = returnMsg + '[Address empty]';
      }
      if (event.newData.MailingAddress === '') {
        returnMsg = returnMsg + '[Mailing Address empty]';
      }
      if (event.newData.Name === '') {
        returnMsg = returnMsg + '[Name empty]';
      }
      if (event.newData.Phone === '') {
        returnMsg = returnMsg + '[Phone empty]';
      }
      if (!this.validateEmail(event.newData.Email) && event.newData.Email !== '') {
        returnMsg = returnMsg + '[Email invalid]';
      }
      if (!this.validatePhone(event.newData.Phone) && event.newData.Phone !== '') {
        returnMsg = returnMsg + '[Phone invalid]';
      }
      if (returnMsg !== '') {
        this.showAlert(NgAlertStatusEnum.warning, returnMsg, this.warningTimeout);
        return;
      }

      this._customerService.save(event.newData).subscribe((data: any) => {
        this.showAlert(NgAlertStatusEnum.success, 'Data created.', this.successTimeout);
        event.confirm.resolve();
      },
      err => {
        this.showAlert(NgAlertStatusEnum.danger, err, this.dangerTimeout);
      });
    } else {
      event.confirm.reject();
    }
  }

  onEditConfirm(event): void {
    if (window.confirm('Are you sure you want to edit?')) {
      let returnMsg = '';
      if (event.newData === null) {
        returnMsg = returnMsg + '[Insert data empty]';
      }
      if (event.newData.Id === '') {
        returnMsg = returnMsg + '[Id empty]';
      }
      if (event.newData.Email === '') {
        returnMsg = returnMsg + '[Email empty]';
      }
      if (event.newData.Address === '') {
        returnMsg = returnMsg + '[Address empty]';
      }
      if (event.newData.MailingAddress === '') {
        returnMsg = returnMsg + '[Mailing Address empty]';
      }
      if (event.newData.Name === '') {
        returnMsg = returnMsg + '[Name empty]';
      }
      if (event.newData.Phone === '') {
        returnMsg = returnMsg + '[Phone empty]';
      }
      if (!this.validateEmail(event.newData.Email) && event.newData.Email !== '') {
        returnMsg = returnMsg + '[Email invalid]';
      }
      if (!this.validatePhone(event.newData.Phone) && event.newData.Phone !== '') {
        returnMsg = returnMsg + '[Phone invalid]';
      }
      if (returnMsg !== '') {
        this.showAlert(NgAlertStatusEnum.warning, returnMsg, this.warningTimeout);
        return;
      }

      const newData = event.newData;
      newData.Id = event.data.Id;
      this._customerService.edit(newData).subscribe((data: any) => {
        this.showAlert(NgAlertStatusEnum.success, 'Data edited.', this.successTimeout);
        event.confirm.resolve();
      },
      err => {
        this.showAlert(NgAlertStatusEnum.danger, err, this.dangerTimeout);
      });
    } else {
      event.confirm.reject();
    }
  }

  onDeleteConfirm(event): void {
    if (window.confirm('Are you sure you want to delete?')) {
      this._customerService.delete(event.data.Id).subscribe((data: any) => {
        this.showAlert(NgAlertStatusEnum.warning, 'Data deleted.', this.successTimeout);
        event.confirm.resolve();
      },
      err => {
        this.showAlert(NgAlertStatusEnum.danger, err, this.dangerTimeout);
      });
    } else {
      event.confirm.reject();
    }
  }
  private showAlert(nbAlertStatus: NgAlertStatusEnum, msg: any, timeout: number): void {
    this.nbAlertShow = true;
    this.nbAlertStatus = NgAlertStatusEnum[nbAlertStatus];
    this.nbAlertMsg = msg;
    setTimeout(() => {
      this.nbAlertShow = false;
    }, timeout);
  }
  private validateEmail(email) {
    return String(email)
    .toLowerCase()
    .match(
      /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
    );
  }
  private validatePhone(phone) {
    return String(phone)
    .toLowerCase()
    .match(
      /^[+]*[(]{0,1}[0-9]{1,3}[)]{0,1}[-\s\./0-9]*$/g,
    );
  }
}
