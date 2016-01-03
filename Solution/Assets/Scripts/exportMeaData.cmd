:: Name:     exportMeaData.cmd
:: Purpose:  Exports the meadata database schema to a SQL file, along with data from "important" tables
::            Optionally allows the user to update the schema's version string
:: Author:   Dan Vicarel (shundra8820@gmail.com)
:: Revision: May 2015 - initial version
::           June 2015 - revised log messages and added support for the meadata.cnf file
::           July 2015 - script can now keep track of the directory in which its placed
::           December 2015 - added this header, removed delayed expansion, added ability to change database schema's version string, and cleaned everything up with "function calls"

:: Set up
@ECHO OFF
SETLOCAL enableDelayedExpansion
SET scriptName=%~n0
SET scriptDir=%~dp0

:: Initialize some environment variables
SET EXIT_SUCCESS=0
SET EXIT_SYNTAX_ERROR=1
SET EXIT_UPDATED=1
SET cnfPath=%scriptDir%meadata.cnf
SET mysqlDir=C:\Program Files*\MySQL\MySQL Server 5.*\bin\
SET dbName=meadata
SET logPath=%scriptDir%%scriptName%.log
ECHO Script started >"%logPath%"

:: Determine whether this script was run from a command line or by double-clicking
CALL :getIsInteractive
SET pauseRequired=%ERRORLEVEL%

:: Set parameters/flags based on the provided arguments
SET index=0
SET sqlFileName=
SET newVersionStr=
SET help=0
SET forceUpdate=0
:Loop
    SET argStr=%1
    IF "%argStr%"=="" GOTO Continue
    CALL :processArgSuccess "%argStr%"
    IF ERRORLEVEL %EXIT_SYNTAX_ERROR% EXIT /B %EXIT_SYNTAX_ERROR%
    SHIFT
GOTO Loop
:Continue

:: If any part of the input was invalid (and help was not requrested), then
:: show prop syntax and exit
IF "%sqlFileName%"=="" (
    IF %help%==0 CALL :log "No dump file name was provided."
    CALL :showSyntax
    EXIT /B %EXIT_SYNTAX_ERROR%
)

:: Show help if requested
IF %help%==1 (
    CALL :showSyntax
    EXIT /B EXIT_SUCCESS
)

:: Perform the version update (if requested)
CD /D "%mysqlDir%"
SET dbUpdated=0
IF NOT "%newVersionStr%"=="" (
    CALL :versionUpdated
    SET dbUpdated=%ERRORLEVEL%
)

:: If the database was updated...
SET shouldUpdate=0
IF %dbUpdated%==1 SET shouldUpdate=1
IF %forceUpdate%==1 SET shouldUpdate=1
IF %shouldUpdate%==1 (
    SET exportPath=%scriptDir%%sqlFileName%.sql
    SET solnDir=%scriptDir%..\..\
    
    REM Export its schema, along with data from non user-specific tables
    ECHO.
    CALL :log "Exporting database schema."
    CALL :log "Only including data from the following tables:"
    CALL :log "    tissue_types"
    CALL :log "    model_organisms"
    CALL :log "    age_units"
    CALL :log "    result_types"
    CALL :log "    version"
    CALL :exportTo "!exportPath!"
    CALL :log "Exporting complete^!"

    REM Copy the dump file to the necessary project Resource directories (overwrite automatically)
    ECHO.
    CALL :log "Copying to the following directories:"
    SET utilProjDir=!solnDir!Util\Resources
    FOR /D %%D IN ("!utilProjDir!") DO (
        CALL :log "    %%~fD"
        COPY /Y "!exportPath!" "%%~fD%" >NUL
    )
    DEL "!exportPath!"
    
    REM Adjust version strings in the necessary Resource files    
)

:: Tear down
ECHO Script finished >>"%logPath%"
IF "%pauseRequired%"=="1" ECHO. && PAUSE
ENDLOCAl
EXIT /B EXIT_SUCCESS


:getIsInteractive
    ::
    :: bool getIsInteractive()
    :: -----------------------------------------------------------------
    ECHO %CMDCMDLINE% | FIND /I "%scriptName%" >NUL
    IF ERRORLEVEL 1 (SET i=0) ELSE SET i=1
    
    EXIT /B %i%


:log
    ::
    :: void log(string message)
    :: -----------------------------------------------------------------
    ECHO %~1
    SET dateTimeStr=%TIME:~0,2%:%TIME:~3,2%:%TIME:~6,2% on %DATE:~10,4%-%DATE:~4,2%-%DATE:~7,2%
    ECHO %scriptName% (%dateTimeStr%)^> %~1 >>"%logPath%"
    
    EXIT /B %EXIT_SUCCESS%


:processArgSuccess
    ::
    :: bool processArgSuccess(int& index, string value)
    :: -----------------------------------------------------------------
    SET value=%~1
    SET exitCode=%EXIT_SUCCESS%
    SET indexIncrement=0
    
    :: Check if this string has flag syntax
    CALL :strFlagState "%value%"
    SET flagState=%ERRORLEVEL%
    
    :: If not, then set the corresponding parameter
    IF %flagState%==0 (
        SET /A index+=1
        SET %~1=%index%
        CALL :setParam
    )
    
    :: If it was a flag, but an invalid one, then show correct syntax and exit
    If %flagState%==1 (
        CALL :log "Invalid switch - '%value%'."
        CALL :showSyntax
        SET exitCode=%EXIT_SYNTAX_ERROR%
    )
    
    :: If it was a valid flag, then set the corresponding global flag
    IF %flagState%==2 (
        CALL :setFlag "%value%"
    )
    
    EXIT /B %exitCode%
    

