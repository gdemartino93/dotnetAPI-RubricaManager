import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginRequest } from 'src/app/models/authModels/auth';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  constructor(private auth : AuthService,
              private fb : FormBuilder,
              private router : Router) { }

  formLogin = this.fb.group({
    'username' : ['',Validators.required],
    'password' : ['',Validators.required]
  });
  login(){
    const loginRequest : LoginRequest = {
      username : this.formLogin.value.username as string,
      password : this.formLogin.value.password as string,
    }
      this.auth.login(loginRequest).subscribe(
        response => {
          console.log("Login avvenuto con successo", response);
          const token= response.result.token;
          localStorage.setItem("token",token);
          this.router.navigate(['']);
        }
      )
    }


  }

