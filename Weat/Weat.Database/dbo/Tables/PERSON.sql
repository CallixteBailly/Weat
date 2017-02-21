/*      INDEX DE FRIDGE      */



/* -----------------------------------------------------------------------------
      TABLE : PERSON
----------------------------------------------------------------------------- */

create table PERSON
  (
     IDUSER smallint identity (1, 1)   ,
     FIRSTNAME varchar(32)  null  ,
     LASTNAME varchar(32)  null  ,
     PSEUDO varchar(32)  null  ,
     PASSWORD varchar(128)  null  
     ,
     constraint PK_PERSON primary key (IDUSER)
  )