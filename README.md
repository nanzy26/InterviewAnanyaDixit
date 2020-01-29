# InterviewAnanyaDixit

Please download the Postman requests via this link: https://www.getpostman.com/collections/467545a379b51fb57157


1. Run the service
2. Using Postman, set the client_id and client_secret
3. Run TestGetCredentials and copy the access_token
4. In TestCreatePayment, paste the access_token in the baseRequest JSON - complete the payment (do this multiple times with different amounts)
5. Run TestGetTransactions by passing in the beneficiary_account_number to the parameter tab to display the completed payments
6. Run TestGetAggregatedAmounts by passing in the beneficiary_account_number to the parameter tab to display aggregated payments for the account specified. The aggregation is done by status category i.e. new, submitted..

Run the tests in the Tests solution.
