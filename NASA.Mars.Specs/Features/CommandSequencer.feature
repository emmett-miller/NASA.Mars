Feature: CommandSequencer
	Simple command sequencer for command string in format ((L|R)\d+)+

@commandSequencer
Scenario: command sequencer
	Given the command sequence of L1R1L19
	When the command is sequenced
	Then the result should be L1 R1 L19