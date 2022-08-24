# Problem to solve - SalesTaxesAPI
There are a variety of items for sale at a store. When a customer purchases items, they receive a receipt. The receipt 
lists all of the items purchased, the sales price of each item (with taxes included), the total sales taxes for all items, 
and the total sales price.

Basic sales tax applies to all items at a rate of 10% of the item’s list price, with the exception of books, food, and 
medical products, which are exempt from basic sales tax. An import duty (import tax) applies to all imported items at 
a rate of 5% of the shelf price, with no exceptions. 

Write an application that takes input for shopping baskets and returns receipts in the format shown below, calculating 
all taxes and totals correctly. When calculating the sales tax, round the value up to the nearest 5 cents. For example, if 
a taxable item costs $5.60, an exact 10% tax would be $0.56, and the final price after adding the rounded tax of $0.60 
should be $6.20. 

# Proposed solution

The project is organized using the clean architecture as shown in the following image.

<p align="center">
  <img src="https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/media/image5-7.png" />
</p>

In this case I chose to create an API that implements the CQRS and Mediator design patterns, the architecture is as follows:

<p align="center">
  <img src="https://miro.medium.com/max/698/1*2k3di0WZPrlYoVsGfiLs_Q.png" />
</p>

<h4>Techologies used:<h4/>

<ul>
  <li>.NET 6</li>
  <li>Entity Framework Core</li>
  <li>SQL Server</li>
</ul>

<h4>Note: to run this proyect you only need to restore your packages</h4>





