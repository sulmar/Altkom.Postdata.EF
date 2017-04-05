# Altkom.Postdata.EF


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
