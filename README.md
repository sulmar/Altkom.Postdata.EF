# Altkom.Postdata.EF

## Tutorial
https://github.com/sulmar/ef-tutorial/wiki


### Indeksy
http://stackoverflow.com/questions/22618237/how-to-create-index-in-entity-framework-6-2-with-code-first


### Polecenia migracji
https://github.com/sulmar/ef-tutorial/wiki/Migrations

## Model

Bike
----
- BikeId
- Number
- BikeType enum 
- Size
- ProductionYear
- IsActive


Customer
------
- CustomerId
- FirstName
- LastName
- Identifier
- PhoneNumber
- Email

Station
-------
- StationId
- Location (gps)
- Symbol
- Name
- Address


Rental
------
- RentalId
- Bike
- Rentee (Customer)
- FromStation
- ToStation
- FromRentalDateTime
- ToRentalDateTime
- Cost
