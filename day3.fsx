open System

let day3InputToLineSeq file =
    IO.File.ReadAllText file
    |> fun lines -> lines.Split Environment.NewLine

let tobogganTrajectory (slope:String[]) right down =
    let lineWidth = slope.[0] |> String.length
    let rec getRightIndex rightIndexCheck =
        if rightIndexCheck < lineWidth
            then rightIndexCheck
            else getRightIndex (rightIndexCheck - lineWidth)
    let rec traverse rightAcc currentLine count =
        let rightIndex = getRightIndex rightAcc
        if Array.length slope <= currentLine + 1 // || Seq.length slope.[currentLine + 1] < 1
            then count
            else slope.[currentLine] |> (fun line -> Seq.item rightIndex line)
                |> (fun x ->
                    traverse (rightIndex + right) (currentLine + down) (if x = '#' then count + 1 else count))
    traverse right down 0;;

day3InputToLineSeq @"./day3_input.txt"
    |> (fun lines -> tobogganTrajectory lines 3 1)
    |> (fun answer -> printfn "answer: %A" answer);;

// let slopes = [[|1;1|];[|3;1|];[|5;1|];[|7;1|];[|1;2|]]

day3InputToLineSeq @"./day3_input.txt"
    |> (fun lines -> //(slopes:list<int[]>)
        let slopes = [[|1;1|];[|3;1|];[|5;1|];[|7;1|];[|1;2|]]
        let rec multiplier acc =
            match slopes with
            | [hd] -> acc * tobogganTrajectory lines hd.[0] hd.[1]
            | hd::_ -> multiplier acc * tobogganTrajectory lines hd.[0] hd.[1]
            | _ -> raise (ArgumentException("other error 1"))
        multiplier 1)


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
