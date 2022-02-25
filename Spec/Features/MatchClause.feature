Feature: The MATCH clause

Scenario: Match all records
    Given a database that contains
    """
    {"title": "Magic: The Gathering", year: "1993"}
    {"title": "Middle-earth Collectible Card Game", year: "1995"}
    {"title": "The Lord of the Rings Trading Card Game", year: "2001"}
    """
    When I execute
    """
    MATCH game;
    """
    Then the results should be
    """
    {"game": {"title": "Magic: The Gathering", year: "1993"}}
    {"game": {"title": "Middle-earth Collectible Card Game", year: "1995"}}
    {"game": {"title": "The Lord of the Rings Trading Card Game", year: "2001"}}
    """
