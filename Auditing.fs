module Auditing

open System
open Domain

// auditor that writes to filesystem in txt files
let fileSystemAudit account message =
    [| "temp"
       "capstone2"
       account.Owner.Name |]
    |> IO.Path.Combine
    |> IO.Directory.CreateDirectory
    |> fun dir ->
        [| dir.FullName
           string account.AccountId + ".txt" |]
    |> IO.Path.Combine
    |> fun tempPath -> (tempPath, $"Account %A{account.AccountId}: %s{message}")
    |> IO.File.AppendAllText

// Auditor that writes to console
let consoleAudit account message =
    printfn $"Account %A{account.AccountId}: %s{message}"

let transactionResult was now =
    if was = now then
        "Transaction rejected!\n"
    else
        sprintf "Transaction accepted! Balance is now %M\n" now

let auditAs operationName audit operation amount account =

    sprintf "Performing a '%s' operation for %M...\n" operationName amount
    |> audit account

    let newAccount = operation amount account

    transactionResult account.Balance newAccount.Balance
    |> audit newAccount

    newAccount
