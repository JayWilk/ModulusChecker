# Modulus Checker 
[![Build status](https://ci.appveyor.com/api/projects/status/cdk59wiol83qlngs?svg=true)](https://ci.appveyor.com/project/JayWilk/moduluschecker) [![Codacy Badge](https://api.codacy.com/project/badge/Grade/ecdc8c7916d64fc7ad1d51b794101375)](https://www.codacy.com/app/wilkinson_929/ModulusChecker?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=JayWilk/ModulusChecker&amp;utm_campaign=Badge_Grade)

This application provides a JSON endpoint that will validate a provided bank account number and sort code against the [Vocalink Mastercard modulus checking specification,](http://jaywilkinson.co.uk/files/Validation_OAN.pdf) based on the algorithms indicated in the weight table documented in section 6.1 of the specification.


## Considerations

- All account numbers and sort codes are considered valid unless otherwise stated
- There is no account number validation within the web service endpoint. This is outside of the scope of this application.
- Currently, only exceptions 4 and 7 are supported. Any account details requiring other exception checks will not be processed and will be considered valid. 

## Tests

This API endpoint is currently deployed to the following website address: http://jaywilkinson.co.uk/api/moduluscheck/

It can be tested by providing a subsequent account number and sort code. A response will be returned in JSON, in the format of a boolean to the value of true or false, depending on the result of the validation processing.
For example: http://jaywilkinson.co.uk/api/moduluscheck/validateaccount?sortCode=089999&accountNumber=66374959

Please note that if a sort code or account number is outside of the range of the weight table, it will still return a value of true based on the considerations documented above. 

The below table details some test accounts which were obtained from the specification

 
| Account Number | Sort Code | Algorithm              | Valid |  Test URL    | Notes                                       |
|----------------|-----------|------------------------|-------|------|---------------------------------------------|
| 66374958       | 089999    | Modulus 10             | Yes   | Test |                                             |
| 88837491       | 107999    | Modulus 11             | Yes   | Test |                                             |
| 66374959       | 089999    | Modulus 10             | No    | Test |                                             |
| 88837493       | 107999    | Modulus 11             | No    | Test |                                             |
| 66831036       | 203099    | Modulus 11  Double Alt | No    | Test | Exception 6 is not supported - returns true |
| 58716970       | 203099    | Modulus 11 Double Alt  | No    | Test | Exception 6 is not supported - returns true |
| 63849203       | 134020    | Modulus 11             | Yes   | Test | Exception 4                                 |
| 99345694       | 772798    | Modulus 11             | Yes   | Test | Exception 7                                 |

Please note that the Unit Tests included in the Core project will provide a more accurate and detailed result, and all of the above tests are covered.


## Installation

For installation on a local environment for local development within IIS:
- Pull the latest release down, build and compile, restoring any Nuget packages.
- Create an IIS website, and map it to the ModulusChecker directory (as this contains the web project)
- Configure any bindings, and make any appropriate updates to the Windows Hosts file if deploying to a local development URL

## Known Issues 

[Please see GitHub issues](https://github.com/JayWilk/ModulusChecker/issues) 


