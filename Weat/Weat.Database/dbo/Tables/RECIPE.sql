/* -----------------------------------------------------------------------------
      TABLE : RECIPE
----------------------------------------------------------------------------- */

create table RECIPE
  (
     IDRECIPE smallint identity (1, 1)   ,
     CODETYPERECIPE varchar(4)  not null  ,
     IDUSER smallint  not null  ,
     NAMERECIPE varchar(32)  null  
     ,
     constraint PK_RECIPE primary key (IDRECIPE)
  )
GO
alter table RECIPE 
     add constraint FK_RECIPE_TYPERECIPE foreign key (CODETYPERECIPE) 
               references TYPERECIPE (CODETYPERECIPE)
GO
alter table RECIPE 
     add constraint FK_RECIPE_PERSON foreign key (IDUSER) 
               references PERSON (IDUSER)