// Learn more about F# at http://fsharp.org

open System.Linq
open System.IO
open FileHelpers

let mutable horizontalPosition = 0
let mutable depthPosition = 0
let mutable depthAim = 0

type directionType =
    | Forward
    | Down
    | Up

let getDirectionType = function
    | "forward" -> Forward
    | "down" -> Down
    | "up" -> Up

let getDirection (inputLine : string) =
    getDirectionType (inputLine.Split(' ').[0] |> string)

let getNumber (inputLine : string) =
    inputLine.Split(' ').[1] |> int32

let calculateDepth (h : int) =
    let pos = h * depthAim
    printfn "Moved: %i Horizontal: %i Aim: %i Depth: %i" pos horizontalPosition depthAim depthPosition
    depthPosition <- depthPosition + pos

let runHorizontal (line: string) =
    //printfn 
    horizontalPosition <- horizontalPosition + getNumber line
    calculateDepth horizontalPosition

let setPositions (line : string) =
    match getDirection line with
        | Forward -> runHorizontal line
        | Down -> depthAim <- depthAim + getNumber line
        | Up -> depthAim <- depthAim - getNumber line

let daytwotwo : int = 
    let inputValues  = (File.ReadLines("../../../Input/daytwo.txt")).ToList()
        
    for line in inputValues do
        setPositions line

    let total = horizontalPosition * depthPosition
    total

[<EntryPoint>]
let main argv =
    printfn "Result is: %i" daytwotwo

    0 // return an integer exit code