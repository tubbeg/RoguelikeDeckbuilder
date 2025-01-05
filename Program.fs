open Browser
open Fable.Core
open Fable.Core.JsInterop
open Phaser
open Load


[<Import("addImage","./Interop.js")>]
let addImage this x y id = jsNative

let c this =
    let c = {rank=Face(Queen);suit=Clubs}
    c |> cardToId |> addImage this 400 400

let u this time delta = ()

let launchGame () =
    let sConf = {|active=true;key="xt"|}
    let s = new SceneExt (sConf, p,c,u)
    let config = createConfig s
    new Game(config)

let div = document.createElement "div"
div.innerHTML <- "git gud"
document.body.appendChild div |> ignore

launchGame () |> ignore