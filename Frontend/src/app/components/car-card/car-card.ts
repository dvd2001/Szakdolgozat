import { Component, Input } from '@angular/core';
import { Car } from '../../models/Car';

@Component({
  selector: 'app-car-card',
  imports: [],
  templateUrl: './car-card.html',
  styleUrl: './car-card.css',
})
export class CarCard {
  @Input() car?: Car;
}
