CREATE TABLE [dbo].[Recipe]
(
    [Id] INT NOT NULL IDENTITY PRIMARY KEY,
    Name NVARCHAR(30) NOT NULL,
    Description TEXT,
    Level CHAR(1) NOT NULL,
    TimeToCook TIME NOT NULL,
    CountofPeople CHAR(1)
)
GO
CREATE TABLE [dbo].[Unit]
(
    [Id] INT NOT NULL IDENTITY PRIMARY KEY,
    ShortName NVARCHAR(10) NOT NULL,
    LongName NVARCHAR(30) NOT NULL
)
GO

CREATE TABLE [dbo].[Ingredient]
(
    [Id] INT NOT NULL IDENTITY PRIMARY KEY,
    Name NVARCHAR(30) NOT NULL,
    UnitId INT NOT NULL,
    CONSTRAINT fk_Ingredient_Unit FOREIGN KEY(UnitID) REFERENCES Unit(Id)
)
GO
CREATE TABLE [dbo].[RecipeIngredient]
(
    RecipeId INT NOT NULL,
    IngredientId INT NOT NULL,
    Quantity DECIMAL DEFAULT 1.0,
    PRIMARY KEY(RecipeId, IngredientId),
    CONSTRAINT fk_RecipeIngredient_Recipe FOREIGN KEY(RecipeId) REFERENCES Recipe(Id) ON UPDATE CASCADE ON DELETE CASCADE,
    CONSTRAINT fk_RecipeIngredient_Ingredient FOREIGN KEY(IngredientId) REFERENCES Ingredient(Id) ON UPDATE CASCADE ON DELETE CASCADE

)


