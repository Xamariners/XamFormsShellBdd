Feature: LoginFeature

Testing for User Authentication

Scenario Outline: Login with valid credentials
	Given I am an unauthenticated user
	When I enter username "<username>" and password "<password>"
	And I tap the login button
	Then I am authenticated
	And I cannot see an Error

Examples: 

| username     | password     |
| goodUserName | goodPassword |

Scenario Outline: Login with invalid credentials
	Given I am an unauthenticated user
	When I enter username "<username>" and password "<password>"
	And I tap the login button
	Then I am an unauthenticated user
	And I can see an Error "Invalid Credentials"

Examples: 

| username    | password    |
| badUserName | badPassword |
