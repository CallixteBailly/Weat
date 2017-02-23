/*      INDEX DE FRIDGE      */



/* -----------------------------------------------------------------------------
      TABLE : PERSON
----------------------------------------------------------------------------- */

create table PERSON
  (
     IDUSER smallint identity (1, 1)   ,
     FIRSTNAME varchar(32)  NOT null  ,
     LASTNAME varchar(32)  NOT null  ,
     PSEUDO varchar(32)  NOT null  ,
     PASSWORD varchar(128)  NOT null  
     ,
     [Mail] VARCHAR(50) NOT NULL, 
    constraint PK_PERSON primary key (IDUSER)
  )