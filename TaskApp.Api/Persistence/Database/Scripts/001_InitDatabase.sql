CREATE TABLE
    IF NOT EXISTS tasks(
                      id UUID PRIMARY KEY,
                      title TEXT NOT NULL,
                      done BOOLEAN NOT NULL
);
