# Matching Patterns

Below is an overview of all the ways to match documents.

## Object Patterns

Usually, document in the database will be objects. Below are all the different ways of matching objects.

```js
{title, year} // match objects that have a title and year, return them as variables
{title, year = null} // match objects that have a title, return the title and year (or null if there is no year)
{title, ...game} // match objects that have a title, return the title and the rest of the document as game
{title: game_title, year: year_published} // match objects that have a title and year, return them as variables with different names
```

You can mix the different property patterns freely, but you can only use one `...` pattern and only at the end.

You can also use a literal pattern for filtering:

```js
{title, year: 1993} // match objects that have a title and where year equals 1993, return the title
```

## Array Patterns

One way of matching arrays is to interpret them as tuples.

```js
[title, year] // match arrays with two elements, return them as variables
[title, year = null] // match arrays with one or two elements, return them as title and year (or null if there is no second element)
[title, ...game] // match arrays with at least one element, return the first element as title and the rest as game
```

Just like with the object pattern, you can use a literal pattern for filtering:

```js
[title, 1993] // match arrays with two elements where the second element equals 1993, return the first element as title
```

## Unwind Pattern

Another way of matching arrays is to treat them as lists.

```js
publisher[] // match an array, return each element as a different result, with publisher as the variable name
```

If you unwind an array this way, you can combine the output variable with other variables:

```js
{title, year, publishers: publisher[]} // match objects with a title, year and publishers where publishers contains an array, return each element in publishers as publisher, combined with the title and year of the corresponding record
```

## Alias Pattern

When matching a pattern, you can choose to return the entire match as a variable as well:

```js
{title, year: 1993} as game // match objects that have a title and where year equals 1993, return the title and return the entire object as game
```

## Literal Patterns

As described above, literal patterns can be used for filtering:

```js
{title, year: 1993} // match objects that have a title and where year equals 1993, return the title
```

Literals can be any type:

```js
1993
"1993"
true
null
```

Array patterns that contain only literals are effectively a literal pattern themselves. Object pattern that contain only literals still match objects with extraneous properties.

## Regular Expression Patterns

You can also use a JavaScript RegExp literal as a pattern:

```js
/^[0-9]+$/ // match a string with one or more decimals
```

TODO: I'm not sure, but maybe I want to make the `^` and `$` implicit

## Template Patterns

A special way of matching strings is to use a template pattern:

```js
`${year}[note 1]` // match a string that ends with "[note 1]", return the beginning as year
```

You can combine this with other patterns, but only those that will match strings:

```js
`${/^[0-9]+$/ as year}[note 1]` // match a string that starts with one or more decimals and ends with "[note 1]", return the beginning as year
```

## JSX Patterns

You may have recognized template patterns as an inverse of template strings. The same goes for JSX expressions:

```xml
<tr>{tds}</tr> // match a tr-tag, return it's children as tds
<tr colspan="2">{tds}</tr> // match a tr-tag with colspan 2, return it's children as tds
<td>${year}</td> // match a td-tag with one text child node, return the child as year
```

Note that we use template pattern syntax for matching the text content of a tag. This is short-hand for:

```xml
<td>{[`${year}`]}</td> // match a td-tag with one text child node, return the child as year
```

In fact, all of the JSX template syntax is sugar for object and array patterns.

TODO: when matching a single text child node, if the node has 0 children, then we probably want to match that as an empty string; this is probably pretty simple if you desugar it as `{children: [`${year}` = '']}`.
TODO: what would it look like if we match attributes? `<tr colspan={colspan}>`? is there a shorthand?
TODO: isn't there a spread operator passing attributes in JSX?
TODO: do we need to add diamond syntax? it would be sugar for an array pattern without the surrounding object pattern.
TODO: show the actual desugared patterns?
