let day3Input file =
    System.IO.File.ReadAllText file
    |> fun lines -> lines.Split "\r\n"
    |> Seq.toList
    |> List.map (fun s -> s.Split "" |> Seq.toList);;

day3Input @"./day3_input.txt"
|> day3Input
|> (fun answer -> printfn "answer: %A" answer);;
