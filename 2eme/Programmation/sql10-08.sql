/*CREATE TABLE Etu1(
    matricule INT NOT NULL,
    nom varchar(255) DEFAULT NULL,
    prenom varchar(255) DEFAULT NULL,
    dateNaissance DATE DEFAULT NULL,
    PRIMARY KEY(matricule)
);*/

/*CREATE TABLE Inscrip(
    matricule int NOT NULL,
    annee varchar(10) NOT NULL,
    statut varchar(10) NOT NULL,
    PRIMARY KEY (matricule, annee),
    CONSTRAINT matriculeVersEtu1Contrainte 
    FOREIGN KEY (matricule) 
    REFERENCES Etu1 (matricule)
);*/

/*INSERT INTO Etu1(matricule,nom,prenom,dateNaissance)
VALUES
(1, 'RICHEZ', 'Antoine', '1999-10-22'),
(2, 'Dudziak', 'Thomas', '1999-01-01'),
(3, 'Leruth', 'Andrews', '1954-05-04');*/

/*INSERT INTO Inscrip
VALUES (3, '2018', 'RATE');*/

-- Exercice

-- Par inscription, les UE passées par cet étudiant avec les derniers points obtenus.

/*CREATE TABLE Ue(
  nomUE VARCHAR(10) NOT NULL,
  matricule VARCHAR(10) NOT NULL,
  annee varchar(10) NOT NULL,
  CONSTRAINT matriculeVersEtudiant FOREIGN KEY (matricule) REFERENCES Etudiant (matricule),
  CONSTRAINT anneeVersInscription FOREIGN KEY (annee) REFERENCES Inscription (annee)
)
CREATE TABLE Points(
  matricule INT NOT NULL,
  points float DEFAULT NULL,
  UE VARCHAR(10) NOT NULL,
  CONSTRAINT matriculeVersEtudiant FOREIGN KEY (matricule) REFERENCES Etudiant (matricule),
  CONSTRAINT ueVersUE FOREIGN KEY (UE) REFERENCES Ue (nomUE)
)
INSERT INTO Points
VALUES
(1,18.5,'UE15'),
(1,16,'UE14'),
(2,12,'UE15');
INSERT INTO Ue
VALUES
('UE14',1,'2018'),
('UE15',1,'2018'),
('UE14',2,'2018');

SELECT E.*,I.annee,I.matricule,Ue.*,P.points 
from Etudiant as E,Inscription as I,Ue,Points as P 
WHERE I.annee = Ue.annee AND E.matricule = Ue.matricule AND Ue.matricule = P.matricule AND E.matricule = I.matricule AND P.UE = Ue.nomUE;
*/
--ALTER TABLE Etudiant DROP COLUMN age;
--ALTER TABLE Etudiant ADD age INT DEFAULT 18;
--ALTER TABLE Etudiant ADD CONSTRAINT prenomUnique UNIQUE (prenom);

CREATE TABLE Personne
(
    matricule INT NOT NULL PRIMARY KEY,
    nom VARCHAR(255) NOT NULL,
    responsable INT NOT NULL
)