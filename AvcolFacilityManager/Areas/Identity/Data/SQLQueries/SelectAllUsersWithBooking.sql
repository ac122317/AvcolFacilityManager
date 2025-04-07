SELECT * FROM AspNetUsers 
WHERE Id IN (SELECT AppUserId FROM Bookings);
