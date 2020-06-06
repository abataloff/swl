-- +migrate Up
CREATE TABLE users
(
  id           INTEGER PRIMARY KEY NOT NULL  UNIQUE
);

-- +migrate Down
DROP TABLE users;