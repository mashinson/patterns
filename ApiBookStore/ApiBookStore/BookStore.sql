USE [BookStoreDB]
GO

INSERT INTO [dbo].[PublishingHome]
           ([Name], [Phone], [Address])
     VALUES
           ('Pearson', '+380499595', 'st erjrj, house 10'),
		   ('Reed Elsevier', '+380499595', 'st erjrj, house 10'),
		   ('ThomsonReuters', '+380499595', 'st erjrj, house 10'),
		   ('Wolters Kluwer', '+380499595', 'st erjrj, house 10')
GO

USE [BookStoreDB]
GO

INSERT INTO [dbo].[Author]
           ([Name]
           ,[Surname], 
			 [Phone])
     VALUES
           ('Peter','Maes', '+3809484884'),
		   ('Dorthea','Johnson', '+3809484884'),
		   ('Lucas','Reid', '+3809484884'),
		   ('Jack','Taylor', '+3809484884')
GO

USE [BookStoreDB]
GO

INSERT INTO [dbo].[Book]
           ([Name]
           ,[Year]
           ,[Author_ID]
           ,[Genre_ID]
           ,[PublishingHome_ID])
     VALUES
          (
	    'Smiles In The Sun'
		,1945
		,1
		,2
		,1

	),
	(
	    'Giants Of Yesterday'
		,2001
		,2
		,3
		,2
	),
	(
	    'Travel To The West'
		,1456
		,3
		,4
		,3
	),
	(
	    'Turtles And Mice'
		,2018
		,4
		,5
		,4
	),
	(
	    'Result Of Desire'
		,1367
		,1
		,6
		,1
	),
	(
	    'Heroes Of The Void'
		,1967
		,2
		,7
		,2
	),
	(
	    'Emperor Without Honor'
		,1935
		,3
		,1
		,3
	),
	(
	    'Write About The East'
		,1989
		,4
		,2
		,4
	),
	(
	    'Searching In The Country'
		,1945
		,1
		,3
		,1
	),
	(
	    'Concept Of Reality'
		,1689
		,2
		,4
		,2
	),
	(
	    'Man And Cat'
		,1123
		,3
		,5
		,3
	)
GO









