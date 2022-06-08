module Operations

open Domain

/// Deposits specified amount on Account
let deposit amount account : Account =
    { account with Balance = account.Balance + amount }

/// Withdraws specified amount from Account
let withdraw amount account =
    if account.Balance < amount then
        account
    else
        { account with Balance = account.Balance - amount }
