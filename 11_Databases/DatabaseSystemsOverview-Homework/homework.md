# Database Systems - Overview Homework

## Task 01.
### What database models do you know?
1. Hierarchical database model

A hierarchical database model is a data model in which the data is organized into a tree-like structure. The data is stored as records which are connected to one another through links.
The hierarchical structure was developed by IBM in the 1960s. This structure is simple but inflexible because the relationship is confined to a one-to-many relationship. 
The hierarchical data model lost traction as Codd's relational model became the de facto standard used by virtually all mainstream database management systems. 

2. Network database model

The network model is a database model conceived as a flexible way of representing objects and their relationships. Its distinguishing feature is that the schema, viewed as a graph in which object types are nodes and relationship types are arcs, is not restricted to being a hierarchy
The network model's original inventor was Charles Bachman, and it was developed into a standard specification published in 1969 by the Conference on Data Systems Languages (CODASYL) Consortium. 
It was eventually displaced by the relational model, which offered a higher-level, more declarative interface. 

3. Relational database model

The relational model for database management is an approach first described in 1969 by Edgar F. Codd. In the relational model of a database, all data is represented in terms of tuples, grouped into relations.
The purpose of the relational model is to provide a declarative method for specifying data and queries: users directly state what information the database contains and what information they want from it, and let the database management system software take care of describing data structures for storing the data and retrieval procedures for answering queries.

4. Object database

An object database (also object-oriented database management system) is a database management system in which information is represented in the form of objects as used in object-oriented programming. 
The term "object-oriented database system" first appeared around 1985.
An object database stores complex data and relationships between data directly, without mapping to relational rows and columns, and this makes them suitable for applications dealing with very complex data. Objects have a many to many relationship and are accessed by the use of pointers. Pointers are linked to objects to establish relationships. 

- - - -

## Task 02.
### Which are the main functions performed by a Relational Database Management System (RDBMS)?

RDBMSs typically implement:

* Creating / altering / deleting tables and relationships between them (database schema)
* Adding, changing, deleting, searching and retrieving of data stored in the tables
* Support for the SQL language
* Transaction management (optional)

- - - -

## Task 03.
### Define what is "table" in database terms.

A table is a collection of related data held in a structured format within a database. It consists of fields (columns), and rows.

In terms of the relational model of databases, a table can be considered a convenient representation of a relation, but the two are not strictly equivalent. For instance, an SQL table can potentially contain duplicate rows, whereas a true relation cannot contain duplicate tuples. Similarly, representation as a table implies a particular ordering to the rows and columns, whereas a relation is explicitly unordered. However, the database system does not guarantee any ordering of the rows unless an 'ORDER BY' clause is specified in the 'SELECT' statement that queries the table.

- - - -

## Task 04.
### Explain the difference between a primary and a foreign key.

In SQL Server, there are two keys - primary key and foreign key which seems identical, but actually both are different in features and behaviours.
| Primary Key   				     	| Foreign Key                                         	| 
| ---------------------------------------------------- 	|:----------------------------------------------------:	| 
| Primary key uniquely identify a record in the table	| Foreign key is a field in the table that is primary 	| 
							| key in another table. 				|
| Primary Key can't accept null values. 		| Foreign key can accept multiple null value. 		|  
 By default, Primary key is clustered index and data    | Foreign key do not automatically create an index,      
 in the database table is physically organized in th	| clustered or non-clustered. You can manually create	
 sequence of clustered index. 				|  an index on foreign key. 				
| We can have only one Primary key in a table. 		| We can have more than one foreign key in a table.  	|

- - - -

## Task 05.
### Explain the different kinds of relationships between tables in relational databases.

There are three types of relationships:

* __One-to-one__: Both tables can have only one record on either side of the relationship. Each primary key value relates to only one (or no) record in the related table. They're like spouses—you may or may not be married, but if you are, both you and your spouse have only one spouse. Most one-to-one relationships are forced by business rules and don't flow naturally from the data. In the absence of such a rule, you can usually combine both tables into one table without breaking any normalization rules.
The primary key side of a one-to-one relationship is denoted by a key symbol. The foreign key side is also denoted by a key symbol.
* __One-to-many__: The primary key table contains only one record that relates to none, one, or many records in the related table. This relationship is similar to the one between you and a parent. You have only one mother, but your mother may have several children.
Make a one-to-many relationship if only one of the related columns is a primary key or has a unique constraint.
The primary key side of a one-to-many relationship is denoted by a key symbol. The foreign key side of a relationship is denoted by an infinity symbol.
* __Many-to-many__: Each record in both tables can relate to any number of records (or no records) in the other table. For instance, if you have several siblings, so do your siblings (have many siblings). Many-to-many relationships require a third table, known as an associate or linking table, because relational systems can't directly accommodate the relationship.

- - - -

## Task 06.
### When is a certain database schema normalized?
	
