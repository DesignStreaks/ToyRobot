Feature: RobotNavigation

Scenario Outline: Add Robot to Table
	Given the robot exists
	And I have a table of height 5 and width 5
	When I place the robot at <x> and <y> facing <orientation>
	Then the value of the status will be <status>
	And the status will contain the message <message>

	Examples:
		| id | x   | y   | orientation | status | message |
		| 1  | 0   | 0   | "North"     | "Ok"   | "Ok"    |
		| 2  | 0   | 4   | "North"     | "Ok"   | "Ok"    |
		| 3  | 4   | 0   | "North"     | "Ok"   | "Ok"    |
		| 4  | 2   | 2   | "North"     | "Ok"   | "Ok"    |
		| 5  | 4   | 4   | "North"     | "Ok"   | "Ok"    |
		| 6  | 0   | 5   | "North"     | "Ok"   | "Ok"    |
		| 7  | 5   | 0   | "North"     | "Ok"   | "Ok"    |
		| 8  | -1  | 2   | "North"     | "Ok"   | "Ok"    |
		| 9  | 2   | -1  | "North"     | "Ok"   | "Ok"    |
		| 10 | -10 | -10 | "North"     | "Ok"   | "Ok"    |

Scenario Outline: ReAdd Robot to Table
	Given the robot exists
	And I have a table of height 5 and width 5
	And the robot is currently on the Table at <x> and <y> facing <orientation>
	When I readd the robot at <x_new> and <y_new> facing <orientation_new>
	Then the value of the status will be <status>
	And the status will contain the message <message>
	And the Robot is on the Table at <x_new> and <y_new> facing <orientation_new>

	Examples:
		| id | x | y | orientation | x_new | y_new | orientation_new | status | message |
		| 1  | 0 | 0 | "North"     | 0     | 0     | "North"         | "Ok"   | "Ok"    |
		| 1  | 0 | 0 | "North"     | 3     | 3     | "North"         | "Ok"   | "Ok"    |

Scenario Outline: Move Robot when on Table
	Given the robot exists
	And I have a table of height 5 and width 5
	And the robot is currently on the Table at <x> and <y> facing <orientation>
	When I move the robot forward
	Then the value of the status will be <status>
	And the status will contain the message <message>

	Examples:
		| id | x | y | orientation | status | message |
		| 1a | 0 | 0 | "North"     | "Ok"   | "Ok"    |
		| 1b | 0 | 0 | "South"     | "Ok"   | "Ok"    |
		| 1c | 0 | 0 | "East"      | "Ok"   | "Ok"    |
		| 1d | 0 | 0 | "West"      | "Ok"   | "Ok"    |
		| 2a | 0 | 4 | "North"     | "Ok"   | "Ok"    |
		| 2b | 0 | 4 | "South"     | "Ok"   | "Ok"    |
		| 2c | 0 | 4 | "East"      | "Ok"   | "Ok"    |
		| 2d | 0 | 4 | "West"      | "Ok"   | "Ok"    |
		| 3a | 4 | 0 | "North"     | "Ok"   | "Ok"    |
		| 3b | 4 | 0 | "South"     | "Ok"   | "Ok"    |
		| 3c | 4 | 0 | "East"      | "Ok"   | "Ok"    |
		| 3d | 4 | 0 | "West"      | "Ok"   | "Ok"    |
		| 4a | 4 | 4 | "North"     | "Ok"   | "Ok"    |
		| 4b | 4 | 4 | "South"     | "Ok"   | "Ok"    |
		| 4c | 4 | 4 | "East"      | "Ok"   | "Ok"    |
		| 4d | 4 | 4 | "West"      | "Ok"   | "Ok"    |
		| 5a | 2 | 2 | "North"     | "Ok"   | "Ok"    |
		| 5b | 2 | 2 | "South"     | "Ok"   | "Ok"    |
		| 5c | 2 | 2 | "East"      | "Ok"   | "Ok"    |
		| 5d | 2 | 2 | "West"      | "Ok"   | "Ok"    |
		| 6a | 3 | 3 | "North"     | "Ok"   | "Ok"    |
		| 6b | 3 | 3 | "South"     | "Ok"   | "Ok"    |
		| 6c | 3 | 3 | "East"      | "Ok"   | "Ok"    |
		| 6d | 3 | 3 | "West"      | "Ok"   | "Ok"    |

