module FileHelpers

open System

let tryParseInt s =
    match Int32.TryParse (s:string) with
    | true, n -> Some n
    | false, _ -> None
