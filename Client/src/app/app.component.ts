import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'Welcome to MeowBook';
  users: any;
  errorMsg = '';

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get("https://localhost:5001/api/users").subscribe({
      next: response => this.users = response,
      error: () => this.errorMsg = "An internal error occured!",
      complete: () => console.log("Request completed")
    });
  }
}
