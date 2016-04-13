function isElement(node: any) {
    return !!(node && (node.nodeName || node.prop && node.attr && node.find));
}

export class FileLikeObject {
    public lastModifiedDate: any;
    public size: number;
    public type: string;
    public name: string;

    constructor(fileOrInput: any) {
        let isInput = isElement(fileOrInput);
        let fakePathOrObject = isInput ? fileOrInput.value : fileOrInput;
        let postfix = typeof fakePathOrObject === 'string' ? 'FakePath' : 'Object';
        let method = '_createFrom' + postfix;
        (<any>this)[method](fakePathOrObject);
    }

    public _createFromFakePath(path: string) {
        this.lastModifiedDate = null;
        this.size = null;
        this.type = 'like/' + path.slice(path.lastIndexOf('.') + 1).toLowerCase();
        this.name = path.slice(path.lastIndexOf('/') + path.lastIndexOf('\\') + 2);
    }

    public _createFromObject(object: { size: number, type: string, name: string }) {
        // this.lastModifiedDate = copy(object.lastModifiedDate);
        this.size = object.size;
        this.type = object.type;
        this.name = object.name;
    }


    public getHumanReadableSize(): string {
        if (this.size < 1024) {
            return this.size + ' B';
        } 
        else if (this.size < 1048576) {
            return (this.size / 1024).toFixed(1) + ' KB';
        }
        return (this.size / 1048576).toFixed(1) + ' MB';
    }
}
