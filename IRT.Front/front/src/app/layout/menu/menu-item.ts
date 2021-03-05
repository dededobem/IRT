import { NavItem } from './menu-list-item.model';

export var navItems: NavItem[] = [
  {
    displayName: 'Painel',
    iconName: 'dashboard',
    route: '/dashboard'
  },
  {
    displayName: 'Bairros',
    iconName: 'other_houses',
    children: [
      {
        displayName: 'Consultar',
        iconName: '',
        route: '/neighborhood',
      },
      {
        displayName: 'Adicionar',
        iconName: '',
        route: '/neighborhood/add',
      }
    ]
  },
  {
    displayName: 'Farmácias',
    iconName: 'health_and_safety',
    children: [
      {
        displayName: 'Consultar',
        iconName: '',
        children: [
          {
            displayName: 'Por nome',
            iconName: '',
            route: '/drugstore/by-name',
          },
          {
            displayName: 'Por bairro',
            iconName: '',
            route: '/drugstore/by-neighborhood',
          }
        ]
      },
      {
        displayName: 'Adicionar',
        iconName: '',
        route: '/drugstore/add',
      }
    ]
  },
]; 
