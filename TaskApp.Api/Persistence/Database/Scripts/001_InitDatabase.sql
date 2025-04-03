CREATE TABLE
    IF NOT EXISTS products(
                      id UUID PRIMARY KEY,
                      title TEXT NOT NULL,
                      done BOOLEAN NOT NULL
);
