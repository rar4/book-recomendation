WITH MeanCentered AS (
  SELECT r.user_id, r.rating - u.mean AS derivative, r.book_id
  FROM Rating r
  JOIN (SELECT user_id, AVG(rating) AS Mean FROM Rating GROUP BY user_id) AS u
  ON r.user_id = u.user_id
)



INSERT INTO Similarity (book_id1, book_id2, similarity)
SELECT 
    book_id1,
    book_id2,
    dot / SQRT(m1 * m2)
FROM (
    SELECT 
        r1.book_id AS book_id1,
        r2.book_id AS book_id2,
        SUM(r1.derivative * r2.derivative) AS dot,
        SUM(r1.derivative * r1.derivative) AS m1,
        SUM(r2.derivative * r2.derivative) AS m2
    FROM MeanCentered r1
    JOIN MeanCentered r2 ON r1.user_id = r2.user_id
    JOIN (SELECT b.user_id FROM Rating b GROUP BY user_id HAVING COUNT(*) >= 20) a ON r1.user_id = a.user_id
    WHERE r1.book_id < r2.book_id
    GROUP BY r1.book_id, r2.book_id
    HAVING COUNT(*) > 20 AND dot > 0
); 