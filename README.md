<b>Design Patterns in C# 7.0</b>


In this repository I am doing some exercises and examples about the GOF design patterns in C# 7, so it's pretty much updated. There is a problem.jpg file on each project folder that is an exercise, and the solution is on the Program.cs file (with the Main method), there are also some other pratical examples.

These examples are for <i>Structural Patterns</i>, it means that Structural Design Patterns are standards that deal with project structures, facilitating communication between their entities. In this way they treat the way objects and classes are arranged in a project in order to form more complex structures

There are also <i>Architecture Patterns</i>, that stands out for MVC (Model-View-Controller) or MVVM (Model View View-Model) that won't be covered in this repository.

Note that this repository stands for KISS (<i>keep it stupid simple</i>) so there are no separation of class in files or helper classes, all is done in one document.

/*Some considerations: */

<b>When to use the Builder and the Factory?</b>

 <i>"The Builder is only needed when an object cannot be produced in one step. One great an example of this would be in the de-serialization process for a complex object. Often times the parameters for the complex object must be retrieved one by one."</i>
 
<b>What's the difference between the Composite Pattern and the Builder Pattern?</b>
 
 <i>"The composite pattern is used when you have a situation when you need to construct Parent and Child, like a dynamic menubar. Or even when you might want to have a single object (like a sum of values) or many values on a row."</i>
 
 <b>What's the difference between the Proxy Pattern and the Decorator?</b>
 
 <i>
 <ul>
 <li>Proxy provides an identical interface, the decorator provides an enhanced interface</li>
 <li>The Decorator typically aggregates (or has references to) what it is decorating; proxy doesn't have to </li>
 <li>Proxy might not even be working with a materialized object</li>
 <li>Proxy is an implementation of lazy of the whole type for eg.</li>

 </ul>
 </i>
 
 <b>Use of dotMemory profiling in the Flyweight design pattern</b>
 <i>In the solution of the Flyweight pattern I make use of the JetBrains (www.jetbrains.com) dotMemory profiler to make some profiling on my tests of the pattern. Documentation can be see here: https://www.jetbrains.com/help/dotmemory/Working_with_dotMemory_Command-Line_Profiler.html although it is not so well documented if you have a free version.</i>