CREATE TABLE [dbo].[CustomerProfile](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](1000) NOT NULL,
	[Phone] [nvarchar](256) NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[Address] [nvarchar](1000) NOT NULL,
	[MailingAddress] [nvarchar](1000) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'uspCustomerProfileList')
BEGIN
	DROP PROCEDURE uspCustomerProfileList
END
GO
CREATE PROCEDURE uspCustomerProfileList
AS
BEGIN
	SELECT [Id]
      ,[Name]
      ,[Phone]
      ,[Email]
      ,[Address]
      ,[MailingAddress]
      ,[Created]
      ,[Updated]
  FROM [AngularNetFw].[dbo].[CustomerProfile]
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'uspCustomerProfileAdd')
BEGIN
	DROP PROCEDURE uspCustomerProfileAdd
END
GO
CREATE PROCEDURE uspCustomerProfileAdd
@Id uniqueidentifier,
@Name nvarchar (1000),
@Phone nvarchar (256),
@Email nvarchar (256),
@Address nvarchar (1000),
@MailingAddress nvarchar (1000),
@Created datetime,
@Updated datetime
AS
BEGIN
	INSERT INTO [AngularNetFw].[dbo].[CustomerProfile]
	VALUES (@Id, @Name, @Phone, @Email, @Address, @MailingAddress, @Created, @Updated);
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'uspCustomerProfileUpdate')
BEGIN
	DROP PROCEDURE uspCustomerProfileUpdate
END
GO
CREATE PROCEDURE uspCustomerProfileUpdate
@Id uniqueidentifier,
@Name nvarchar (1000),
@Phone nvarchar (256),
@Email nvarchar (256),
@Address nvarchar (1000),
@MailingAddress nvarchar (1000),
@Updated datetime
AS
BEGIN
	UPDATE [AngularNetFw].[dbo].[CustomerProfile] 
	SET [Name] = @Name, Phone = @Phone, Email = @Email, [Address] = @Address, MailingAddress = @MailingAddress,
	Updated = @Updated
	WHERE Id = @Id
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'uspCustomerProfileDelete')
BEGIN
	DROP PROCEDURE uspCustomerProfileDelete
END
GO
CREATE PROCEDURE uspCustomerProfileDelete
@Id uniqueidentifier
AS
BEGIN
	DELETE [AngularNetFw].[dbo].[CustomerProfile]
	WHERE Id = @Id
END
GO
