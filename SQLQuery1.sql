USE HospitalDB
GO



CREATE TABLE People
(
        PersonId int NOT NULL PRIMARY KEY IDENTITY(1,1),
        [Name] nvarchar(20) NOT NULL, 
        [Surname] nvarchar(20) NOT NULL,
        BirthDay DateTime NOT NULL,
        Diagnosis nvarchar(20),
        [Description] nvarchar(200)
)
GO


INSERT INTO People([Name], [Surname], [BirthDay], Diagnosis, [Description]) VALUES
('Ivan', 'Petrov', 01/02/1998, 'gastritis', 'stomackache'),
('Petr', 'Ivanov', 01/02/1962, 'flu', 'fever'),
('Sergei', 'Petrov', 1/2/1944, 'gastritis', 'sneeze, nasal congestion')
GO
