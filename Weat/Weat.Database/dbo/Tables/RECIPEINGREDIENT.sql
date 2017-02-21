/*      INDEX DE PLANNING      */



/* -----------------------------------------------------------------------------
      TABLE : RECIPEINGREDIENT
----------------------------------------------------------------------------- */

create table RECIPEINGREDIENT
  (
     IDINGREDIENT smallint  not null  ,
     IDRECIPE smallint  not null  
     ,
     constraint PK_RECIPEINGREDIENT primary key (IDINGREDIENT, IDRECIPE)
  )
GO
alter table RECIPEINGREDIENT 
     add constraint FK_RECIPEINGREDIENT_INGREDIENT foreign key (IDINGREDIENT) 
               references INGREDIENT (IDINGREDIENT)
GO
alter table RECIPEINGREDIENT 
     add constraint FK_RECIPEINGREDIENT_RECIPE foreign key (IDRECIPE) 
               references RECIPE (IDRECIPE)