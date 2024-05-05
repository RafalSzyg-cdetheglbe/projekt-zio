import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [ButtonModule, DialogModule],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent {

  public visible: boolean = false;
  
  showDialog(){
    this.visible = true
  }

  closeDialog(){
    this.visible = false
  }
}
