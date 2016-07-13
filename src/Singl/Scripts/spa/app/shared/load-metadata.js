import {Injector}   from '@angular/core';
import {ModelMetadataService}   from './';

export const loadMetadata = (model) => {
let injector = Injector.resolveAndCreate([
    ModelMetadataService
  ]);

  let mms = injector.get(ModelMetadataService);

  return mms.get(model);  
};