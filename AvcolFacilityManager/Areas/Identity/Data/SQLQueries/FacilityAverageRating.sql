SELECT FacilityId, AVG(Rating) AS AverageRating
FROM Reviews
JOIN Bookings ON Reviews.BookingId = Bookings.BookingId
WHERE Bookings.FacilityId = 4
GROUP BY FacilityId;