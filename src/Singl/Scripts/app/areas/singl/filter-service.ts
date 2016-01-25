import {Injectable} from 'angular2/core';

@Injectable()
export class FilterService {
    
    
    public static filters = {};
    
    constructor() {
        FilterService.filters["Singl.Models.Curso"] = this.getCursoFilters();
    }
    
    public getFilters(modelName : string) : any[] {
        return FilterService.filters[modelName];
    }
    
    public static CursosPresenciais(list:Array<any>) : Array<any> {
        return list.filter(m => m.ModalidadeEnsino.Name == "Presencial");
    }
            
    public static CursosDistancia(list:Array<any>) : Array<any> {
        return list.filter(m => m.ModalidadeEnsino.Name == "Distancia");
    }
            
    public static CursosSemipresenciais(list:Array<any>) : Array<any> {
        return list.filter(m => m.ModalidadeEnsino.Name == "Semipresencial");
    }

    public static CursosBacharelado(list:Array<any>) : Array<any> {
        return list.filter(m => m.Tipo.Name == "Bacharelado");
    }

    public static CursosLicenciatura(list:Array<any>) : Array<any> {
        return list.filter(m => m.Tipo.Name == "Licenciatura");
    }
            
    public static CursosEspecializacao(list:Array<any>) : Array<any> {
        return list.filter(m => m.Tipo.Name == "Especializacao");
    }
    
    public static CursosMestrado(list:Array<any>) : Array<any> {
        return list.filter(m => m.Tipo.Name == "Mestrado");
    }
            
    public static CursosDoutorado(list:Array<any>) : Array<any> {
        return list.filter(m => m.Tipo.Name == "Doutorado");
    }
            
    public static CursosNead(list:Array<any>) : Array<any> {
        return list.filter(m => m.ModalidadeEnsino.Name == "Presencial");
    }
    
    getCursoFilters() : Array<any> {
        return [
            {description: "Bacharelado", value: "CursosBacharelado"},
            {description: "Licenciatura", value: "CursosLicenciatura"},
            {description: "Especialização", value: "CursosEspecializacao"},
            {description: "Mestrado", value: "CursosMestrado"},
            {description: "Doutorado", value: "CursosDoutorado"},
            {description: "Presenciais", value: "CursosPresenciais"},
            {description: "A distância", value: "CursosDistancia"},
            {description: "Semipresenciais", value: "CursosSemipresenciais"}
        ];
    }    
            
}
