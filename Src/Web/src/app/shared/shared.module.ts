import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { MatInputModule, MatButtonModule, MatSelectModule, MatIconModule, MatTabsModule, MatFormFieldModule, MatGridListModule, MatCardModule, MatTableModule, MatDialogModule, MatDatepickerModule, MatNativeDateModule, MatTooltipModule, MatSnackBarModule } from '@angular/material';
import { MatListModule } from '@angular/material/list';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ConfirmDialogComponent } from './components/confirm-dialog/confirm-dialog.component';

@NgModule({
    declarations: [
    ConfirmDialogComponent],
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
        CommonModule
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
        CommonModule
    ],
    providers: [HttpClient],
    bootstrap: []
})
export class SharedModule { }
