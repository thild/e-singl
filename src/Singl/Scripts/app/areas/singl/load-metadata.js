import {Injector}   from 'angular2/core';
import {ModelMetadataService}   from './model-metadata.service';

export const loadMetadata = (model) => {
let injector = Injector.resolveAndCreate([
    ModelMetadataService
  ]);

  let mms = injector.get(ModelMetadataService);

  return mms.get(model);  
};