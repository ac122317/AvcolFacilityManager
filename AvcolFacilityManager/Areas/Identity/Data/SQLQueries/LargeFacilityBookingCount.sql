SELECT Facility.FacilityId, Facility.FacilityName, Facility.Capacity, COUNT(Bookings.BookingId) AS TotalBookings
FROM Facility
LEFT JOIN Bookings ON Facility.FacilityId = Bookings.FacilityId
WHERE Facility.Capacity > 500
GROUP BY Facility.FacilityId, Facility.FacilityName, Facility.Capacity