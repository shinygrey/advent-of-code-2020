open System.Text.RegularExpressions;;

let day2Input file = 
    System.IO.File.ReadAllText file
    |> fun lines -> Seq.toList (lines.Split([|'\n'; '\r'|])) // lines.Split "\r\n" ... split can take array of char ... change to \n on Mac
    |> List.map (fun x ->
        (Regex.Match(x, @"(\d{1,3})-(\d{1,3})\s(\w):\s(\w*)")
        |> fun m -> m.Groups
        |> fun gc -> gc.Values
        |> Seq.map (fun item -> item |> string)));;

let part1 stringSeqs =
    (List.filter (fun sseq ->
        let low = Seq.item 1 sseq |> int
        let high = Seq.item 2 sseq |> int
        let p = Seq.item 3 sseq
        let pw = Seq.item 4 sseq
        let count = Regex.Matches(pw,p) |> (fun mc -> mc.Count)
        if count < low || count > high
            then false
            else true)
        stringSeqs)
    |> List.length;;

let part2 stringSeqs =
    (List.filter (fun sseq ->
        let p1 = Seq.item 1 sseq |> int
        let p2 = Seq.item 2 sseq |> int
        let pos1 = (p1 - 1) |> string
        let pos2 = (p2 - (p1 + 1)) |> string
        let c = Seq.item 3 sseq
        let p1 = "^(?:\\w{"+pos1+"}["+c+"]\\w{"+pos2+"}[^"+c+"].*)$"
        let p2 = "^(?:\\w{"+pos1+"}[^"+c+"]\\w{"+pos2+"}["+c+"].*)$"
        let pw = Seq.item 4 sseq
        let m1 = Regex.Match(pw,p1)
        let m2 = Regex.Match(pw,p2)
        if (m1.Success <> m2.Success) && (m1.Success || m2.Success)
            then true
            else false)
        stringSeqs)
    |> List.length;;

day2Input @"./day2_input.txt"
|> part1
|> (fun answer -> printfn "answer: %d" answer);;

day2Input @"./day2_input.txt"
|> part2
|> (fun answer -> printfn "answer: %d" answer);;
