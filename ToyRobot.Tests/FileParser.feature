Feature: FileParser

Scenario Outline: Validate Place Commands
	Given I have a command with the <arguments>
	When I validate the Place command parameters
	Then the value of the status will be <status>
	And the status will contain the message <message>

	Examples:
		| id | arguments     | status  | message                                        |
		| 1  | "0, 0, North" | "Ok"    | "Ok"                                           |
		| 2  | "8, 0, South" | "Ok"    | "Ok"                                           |
		| 3  | ""            | "Error" | "Place command requires 3 arguments"           |
		| 4  | " , 0, North" | "Error" | "Place command invalid 'x' argument"           |
		| 5  | "0 , , North" | "Error" | "Place command invalid 'y' argument"           |
		| 6  | "0 , 0, "     | "Error" | "Place command invalid 'orientation' argument" |
		| 7  | "0 , 0, asdf" | "Error" | "Place command invalid 'orientation' argument" |

Scenario Outline: Validate Move Commands
	Given I have a command with the <arguments>
	When I validate the command Move command parameters
	Then the value of the status will be <status>
	And the status will contain the message <message>

	Examples:
		| id | arguments | status  | message                               |
		| 1  | ""        | "Ok"    | "Ok"                                  |
		| 2  | "asdf"    | "Error" | "Move command invalid argument count" |

Scenario Outline: Validate Left Commands
	Given I have a command with the <arguments>
	When I validate the command Left command parameters
	Then the value of the status will be <status>
	And the status will contain the message <message>

	Examples:
		| id | arguments | status  | message                               |
		| 1  | ""        | "Ok"    | "Ok"                                  |
		| 2  | "asdf"    | "Error" | "Left command invalid argument count" |

Scenario Outline: Validate Right Commands
	Given I have a command with the <arguments>
	When I validate the command Right command parameters
	Then the value of the status will be <status>
	And the status will contain the message <message>

	Examples:
		| id | arguments | status  | message                               |
		| 1  | ""        | "Ok"    | "Ok"                                  |
		| 2  | "asdf"    | "Error" | "Right command invalid argument count" |

Scenario Outline: Validate Report Commands
	Given I have a command with the <arguments>
	When I validate the command Report command parameters
	Then the value of the status will be <status>
	And the status will contain the message <message>

	Examples:
		| id | arguments | status  | message                               |
		| 1  | ""        | "Ok"    | "Ok"                                  |
		| 2  | "asdf"    | "Error" | "Report command invalid argument count" |
