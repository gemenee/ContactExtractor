CREATE UNIQUE INDEX "IX_Results_DocumentId" ON "Results" ("DocumentId");

CREATE TABLE "ef_temp_Documents" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Documents" PRIMARY KEY AUTOINCREMENT,
    "CreationDateTimeUtc" TEXT NOT NULL,
    "FilePath" TEXT NOT NULL,
    "OriginFileName" TEXT NOT NULL,
    "PlainTextFilePath" TEXT NULL,
    "Processed" INTEGER NOT NULL,
    "SizeInBytes" INTEGER NOT NULL
);

INSERT INTO "ef_temp_Documents" ("Id", "CreationDateTimeUtc", "FilePath", "OriginFileName", "PlainTextFilePath", "Processed", "SizeInBytes")
SELECT "Id", "CreationDateTimeUtc", "FilePath", "OriginFileName", "PlainTextFilePath", "Processed", "SizeInBytes"
FROM "Documents";

COMMIT;

PRAGMA foreign_keys = 0;

BEGIN TRANSACTION;

DROP TABLE "Documents";

ALTER TABLE "ef_temp_Documents" RENAME TO "Documents";

COMMIT;

PRAGMA foreign_keys = 1;

BEGIN TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221211185238_RemoveDocumentResultEntity', '7.0.0');

COMMIT;

BEGIN TRANSACTION;

CREATE TABLE "ef_temp_Persons" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Persons" PRIMARY KEY AUTOINCREMENT,
    "CreationDateTimeUtc" TEXT NOT NULL,
    "Email" TEXT NULL,
    "FirstName" TEXT NULL,
    "LastName" TEXT NULL,
    "MiddleName" TEXT NULL,
    "OrganizationId" INTEGER NULL,
    "Phone" TEXT NULL,
    "Position" TEXT NULL,
    "ResultEntityId" INTEGER NOT NULL,
    CONSTRAINT "FK_Persons_Organizations_OrganizationId" FOREIGN KEY ("OrganizationId") REFERENCES "Organizations" ("Id"),
    CONSTRAINT "FK_Persons_Results_ResultEntityId" FOREIGN KEY ("ResultEntityId") REFERENCES "Results" ("Id") ON DELETE CASCADE
);

INSERT INTO "ef_temp_Persons" ("Id", "CreationDateTimeUtc", "Email", "FirstName", "LastName", "MiddleName", "OrganizationId", "Phone", "Position", "ResultEntityId")
SELECT "Id", "CreationDateTimeUtc", "Email", "FirstName", "LastName", "MiddleName", "OrganizationId", "Phone", "Position", "ResultEntityId"
FROM "Persons";

COMMIT;

PRAGMA foreign_keys = 0;

BEGIN TRANSACTION;

DROP TABLE "Persons";

ALTER TABLE "ef_temp_Persons" RENAME TO "Persons";

COMMIT;

PRAGMA foreign_keys = 1;

BEGIN TRANSACTION;

CREATE INDEX "IX_Persons_OrganizationId" ON "Persons" ("OrganizationId");

CREATE INDEX "IX_Persons_ResultEntityId" ON "Persons" ("ResultEntityId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221212102510_MakePersonPropsNullable', '7.0.0');

COMMIT;

BEGIN TRANSACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221213142716_MakeResultpropertyvirtualForLazyLoading', '7.0.0');

COMMIT;