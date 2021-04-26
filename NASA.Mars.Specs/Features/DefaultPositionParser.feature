Feature: DefaultPositionParser
	Parse position sequence string

@parsePositionSequence
Scenario: parse position sequence
	Given an initial sequence of
		| Sequence  |
		| [10 10 N] |
	When the parse command is given
	Then result should be X=10, Y=10 and Direction="N"