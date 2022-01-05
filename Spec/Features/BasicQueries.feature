Feature: Basic Queries

Scenario: Return 1
    Given an empty database
    When I execute
    """
    RETURN 1;
    """
    Then the results should be
    """
    1
    """
