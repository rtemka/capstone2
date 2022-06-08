open System
open Domain
open Operations
open Auditing

let withdrawWithConsoleAudit = auditAs "withdraw" consoleAudit withdraw

let depositWithConsoleAudit = auditAs "deposit" consoleAudit deposit

let withdrawWithFileSystemAudit = auditAs "withdraw" fileSystemAudit withdraw

let depositWithFileSystemAudit = auditAs "deposit" fileSystemAudit deposit


[<EntryPoint>]
let main _ =
    printfn "Your name for opening account, please:"
    let name = Console.ReadLine()
    printfn "Your initial balance, please:"
    let balance = Console.ReadLine() |> Decimal.Parse
    let customer = { Name = name }

    let mutable account =
        { AccountId = Guid.NewGuid()
          Owner = customer
          Balance = balance }

    while true do
        printfn "Please type action on account ('d' for deposit, 'w' for withdrawal, 'x' for quit)\n"
        let action = Console.ReadLine()
        if action = "x" then Environment.Exit 0

        printfn "Specify the amount for the operation:"
        let amount = Console.ReadLine() |> Decimal.Parse

        account <-
            if action = "d" then
                account |> depositWithConsoleAudit amount
            elif action = "w" then
                account |> withdrawWithConsoleAudit amount
            else
                account

    0
