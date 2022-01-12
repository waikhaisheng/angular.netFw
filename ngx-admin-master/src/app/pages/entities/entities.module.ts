import { NgModule } from '@angular/core';
import { NbCardModule, NbIconModule, NbInputModule, NbTreeGridModule, NbAlertModule } from '@nebular/theme';
import { Ng2SmartTableModule } from 'ng2-smart-table';

import { ThemeModule } from '../../@theme/theme.module';
import { EntitiesRoutingModule, routedComponents } from './entities-routing.module';
import { ProfileComponent } from './customer/profile.component';

@NgModule({
  imports: [
    NbCardModule,
    NbTreeGridModule,
    NbIconModule,
    NbInputModule,
    ThemeModule,
    EntitiesRoutingModule,
    Ng2SmartTableModule,
    NbAlertModule,
  ],
  declarations: [
    ...routedComponents,
    ProfileComponent,
  ],
})
export class EntitiesModule { }
