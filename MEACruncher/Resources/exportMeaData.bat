@ECHO OFF
CLS

SETLOCAL EnableDelayedExpansion

REM ***********  This shouldn't need to be declared ******************
SET destPath="C:\Dan_Programming\DefaultCollection\MEA-Cruncher\MEACruncher\Resources"

REM Get the name of the SQL file to export to from the user
ECHO.
ECHO Enter the name of the file to which the exported schema's SQL will be stored.
ECHO You don't need to provide an extension.
SET /p sqlFileName=">"

REM Navigate to where the mysqldump executable is stored
CD C:\Program Files\MySQL\MySQL Server 5.7\bin

REM Export database structure
ECHO.
ECHO -- ********** DATABASE STRUCTURE ********** >!destPath!/!sqlFileName!.sql
ECHO. >>!destPath!/!sqlFileName!.sql
ECHO Exporting database structure...
mysqldump --defaults-extra-file=!destPath!/meadata.cnf --skip-comments --no-data meadata >> !destPath!/!sqlFileName!.sql

REM Export data from specific tables	
ECHO. >>!destPath!/!sqlFileName!.sql
ECHO -- ********** DATA FROM SPECIFIC TABLES ********** >>!destPath!/!sqlFileName!.sql
ECHO. >>!destPath!/!sqlFileName!.sql
ECHO Exporting data from version table...
mysqldump --defaults-extra-file=!destPath!/meadata.cnf --skip-comments meadata version >> !destPath!/!sqlFileName!.sql

ECHO Exporting complete!

SET sqlFileName=

ECHO.
PAUSE

ENDLOCAl

@ECHO ON
