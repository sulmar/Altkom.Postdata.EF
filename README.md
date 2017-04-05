# Altkom.Postdata.EF

## Tutorial
https://github.com/sulmar/ef-tutorial/wiki


### Indeksy
https://github.com/sulmar/ef-tutorial/wiki/Indexes


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
