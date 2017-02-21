/*      INDEX DE FRIGDEINGREDIENT      */



/* -----------------------------------------------------------------------------
      TABLE : PLANNING
----------------------------------------------------------------------------- */

create table PLANNING
  (
     IDRECIPE smallint  not null  ,
     IDUSER smallint  not null  ,
     DATETIME datetime  null  
     ,
     constraint PK_PLANNING primary key (IDRECIPE, IDUSER)
  )
GO
alter table PLANNING 
     add constraint FK_PLANNING_RECIPE foreign key (IDRECIPE) 
               references RECIPE (IDRECIPE)
GO
alter table PLANNING 
     add constraint FK_PLANNING_PERSON foreign key (IDUSER) 
               references PERSON (IDUSER)