Feature: EC4_Login
	Verify login functionality
@mytag
Scenario: EC4_Login_Logout

	Given I have launched the EC4 application
	And i have inputted "nlevchuk" to the Login field.
	And I have inputted "initial" in to the Password field
	And I have inputted "Devco" to the Client field.
	And i have selected Remember me checkbox
	And I have clicked Login button
	Then Desktop selection window with desk selection combobox appeared 
	And I have checked Make me immediately available Checkbox
	And I have clicked ok button
	Then agent dashboard window opened.
	And i closed the application.

	

	

	

	
