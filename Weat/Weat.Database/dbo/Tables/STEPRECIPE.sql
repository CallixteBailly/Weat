/* -----------------------------------------------------------------------------
      TABLE : STEPRECIPE
----------------------------------------------------------------------------- */

create table STEPRECIPE
  (
     IDRECIPE smallint  not null  ,
     IDSTEPRECIPE smallint  not null  ,
     TIMEPERIOD smallint  null  ,
     MESSAGE varchar(255)  null  
     ,
     constraint PK_STEPRECIPE primary key (IDRECIPE, IDSTEPRECIPE)
  )
GO
alter table STEPRECIPE 
     add constraint FK_STEPRECIPE_RECIPE foreign key (IDRECIPE) 
               references RECIPE (IDRECIPE)