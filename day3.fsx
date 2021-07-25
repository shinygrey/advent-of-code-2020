open System

let day3InputToLineSeq file =
    IO.File.ReadAllText file
    |> fun lines -> lines.Split Environment.NewLine
    |> Array.toSeq

(*
let day3InputToList file =
    IO.File.ReadAllText file
    |> fun lines -> lines.Split Environment.NewLine
    |> Seq.toList
    //|> List.map (fun s -> s.Split "" |> Seq.toList);;

let day3InputToLineArray file =
    IO.File.ReadAllText file
    |> fun lines -> lines.Split Environment.NewLine
*)

let tobogganTrajectory slope right down =
    let lineWidth = Seq.item 0 slope |> Seq.length
    let rec getRightIndex rightIndexCheck =
        if rightIndexCheck < lineWidth
            then rightIndexCheck
            else getRightIndex (rightIndexCheck - lineWidth)
    let rec traverse rightAcc currentLine count =
        let rightIndex = getRightIndex rightAcc
        if Seq.length slope <= currentLine
            then count
            else Seq.item currentLine slope |> (fun line -> Seq.item rightIndex line)
                |> (fun x ->
                    traverse (rightIndex + rightAcc) (currentLine + down) (if x = '#' then count + 1 else count))
    traverse right 0 0;;

day3InputToLineSeq @"./day3_input.txt"
    |> (fun lines -> tobogganTrajectory lines 3 1)
    |> (fun answer -> printfn "answer: %A" answer);;

(*
day3InputToList @"./day3_input.txt"
|> day3Input
|> (fun answer -> printfn "answer: %A" answer);;
*)


// Math.Floor 3.86 |> (fun answer -> printfn "answer: %A" answer)
// Seq.item 0 "myteststring" |> (fun answer -> printfn "answer: %A" answer)

// open System
(*
let day3Input file =
    IO.File.ReadAllText file
    |> fun lines -> lines.Split Environment.NewLine file
    |> Seq.toList
    |> List.map (fun s -> s.Split "" |> Seq.toList);;

day3Input @"./day3_input.txt"
|> day3Input
|> (fun answer -> printfn "answer: %A" answer);;
*)
