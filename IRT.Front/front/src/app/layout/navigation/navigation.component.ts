import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { MenuService } from '../menu/menuService';
import { TokenStorageService } from 'src/app/auth/services/token-storage.service';
import { navItems } from "../menu/menu-item";
import { NavItem } from '../menu/menu-list-item.model';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit{ 
  navItems: NavItem[] = navItems;
  currentUser: any;
  
  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver,
    private navService: MenuService,
    private tokenStorageService: TokenStorageService) {}

  ngOnInit(): void {
    this.currentUser = this.tokenStorageService.getUser();
  }

  logout(): void {
    this.tokenStorageService.signOut();    
    window.location.href = '/';
  }
}
