import {Component, Input} from 'angular2/core';

@Component({
    selector: 'instituicao-footer',
    template: `
<div class="col-lg-8 col-lg-offset-2 text-center">
    <hr class="primary">
    <div itemscope itemtype="http://schema.org/LocalBusiness">
        <address>
            <strong><span itemprop="name">{{instituicao?.Nome}}</span></strong><br>
            {{instituicao?.Endereco}}<br>
            <abbr title="Telefone">Fone:</abbr> <span itemprop="telephone"><a href="tel:{{instituicao?.Telefone}}">{{instituicao?.Telefone}}</a></span> <br>
            <abbr title="Fax">Fax:</abbr> {{instituicao?.Fax}}
        </address>
    </div>
</div>
`,
})
export class InstituicaoFooterComponent {
    @Input() instituicao: any;
}