import {Component, Input} from '@angular/core';
import {ROUTER_DIRECTIVES} from '@angular/router';

@Component({
    selector: 'polo-list',
    directives: [ROUTER_DIRECTIVES],
    styles: [`
        .zippy {
            background: green;
        }
    `],    
    template: `
    <ul class="list-unstyled">
        <li *ngFor="let item of polos">
            <div itemscope itemtype="http://schema.org/LocalBusiness">
                <strong><span itemprop="name"><a [routerLink]="['/PoloHome',{id:item.Id}]">{{item.Nome}}</a></span></strong><br>
                <div *ngIf="item.Coordenador">
                    Coordenador(a): {{item.Coordenador}}
                </div>
                <address>
                    {{item.Endereco}}<br>
                    Email(s): <span itemprop="email">{{item.Emails}}</span> <br>
                    Telefone(s): <span itemprop="telephone">{{item.Telefones}}</span> <br>
                </address>
            </div>
        </li>
    </ul>
`,
})
export class PoloListComponent {
    @Input() polos: any;
}