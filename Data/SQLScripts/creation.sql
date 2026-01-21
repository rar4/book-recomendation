-- SQLite
CREATE TABLE IF NOT EXISTS Book(
    id INT PRIMARY KEY,
    isbn INT NOT NULL
);

CREATE TABLE IF NOT EXISTS Rating(
    user_id INTEGER NOT NULL,
    book_id INTEGER NOT NULL,
    rating BYTE NOT NULL,
    PRIMARY KEY (user_id, book_id)
);

CREATE TABLE IF NOT EXISTS  Similarity(
    book_id1 INT NOT NULL,
    book_id2 INT NOT NULL,
    similarity FLOAT NOT NULL,
    PRIMARY KEY (book_id1, book_id2)
);

CREATE TABLE IF NOT EXISTS UserRatings
(
    book_id INT NOT NULL PRIMARY KEY,
    rating BYTE NOT NULL
);

CREATE INDEX IF NOT EXISTS idx_rating_userid_bookid ON Rating(user_id, book_id);
CREATE INDEX IF NOT EXISTS idx_rating_bookid ON Rating(book_id);

-- optional but often helps a lot
PRAGMA journal_mode = WAL;
PRAGMA synchronous = NORMAL;
PRAGMA cache_size = -20000;   -- ~20 MB

CREATE INDEX idx_similarity_book1 ON Similarity(book_id1);
CREATE INDEX idx_similarity_book2 ON Similarity(book_id2);