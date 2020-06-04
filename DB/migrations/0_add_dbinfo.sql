-- +migrate Up
CREATE TABLE db_info
(
  key           TEXT PRIMARY KEY NOT NULL,
  value         TEXT NOT NULL
);

-- +migrate Down
DROP TABLE db_info;