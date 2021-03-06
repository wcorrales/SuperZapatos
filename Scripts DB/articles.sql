/*
   martes 24 de enero de 201705:42:30 p.m.
   User: 
   Server: CORRALES-MENA\ROBERTO
   Database: GAP-SuperZapatos
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.articles
	(
	id int NOT NULL IDENTITY (1, 1),
	name nvarchar(50) NOT NULL,
	description nvarchar(250) NOT NULL,
	price decimal(18, 2) NOT NULL,
	total_in_shelf int NOT NULL,
	total_in_vault int NOT NULL,
	store_id int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.articles ADD CONSTRAINT
	PK_articles PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.articles SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
