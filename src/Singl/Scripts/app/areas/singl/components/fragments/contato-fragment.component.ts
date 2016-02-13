import {Component, Input, OnInit, ViewEncapsulation} from 'angular2/core';

@Component({
    selector: 'contato-fragment',
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
    </div>
</section>
`,
})
export class ContatoFragmentComponent implements OnInit {

    @Input() mensagem: any;
    @Input() telefone: any;
    @Input() email: any;

    constructor(
    ) { }

    ngOnInit() {
    }
}