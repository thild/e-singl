
import {Component} from 'angular2/core';
import {CORE_DIRECTIVES, FORM_DIRECTIVES, NgClass, NgStyle} from 'angular2/common';
import {RouteConfig, ROUTER_DIRECTIVES, CanActivate, ComponentInstruction} from 'angular2/router';
import {isLoggedIn} from '../components/login.component'

import {FILE_UPLOAD_DIRECTIVES, FileUploader} from '../components/file-upload/ng2-file-upload';

// webpack html imports
//let template = require('./file-upload.component.html');

// const URL = '/api/';
const URL = '/api/files';

@Component({
    selector: 'file-upload-form',
    templateUrl: 'app/areas/admin/forms/file-upload-form.component.html',
    directives: [FILE_UPLOAD_DIRECTIVES, NgClass, NgStyle, CORE_DIRECTIVES, FORM_DIRECTIVES]
})
@CanActivate((next: ComponentInstruction, previous: ComponentInstruction) => {
  return isLoggedIn(next, previous);
})
export class FileUploadFormComponent {
    private uploader: FileUploader = new FileUploader({ url: URL });
    private hasBaseDropZoneOver: boolean = false;
    private hasAnotherDropZoneOver: boolean = false;

    private fileOverBase(e: any) {
        this.hasBaseDropZoneOver = e;
    }

    private fileOverAnother(e: any) {
        this.hasAnotherDropZoneOver = e;
    }
}

