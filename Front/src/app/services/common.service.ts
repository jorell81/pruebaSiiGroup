import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class CommonService {
    
    swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'm-2 mdc-button mdc-button--raised mat-mdc-raised-button mat-primary mat-mdc-button-base',
            cancelButton: 'm-2 mdc-button mdc-button--raised mat-mdc-raised-button mat-unthemed mat-mdc-button-base'
        },
        buttonsStyling: false
    });

    public showSuccess(message: string) {
        this.show(message, 'success');
    }

    public showWarning(message: string) {
        this.show(message, 'warning');
    }

    public showError(message: string) {
        this.show(message, 'error');
    }

    private show(message: string, type: string) {
        this.swalWithBootstrapButtons.fire({
            title: '',
            text: message,
            icon: type,
            confirmButtonText: 'Aceptar'
        } as any);
    }

    public showConfirm(message: string): Promise<null> {
        return new Promise((resolve: any, reject: any) => {
            this.swalWithBootstrapButtons.fire({
                title: '',
                text: message,
                icon: 'question',
                showCancelButton: true,
                confirmButtonText: 'Aceptar',
                cancelButtonText: 'Cancelar'
            } as any).then((result:any) => {
                if (result.isConfirmed) {
                    resolve();
                } else {
                    reject();
                }
            })
        });
    }
}