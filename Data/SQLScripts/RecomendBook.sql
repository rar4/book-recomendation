WITH Candidates AS (
    SELECT
        CASE
            WHEN s.book_id1 = u.book_id THEN s.book_id2 
            ELSE s.book_id1
        END AS SimilarBookId,
        s.similarity AS Similarity
    FROM Similarity s
    JOIN UserRatings u
        ON s.book_id1 = u.book_id
        OR s.book_id2 = u.book_id
    WHERE u.rating > 3
)
SELECT
    c.SimilarBookId,
    SUM(Similarity) AS Similarity
FROM Candidates c
WHERE SimilarBookId NOT IN (SELECT book_id FROM UserRatings ur)
GROUP BY SimilarBookId
ORDER BY Similarity DESC
LIMIT 1