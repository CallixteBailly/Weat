/* -----------------------------------------------------------------------------
      TABLE : FRIDGE
----------------------------------------------------------------------------- */

create table FRIDGE
  (
     IDFRIDGE smallint identity (1, 1)   ,
     CODETYPEFRIDGE varchar(4)  not null  ,
     IDUSER smallint  not null  ,
     NAMEFRIDGE varchar(32)  null  
     ,
     constraint PK_FRIDGE primary key (IDFRIDGE)
  )
GO
/*      INDEX DE RECIPEINGREDIENT      */



/* -----------------------------------------------------------------------------
      REFERENCES SUR LES TABLES
----------------------------------------------------------------------------- */



alter table FRIDGE 
     add constraint FK_FRIDGE_TYPEFRIDGE foreign key (CODETYPEFRIDGE) 
               references TYPEFRIDGE (CODETYPEFRIDGE)
GO
alter table FRIDGE 
     add constraint FK_FRIDGE_PERSON foreign key (IDUSER) 
               references PERSON (IDUSER)