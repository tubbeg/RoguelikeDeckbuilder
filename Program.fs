open Browser
open Fable.Core
open Fable.Core.JsInterop
open Phaser

let assetPath = "./assets/CARDS/"


let path = assetPath + "Diamonds_ACE.png"

[<Import("loadImage","./Interop.js")>]
let loadImage this id path = jsNative

let p this =
    printfn "PRELOADING !!!!"
    loadImage this "stuff" path


[<Import("addImage","./Interop.js")>]
let addImage this x y path = jsNative

let c this =
    addImage this 400 400 "stuff"

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