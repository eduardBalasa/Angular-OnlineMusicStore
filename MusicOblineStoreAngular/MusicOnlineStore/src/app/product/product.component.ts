import { Component, OnInit } from "@angular/core";
import { GuitarsTypes } from "../models/guitars";
import { DrumsTypes } from "../models/drums";
import { OrchestrateTypes } from "../models/orchestrate";
import { MicrophonesTypes } from "../models/microphones";
import { ProductsService } from "../services/products.service";
import { GuitarsTypesService } from '../services/guitars.service';
import { DrumsTypesService } from '../services/drums.service';
import { OrchestrateTypesService } from '../services/orchestrate.service';
import { MicrophonesTypesService } from '../services/microphones.service';

@Component({
  selector: "app-product",
  templateUrl: "./product.component.html",
  styleUrls: ["./product.component.css"]
})
export class ProductComponent implements OnInit {
  guitars: GuitarsTypes[];
  drums: DrumsTypes[];
  orchestrate: OrchestrateTypes[];
  microphones: MicrophonesTypes[];

  constructor(private productService: ProductsService,
              private guitarService: GuitarsTypesService,
              private drumsService: DrumsTypesService,
              private orchestrateService: OrchestrateTypesService,
              private microphoneService: MicrophonesTypesService) {}

  ngOnInit() {
    this.getDrumsTypes();
    this.getGuitarsTypes();
    this.getMicrophonesTypes();
    this.getOrchestrateTypes();
  }

  getGuitarsTypes() {
    this.guitarService.getGuitarsTypes().subscribe(res => {
      this.guitars = res;
      console.log(this.guitars);
    });
  }

  getDrumsTypes() {
    this.drumsService.getDrumsTypes().subscribe(res => {
      this.drums = res;
      console.log(this.drums);
    });
  }

  getMicrophonesTypes() {
    this.microphoneService.getMicrophonesTypes().subscribe(res => {
      this.microphones = res;
      console.log(this.microphones);
    });
  }

  getOrchestrateTypes() {
    this.orchestrateService.getOrchestrateTypes().subscribe(res => {
      this.orchestrate = res;
      console.log(this.orchestrate);
    });
  }
}
