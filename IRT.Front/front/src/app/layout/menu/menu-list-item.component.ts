import { trigger, state, style, transition, animate } from "@angular/animations";
import { Component, HostBinding, Input, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { NavItem } from "./menu-list-item.model";
import { MenuService } from "./menuService";

@Component({
    selector: 'app-menu-list-item',
    templateUrl: './menu-list-item.component.html',
    styleUrls: ['./menu-list-item.component.css'],
    animations: [
      trigger('indicatorRotate', [
        state('collapsed', style({transform: 'rotate(0deg)'})),
        state('expanded', style({transform: 'rotate(180deg)'})),
        transition('expanded <=> collapsed',
          animate('225ms cubic-bezier(0.4,0.0,0.2,1)')
        ),
      ])
    ],
  })
  export class MenuListItemComponent implements OnInit {
    expanded = false;    
    ariaExpanded = this.expanded;
    
    @Input() item: NavItem = {
        displayName: '',
        iconName: ''
    };
    
    @Input() depth = 0;
 
    constructor(public menuService: MenuService,
        public router: Router) {
      if (this.depth === undefined) {
        this.depth = 0;
      }
    }
  
    ngOnInit() {
      this.menuService.currentUrl.subscribe((url: string) => {
        if (this.item.route && url) {
          this.expanded = url.indexOf(`/${this.item.route}`) === 0;
          this.ariaExpanded = this.expanded;
        }
      });
    }
  
    onItemSelected(item: NavItem) {     
      if (!item.children || !item.children.length) {
        this.router.navigate([item.route]);
      }
      if (item.children && item.children.length) {
        this.expanded = !this.expanded;
      }
    }    
  }