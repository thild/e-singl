import {Injectable, Input, Component} from '@angular/core';

import {
    ROUTER_DIRECTIVES,
} from '@angular/router';



@Component({
    selector: 'app-nav',
    directives: [ROUTER_DIRECTIVES],
    template:
    `
    <nav id="mainNav" class="navbar navbar-default navbar-fixed-top" role="navigation">
        <div class="container-fluid">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span aria-hidden="true" class="sr-only">Ligar/desligar navegação</span>
                </button>
                <!--<a class="navbar-brand page-scroll" href="#page-top">Singl</a>-->
                <a class="navbar-brand page-scroll" [routerLink]="['/']">Singl</a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <template ngFor let-route [ngForOf]="routes">
                        <li [class.active]="active">
                            <a [routerLink]="[route.path]" class="link">{{route.text}}</a>
                        </li>
                    </template>
                    <li [class.active]="active">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Cursos <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li class="dropdown-header">Graduação</li>
                            <!--<li role="separator" class="divider"></li>                          -->
                            <li [class.active]="active"><a [routerLink]="['/cursos',{filter:'CursosBacharelado'}]" class="link">Bacharelado</a></li>
                            <li [class.active]="active"><a [routerLink]="['/cursos',{filter:'CursosLicenciatura'}]" class="link">Licenciatura</a></li>
                            <li class="dropdown-header">Pós-Graduação</li>
                            <!--<li role="separator" class="divider"></li>                          -->
                            <li [class.active]="active"><a [routerLink]="['/cursos',{filter:'CursosEspecializacao'}]" class="link">Especialização</a></li>
                            <li [class.active]="active"><a [routerLink]="['/cursos',{filter:'CursosMestrado'}]" class="link">Mestrado</a></li>
                            <li [class.active]="active"><a [routerLink]="['/cursos',{filter:'CursosDoutorado'}]" class="link">Doutorado</a></li>
                            <!--<li role="separator" class="divider"></li>                          -->
                            <li class="dropdown-header">Extensão</li>
                            <li [class.active]="active"><a [routerLink]="['/cursos']" class="link">Curta duração</a></li>
                            <li class="dropdown-header">Por modalidade de ensino</li>
                            <!--<li role="separator" class="divider"></li>                          -->
                            <li [class.active]="active"><a [routerLink]="['/cursos',{filter:'CursosPresenciais'}]" class="link">Presencial</a></li>
                            <li [class.active]="active"><a [routerLink]="['/cursos',{filter:'CursosDistancia'}]" class="link">Distância</a></li>
                            <li [class.active]="active"><a [routerLink]="['/cursos',{filter:'CursosSemipresenciais'}]" class="link">Semipresencial</a></li>
                            <li class="dropdown-header">Por setor administrativo</li>
                            <li [class.active]="active"><a [routerLink]="['/cursos',{filter:'CursosNead'}]" class="link">NEAD</a></li>
                        </ul>
                    </li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li><a [routerLink]="['/ajuda']" class="link" aria-label="Ajuda"><span class="glyphicon glyphicon-question-sign" aria-hidden="true"></span></a></li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
    </nav>
    `
})
export class AppNav{
    @Input()
    routes: any[];
}