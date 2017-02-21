/*      INDEX DE STEPRECIPE      */



/* -----------------------------------------------------------------------------
      TABLE : TYPEFRIDGE
----------------------------------------------------------------------------- */

create table TYPEFRIDGE
  (
     CODETYPEFRIDGE varchar(4)  not null  ,
     CAPTION varchar(128)  null  
     ,
     constraint PK_TYPEFRIDGE primary key (CODETYPEFRIDGE)
  )