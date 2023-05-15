import { Component } from '@angular/core';
import { User } from './models/user';
import { AuthService } from './services/auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'RubricaManager';
  user =  {} as User;
  constructor(private auth : AuthService){}

  register(){
    this.auth.register(this.user).subscribe();
  }












}
