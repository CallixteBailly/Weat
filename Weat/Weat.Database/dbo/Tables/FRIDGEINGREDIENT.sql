/*      INDEX DE FAVORITERECIPEUSER      */



/* -----------------------------------------------------------------------------
      TABLE : FRIDGEINGREDIENT
----------------------------------------------------------------------------- */

create table FRIDGEINGREDIENT
  (
     IDINGREDIENT smallint  not null  ,
     IDFRIDGE smallint  not null  ,
     QUANTITY smallint  null  
     ,
     constraint PK_FRIDGEINGREDIENT primary key (IDINGREDIENT, IDFRIDGE)
  )
GO
alter table FRIDGEINGREDIENT 
     add constraint FK_FRIDGEINGREDIENT_INGREDIENT foreign key (IDINGREDIENT) 
               references INGREDIENT (IDINGREDIENT)
GO
alter table FRIDGEINGREDIENT 
     add constraint FK_FRIDGEINGREDIENT_FRIDGE foreign key (IDFRIDGE) 
               references FRIDGE (IDFRIDGE)