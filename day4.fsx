open System
open System.Text.RegularExpressions

(*
byr (Birth Year)
iyr (Issue Year)
eyr (Expiration Year)
hgt (Height)
hcl (Hair Color)
ecl (Eye Color)
pid (Passport ID)
cid (Country ID) - not needed
*)

let day4validate passports =
    IO.File.ReadAllText passports
    |> fun sections -> sections.Split (Environment.NewLine + Environment.NewLine)
    |> Array.filter (fun section ->
        Regex.Matches (section,@"\w{3}(?=:[\w#]+)")
        |> Seq.fold (fun acc item ->
            match item.Value with
            | "byr" -> acc + 1
            | "iyr" -> acc + 1
            | "eyr" -> acc + 1
            | "hgt" -> acc + 1
            | "hcl" -> acc + 1
            | "ecl" -> acc + 1
            | "pid" -> acc + 1
            | _     -> acc
        ) 0
        |> (fun v -> v > 6)
    )
    |> (fun validPassports -> validPassports.Length)

day4validate @"./day4_input.txt"
    |> (fun answer -> printfn "answer: %A" answer);;
