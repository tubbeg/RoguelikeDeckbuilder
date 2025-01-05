module Phaser
open Fable.Core
open Fable.Core.JsInterop

[<Import("AUTO","phaser")>]
let auto = jsNative

let createConfig scenes =
    createObj [
        "type",auto
        "width",800
        "height",600
        "scene", scenes
        "physics", createObj [
            "default", "arcade"
            "arcade", {|gravity={|y=200|}|}
        ]
    ]

type SceneConf = {|active:bool;key:string|}

[<Import("Scene","phaser")>]
type Scene (conf : SceneConf) =
    abstract member preload : unit -> unit
    default this.preload () = ()
    abstract member create : unit -> unit
    default this.create () = ()
    //int is actually js number
    abstract member update : int -> int -> unit
    default this.update time dt = ()

[<Import("Game","phaser")>]
type Game (conf) =
    class
    end

//I should not be calling functions using the object instance.
//This is usually quite a bad solution. I am simply doing this
//because I prefer working in a functional way
type SceneExt (conf, preload,create,update) =
    inherit Scene(conf)
    override this.preload (): unit =
        preload this
    override this.create (): unit =
        create this
    override this.update (time: int) (dt: int) =
        update this time dt 