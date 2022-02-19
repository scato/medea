Feature: The LOAD clause

Scenario: Load raw string
    Given an empty database
    When I execute
    """
    LOAD RAW FROM "Fixtures/example.txt" AS contents
    RETURN contents.replace(/\r/g, "");
    """
    Then the results should be
    """
    "foo\nbar\n"
    """
