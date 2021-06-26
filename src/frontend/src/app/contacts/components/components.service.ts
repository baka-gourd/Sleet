import { Injectable } from '@angular/core';
import { Component } from '../../../services/openapi/models/Component'
import { Observable, of } from 'rxjs';
const COMPONENTS = [
  { name: "114" },
  { name: "514" },
  { name: "1919" }
];

@Injectable({
  providedIn: 'root'
})
export class ComponentsService {

  constructor() { }

  getComponents(): Observable<Component[]> {
    return of(COMPONENTS);
  }
}
