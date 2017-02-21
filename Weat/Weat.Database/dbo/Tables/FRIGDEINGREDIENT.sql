/*      INDEX DE FAVORITERECIPEUSER      */



/* -----------------------------------------------------------------------------
      TABLE : FRIGDEINGREDIENT
----------------------------------------------------------------------------- */

create table FRIGDEINGREDIENT
  (
     IDINGREDIENT smallint  not null  ,
     IDFRIDGE smallint  not null  ,
     QUANTITY smallint  null  
     ,
     constraint PK_FRIGDEINGREDIENT primary key (IDINGREDIENT, IDFRIDGE)
  )
GO
alter table FRIGDEINGREDIENT 
     add constraint FK_FRIGDEINGREDIENT_INGREDIENT foreign key (IDINGREDIENT) 
               references INGREDIENT (IDINGREDIENT)
GO
alter table FRIGDEINGREDIENT 
     add constraint FK_FRIGDEINGREDIENT_FRIDGE foreign key (IDFRIDGE) 
               references FRIDGE (IDFRIDGE)