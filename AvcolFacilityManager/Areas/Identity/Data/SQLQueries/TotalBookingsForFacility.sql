SELECT FacilityId, COUNT(*) AS TotalBookings
FROM Bookings
GROUP BY FacilityId;