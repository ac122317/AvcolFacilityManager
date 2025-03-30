SELECT * FROM Bookings
WHERE FacilityId IN (
SELECT FacilityId FROM Bookings
GROUP BY FacilityId
HAVING COUNT(BookingId) < 2);