Normalisation is the process of organizing the columns (attributes) and tables (relations) of a relational database to minimize data redundancy.	
Normalization involves decomposing a table into less redundant (and smaller) tables without losing information; defining foreign keys in the old table referencing the primary keys of the new ones. The objective is to isolate data so that additions, deletions, and modifications of an attribute can be made in just one table and then propagated through the rest of the database using the defined foreign keys.
A typical example of normalization is that an entity's unique ID is stored everywhere in the system but its name is held in only one table. The name can be updated more easily in one row of one table.

__Advantages__

* Smaller database: By eliminating duplicate data, you will be able to reduce the overall size of the database.
* Better performance: Fewer indexes per table mean faster maintenance tasks such as index rebuilds. Only join tables that you need.
* Narrow tables: Having more fine-tuned tables allows your tables to have less columns and allows you to fit more records per data page.	

- - - -

## Task 07.
### What are database integrity constraints and when are they used?

Data integrity is normally enforced in a database system by a series of integrity constraints or rules. Three types of integrity constraints are an inherent part of the relational data model: entity integrity, referential integrity and domain integrity:

* __Entity integrity__ concerns the concept of a primary key. Entity integrity is an integrity rule which states that every table must have a primary key and that the column or columns chosen to be the primary key should be unique and not null.
* __Referential integrity__ concerns the concept of a foreign key. The referential integrity rule states that any foreign-key value can only be in one of two states. The usual state of affairs is that the foreign-key value refers to a primary key value of some table in the database. Occasionally, and this will depend on the rules of the data owner, a foreign-key value can be null. In this case we are explicitly saying that either there is no relationship between the objects represented in the database or that this relationship is unknown.
* __Domain integrity__ specifies that all columns in a relational database must be declared upon a defined domain. The primary unit of data in the relational data model is the data item. Such data items are said to be non-decomposable or atomic. A domain is a set of values of the same type. Domains are therefore pools of values from which actual values appearing in the columns of a table are drawn.
* __User-defined integrity__ refers to a set of rules specified by a user, which do not belong to the entity, domain and referential integrity categories.

Having a single, well-controlled, and well-defined data-integrity system increases

* stability (one centralized system performs all data integrity operations)
* performance (all data integrity operations are performed in the same tier as the consistency model)
* re-usability (all applications benefit from a single centralized data integrity system)
* maintainability (one centralized system for all data integrity administration).

- - - -

## Task 08.
### Point out the pros and cons of using indexes in a database.

__Advantages__: use an index for quick access to a database table specific information. The index is a structure of the database table the value of one or more columns to sort
As a general rule, only when the data in the index column Frequent queries, only need to create an index on the table. The index take up disk space and reduce to add, delete, and update the line speed. In most cases, the speed advantages of indexes for data retrieval greatly exceeds it. 

__Disadvantages__: too index will affect the speed of update and insert, because it requires the same update each index file. For a frequently updated and inserted into the table, there is no need for a rarely used where the words indexed separately, small table, the cost of sorting will not be great, there is no need to create additional indexes. In some cases, the indexing words may not be fast, for example, the index is placed in a contiguous memory space, which will increase the burden of disk read, which is optimal, it should be through the actual use of the environment to be tested

- - - -

## Task 09.
### What's the main purpose of the SQL language?

SQL (Structured Query Language) is a special-purpose programming language designed for managing data held in a relational database management system. SQL consists of a data definition language, data manipulation language, and a data control language. The scope of SQL includes data insert, query, update and delete, schema creation and modification, and data access control.

SQL was created to shield the database programmer from understanding the specifics of how data is physically stored in each database management system and also to provide a universal foundation for updating, creating and extracting data from database systems that support an SQL interface. SQL approaches databases from a logical perspective rather than a physical perspective. In the old days (before SQL was around), in order to query and/or update a database, a programmer would have to understand how data was physically stored, for example the number of bytes in a record, stop tags etc. This requirement made code hard to read, difficult to port if the underlying database system changed, and required a lot more coding. SQL and its predecessors (other query languages) changed a lot of that by providing a logical abstraction to this physical layer. Now a DB programmer only had to worry about the tables that made up a database and how each table related - a programmer could now focus more on the meaning of the data and much less on how this data was physically stored.

- - - -

## Task 10.
### What are transactions used for?

A transaction is a unit of work that is performed against a database. Transactions are units or sequences of work accomplished in a logical order, whether in a manual fashion by a user or automatically by some sort of a database program.

A transaction is the propagation of one or more changes to the database. For example, if you are creating a record or updating a record or deleting a record from the table, then you are performing transaction on the table. It is important to control transactions to ensure data integrity and to handle database errors.

Practically, you will club many SQL queries into a group and you will execute all of them together as a part of a transaction.

__Properties of Transactions:__
Transactions have the following four standard properties, usually referred to by the acronym ACID:

* Atomicity: ensures that all operations within the work unit are completed successfully; otherwise, the transaction is aborted at the point of failure, and previous operations are rolled back to their former state.
* Consistency: ensures that the database properly changes states upon a successfully committed transaction.
* Isolation: enables transactions to operate independently of and transparent to each other.
* Durability: ensures that the result or effect of a committed transaction persists in case of a system failure.

__Transaction Control:__
There are following commands used to control transactions:

