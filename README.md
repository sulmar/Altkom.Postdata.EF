# Altkom.Postdata.EF


## Pytania
- W jaki sposób wywołać skrypt z migracji?
- W jaki sposób utworzyć indeksy?
- Czy EF wspiera własne typy SQL Server?


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
