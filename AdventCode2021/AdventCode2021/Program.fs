// Learn more about F# at http://fsharp.org

open System
open System.Linq
open System.IO
open System.Collections

let tryParseInt s =
    match Int32.TryParse (s:string) with
    | true, n -> Some n
    | false, _ -> None

let readLinesString  = File.ReadLines("../../../Input/dayone.txt")
let numbers = readLinesString |> Seq.choose tryParseInt |> Seq.sort
let fileLen = readLinesString.Count()

let findLargerThanPrevious (lines : int seq) : int = 
    let mutable greaterThanCount = 0
    let mutable prevLine = lines.First()

    for line in lines.Skip(1) do
        if line > 0 then
            printf "Is %i greater than %i" line prevLine
            if line > prevLine
                then 
                    greaterThanCount <- greaterThanCount + 1
                    printfn " yes - the total is %i" greaterThanCount
            else printfn " no - the total is %i" greaterThanCount
        prevLine <- line

    greaterThanCount
    

[<EntryPoint>]
let main argv =
    let result = findLargerThanPrevious numbers //Comes up with 1810
    0 // return an integer exit code