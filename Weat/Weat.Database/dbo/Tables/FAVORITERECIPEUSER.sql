/*      INDEX DE INGREDIENT      */



/* -----------------------------------------------------------------------------
      TABLE : FAVORITERECIPEUSER
----------------------------------------------------------------------------- */

create table FAVORITERECIPEUSER
  (
     IDRECIPE smallint  not null  ,
     IDUSER smallint  not null  
     ,
     constraint PK_FAVORITERECIPEUSER primary key (IDRECIPE, IDUSER)
  )
GO
alter table FAVORITERECIPEUSER 
     add constraint FK_FAVORITERECIPEUSER_RECIPE foreign key (IDRECIPE) 
               references RECIPE (IDRECIPE)
GO
alter table FAVORITERECIPEUSER 
     add constraint FK_FAVORITERECIPEUSER_PERSON foreign key (IDUSER) 
               references PERSON (IDUSER)