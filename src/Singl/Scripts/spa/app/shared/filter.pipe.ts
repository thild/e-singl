import {Component, Pipe, PipeTransform}  from '@angular/core';
import {FilterService}  from './filter.service';

// We use the @Pipe decorator to register the name of the pipe
@Pipe({
    name: 'filter',
    pure: false
})

// The work of the pipe is handled in the tranform method with our pipe's class
export class FilterPipe implements PipeTransform {
    transform(value: Array<any>, args: any[]) {
        if (!value || value.length == 0 ||
            !args || args.length != 1 ||
            args[0] == null) {
            return value;
        };
        let filters:any[] = args[0];
        if(filters.length == 0) {
            return value;
        }
      
         let ret = filters.reduce(
             (acc, y) => FilterService[y](acc), value
         );
        return ret;
    }
}