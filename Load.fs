module Load
open Fable.Core

type Suit = | Clubs | Spades | Hearts | Diamonds
type Face = King | Queen | Jack
type Rank =
    | Number of int
    | Face of Face
    | Ace
type Card = {rank:Rank;suit:Suit}
type Deck = Card array

let numberToRank n=
    match n with
    | l when l >= 2 && l <= 10 -> Number(l) |> Some
    | 11 -> Jack |> Face |> Some
    | 12 -> Queen |> Face |> Some
    | 13 -> King |> Face |> Some
    | 14 -> Ace  |> Some
    | _ -> None

let createDefaultSuit suit =
    let foldFunction l r =
        match r with
        | Some rank ->
            let card = {rank=rank;suit=suit}
            card::l
        | None -> l 
    [for i in 2 .. 14 -> i] |>
    List.map (fun i -> numberToRank i) |>
    List.fold foldFunction [] //folds are absolutely perfect <3

let default52Deck =
    let d = createDefaultSuit Diamonds
    let s = createDefaultSuit Spades
    let h = createDefaultSuit Hearts
    let c = createDefaultSuit Clubs
    d @ s @ h @ c |> List.toArray

let assetPath = "./assets/CARDS/"

[<Import("loadImage","./Interop.js")>]
let loadImage this id path = jsNative

let rankToPath r =
    match r with
    | Number(n) -> n.ToString()
    | Ace -> "ACE"
    | Face(Jack) -> "J"
    | Face(Queen) -> "Q"
    | Face(King) -> "K"
    
let cardToId card =
    card.suit.ToString() + card.rank.ToString()

let loadCard this card =
    let id = cardToId card
    let rpath = rankToPath card.rank
    let path = assetPath + card.suit.ToString() + "_" + rpath + ".png"
    loadImage this id path

let loadDeck this  deck : unit =
    deck |> Array.iter (fun c -> loadCard  this c)

let p this =
    printfn "PRELOADING !!!!"
    loadDeck this default52Deck

