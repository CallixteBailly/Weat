/* -----------------------------------------------------------------------------
      TABLE : TYPERECIPE
----------------------------------------------------------------------------- */

create table TYPERECIPE
  (
     CODETYPERECIPE varchar(4)  not null  ,
     CAPTION varchar(128)  null  
     ,
     constraint PK_TYPERECIPE primary key (CODETYPERECIPE)
  )