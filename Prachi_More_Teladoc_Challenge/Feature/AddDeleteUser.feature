Feature: AddDeleteUser
As an Engr. Candidate
I need to automate http://www.way2automation.com/angularjs-protractor/webtables
So I can show my awesome automation skills

@MyTest
Scenario: Add a user and validate the user has been added to the table
Given I am on the site
Then I Add User
| FirstName | LastName | UserName     | Password | Customer    | Role     | Email           | CellPhone    |
| TestFirst | TestLast | testusername | test@123 | Company AAA | Customer | email@email.com | 555-555-5555 |
And I verify username testusername has been added

@MyTest
Scenario: Delete user User Name: novak and validate user has been deleted
Given I am on the site
Then I delete the user with username novak
And I verify user with username novak has been deleted