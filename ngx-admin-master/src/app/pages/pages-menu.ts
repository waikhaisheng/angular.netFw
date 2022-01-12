import { NbMenuItem } from '@nebular/theme';

export const MENU_ITEMS: NbMenuItem[] = [
  {
    title: 'Entities',
    icon: 'layout-outline',
    children: [
      {
        title: 'CustomerProfile',
        link: '/pages/entities/smart-table-customer-profile',
      },
    ],
  },
];
