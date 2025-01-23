
---ROL---
INSERT INTO [dbo].[Rols] (RolDescription)
VALUES ('Administrador');

INSERT INTO [dbo].[Rols] (RolDescription)
VALUES ('Gestor');

INSERT INTO [dbo].[Rols] (RolDescription)
VALUES ('Cajero');

INSERT INTO [dbo].[Rols] (RolDescription)
VALUES ('Cliente');

SELECT * FROM [dbo].[Rols];

---USER STATUS---
INSERT INTO [dbo].[UserStatuses](StatusId, Description)
VALUES('A','Activo')

INSERT INTO [dbo].[UserStatuses](StatusId, Description)
VALUES('E','Eliminado')

SELECT * FROM [dbo].[UserStatuses];

---SERVICE---
INSERT INTO [dbo].[Services](ServiceName, ServiceDescription, Price)
VALUES('S1', 'Servicio de gama alta', 99.99);

INSERT INTO [dbo].[Services](ServiceName, ServiceDescription, Price)
VALUES('S2','Servicio de gama media', 74.99)

INSERT INTO [dbo].[Services](ServiceName, ServiceDescription, Price)
VALUES('S3', 'Servicio de gama baja', 49.99)

SELECT * FROM [dbo].[Services];

---Method Payment---
INSERT INTO [dbo].[PaymentMethods](Description)
VALUES('Efectivo')

INSERT INTO [dbo].[PaymentMethods](Description)
VALUES('Credito')

SELECT * FROM [dbo].[PaymentMethods];

---STATUS CONTRACT---
INSERT INTO [dbo].[StatusContracts](StatusContractId ,Description)
VALUES('SC1', 'Activo')

INSERT INTO [dbo].[StatusContracts](StatusContractId ,Description)
VALUES('SC2', 'Eliminado')

SELECT * FROM [dbo].[StatusContracts];

---ATTENTION TYPE---

INSERT INTO [dbo].[AttentiontTypes](AttentionTypeId, AttentionDescription)
VALUES('AT1','Atencion al cliente')
SELECT * FROM [dbo].[AttentiontTypes];


---	ATTENTION STATUS---
INSERT INTO [dbo].[AttentionsStatuses](Descrription)
VALUES('EN ESPERA')

INSERT INTO [dbo].[AttentionsStatuses](Descrription)
VALUES('ATENDIDO')


SELECT * FROM [dbo].[AttentionsStatuses];

---CASH---
INSERT INTO [dbo].[Cashs](CashDescription, active)
VALUES('Caja1', 'A')

INSERT INTO [dbo].[Cashs](CashDescription, active)
VALUES('Caja2', 'A')

INSERT INTO [dbo].[Cashs](CashDescription, active)
VALUES('Caja3', 'A')
 
UPDATE [dbo].[Cashs]
SET CashDescription = 'Caja6'
WHERE [dbo].[Cashs].CashId = 6;

SELECT * FROM [dbo].[Cashs];
