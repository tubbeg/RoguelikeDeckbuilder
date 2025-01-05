

/*Under normal circumstances I would be writing
Fable bindings for every phaser property. The only issue
is that the phaser game framework consists of many
many classes, which makes it very time consuming. Also
some things in javascript does not translate 100 % perfectly to F#,
but that is also why we have Import and Emit. Sometimes Fable is
not good enough, but that's OK!*/
export function loadImage (t,id,path) {
    return t.load.image(id,path);
}

export function addImage(t,x,y,id){
    return t.add.image(x,y,id);
}