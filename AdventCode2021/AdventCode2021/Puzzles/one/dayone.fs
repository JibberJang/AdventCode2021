module dayone

open FileHelpers
open System.Linq
open System.IO

let dayone : int = 
    let readLinesString  = File.ReadLines("../../../Input/dayone.txt")
    let numbers = readLinesString |> Seq.choose tryParseInt
    let mutable greaterThanCount = 0
    let mutable prevLine = numbers.First()

    for line in numbers.Skip(1) do
        if line > 0 then
            printf "Is %i greater than %i" line prevLine
            if line > prevLine
                then 
                    greaterThanCount <- greaterThanCount + 1
                    printfn " yes - the total is %i" greaterThanCount
            else printfn " no - the total is %i" greaterThanCount
        prevLine <- line

    greaterThanCount
    