USE [CustomerData]
GO

/****** Object:  StoredProcedure [dbo].[updateFirstNamenotlast]    Script Date: 3/13/2021 1:26:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[updateFirstNamenotlast]	
@upId int,
@firstName nvarchar(40)
as
Update Customers set 
Firstname=@firstName
where CustomerID = @upId

GO

