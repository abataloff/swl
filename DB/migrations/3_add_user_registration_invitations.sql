-- +migrate Up
CREATE TABLE user_registration_invitations
(
  id                          INTEGER PRIMARY KEY NOT NULL UNIQUE,
  communication_channel_type  TEXT NOT NULL,
  identifier_hash             TEXT NOT NULL,
  token                       TEXT NOT NULL
);

-- +migrate Down
DROP TABLE user_registration_invitations;