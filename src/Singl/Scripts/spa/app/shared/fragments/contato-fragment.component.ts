import {Component, Input, OnInit, ViewEncapsulation} from '@angular/core';

@Component({
    selector: 'contato-fragment',
    styles: [
        `
        hr {
            border-color: #F05F40;
            border-width: 3px;
            max-width: 350px;
        }
        `
    ],
    template: `
<section id="contact">
    <div class="container">
        <div class="row">
            <div class="col-lg-8 col-lg-offset-2 text-center">
                <h2 class="section-heading">Entre em contato!</h2>
                <hr class="primary">
                <p>{{mensagem}}</p>
            </div>
            <div class="col-lg-4 col-lg-offset-2 text-center">
                <i class="fa fa-phone fa-3x wow bounceIn"></i>
                <p><span itemprop="telephone"><a href="tel:{{telefone}}">{{telefone}}</a></span></p>
            </div>
            <div class="col-lg-4 text-center">
                <i class="fa fa-envelope-o fa-3x wow bounceIn" data-wow-delay=".1s"></i>
                <p><a href="mailto:{{email}}">{{email}}</a></p>
            </div>
        </div>
        <div class="row" *ngIf="facebook">
            <div class="col-lg-8 col-lg-offset-2 text-center">
                <i class="fa fa-facebook fa-3x wow bounceIn"></i>
                <p><a href="{{facebook}}">Acesse nossa página no Facebook</a></p>
            </div>
        </div>
    </div>
</section>
`,
})
export class ContatoFragmentComponent implements OnInit {

    @Input() mensagem: any;
    @Input() telefone: any;
    @Input() email: any;
    @Input() facebook: any;

    constructor(
    ) { }

    ngOnInit() {
    }
}