CREATE TABLE StudStatus
(
Id INT PRIMARY KEY,
StatusDescr VARCHAR(100)
);

INSERT INTO StudStatus
(Id, StatusDescr)
VALUES
(1, '�������'),
(2, '������. ����������'),
(3, '�������'),
(4, '��������� �� �����'),
(5, '��������� �� ������'),
(6, '��������� �� ����������')



CREATE TABLE Logs
(
Id INT PRIMARY KEY,
studentName VARCHAR(100),
facultyNumber VARCHAR(100),
timeOfLogin Date
);
