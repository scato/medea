Feature: The LOAD clause

Scenario: Load raw string
    Given an empty database
    When I execute
    """
    LOAD RAW FROM "Fixtures/example.txt" AS contents;
    """
    Then the results should be
    """
    {"contents":"foo\r\nbar\r\n"}
    """
