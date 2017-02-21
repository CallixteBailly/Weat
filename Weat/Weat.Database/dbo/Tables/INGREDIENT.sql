/*      INDEX DE RECIPE      */



/* -----------------------------------------------------------------------------
      TABLE : INGREDIENT
----------------------------------------------------------------------------- */

create table INGREDIENT
  (
     IDINGREDIENT smallint identity (1, 1)   ,
     CODETYPEINGREDIENT varchar(4)  not null  ,
     URLIMAGE varchar(255)  null  ,
     NAMEINGREDIENT varchar(32)  null  
     ,
     constraint PK_INGREDIENT primary key (IDINGREDIENT)
  )
GO
alter table INGREDIENT 
     add constraint FK_INGREDIENT_TYPEINGREDIENT foreign key (CODETYPEINGREDIENT) 
               references TYPEINGREDIENT (CODETYPEINGREDIENT)