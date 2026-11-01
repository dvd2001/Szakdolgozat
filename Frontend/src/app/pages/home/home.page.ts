import { Component, OnInit } from '@angular/core';
import { Navbar } from '../../components/navbar/navbar';
import { NgIf, NgFor } from '@angular/common';
import { Router } from '@angular/router';
import { CarCard } from '../../components/car-card/car-card';

@Component({
  selector: 'app-home.page',
  imports: [Navbar, NgIf, NgFor, CarCard],
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
