namespace Payment_FS

module PaymentService_FS =
    open System.Text.RegularExpressions
    let ccRegex = "\d\d\d\d-\d\d\d\d-\d\d\d\d-\d\d\d\d"

    type Payment = 
    | Cash of decimal
    | CreditCard of (string * decimal) /// (ccNum * amount)

    let createCashPayment amount =
        if amount >= 0m
        then Ok (Cash amount)
        else Error "Cash must be a positive amount"

    let createCreditCardPayment ccNumber amount =
        if Regex.IsMatch(ccNumber, ccRegex)
        then Ok (CreditCard (ccNumber, amount))
        else Error ($"Invalid credit card number: {ccNumber}")

    let processPayment (payment: Payment) =
        match payment with
        | Cash amt ->
            sprintf $"Cash payment of {amt} received"
        | CreditCard (ccNum, amt) ->
            sprintf $"Credit card payment of {amt} received via credit card {ccNum}"
    
    let processPaymentCash amount =
        let payment = createCashPayment amount
        match payment with
        | Ok p ->
            let result = processPayment p
            sprintf $"Payment processed: {result}"
        | Error msg ->
            sprintf $"Invalid payment: {msg}"

    let processPaymentCreditCard ccNumber amount =
        let payment = createCreditCardPayment ccNumber amount
        match payment with
        | Ok p ->
            let result = processPayment p
            sprintf $"Payment processed: {result}"
        | Error msg ->
            sprintf $"Invalid payment: {msg}"