Scenario Outline: Move Robot when not on Table
	Given the robot exists
	And I have a table of height 5 and width 5
	When I move the robot forward
	Then the value of the status will be <status>
	And the status will contain the message <message>

	Examples:
		| id | status | message |
		| 1  | "Ok"   | "Ok"    |

Scenario Outline: Turn Robot when not on Table
	Given the robot exists
	And I have a table of height 5 and width 5
	When I turn the robot <direction>
	Then the value of the status will be <status>
	And the status will contain the message <message>

	Examples:
		| id | direction | status | message |
		| 1  | "Left"    | "Ok"   | "Ok"    |

Scenario Outline: Report Robot Position when on Table
	Given the robot exists
	And I have a table of height 5 and width 5
	And the robot is currently on the Table at <x> and <y> facing <orientation>
	When I Report the Robot Position
	Then the Robot is on the Table at <x> and <y> facing <orientation>

	Examples:
		| id | x | y | orientation |
		| 1a | 0 | 0 | "North"     |
		| 1b | 0 | 0 | "South"     |
		| 1c | 0 | 0 | "East"      |
		| 1d | 0 | 0 | "West"      |
		| 2a | 3 | 2 | "North"     |
		| 2b | 3 | 2 | "South"     |
		| 2c | 3 | 2 | "East"      |
		| 2d | 3 | 2 | "West"      |

Scenario Outline: Report Robot Position after Valid Move
	Given the robot exists
	And I have a table of height 5 and width 5
	And the robot is currently on the Table at <x> and <y> facing <orientation>
	When I move the robot forward
	And I Report the Robot Position
	Then the Robot is on the Table at <x_result> and <y_result> facing <orientation_result>

	Examples:
		| id | x | y | orientation | status | message | x_result | y_result | orientation_result |
		| 1  | 3 | 3 | "North"     | "Ok"   | "Ok"    | 3        | 4        | "North"            |
		| 2  | 3 | 3 | "South"     | "Ok"   | "Ok"    | 3        | 2        | "South"            |
		| 3  | 3 | 3 | "East"      | "Ok"   | "Ok"    | 4        | 3        | "East"             |
		| 4  | 3 | 3 | "West"      | "Ok"   | "Ok"    | 2        | 3        | "West"             |

Scenario Outline: Report Robot Position after Invalid Move
	Given the robot exists
	And I have a table of height 5 and width 5
	And the robot is currently on the Table at <x> and <y> facing <orientation>
	When I move the robot forward
	And I Report the Robot Position
	Then the Robot is on the Table at <x> and <y> facing <orientation>

	Examples:
		| id | x | y | orientation | status | message |
		| 1  | 0 | 4 | "North"     | "Ok"   | "Ok"    |
		| 2  | 0 | 0 | "South"     | "Ok"   | "Ok"    |
		| 3  | 4 | 0 | "East"      | "Ok"   | "Ok"    |
		| 4  | 0 | 0 | "West"      | "Ok"   | "Ok"    |

Scenario Outline: Report Robot Position after Turn
	Given the robot exists
	And I have a table of height 5 and width 5
	And the robot is currently on the Table at <x> and <y> facing <orientation>
	When I turn the robot <direction>
	And I Report the Robot Position
	Then the Robot is on the Table at <x_result> and <y_result> facing <orientation_result>

	Examples:
		| id | x | y | orientation | direction | x_result | y_result | orientation_result | status | message |
		| 1  | 3 | 3 | "North"     | "Left"    | 3        | 3        | "West"             | "Ok"   | "Ok"    |
		| 2  | 3 | 3 | "North"     | "Right"   | 3        | 3        | "East"             | "Ok"   | "Ok"    |
		| 3  | 3 | 3 | "South"     | "Left"    | 3        | 3        | "East"             | "Ok"   | "Ok"    |
		| 4  | 3 | 3 | "South"     | "Right"   | 3        | 3        | "West"             | "Ok"   | "Ok"    |
		| 5  | 3 | 3 | "East"      | "Left"    | 3        | 3        | "North"            | "Ok"   | "Ok"    |
		| 6  | 3 | 3 | "East"      | "Right"   | 3        | 3        | "South"            | "Ok"   | "Ok"    |
		| 7  | 3 | 3 | "West"      | "Left"    | 3        | 3        | "South"            | "Ok"   | "Ok"    |
		| 8  | 3 | 3 | "West"      | "Right"   | 3        | 3        | "North"            | "Ok"   | "Ok"    |