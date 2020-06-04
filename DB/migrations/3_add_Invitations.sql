-- +migrate Up
CREATE TABLE invitations
(
  id					INTEGER PRIMARY KEY NOT NULL UNIQUE,
  email       TEXT NOT NULL,
  token				TEXT NOT NULL
);

-- +migrate Down
DROP TABLE user_communication_channels;