import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterLink, RouterLinkActive],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'angular';
  toggleNavbar(){
    const navbar = document.querySelector('.navbar-collapse') as HTMLElement;
    if (navbar) {
      navbar.classList.toggle('show');
    }
  }
}
