import { Component, OnInit } from '@angular/core';
import { Navbar } from '../../components/navbar/navbar';
import { NgIf } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home.page',
  imports: [Navbar, NgIf],
  templateUrl: './home.page.html',
  styleUrl: './home.page.css',
})
export class HomePage implements OnInit {

  public isNoContent: boolean = true;
  public carList: any[] = [];

  constructor(private router: Router) { }

  ngOnInit() {
    this.isNoContent = this.carList.length === 0;
  }
}
