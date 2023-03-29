# Serialisation
 
What is serialisation?

Serialization is the process of converting a data object into a series of bytes that saves the state of the object in an easily transmittable form so turn a c# class into a json file.

What are the advantages and disadvantages of using binary object serialisation? JSON Serialisation? / XML Serialisation?

Advantages:

Crates a clone of the object, very useful for creating a cross platform save file

Makes the file transportable through a network, can be used for anti cheat

Disadvantages:

Serialisation can be quite slow,
There is high overhead on the CPU with object serialisation

XML serialisation also has a big disadvantage in that it only works on Public values therefore potencially violating Abstraction
 
# File Formats
 
Describe the JSON structure

A JSON object contains zero, one, or more key-value pairs, also called properties. The object is surrounded by curly braces {} . Every key-value pair is separated by a colon and then a comma between seprerate values.

What C# collection does JSON correspond to?

JsonSerialiser

What data type are the keys in JSON ?

In JSON, the “keys” must always be strings. Each of these pairs is conventionally referred to as a “property”.

Describe the XML structure

XML documents are formed as element trees. An XML tree starts at a root element and branches from the root to child elements. The terms parent, child, and sibling are used to describe the relationships between elements.

What is the difference between XML and HTML?

The key difference between HTML and XML is that HTML displays data and describes the structure of a webpage, whereas XML stores and transfers data.

Describe the structure of YAML

Note that the structure of a YAML file is a map or a list, and it follows a hierarchy depending on the indentation, and how you define your key values. Maps allow you to associate key-value pairs. Each key must be unique, and the order doesn't matter.

Why are JSON, XML and YAML used?

XML, JSON and YAML are the most popular data serialization languages. This means we use them to represent data structures and values, which enables data storage, transfer and distribution, often for use in configurations.