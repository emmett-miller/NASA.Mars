Feature: MarsRover
	Final position and orientation as a result of a command sequence

@resultOfCommandSequence
Scenario: Final position as a result of command sequence
	Given initial position is [10 10 N]
	And the following command sequence R1R3L2L1
	When move command is given
	Then final position should be [13 8 N]