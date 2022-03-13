# Architectural Overview

Medea consists of three main components:
  * Client
  * Server
  * Core

The Core component contains all of the modules needed to manage the database and execute queries.

The Server component wraps around the Core to provide clients with access to the database.

The Client component can be used to connect to the Server, but it also contains a dynamic link to the Core. This means that if Medea.Core.dll is available, the Client can be used to run a database within the same process (in-memory, file-backed or embedded).

## Medea.Client

The Client can be used to start a session (using the Session class). `Session.Create` accepts a URL with one of the following schemes:
  * `data` (followed by an initial data set)
  * `file` (with the path to an initial data set)
  * `file` (with the path to the data storage directory)
  * `http` (pointing to a local or remote server)
  * `https` (same as http but over TLS)

## Medea.Server

The Server is built using ASP.NET Core. It exposes the following endpoints:
  * `/` (inspect node status, role, etc.)
  * `/query` (submit queries from client to server)
  * `/job` (submit jobs from server to worker)
  * `/log` (submit log entries from leader to follower)

Servers can be run in standalone or cluster mode. In cluster mode, there are several replication modes:
  * asynchronous (followers can handle read queries that may return stale results)
  * synchronous (followers can handle read queries that always return fresh results)
  * multi-leader (read and write queries are handled by multiple nodes)

## Medea.Core

The Core follows the Parser/Planner/Executor paradigm. Executors use the Compiler to turn plans into C# code. That code uses facades from the JavaScript, FileStorage and DataStorage modules to perform more complicated tasks. All this is orchestrated from the Service module.

### Medea.Core.Service

The services in this module should be used as entry-points to the Core. A `DatabaseService` can be used to manage the database. A `QueryService` can be used to execute queries.

### Medea.Core.Parser

The Parser is built using [Hime](https://cenotelie.fr/projects/hime). The grammar is inspired by Cypher and ECMAScript.

### Medea.Core.Planner

The Planner turns ASTs into query plans.

TODO: this should include a cost-based planner, but at the moment it just translates clauses to operators.

### Medea.Core.Executor

TODO: There should be multiple strategies for executing a query. I'm working on `LocalExecutor` first, but as soon as I get around to cluster-mode I'll have to implement `RemoteExecutor` as well.

### Medea.Core.Compiler

The Compiler turns a query plan stage into an ICompiledQueryStage in the following steps:

  1. turn a query plan stage into C# code (and JavaScript code)
  2. compiles the C# code into an in-memory assembly
  3. load the assembly and use reflection to create an instance

Expressions are compiled into JavaScript so that they can be evaluated using the `JavaScriptFacade`.

Patterns are compiled into C# to minimize overhead.

Operators are compiled into C# that uses the compiled expressions and patterns, as well as the `FileStorageFacade` and the `DataStorageFacade`.

### Medea.Core.JavaScript

The `JavaScriptFacade` uses [Jint](https://github.com/sebastienros/jint) for evaluating expressions.

TODO: at the moment it creates a new `Engine` every time it evaluates an expression; there might be a smarter way to do this.

### Medea.Core.FileStorage

The `FileStorageFacade` provides a simple API for queries to read and write data files.

TODO: at the moment it only reads RAW text files from the local filesystem; I intend to add reading TEXT, JSON, NDJSON, XML, NDXML, HTML, and CSV, both uncompressed and compressed, writing all these formats, and remote filesystems like WebDAV, cloud storage, etc.

### Medea.Core.DataStorage

TODO: the `DataStorageFacade` should provide access to all the data storage mechanisms for the WAL, row/column/event stores, and indexes; probably metadata as well, which includes statistics; all this using my home grown implementations of B-trees, log-merge-trees, etc. in some weird JSON-based format.
