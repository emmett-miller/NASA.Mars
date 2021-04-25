Feature: Rover

@move
Scenario: Single command sequence
	Given initial position is [0 0 N]
	And command sequence is L2
	When move command is given
	Then the result should be [2 0 E]

@moveSequence
Scenario: Multiple command Sequence
	Given initial position is [10 10 N]
	And the following command sequence R1R3L2L1
	When move command is given
	Then the result should be [8 13 S]

@roverBoundaryReached
Scenario: Rover has reached edge
	Given initial position is [0 0 N]
	And the following command sequence L1R3L2L1
	When move command is given
	Then rover should inform NASA that it cannot execute sequence

@sequencer
Scenario: Command sequencer
	Given initial command sequence is R1R3L2L1
	When command is sequenced
	Then the result should be
		| Step | Command |
		| 1    | R1      |
		| 2    | R3      |
		| 3    | L2      |
		| 4    | L1      |

@movementTracker
Scenario: Action space
	Given initial position is [10 10 N]
	And command sequence R1R3L2L1
	When move command is given
	Then the action space should be	
	  | Oriention | Steps | Position  |
	  | R         | 1     | [11 10 E] |
	  | R         | 3     | [11 13 N] |
	  | L         | 2     | [9 13 W]  |
	  | L         | 1     | [8 13 S]  |