:strFlagState
    ::
    :: bool isFlag(string str)
    :: -----------------------------------------------------------------
    SET str=%~1
    
    :: Check if this string has flag syntax
    SET flag=0
    SET char=%str:~0,1%
    IF "%char%"=="-" SET flag=1
    IF "%char%"=="/" SET flag=1

    :: If it does, then check that it is one of the flags supported by this script
    IF %flag%==1 (
        IF /I "%str%"=="--force" SET flag=2
        IF /I "%str%"=="-F" SET flag=2
        IF /I "%str%"=="/F" SET flag=2)
        
        IF /I "%str%"=="--help" SET flag=2
        IF /I "%str%"=="-H" SET flag=2
        IF /I "%str%"=="/H" SET flag=2)
        IF /I "%str%"=="/?" SET flag=2)
    )
    EXIT /B %flag%
 
:setParam 
    ::
    :: void setParam(int& index, string& value)
    :: -----------------------------------------------------------------
    REM Set the global parameter matching this arg index
    IF %index%==1 SET sqlFileName=%value%
    IF %index%==2 SET newVersionStr=%value%
    
    EXIT /B %EXIT_SUCCESS%
 
 
:setFlag
    ::
    :: void setFlag(string& flag)
    :: -----------------------------------------------------------------
    SET flag=%~1
    
    :: Set the global flag matching this string
    
    :: Force update flag
    SET state=0
    IF /I "%flag%"=="--force" SET state=1
    IF /I "%flag%"=="-F" SET state=1
    IF /I "%flag%"=="/F" SET state=1
    IF %state%==1 SET forceUpdate=1
        
    :: Help flag
    SET state=0
    IF /I "%flag%"=="--help" SET state=1
    IF /I "%flag%"=="-H" SET state=1
    IF /I "%flag%"=="/H" SET state=1
    IF /I "%flag%"=="/?" SET state=1
    IF %state%==1 SET help=1
    
    EXIT /B %EXIT_SUCCESS%


:showSyntax
    ::
    :: void showSyntax()
    :: -----------------------------------------------------------------
    ECHO.
    CALL :log "Exports the %dbName% database schema to the necessary project directories."
    ECHO.
    CALL :log "EXPORTMEADATA [options] dumpFileName [newVersionString]"
    ECHO.
    CALL :log "  dumpFileName       Specifies the name of the exported SQL file that"
    CALL :log "                     will be placed in each required project directory."
    CALL :log "                     No file extension need (or should^) be given."
    ECHO.
    CALL :log "  newVersionString   Optional.  Specifies a new version string for the"
    CALL :log "                     exported database.  This string will be passed to "
    CALL :log "                     the database in an UPDATE statement before"
    CALL :log "                     exporting.  It will also be used to update all"
    CALL :log "                     version-related text and resource comments within"
    CALL :log "                     the solution.  This string may contain characters"
    CALL :log "                     other than numbers."
    ECHO.
    CALL :log "  /F, --force        Force the database to be exported, even if its"
    CALL :log "                     current version matches the provided version."
    CALL :log "                     Has no effect if a version string was not provided."
    ECHO.
    CALL :log "Data will only be exported from non-user-specific tables.  All other"
    CALL :log "tables will export just their schema."
    
    IF %pauseRequired%==1 ECHO. && PAUSE
    EXIT /B %EXIT_SUCCESS%


:versionUpdated
    ::
    :: bool versionUpdated(string& newVersionStr)
    :: -----------------------------------------------------------------
    SET exitCode=0
    
    :: Select the old version string from the database
    SET selectQuery=SELECT Version FROM version;
    SET selectMacro=mysql --defaults-extra-file="%cnfPath%" --execute="%selectQuery%" %dbName%
    FOR /F "skip=1 usebackq" %%I IN (`"%selectMacro%"`) DO SET oldVersionStr=%%I

    :: If it doesn't match the new version string, perform an update
    :: Return whether or not an update was performed
    IF NOT "%oldVersionStr%"=="%newVersionStr%" (
        CALL :log "Updating database from version '%oldVersionStr%' to '%newVersionStr%'..."
        SET updateQuery=UPDATE version SET Version=%newVersionStr%;
        mysql --defaults-extra-file="%cnfPath%" --execute="!updateQuery!" %dbName%
        SET exitCode=1
    ) ELSE (
        CALL :log "Database already at version '%newVersionStr%'"
        SET exitCode=0
    )
    
    EXIT /B %exitCode%


:exportTo
    ::
    :: void exportTo(string dumpFilePath)
    :: -----------------------------------------------------------------
    SET exportPath=%~1
    
    :: Export database structure
    >"%exportPath%" (
        mysqldump ^
            --defaults-extra-file="%cnfPath%" ^
            --no-data ^
            --no-create-db ^
            --ignore-table=%dbName%.tissue_types ^
            --ignore-table=%dbName%.model_organisms ^
            --ignore-table=%dbName%.age_units ^
            --ignore-table=%dbName%.result_types ^
            --ignore-table=%dbName%.version ^
            %dbName%
    )

    :: Export data from specific tables
    >>"%exportPath%" (
        mysqldump ^
            --defaults-extra-file="%cnfPath%" ^
            --databases %dbName% ^
            --no-create-db ^
            --tables tissue_types model_organisms age_units result_types version ^
    )
    
    EXIT /B %EXIT_SUCCESS%
