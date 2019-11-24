import { NgModule } from '@angular/core';
import { MatInputModule, MatButtonModule, MatSelectModule, MatIconModule } from '@angular/material';
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations: [
    ],
    imports: [
        FormsModule,
        MatInputModule,
        MatButtonModule,
        MatSelectModule,
        MatIconModule
    ],
    exports: [
        FormsModule,
        MatInputModule,
        MatButtonModule,
        MatSelectModule,
        MatIconModule
    ],
    providers: [],
    bootstrap: []
})
export class SharedModule { }
