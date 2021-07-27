open System

let textFileToLineSeq file =
    IO.File.ReadAllText file
    |> fun lines -> lines.Split Environment.NewLine

let tobogganTrajectory slope (right,down) =
    let slopeLength = Array.length slope
    let lineWidth = slope.[0] |> String.length
    let rec getRightIndex rightIndexCheck =
        if rightIndexCheck < lineWidth
            then rightIndexCheck
            else getRightIndex (rightIndexCheck - lineWidth)
    let rec traverse rightAcc currentLine count =
        let rightIndex = getRightIndex rightAcc
        if slopeLength <= currentLine
            then count
            else if slopeLength <= currentLine + 1 && Seq.length slope.[currentLine] < 1
                then count
                else slope.[currentLine] |> (fun line -> Seq.item rightIndex line)
                    |> (fun x ->
                        traverse (rightIndex + right) (currentLine + down) (if x = '#' then count + 1 else count))
    traverse right down 0;;

textFileToLineSeq @"./day3_input.txt"
    |> (fun lines  -> tobogganTrajectory lines (3,1))
    |> (fun answer -> printfn "answer: %A" answer);;

let tobogganTrajectories trajectories slope : Int64 =
    let rec multiply vs acc: int64 =
        match vs with
        | [(v1r,v1d)]     -> tobogganTrajectory slope (v1r,v1d) |> int64 |> (fun (x:int64) -> acc * x)
        | (v1r,v1d)::tail -> multiply tail (tobogganTrajectory slope (v1r,v1d) |> int64 |> (fun (x:int64) -> acc * x))
        | _               -> raise (ArgumentException("invalid trajectories"))
    multiply trajectories 1L

textFileToLineSeq @"./day3_input.txt"
    |> tobogganTrajectories [(1,1);(3,1);(5,1);(7,1);(1,2)]
    |> (fun answer -> printfn "answer: %A" answer);;
