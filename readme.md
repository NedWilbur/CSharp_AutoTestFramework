# C# Test Framework using Selenium & NUnit
A small sample project of how I like to build a maintainable and scalable c# selenium framework by using several layers of abstraction. There are a lot more features that could be added, but this is a helpful starting point.

## Architecture
`ATB (AutoTestBase)` <-- `WebFramework` <-- `Test`

`Test` makes calls from `WebFramework`, `WebFramework` makes calls from `ATB`. 

### ATB
The AutoTestBase wraps around Seleniums API to add addition features. This project handles driver generation, custom actions, custom 'Element', logging, integrations (todo), wait-for feature (todo), and much more. 

Designed to be imported into ANY project needing automation.

### WebFramework 
Contains Page Object Model (POM) for each page/view (I like to call them views, since most web apps have a  lot of reused 'views' or components such as a navbar).

### Test
Contains the NUnit tests themselves. 99% of the method calls will be from the `WebFramework`.