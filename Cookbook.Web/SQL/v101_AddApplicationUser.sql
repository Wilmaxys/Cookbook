CREATE TABLE [dbo].[ApplicationRole]
(
    ApplicationRoleId INT IDENTITY NOT NULL,
    Nom NVARCHAR(20) NOT NULL,
	PRIMARY KEY(ApplicationRoleId)
)
GO
CREATE TABLE [dbo].[ApplciationUser]
(
    ApplicationUserId INT NOT NULL,
    LastName NVARCHAR(20) NOT NULL,
    FirstName NVARCHAR(20) NOT NULL,
    Email NVARCHAR(254) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
	ApplicationRoleId INT NOT NULL,
    PRIMARY KEY(ApplicationUserId),
    CONSTRAINT fk_ApplicationUser_ApplicationRole FOREIGN KEY(ApplicationRoleId) REFERENCES ApplicationRole(ApplicationRoleId) ON UPDATE CASCADE ON DELETE CASCADE,
)
GO
ALTER TABLE  [dbo].[Recipe] ADD CreatedById INT;
GO
ALTER TABLE  [dbo].[Recipe] ADD CONSTRAINT fk_Recipe_ApplicationUser_CreatedBy FOREIGN KEY(CreatedById) REFERENCES [dbo].[ApplciationUser](ApplicationUserId);
GO
ALTER TABLE  [dbo].[Recipe] ADD UpdatedById INT;
GO
ALTER TABLE  [dbo].[Recipe] ADD CONSTRAINT fk_Recipe_ApplicationUser_UpdatedBy FOREIGN KEY(UpdatedById) REFERENCES [dbo].[ApplciationUser](ApplicationUserId);