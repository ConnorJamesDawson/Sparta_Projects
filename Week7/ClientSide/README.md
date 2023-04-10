# Web Development with ASP.NET 

## HTML
html are client side apps

useful for designing pages

html tags are all specified, theres syntax to them unlike xml

Only one head and one body - This is all you really need

Head - There because it tells the brower about the webpage
Body - What is going to be displayed

Title- Appears in the browers titlebar/ tab title

Tag- Open or close of an element
Element - The body between the open and close

An attribute goes in the opening tag always

## Java

Weakly types with dynamically interpreted language

Weakly types - rules are not rigidly applied


## Extra reading

- [CSS Syntax](https://www.w3schools.com/css/css_syntax.asp)
- [CSS Selectors](https://www.w3schools.com/css/css_selectors.asp)
- [CSS Tricks - Flexbox](https://css-tricks.com/snippets/css/a-guide-to-flexbox/)
- [Boot Strap](https://getbootstrap.com/docs/5.3/content/tables/#overview)
- [CSS Zen Garden](https://www.csszengarden.com)

## GitHub questions

### HTML & CSS
What are the new features of HTML5?

Audio & Video - Allow software to embed these features into the website instead of through portals to the hosted video

Header and Footer - Seperates the page into Header - Body - Footer instead of having to manually set the load order yourself

Figure & Figcaption - a <figure> element to mark up a photo in a document, and a <figcaption> element to define a caption for the photo.

Nav - Nav tag are used to provide navigtion links to either ids set for the websote itself or external ones

Progress - The progress tag is used to check the progress of a task during the execution.

Placeholder - example text to be used to describe the expected input in an text area/field

Email - Validate if the input has email format

What is the difference between the <head> and <header> tags?

The head is used to define Meta infomrtaion that the rest of the website needs; scripts, styles ect.

The Header is the top of the website/article

What is a <nav> element?

The nav element is ued to define naviagtion links to either internal or external destinations.

What does CSS stand for?

Cascading Style Sheets

What does Cascading mean in this context?

The “cascading” in CSS refers to the fact that styling rules “cascade” down from several sources. This means that CSS has an inherent hierarchy and styles of a higher precedence will overwrite rules of a lower precedence.

Inline style inputs have the highest priority unless a style is marked with the !important.

Rules that appear later in the code override earlier rules if both have the same specificity.

Give some examples of CSS selectors

CSS selectors are used to "find" (or select) the HTML elements you want to style.

Simple selectors:

- id selector #para1 will look for id="#para1"
- class selector .center will look for class="center"
- * is universal

Combinator selectors:

- div > p, will apply rules to all children of div
- div + p, will apply rules to the next p element after div

Pseudo-class selectors (select elements based on a certain state) only one :

/* unvisited link */
a:link {
  color: #FF0000;
}

/* visited link */
a:visited {
  color: #00FF00;
}

/* mouse over link */
a:hover {
  color: #FF00FF;
}

/* selected link */
a:active {
  color: #0000FF;
}

a:hover MUST come after a:link and a:visited in the CSS definition in order to be effective! 

a:active MUST come after a:hover in the CSS definition in order to be effective! 

Pseudo-class names are not case-sensitive.

Pseudo-elements selectors (select and style a part of an element) has two :: distinguishes the elements from the class

- p::first-line will apply a special style on the first line of text

- h1::before, puts content before the element used, ::after is the opposite

Attribute selectors (select elements based on an attribute or attribute value)

HTML elements can have multiple attributes attached to them.

- p[target], will select all p elemnets with the attribute target

- p[target="player"], will select all p elements with the specific attribute and value of target="player"

What is the difference between an id and a class?

An id is used to give individual elements a unique Id (cannot be duplicate values), class can be used in multiple instances at the same time

What is the prefix for an id?

#param, use # first with the id name, then define a code body with {} to be used with the id

What is a Class?

A class is a way of marking multiple elements in HTML so you an easily group these elements together and manipulate them using one tag instead of individual Ids

What is the CSS box model?

The box model essentially refers to 3 seperate boxes that wrap around each elements in HTML, they are called; The outermost is the Margin, Middle is the Border and the most inner one is the padding with the conter of the box being the actual content of the element.

Why are inline styles not a good idea

Bad for reuse purposes, makes your code look disorganised, can be really confusing on what elements are getting effected by what rule if it's all in the signature
 
### JavaScript
 
Is Javascript statically or dynamically typed?  What does that mean?

Dynamically typed - means that value types are assigned by the system infering what should be stored, "one":1, system would infer that "one" should be an int

How do you tell if you have made a javascript error?

In the browsers DevTools page (F12 for chrome) there is a console tab where Java errors are located 

What are some examples of events that javascript can respond to?

- onload | The browser has finished loading the page
- onkeydown	The user pushes a keyboard key
- An HTML input field was changed
- An HTML button was clicked

Where is the best place to put your javascript and why?

The best place to have your javascripts is externally and that's because it makes your code more modular by making it less dependant on code made inside of HTML documents

What is the difference between a javascript and a c# class declaration?

When declaring a class in Java you need to use the classs keyword, public class Foo() where as in c# it'd be public void Foo()

What is the DOM?

The Document Object Model (DOM) is an application programming interface (API) for HTML and XML documents. It parses the document and gives back a tree structure that contains all of the elements of the document.

A common DOM method is GetElementId()

What is Bootstrap?

Bootstrap is a tool box of predefined commonly used elements n Java/HTML applications

What is JQuery?

Same as bootstrap, it's a set of predefined methods that are commonly used so developers can use single line methods instead of having to write various lines of code.

How can DOM elements be accessed?

- document.getElementById(id) 
- document.getElementsByClassName(className)
- document.getElementsByTagName(tagName)
- document.querySelector(cssSelector)
- document.querySelectorAll(cssSelector)