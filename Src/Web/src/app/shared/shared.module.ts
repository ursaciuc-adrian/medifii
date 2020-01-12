import { HttpClient, HttpClientModule } from '@angular/common/http'
import { NgModule } from '@angular/core'
import {
  MatInputModule,
  MatButtonModule,
  MatSelectModule,
  MatIconModule,
  MatTabsModule,
  MatFormFieldModule,
  MatGridListModule,
  MatCardModule,
  MatTableModule,
  MatDialogModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatTooltipModule,
  MatSnackBarModule,
  MatSidenavModule,
  MatToolbarModule,
  MatMenuModule,
  MatSlideToggleModule,
  MatBottomSheetModule,
} from '@angular/material'
import { MatListModule } from '@angular/material/list'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { CommonModule } from '@angular/common'
import { ConfirmDialogComponent } from './components/confirm-dialog/confirm-dialog.component'
import { NavigationMenuComponent } from './components/navigation-menu/navigation-menu.component'
import { RouterModule } from '@angular/router'
import { FlexLayoutModule } from '@angular/flex-layout'
import { PharmacyService } from './services/pharmacy.service'
import { LoginService } from './services/login.service'
import { AuthGuard } from './guards/authentication.guard'
import { LoginGuard } from './guards/login.guard'
import { BottomInfoComponent } from './components/bottom-info/bottom-info.component'
@NgModule({
  declarations: [ConfirmDialogComponent, NavigationMenuComponent, BottomInfoComponent],
  imports: [
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatIconModule,
    MatTabsModule,
    MatGridListModule,
    MatCardModule,
    MatListModule,
    MatTableModule,
    MatDialogModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatTooltipModule,
    MatSnackBarModule,
    MatSidenavModule,
    MatToolbarModule,
    RouterModule,
    FlexLayoutModule,
    MatMenuModule,
    CommonModule,
    MatSlideToggleModule,
    MatBottomSheetModule
  ],
  exports: [
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatIconModule,
    MatTabsModule,
    MatGridListModule,
    MatCardModule,
    MatListModule,
    MatTableModule,
    MatDialogModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatTooltipModule,
    MatSnackBarModule,
    NavigationMenuComponent,
    FlexLayoutModule,
    CommonModule,
    MatSlideToggleModule,
    MatBottomSheetModule
  ],
  providers: [HttpClient, PharmacyService, LoginService, AuthGuard, LoginGuard],
  bootstrap: [],
  entryComponents:[BottomInfoComponent]
})
export class SharedModule {}
