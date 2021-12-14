module daytwo

open System.Linq
open System.IO
open FileHelpers

type directionType =
    | Forward
    | Down
    | Up

let parseDirection = function
    | "forward" -> Forward
    | "down" -> Down
    | "up" -> Up

let daytwo : int = 
    let inputValues  = (File.ReadLines("../../../Input/daytwo.txt")).ToList()
    let mutable horizontalPosition = 0
    let mutable depthPosition = 0

    for line in inputValues do
        let rawDirection = line.Split(' ')
        let direction = parseDirection rawDirection.[0]

        match direction with
            | Forward -> (horizontalPosition <- horizontalPosition + (tryParseInt rawDirection.[1]).Value)
            | Down -> (depthPosition <- depthPosition + (tryParseInt rawDirection.[1]).Value)
            | Up -> (depthPosition <- depthPosition - (tryParseInt rawDirection.[1]).Value)

    let total = horizontalPosition * depthPosition
    total