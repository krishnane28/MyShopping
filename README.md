# MyShopping
Shopping Website using ASP.NET Webforms

## Layers used


- Business Layer which implements all the business functionalities

- Repository Layer which composes the SQL 

- Data Layer which contains the data from the database using SQL provided by the
  Repository layer


## Design Patterns Used


- Facade pattern for session management

- Factory pattern for creation of the layers

- Bridge pattern for decoupling an abstraction from its implementation

- Adapter pattern for delegating the work to the existing code and providing the
  implementation to the interface


## Design Principle Used

S.O.L.I.D 

S -> Separation of Concern or Single Responsibility Principle

O -> Open Closed Principle

L -> Liskov's Substitution Principle

I -> Interface Segregation Principle

D -> Dependency Injection for loosely coupled architecture


## Paypal Integration


Myshopping website consumes paypal service for making online payments


