Feature: Create and send email
	Verify saving new draft Email

@mytag
Scenario: Create and send email
	Given I have launched appliction with "nlevchuk", "initial", "Devco" credentials;
	And I have opened My Emails tab;
	When I press New;
	Then I fill to field with "Email@mail.com" Email;
	Then i fill CC field with "Zero@mail.com" email;
	Then I fill subject field with "Test subject" subject;
	Then clicked Send button;
	Then I have closed appilcation.

