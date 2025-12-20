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
    similarity FLOAT NOT NULL
    PRIMARY KEY (book_id1, book_id2)
);