import { Component, ChangeDetectorRef, OnDestroy } from "@angular/core";
import { Router } from "@angular/router";
import { User } from "./models/user";
import { AuthenticationService } from "./services/authentication.service";
import { Role } from "./models/role";
import { MediaMatcher } from "@angular/cdk/layout";
import { CategoryService } from './services/category.service';
import { Category } from './models/category';

@Component({
  selector: "app-root",
  templateUrl: "app.component.html",
  styleUrls: ["app.component.css"]
})
export class AppComponent implements OnDestroy {
  currentUser: User;
  mobileQuery: MediaQueryList;
  categories: Category[];

  private _mobileQueryListener: () => void;

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService,
    private categoryService: CategoryService,
    changeDetectorRef: ChangeDetectorRef,
    media: MediaMatcher
  ) {
    this.authenticationService.currentUser.subscribe(
      x => (this.currentUser = x)
    );
    this.mobileQuery = media.matchMedia("(max-width: 600px)");
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
  }

  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }

  ngOnInit() {
    this.getCategories();
  }
  get isAdmin() {
    return this.currentUser && this.currentUser.role === Role.Admin;
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(["/login"]);
  }

  isLoggedIn() {
    const userLogged = this.authenticationService.currentUserValue;
    if (userLogged == null) {
      return false;
    } else {
      return true;
    }
  }

  getCategories() {
    this.categoryService.getAll().subscribe(res => {
      this.categories = res;
      console.log(this.categories);
    });
  }
}
