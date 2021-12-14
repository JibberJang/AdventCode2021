module dayonetwo

open System.Linq
open System.IO
open FileHelpers

let dayonetwo : int = 
    let readLinesString  = (File.ReadLines("../../../Input/dayone.txt")).ToList()
    let numbers = readLinesString |> Seq.choose tryParseInt
    let mutable greaterThanCount = 0
    let mutable prevLine = 0
    let mutable iterationCount = 0

    for line in numbers do
        if iterationCount > 2 then
            let groupSum = query {
                for number in numbers.Skip(iterationCount-2).Take(3) do
                sumBy number
            }

            if groupSum > prevLine
                then 
                    greaterThanCount <- greaterThanCount + 1
                    printfn " yes - the total is %i" greaterThanCount
            else printfn " no - the total is %i" greaterThanCount
            prevLine <- groupSum
        iterationCount <- iterationCount + 1
    greaterThanCount
