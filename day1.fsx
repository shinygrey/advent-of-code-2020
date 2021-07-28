let day1_input = @"./day1_input.txt"

// file:string -> int list
let day1Numbers file = 
    System.IO.File.ReadAllText file
    |> fun line -> Seq.toList (line.Split System.Environment.NewLine)
    |> List.map (fun s -> int s)
    |> List.sort;;

// ns:int list -> nc:int -> int * int * int
let rec findNumberToSum2020 nc ns = 
    match ns with
    | n1::tail  -> if (n1 + nc) = 2020
                    then (n1, nc, n1 * nc)
                    else findNumberToSum2020 nc tail
    | []        -> (0,0,0);;

// int list -> int * int * int
let rec findTwoNumbersThatAddUpTo2020 numbers = 
    match numbers with
    | n1::tail  -> match findNumberToSum2020 n1 numbers with
                    | (0,0,0) -> findTwoNumbersThatAddUpTo2020 tail
                    | (x,y,z) -> (x,y,z)
    | []        -> raise (System.ArgumentException("no numbers sum to 2020"));;

day1Numbers day1_input
|> findTwoNumbersThatAddUpTo2020
|> (fun answer -> match answer with // int * int * int -> unit
                    | (a,b,c) -> printfn "answer: %d x %d is %d" a b c);;

// int list -> int * int * int * int
let rec findThreeNumbersThatAddUpTo2020 numbers =
    let rec is_answer numbers1 nc =
        match numbers1 with
        | n1::[]    -> None
        | n1::tail  -> if n1 + nc = 2020
                        then Some(n1)
                        else is_answer tail nc
        | _         -> None
    let rec check_number numbers2 =
        match numbers2 with
        | n1::n2::[]    -> match numbers with
                            | n1::n2::[]    -> raise (System.ArgumentException("no numbers sum to 2020"))
                            | n1::n2::tail  -> n2::tail |> findThreeNumbersThatAddUpTo2020
                            | _             -> raise (System.ArgumentException("other error 2"))
        | n1::n2::tail  -> match n1 + n2 |> is_answer tail with
                            | Some(x)   -> n1*n2*x |> (fun a -> (n1,n2,x,a))
                            | None      -> n1::tail |> check_number
        | n1::[]        -> raise (System.ArgumentException("invalid argument"))
        | _             -> raise (System.ArgumentException("other error 1"))
    check_number numbers;;

day1Numbers day1_input
|> findThreeNumbersThatAddUpTo2020
|> (fun answer -> match answer with // int * int * int * int -> unit
                    | (a,b,c,d) -> printfn "answer: %d x %d x %d is %d" a b c d);;
