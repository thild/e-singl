// import { Component } from 'angular2/core';
// import { Injectable } from 'angular2/core';
// import { Observable } from 'rxjs/Observable';
// import 'rxjs/add/operator/share';

// import {Component, View, NgFor, FORM_DIRECTIVES, FormBuilder, ControlGroup} from 'angular2/angular2';
// import {Http, Response, Headers} from 'http/http';


// @Component({ selector: 'file-upload' })
// @View({
//     directives: [FORM_DIRECTIVES],
//     template: `
// <h3>File Upload</h3>

// <div>
//      Select file:
//     <input type="file" (change)="changeListener($event)">
// </div>

// `
// })
// export class FileUploadCmp {

//     public file: File;
//     public url: string;
//     headers: Headers;


//     constructor(public http: Http, private fileUploadService: FileUploadService) {
//         console.log('file upload Initialized');
//         //set the header as multipart        
//         this.headers = new Headers();
//         this.headers.set('Content-Type', 'multipart/form-data');
//         this.url = 'http://localhost:8080/test';
//     }

//     //onChange file listener
//     changeListener($event): void {
//         this.postFile($event.target);
//     }

//     //send post file to server 
//     postFile(inputValue: any): void {

//         var formData = new FormData();
//         formData.append("name", "Name");
//         formData.append("file", inputValue.files[0]);

//         this.http.post(this.url +,
//             formData,
//             {
//                 headers: this.headers

//             });
//     }

//     /**
//      * @param fileInput
//      */
//     public psdTemplateSelectionHandler(fileInput: any) {
//         let FileList: FileList = fileInput.target.files;

//         for (let i = 0, length = FileList.length; i < length; i++) {
//             this.psdTemplates.push(FileList.item(i));
//         }

//         this.progressBarVisibility = true;
//     }

//     public async psdTemplateUploadHandler(): Promise<any> {
//         let result: any;

//         if (!this.psdTemplates.length) {
//             return;
//         }

//         this.isSubmitted = true;

//         this.fileUploadService.getObserver()
//             .subscribe(progress => {
//                 this.uploadProgress = progress;
//             });

//         try {
//             result = await this.fileUploadService.upload(this.uploadRoute, this.psdTemplates);
//         } catch (error) {
//             document.write(error)
//         }

//         if (!result['images']) {
//             return;
//         }

//         this.saveUploadedTemplatesData(result['images']);
//         this.redirectService.redirect(this.redirectRoute);
//     }

// }

// @Injectable()
// export class FileUploadService {
//     /**
//      * @param Observable<number>
//      */
//     private progress$: Observable<number>;

//     /**
//      * @type {number}
//      */
//     private progress: number = 0;

//     private progressObserver: any;

//     constructor() {
//         this.progress$ = new Observable(observer => {
//             this.progressObserver = observer
//         });
//     }

//     /**
//      * @returns {Observable<number>}
//      */
//     public getObserver(): Observable<number> {
//         return this.progress$;
//     }

//     /**
//      * Upload files through XMLHttpRequest
//      *
//      * @param url
//      * @param files
//      * @returns {Promise<T>}
//      */
//     public upload(url: string, files: File[]): Promise<any> {
//         return new Promise((resolve, reject) => {
//             let formData: FormData = new FormData(),
//                 xhr: XMLHttpRequest = new XMLHttpRequest();

//             for (let i = 0; i < files.length; i++) {
//                 formData.append("uploads[]", files[i], files[i].name);
//             }

//             xhr.onreadystatechange = () => {
//                 if (xhr.readyState === 4) {
//                     if (xhr.status === 200) {
//                         resolve(JSON.parse(xhr.response));
//                     } else {
//                         reject(xhr.response);
//                     }
//                 }
//             };

//             FileUploadService.setUploadUpdateInterval(500);

//             xhr.upload.onprogress = (event) => {
//                 this.progress = Math.round(event.loaded / event.total * 100);

//                 this.progressObserver.next(this.progress);
//             };

//             xhr.open('POST', url, true);
//             xhr.send(formData);
//         });
//     }

//     /**
//      * Set interval for frequency with which Observable inside Promise will share data with subscribers.
//      *
//      * @param interval
//      */
//     private static setUploadUpdateInterval(interval: number): void {
//         setInterval(() => { }, interval);
//     }
// }