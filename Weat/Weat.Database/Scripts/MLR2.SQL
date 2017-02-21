/*
 ----------------------------------------------------------------------------
             Génération d'une base de données pour
                        SQL Server 2005
                       (13/1/2017 13:38:50)
 ----------------------------------------------------------------------------
     Nom de la base : MLR2
     Projet : Espace de travail
     Auteur : Matt
     Date de dernière modification : 13/1/2017 13:38:37
 ----------------------------------------------------------------------------
*/

drop database MLR2
go

/* -----------------------------------------------------------------------------
      OUVERTURE DE LA BASE MLR2
----------------------------------------------------------------------------- */

create database MLR2
go

use MLR2
go



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
go



/*      INDEX DE FRIDGE      */



/* -----------------------------------------------------------------------------
      TABLE : PERSON
----------------------------------------------------------------------------- */

create table PERSON
  (
     IDUSER smallint identity (1, 1)   ,
     FIRSTNAME varchar(32)  null  ,
     LASTNAME varchar(32)  null  ,
     PSEUDO varchar(32)  null  ,
     PASSWORD varchar(128)  null  
     ,
     constraint PK_PERSON primary key (IDUSER)
  ) 
go



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
go



/* -----------------------------------------------------------------------------
      TABLE : TYPEINGREDIENT
----------------------------------------------------------------------------- */

create table TYPEINGREDIENT
  (
     CODETYPEINGREDIENT varchar(4)  not null  ,
     CAPTION varchar(128)  null  
     ,
     constraint PK_TYPEINGREDIENT primary key (CODETYPEINGREDIENT)
  ) 
go



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
go



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
go



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
go



/*      INDEX DE RECIPE      */



/* -----------------------------------------------------------------------------
      TABLE : INGREDIENT
----------------------------------------------------------------------------- */

create table INGREDIENT
  (
     IDINGREDIENT smallint identity (1, 1)   ,
     CODETYPEINGREDIENT varchar(4)  not null  ,
     URLIMAGE varchar(255)  null  ,
     NAMEINGREDIENT varchar(32)  null  
     ,
     constraint PK_INGREDIENT primary key (IDINGREDIENT)
  ) 
go



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
go



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
go



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
go



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
go



/*      INDEX DE RECIPEINGREDIENT      */



/* -----------------------------------------------------------------------------
      REFERENCES SUR LES TABLES
----------------------------------------------------------------------------- */



alter table FRIDGE 
     add constraint FK_FRIDGE_TYPEFRIDGE foreign key (CODETYPEFRIDGE) 
               references TYPEFRIDGE (CODETYPEFRIDGE)
go




alter table FRIDGE 
     add constraint FK_FRIDGE_PERSON foreign key (IDUSER) 
               references PERSON (IDUSER)
go




alter table STEPRECIPE 
     add constraint FK_STEPRECIPE_RECIPE foreign key (IDRECIPE) 
               references RECIPE (IDRECIPE)
go




alter table RECIPE 
     add constraint FK_RECIPE_TYPERECIPE foreign key (CODETYPERECIPE) 
               references TYPERECIPE (CODETYPERECIPE)
go




alter table RECIPE 
     add constraint FK_RECIPE_PERSON foreign key (IDUSER) 
               references PERSON (IDUSER)
go




alter table INGREDIENT 
     add constraint FK_INGREDIENT_TYPEINGREDIENT foreign key (CODETYPEINGREDIENT) 
               references TYPEINGREDIENT (CODETYPEINGREDIENT)
go




alter table FAVORITERECIPEUSER 
     add constraint FK_FAVORITERECIPEUSER_RECIPE foreign key (IDRECIPE) 
               references RECIPE (IDRECIPE)
go




alter table FAVORITERECIPEUSER 
     add constraint FK_FAVORITERECIPEUSER_PERSON foreign key (IDUSER) 
               references PERSON (IDUSER)
go




alter table FRIGDEINGREDIENT 
     add constraint FK_FRIGDEINGREDIENT_INGREDIENT foreign key (IDINGREDIENT) 
               references INGREDIENT (IDINGREDIENT)
go




alter table FRIGDEINGREDIENT 
     add constraint FK_FRIGDEINGREDIENT_FRIDGE foreign key (IDFRIDGE) 
               references FRIDGE (IDFRIDGE)
go




alter table PLANNING 
     add constraint FK_PLANNING_RECIPE foreign key (IDRECIPE) 
               references RECIPE (IDRECIPE)
go




alter table PLANNING 
     add constraint FK_PLANNING_PERSON foreign key (IDUSER) 
               references PERSON (IDUSER)
go




alter table RECIPEINGREDIENT 
     add constraint FK_RECIPEINGREDIENT_INGREDIENT foreign key (IDINGREDIENT) 
               references INGREDIENT (IDINGREDIENT)
go




alter table RECIPEINGREDIENT 
     add constraint FK_RECIPEINGREDIENT_RECIPE foreign key (IDRECIPE) 
               references RECIPE (IDRECIPE)
go




/*
 -----------------------------------------------------------------------------
               FIN DE GENERATION
 -----------------------------------------------------------------------------
*/