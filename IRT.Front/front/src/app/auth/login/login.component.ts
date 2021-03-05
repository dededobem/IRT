import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { TokenStorageService } from '../services/token-storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form: any = {
    login: null,
    password: null
  }
  isLoading = false;
  isLoggedIn = false;
  isLoginFailed = false;
  errorMessage = '';

  constructor(private authService: AuthService, 
    private tokenStorageService: TokenStorageService,
    private route: Router) { }

  ngOnInit(): void {
    if(this.tokenStorageService.getToken()){
      this.isLoggedIn = true;      
    }
  }

  onSubmit(): void {
    this.isLoading = true;
    const { login, password } = this.form;

    this.authService.login(login, password).subscribe(res => {
      this.tokenStorageService.saveToken(res.token);
      this.tokenStorageService.saveUser(res);

      this.isLoginFailed = false;
      this.isLoggedIn = true;

      window.location.href = '/dashboard';
    },
      err => {
        this.errorMessage = err.error.message;
        this.isLoading = false;
        this.isLoginFailed = true;
      }
    );
  }

  reloadPage(): void {
    window.location.reload();
  }

}
