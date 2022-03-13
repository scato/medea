# Querying

The Medea Query Language was inspired by [Cypher](https://neo4j.com/developer/cypher/), but instead of matching nodes in a graph, we match documents.

## Matching

The patterns used for matching are inspired by JavaScript [destructuring](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Operators/Destructuring_assignment). The following query will only match documents that contain both a `title` and a `year` property:

```
MATCH {title, year};
```

As with destructuring, the values of these properties will be put in variables `title` and `year`.

The pattern above is short hand for `{title: title, year: year}`. You could also assign those properties to variables with different names:

```
MATCH {title: game_title, year: year_published};
```

Unlike destructuring, you won't get an error if there is a mismatch. The document will simply not be matched. Another way to use this matching behaviour is if you are only interested in documents with a certain value for `year`:

```
MATCH {title, year: "1993"};
```

If you are interested in the other properties that are on the document that was matched, there are two options. You can use rest syntax:

```
MATCH {year: "1993", ...game};
```

Or you can use an alias:

```
MATCH {year: "1993"} AS game;
```

In the first query, `game` will not include `year`. In the second query it will.

See [Matching Patterns](Matching%20Patterns.md) for more ways to match documents.

## Transforming

Once you have matched some records, you can return them directly or you can perform some additional transformations.

For example, suppose you want the year as a number instead of a string:

```
MATCH {year, ...game}
RETURN {year: Number(year), ...game};
```

Almost any JavaScript expression is also a valid Medea expression. In this case, we used the `Number` constructor to convert `year` to a number, and we use the spread operator to add all properties in `game` to our result.

You can also use `LET` and `WITH` to perform intermediate steps:

```
MATCH {year, ...game}
LET year = Number(year)
WITH {year, ...game} AS game
RETURN game;
```

Both `LET` and `WITH` use an expression to generate results, and a pattern to match those results. In the case of `LET`, `Number(year)` is evaluated and matched to `year`. In the case of `WITH`, `{year, ...game}` is evaluated and matched to `game`.

The difference between `LET` and `WITH` is that `LET` assigns or replaces the variables it matches, while `WITH` replaces the entire context. Therefore, the following will not work:

```
MATCH {year, ...game}
WITH {year, ...game} AS game
LET year = Number(year)
RETURN game;
```

In this case `year` is thrown out by the `WITH` clause and `Number(year)` throws an exception.

`WITH` also allows you to perform multiple matches and join the results. However, all the expressions are evaluated before the matches are made, so the following query will work, but it will still contain years as strings instead of numbers:

```
MATCH {year, ...game}
WITH Number(year) AS year, {year, ...game} AS game
RETURN game;
```

TODO: write more about expressions and link to that page.

## Joining

TODO
