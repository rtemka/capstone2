module Domain

/// Represent an individual customer entity
type Customer = { Name: string }

/// Represent an account entity
type Account =
    { AccountId: System.Guid
      Owner: Customer
      Balance: decimal }