* 'COMMIT': to save the changes.
* 'ROLLBACK': to rollback the changes.
* 'SAVEPOINT': creates points within groups of transactions in which to ROLLBACK
* 'SET TRANSACTION': Places a name on a transaction.

Transactional control commands are only used with the DML commands INSERT, UPDATE and DELETE only. They can not be used while creating tables or dropping them because these operations are automatically commited in the database.

- - - -

## Task 11.
### What is a NoSQL database?

A NoSQL database environment is, simply put, a non-relational and largely distributed database system that enables rapid, ad-hoc organization and analysis of extremely high-volume, disparate data types. 
NoSQL databases are sometimes referred to as cloud databases, non-relational databases, Big Data databases and a myriad of other terms and were developed in response to the sheer volume of data being generated, stored and analyzed by modern users (user-generated data) and their applications (machine-generated data).

In general, NoSQL databases have become the first alternative to relational databases, with scalability, availability, and fault tolerance being key deciding factors. 
They go well beyond the more widely understood legacy, relational databases (such as Oracle, SQL Server and DB2 databases) in satisfying the needs of today’s modern business applications. 
A very flexible and schema-less data model, horizontal scalability, distributed architectures, and the use of languages and interfaces that are “not only” SQL typically characterize this technology.

- - - -

## Task 12.
### Explain the classical non-relational data models.

__Document model__

* The central concept of a document model is the notion of a "document". While each document-oriented database implementation differs on the details of this definition, in general, they all assume that documents encapsulate and encode data (or information) in some standard formats or encodings. Encodings in use include XML, YAML, and JSON as well as binary forms like BSON.
* Documents are addressed in the database via a unique key that represents that document. One of the other defining characteristics of a document-oriented database is that in addition to the key lookup performed by a key-value store, the database offers an API or query language that retrieves documents based on their contents.
* Compared to relational databases, for example, collections could be considered analogous to tables and documents analogous to records. But they are different: every record in a table has the same sequence of fields, while documents in a collection may have fields that are completely different.

__Key-value model__

* Key-value model use the associative array (a.k.a. Dictionary in C#) as their fundamental data model. In this model, data is represented as a collection of key-value pairs, such that each possible key appears at most once in the collection.
* The Key-value model is one of the simplest non-trivial data models, and richer data models are often implemented on top of it. The key-value model can be extended to an ordered model that maintains keys in lexicographic order. This extension is powerful, in that it can efficiently process key ranges.
* Key-value model can use consistency models ranging from eventual consistency to serializability. Some support ordering of keys. Some maintain data in memory (RAM), while others employ solid-state drives or rotating disks.

__Hierarchical key-value model__

* This data model allows elements to link and be linked by several other elements thus constructing a hierarchical structure. Links usually have additional properties to describe the relation between elements.

__Wide-column model__

* Wide-column model takes a hybrid approach mixing the declarative characteristics game of relational databases with the key-value pair based and totally variables schema of key-value stores. Wide Column databases stores data tables as sections of columns of data rather than as rows of data.

__Object model__

* Object-oriented database management systems (OODBMSs) combine database capabilities with object-oriented programming language capabilities. They allow object-oriented programmers to develop the product, store them as objects, and replicate or modify existing objects to make new objects within the OODBMS. Because the database is integrated with the programming language, the programmer can maintain consistency within one environment, in that both the OODBMS and the programming language will use the same model of representation.

- - - -

## Task 13.
### Give few examples of NoSQL databases and their pros and cons.

There are four general types of NoSQL databases, each with their own specific attributes:

* Key-Value store – we start with this type of database because these are some of the least complex NoSQL options. These databases are designed for storing data in a schema-less way. In a key-value store, all of the data within consists of an indexed key and a value, hence the name. Examples of this type of database include: Cassandra, DyanmoDB, Azure Table Storage (ATS), Riak, BerkeleyDB.
* Column store – (also known as wide-column stores) instead of storing data in rows, these databases are designed for storing data tables as sections of columns of data, rather than as rows of data. While this simple description sounds like the inverse of a standard database, wide-column stores offer very high performance and a highly scalable architecture. Examples include: HBase, BigTable and HyperTable.
* Document database – expands on the basic idea of key-value stores where “documents” are more complex, in that they contain data and each document is assigned a unique key, which is used to retrieve the document. These are designed for storing, retrieving, and managing document-oriented information, also known as semi-structured data. Examples include: MongoDB and CouchDB.
* Graph database – Based on graph theory, these databases are designed for data whose relations are well represented as a graph and has elements which are interconnected, with an undetermined number of relations between them. Examples include: Neo4J and Polyglot.


|Datamodel		 | Performance	| Scalability  | Flexibility  |	Complexity	 | Functionality  |
| ---------------|:------------:|:------------:|:------------:|:------------:| :-------------:|   
|Key-value store | High			| High		   | High         |	None	     | Variable (None)|
|Column Store	 | High			| High		   | Moderate	  | Low		     | Minimal		  |
|Document Store	 | High			|Variable(High)| High	      | Low	         | Variable (Low) |
|Graph Database	 | Variable		| Variable	   | High	      | High	     | Graph Theory   |
