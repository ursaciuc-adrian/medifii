import { NgModule } from '@angular/core';
import { MatInputModule, MatButtonModule, MatSelectModule, MatIconModule, MatTabsModule, MatFormFieldModule } from '@angular/material';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
    declarations: [
    ],
    imports: [
        FormsModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        MatSelectModule,
        MatIconModule,
        MatTabsModule,
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
    ],
    providers: [],
    bootstrap: []
})
export class SharedModule { }
