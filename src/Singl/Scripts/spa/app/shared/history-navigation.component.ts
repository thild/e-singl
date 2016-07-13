import {Component} from '@angular/core';
import {Router, ROUTER_DIRECTIVES} from '@angular/router';

@Component({
    selector: 'history-navigation',
    template: `
<nav class="navbar navbar-default" role="navigation">
    <div class="container-fluid">
        <div class="btn-toolbar" role="toolbar" aria-label="Barra de ferramentas">
            <div class="btn-group" role="group" aria-label="Voltar/Avançar">
                <button aria-label="Volbar" class="btn btn-default" onclick="javascript:history.go(-1)">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                </button>
                <button aria-label="Avançar" class="btn btn-default" onclick="javascript:history.go(1)">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                </button>
            </div>
        </div>
    </div>
</nav>      
  `,
})
export class HistoryNavigationComponent {
}