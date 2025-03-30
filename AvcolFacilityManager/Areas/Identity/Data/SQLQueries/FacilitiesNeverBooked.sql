SELECT * FROM Facility
WHERE FacilityId NOT IN (SELECT DISTINCT FacilityId FROM Bookings)