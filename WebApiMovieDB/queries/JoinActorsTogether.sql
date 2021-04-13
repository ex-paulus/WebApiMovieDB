Select MovieName, FirstName, LastName, Role 
From Movies
JOIN MovieCast 
  ON MovieCast.MovieId=Movies.MovieId 
JOIN Actors 
  ON MovieCast.ActorId=Actors.ActorId
WHERE Actors.ActorId IN (
SELECT ActorId 
FROM MovieCast 
GROUP BY ActorId HAVING COUNT(*)>=2)
ORDER BY MovieName ASC;