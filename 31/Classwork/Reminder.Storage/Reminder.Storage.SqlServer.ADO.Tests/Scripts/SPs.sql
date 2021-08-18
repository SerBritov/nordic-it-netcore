USE [ReminderTest]
GO
DROP PROCEDURE IF EXISTS [dbo].[AddReminderItem]
GO
CREATE PROCEDURE [dbo].[AddReminderItem] (
	@contactId AS VARCHAR(50),
	@targetDate AS DATETIMEOFFSET,
	@message AS NVARCHAR(200),
	@statusId AS TINYINT,
	@reminderId AS UNIQUEIDENTIFIER OUTPUT
)
AS BEGIN
	SET NOCOUNT ON

	DECLARE @tempReminderItem AS UNIQUEIDENTIFIER,
			@now AS DATETIMEOFFSET
	
	SELECT @tempReminderItem = NEWID(),
			@now = SYSDATETIMEOFFSET();
	INSERT INTO [dbo].[ReminderItem]
           ([Id]
           ,[ContactId]
           ,[TargetDate]
           ,[Message]
           ,[StatusId]
           ,[CreatedDate]
           ,[UpdatedDate])
     VALUES
           (@tempReminderItem,
           @contactId,
           @targetDate,
           @message,
           @statusId,
           @now,	--CreatedDate
		   @now	    --UpdatedDate
		   )
	SET @reminderId = @tempReminderItem
END
GO

