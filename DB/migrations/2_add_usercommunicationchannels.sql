-- +migrate Up
CREATE TABLE user_communication_channels
(
  id					INTEGER PRIMARY KEY NOT NULL UNIQUE,
  type					TEXT NOT NULL,
  user_id				INTEGER NOT NULL,
  identifier_hash		TEXT NOT NULL,
  FOREIGN KEY(user_id)	REFERENCES user
);

-- +migrate Down
DROP TABLE user_communication_channels;