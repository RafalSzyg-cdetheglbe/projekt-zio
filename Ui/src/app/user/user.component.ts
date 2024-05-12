import { Component, EventEmitter, Output } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [ButtonModule, DialogModule,FormsModule, CommonModule],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent {
  public visible: boolean = false;
  private readonly URL = "https://localhost:7013/api/Users/login";
  @Output() userIdEmitter: EventEmitter<number> = new EventEmitter<number>();
  
  username :string ="";
  password : string ="";
  bledneDaneLogowania: boolean = false;

  constructor(private httpClient: HttpClient){}
  
  showDialog() {
    this.visible = true
  }

  closeDialog() {
    this.visible = false
  }

  signIn() {
    if (this.username && this.password) {
      this.httpClient.get<any>(this.URL, {
        params: {
          login: this.username,
          password: this.password
        }
      }).subscribe(
        response => {
          if(response === undefined)
            this.bledneDaneLogowania = true;
          else{
            this.userIdEmitter.emit(response);
            this.bledneDaneLogowania = false;
            this.visible = false;
          }
        }
      );
    } else {
      this.bledneDaneLogowania = true;
    }
    this.username = "";
    this.password ="";
  }
}
