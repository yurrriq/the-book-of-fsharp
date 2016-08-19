module TheBookOfFSharp.RpnCalculator

open System

let evalRpnExpr (s : string) =
  let solve items current =
    match (current, items) with
      | "+", y::x::t -> (x + y)::t
      | "-", y::x::t -> (x - y)::t
      | "*", y::x::t -> (x * y)::t
      | "/", y::x::t -> (x / y)::t
      | _ -> (float current)::items
  (s.Split(' ') |> Seq.fold solve []).Head

[<EntryPoint>]
let main argv =
  [ "4 2 5 * + 1 3 2 * + /"
    "5 4 6 + /"
    "10 4 3 + 2 * -"
    "2 3 +"
    "90 34 12 33 55 66 + * - + -"
    "90 3 -" ]
  |> List.map (fun expr -> expr, evalRpnExpr expr)
  |> List.iter (fun (expr, result) -> printfn "(%s) = %A" expr result) |> ignore
  0 // return an integer exit code
