open System.Text.RegularExpressions;;

let day2Input file = 
    System.IO.File.ReadAllText file
    |> fun lines -> Seq.toList (lines.Split "\r\n")
    |> List.map (fun x -> Regex.Match(x, @"(\d{1,3})-(\d{1,3})\s(\w):\s(\w*)"))
    |> List.map (fun m -> m.Groups)
    |> List.map (fun gc -> 
        gc.Captures       
    )
    |> List.filter (fun g ->
        let low = Seq.item 0 g |> int
        let high = Seq.item 1 g |> int
        let count = 5
        if count < low || count > high
            then false
            else true
    )
   // |> List.map (fun g -> enum<Collection> g)

  //  |> Seq.cast<Match>

    //|> (fun input -> Regex.Match(input, @"(\d{1,3})-(\d{1,3})\s(\w):\s(\w*)"))
    //|> (fun r -> Seq.item 1 r)
    //|> (fun g -> Seq.item 1 g)

day2Input @"C:\Users\Greg\source\advent-of-code\day2_input.txt"
|> (fun answer -> printfn "answer: %A" answer);;

    (*
seq { for i in 1 .. 10 do yield i * i }
    |> (fun reg ->
        let low = Seq.item 0 reg.Groups
        let high = Seq.item 1 reg.Groups
        let count = 5
        if count < low || count > high
            then false
            else true
    );;


    let p = Seq.item 2 g
    let pw = Seq.item 3 g
    let m = Regex(p).Matches(pw)
    if m.Count < low || m.Count > high
        then false
        else true;;
    *)


  //  |> Seq.cast<Match>
  //  |> Seq.length
//    |> Seq.groupBy (fun m -> m.Value);;
//    |> Seq.map (fun (value, groups) -> value, (groups |> Seq.length))














//day2Input @"C:\Users\Greg\source\advent-of-code\day2_input.txt"
//|> rGroups

//let checkPassWordsAgainstPolicy g =
//    g |> Seq.cast<Group> |> Seq.toList source


// gs:string list -> seq<Group> list
//  gs:string list -> System.Collections.Generic.IEnumerable<Group> list
//let rGroups gs = List.map (fun item -> 
//    let m = Regex(@"(\d{1,3})-(\d{1,3})\s(\w):\s(\w*)").Match(item)
//    if m.Success
//    then m.Groups.Values
//    else raise (System.ArgumentException("Match not success"))) gs;;

    (*
Seq.map (fun (x:Match) -> x.Groups) |>
Seq.map (fun x -> x |> Seq.cast<Group> |> Seq.nth 1) |>
Seq.map (fun x -> x.Value)


    let low = Seq.item 0 g
    let high = Seq.item 1 g
    let p = Seq.item 2 g
    let pw = Seq.item 3 g
    let m = Regex(p).Matches(pw)
    if m.Count < low || m.Count > high
        then false
        else true;;
        *)
 (* 
 |> Seq.cast<Group>
 seq<Group> 
  *)
(*    *)

//|> List.filter checkPassWordsAgainstPolicy
//|> List.length
//|> (fun x -> printfn "answer is %d" x);;

(*
let newList = List.map (fun x -> x + 1) list1

let (|ParseRegex|_|) regex str =
    let m = Regex(regex).Match(str)
    if m.Success
    then Some (List.tail [ for x in m.Groups -> x.Value ])
    else None

//Example:
let phone = "(555) 555-5555"
match phone with
    | Regex @"\(([0-9]{3})\)[-. ]?([0-9]{3})[-. ]?([0-9]{4})" [ area; prefix; suffix ] -> printfn "Area: %s, Prefix: %s, Suffix: %s" area prefix suffix
    | _ -> printfn "Not a phone number"

// Three different date formats are demonstrated here. The first matches two-
// digit dates and the second matches full dates. This code assumes that if a two-digit
// date is provided, it is an abbreviation, not a year in the first century.
let parseDate str =
   match str with
     | ParseRegex "(\d{1,2})/(\d{1,2})/(\d{1,2})$" [Integer m; Integer d; Integer y]
          -> new System.DateTime(y + 2000, m, d)
     | ParseRegex "(\d{1,2})/(\d{1,2})/(\d{3,4})" [Integer m; Integer d; Integer y]
          -> new System.DateTime(y, m, d)
     | ParseRegex "(\d{1,4})-(\d{1,2})-(\d{1,2})" [Integer y; Integer m; Integer d]
          -> new System.DateTime(y, m, d)
     | _ -> new System.DateTime()

let dt1 = parseDate "12/22/08"
let dt2 = parseDate "1/1/2009"
let dt3 = parseDate "2008-1-15"
let dt4 = parseDate "1995-12-28"

printfn "%s %s %s %s" (dt1.ToString()) (dt2.ToString()) (dt3.ToString()) (dt4.ToString())

*)
