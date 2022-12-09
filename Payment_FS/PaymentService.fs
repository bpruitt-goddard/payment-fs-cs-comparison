namespace Payment_FS

module PaymentService_FS =
    type Payment = 
    | Cash of decimal
    | CreditCard of (string * decimal) /// (ccNum * amount)

    let createCashPayment amount =
        if amount >= 0m
        then Ok (Cash amount)
        else Error "Cash must be a positive amount"

    let processPayment (payment: Payment) =
        match payment with
        | Cash amt ->
            sprintf $"Cash payment of {amt} received"
        | CreditCard (ccNum, amt) ->
            sprintf $"Credit card payment of {amt} recieved via credit card {ccNum}"
    
    let processPaymentCash amount =
        let payment = createCashPayment amount
        match payment with
        | Ok p ->
            let result = processPayment p
            sprintf $"Cash payment processd: {result}"
        | Error msg ->
            sprintf $"Invalid cash payment: {msg}"


    let add num1 num2 = num1 + num2
