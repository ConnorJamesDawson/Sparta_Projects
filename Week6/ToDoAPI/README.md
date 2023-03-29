# Rest API & API Test Design

## API

(A)pplication
(P)rogram
(I)nterface

It is an intemediary, recieves and sends commands to each other

Provides access to an apps code from outside, this extends the functionality

Server
    - holds information
- Client
    - requests information / asks for it to be created, updated or deleted. Standard CRUD operations

- Client sends a request to the server and receives a response

## HTTP

- HTTP is the protocol of internet communication

- HTTP works on the simple methodology of a request / response system
    - Client makes a request to the server.
    - The Server processes the request and makes a response to the Client.

- Used by web pages
    - Request to web server
    - Response is html, to be rendered by the browser

In both cases the client sends an HTTP request to a server

- The server sends an HTTP response back to the client
    - The response contains a representation of the resource held by the server
    - And can change the client's state

- The client and server don't know anything about how the other is implemented (types of OS, languages ect. could be different)

- Each request/response pair is completely independent
    - Client and server donlt know about each other's state
    - Session state is stored on the client
    - Which sends all necessary information in each request
    - Don't have a permanent client-server connection

## HTTP Methods/Verbs

- Get - Read - Retrieves a representation of the resource
- Post - Create - Creates a new resource
- Put - Create/Update - Creates or Replace a resource
- Patch - Update - Replaces part of a resource instead of creating a whole new resource. Idempotent (doesn't matter how many times it's called it's the same effect as the first time)
- Delete - Delete - Deletes a specified resource
- Head -  - Same as Get but returns only the header with no body attached

## HTTP status codes

- lxx — Informational
    - 100 Continue
    - 102 Processing
- 2xx — Success
    - 200 0K
    - 201 Created
    - 202 Accepted
- 3xx — Redirection
    - 301 Moved Permanently
- 4xx - Client error
    - 400 Bad Request
    - 401 Unauthorized
    - 418 I'm a teapot
- 5xx — Server error
    - 500 Internal server error
    - 503 Service Unavailable
    - 504 Gateway Timeout

## RESTful Services
- (Re)presentational (S)tate (T)ransfer
    - Used to build lightweight, maintainable and scalable Web services
    - Not tied to a particular protocol (but normally HTTP)
- RESTful services should support:
    - Client-server O
    - Stateless
    - Uniform interface — HTTP method + resource URI
    - Cacheable
    - Layered System
    - Code on demand (optional)  
      
See [REST architecture](https://restfulapi.net/rest-architectural-constraints/)

## URIs and Naming Resources
Naming resources is key in regard to the R - Representational part of REST.  
- If we were to expose our customer database to partners and third parties, it may look like:
    - URI for the service:  http://api.oursservice.com/customers/l  
- Response body:  

{  

    "surname" : "Bloggs",  
    1,  
    "firstname  : "Joe",
    "email" : "joe . b@gmail . com"  

}
- There will also be the option of providing query parameters which may look like:  
    - http://oursservice.com/customers ?id=l

- the service may support other search parameters
    - http://api.oursservice.com/customers ? surname=B10ggs

## Representation and Data Flow

- The server holds data that the client wants to retrieve or interact with
    - This is the resource
    - A representation of this resource can be passed from client to server (or vice-versa) in a form understood to both — data flow
- The representation can be in a variety of formats:
    - json, XML, plain text, HTML, pdf, jpeg....
    - Independent of how it is actually held on the server
- Both the client and server needs to be able to read the format
    - The resource contract (API) should be documented
    - What information is available? What format will it be in? What parameters are needed?
    - If your client does not know what will be received they may not be able to consume it

- HTTP Headers: Key value pairs displayed in requests and responses message headers for HTTP. Contains extra information about the request and response:

    - Request Headers: pertains to information about the client (e.g OS they are using, date request made) or the resource being requested (specifies the language, the charset, encoding, etc)

    - Responses headers: pertains to information about the response (information about the server, whether the request that was made was unauthorised)

- HTTP Message Body: It is via the message body data is exchanged between the server and client.

- Endpoint: The touchpoint between the API and Sever — it where we access our resource e.g. http://api.oursservice.com/customers/l

## Caching

Storing data so the information doesn't need to be processed each time a call is used, it is mainly used for time purposes.

Important to think, How long should this Cach last?

## API Test Stratergy

Test like how we've been shown in C#, Correct responces, status codes, ect.

## GitHub questions

- What does API stand for?
Application Program Interface

- What are the HTTP verbs and what are their CRUD equivalents?
    - Get - Read 
    - Post - Create 
    - Put - Create/Update 
    - Patch - Update 
    - Delete - Delete 

- What is the structure of an HTTP request?  An HTTP response?
The structure of a HTTP request is: Request Line, Headers, Message Body
The structure of a HTTP responce is: A Status Line/Code, Headers, Message Body in Json

- What are the categories of HTTP response status code?
- lxx — Informational
    - 100 Continue
    - 102 Processing
- 2xx — Success
    - 200 0K
    - 201 Created
    - 202 Accepted
- 3xx — Redirection
    - 301 Moved Permanently
- 4xx - Client error
    - 400 Bad Request
    - 401 Unauthorized
    - 418 I'm a teapot
- 5xx — Server error
    - 500 Internal server error
    - 503 Service Unavailable
    - 504 Gateway Timeout

- What does REST stand for in the context of RESTful APIs?
(Re)presentational (S)tate (T)ransfer

- What are the characteristics of a REST API
lightweight, maintainable and scalable Web services

- For the endpoint myapi.com/api/customers what would you expect a GET request to do?  A POST request?  PUT? DELETE?
The get would get all instances of Customer in the Customer table, Post would Create a new Customer for the table, Put would change a given instance of Customer with a given ID, Delete would delete

- What do we mean by caching?
Storing common data that is used in similar requests, such as you might cach log in details so you don't have to log in everytime you visit a web page

- What should the RESTful endpoint myresource.io/Employees/6/Order/2 GET?
It should get the order with an id of 2 that is assigned to the employee with the Id 6

- Give some examples of header elements that can be used to control caching?
User name token
Password token
Working Resource Name
Owner