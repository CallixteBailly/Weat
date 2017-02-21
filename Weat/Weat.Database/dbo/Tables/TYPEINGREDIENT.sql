/* -----------------------------------------------------------------------------
      TABLE : TYPEINGREDIENT
----------------------------------------------------------------------------- */

create table TYPEINGREDIENT
  (
     CODETYPEINGREDIENT varchar(4)  not null  ,
     CAPTION varchar(128)  null  
     ,
     constraint PK_TYPEINGREDIENT primary key (CODETYPEINGREDIENT)
  )