﻿CREATE TABLE Accounts (
	accountId INTEGER PRIMARY KEY,
	userName TEXT NOT NULL COLLATE NOCASE UNIQUE,
	passwordHash TEXT NOT NULL,
	passwordSalt TEXT NOT NULL,
	email TEXT NOT NULL COLLATE NOCASE,
	createDate TEXT NOT NULL,
	updateDate TEXT NOT NULL
);