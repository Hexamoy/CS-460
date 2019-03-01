﻿CREATE TABLE [dbo].[UserWorkout]
(
	[UWId] INT IDENTITY(1,1) NOT NULL,
	[UsernameId] NVARCHAR(128) NOT NULL,
	[UserCurrentPlan] INT NOT NULL
	CONSTRAINT [PK_dbo.UserWorkout] PRIMARY KEY CLUSTERED ([UWId] ASC),
	CONSTRAINT [FK_dbo.UserWorkout_AspNetUsers] FOREIGN KEY (UsernameId) REFERENCES AspNetUsers(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT [FK_dbo.UserWorkout_WorkoutPlanWorkout] FOREIGN KEY (UserCurrentPlan) REFERENCES WorkoutPlanWorkout(LinkId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);
