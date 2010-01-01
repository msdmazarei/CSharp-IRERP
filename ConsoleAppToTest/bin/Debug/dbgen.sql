
    
alter table irerp__bases__CallInfo  drop foreign key FKAB5194AA92876635


    
alter table irerp__bases__CallInfo  drop foreign key FKAB5194AA79D46C19


    
alter table irerp__bases__Character  drop foreign key FK6DB62DD5F65B3F33


    
alter table irerp__bases__Character  drop foreign key FK6DB62DD5955C57DA


    
alter table irerp__bases__Help  drop foreign key FKA14D3E525E52E543


    
alter table irerp__bases__Identification  drop foreign key FK9423D09D6484BA36


    
alter table irerp__bases__Identification  drop foreign key FK9423D09DA84F2D7


    
alter table irerp__bases__Identification  drop foreign key FK9423D09D2421BCE8


    
alter table irerp__bases__LegalCharacter  drop foreign key FK84F663A9748BDB39


    
alter table irerp__bases__LegalCharacter  drop foreign key FK84F663A912058E8E


    
alter table irerp__bases__LegalCharacter  drop foreign key FK84F663A943AAA5E1


    
alter table irerp__bases__LegalCharacter  drop foreign key FK84F663A9671C100F


    
alter table irerp__bases__MessagingInfo  drop foreign key FK2C0CD681E77BBF21


    
alter table irerp__bases__MessagingInfo  drop foreign key FK2C0CD681A44761E6


    
alter table irerp__bases__MessagingInfo  drop foreign key FK2C0CD68179D46C19


    
alter table irerp__bases__PostalAddress  drop foreign key FKEE6E4137A76F51A6


    
alter table irerp__bases__PostalAddress  drop foreign key FKEE6E413779D46C19


    
alter table irerp__bases__RightFulCharacter  drop foreign key FKBDD49F1CD38FB382


    
alter table irerp__bases__RoleOfCharacter  drop foreign key FK80044390140100F


    
alter table irerp__bases__RoleOfCharacter  drop foreign key FK8004439079D46C19


    
alter table irerp__sys__GroupUser  drop foreign key FKF45B09B143A093C7


    
alter table irerp__sys__GroupUser  drop foreign key FKF45B09B14493F486


    
alter table irerp__sys__GroupMenu  drop foreign key FK1E223C9478C8102B


    
alter table irerp__sys__GroupMenu  drop foreign key FK1E223C944493F486


    
alter table jah__FilmContentlist  drop foreign key FKEBF3417B78CA35F0


    
alter table jah__Film_Actors  drop foreign key FK44847B7A7DD459C


    
alter table jah__Film_Directors  drop foreign key FK1D6B105A7DD459C


    
alter table jah__Film_EducationalGoals  drop foreign key FK57F802EE78CA35F0


    
alter table jah__Film_Executives  drop foreign key FK6F6C65E97DD459C


    
alter table jah__Film_Senarists  drop foreign key FKA4AC0B647DD459C


    
alter table jah__Film_Speakers  drop foreign key FK3C823E97DD459C


    
alter table jah__Film_TechnicalExperts  drop foreign key FK4A03E9147DD459C


    
alter table jah__Film_Writers  drop foreign key FK725C756A7DD459C


    drop table if exists irerp__bases__CallInfoLog_Tb

    drop table if exists irerp__bases__CallInfo

    drop table if exists irerp__bases__CharacterLog

    drop table if exists irerp__bases__Character

    drop table if exists irerp__bases__CharacterRoleLog

    drop table if exists irerp__bases__CharacterRole

    drop table if exists irerp__bases__GenderLog

    drop table if exists irerp__bases__Gender

    drop table if exists irerp__bases__HelpLog

    drop table if exists irerp__bases__Help

    drop table if exists irerp__bases__IdentificationLog

    drop table if exists irerp__bases__Identification

    drop table if exists irerp__bases__IdentificationTypeLog

    drop table if exists irerp__bases__IdentificationType

    drop table if exists irerp__bases__LanguageLog

    drop table if exists irerp__bases__Language

    drop table if exists irerp__bases__LegalBranchLog

    drop table if exists irerp__bases__LegalBranch

    drop table if exists irerp__bases__LegalCharacterLog

    drop table if exists irerp__bases__LegalCharacter

    drop table if exists irerp__bases__LegalCharacterTypelog

    drop table if exists irerp__bases__LegalCharacterType

    drop table if exists irerp__bases__MessagingInfoLog

    drop table if exists irerp__bases__MessagingInfo

    drop table if exists irerp__bases__MessagingInfoTypeLog

    drop table if exists irerp__bases__MessagingInfoType

    drop table if exists irerp__bases__NationalityLog

    drop table if exists irerp__bases__Nationality

    drop table if exists irerp__bases__PlacesLog

    drop table if exists irerp__bases__Places

    drop table if exists irerp__bases__CallInfoTypeLog

    drop table if exists irerp__bases__CallInfoType

    drop table if exists irerp__bases__MessagingRelationTypeLog

    drop table if exists irerp__bases__MessagingRelationType

    drop table if exists irerp__bases__PostalAddressLog

    drop table if exists irerp__bases__PostalAddress

    drop table if exists irerp__bases__PostalAddressTypeLog

    drop table if exists irerp__bases__CharacterTypeLog

    drop table if exists irerp__bases__CharacterType

    drop table if exists irerp__bases__RightFulCharacterLog

    drop table if exists irerp__bases__RightFulCharacter

    drop table if exists irerp__bases__RoleOfCharacterLog

    drop table if exists irerp__bases__RoleOfCharacter

    drop table if exists irerp__sys__Group

    drop table if exists irerp__sys__GroupUser

    drop table if exists irerp__sys__GroupMenu

    drop table if exists irerp__bases__PostalAddressType

    drop table if exists jah__Auidunce

    drop table if exists jah__AuidunceLog

    drop table if exists jah__FilmContentlist

    drop table if exists jah__FilmEducationalGoal

    drop table if exists jah__FilmEducationalGoalLog

    drop table if exists jah__Film

    drop table if exists jah__FilmProductionFormat

    drop table if exists jah__FilmProductionFormatLog

    drop table if exists jah__FilmSystemType

    drop table if exists jah__FilmSystemTypeLog

    drop table if exists jah__Film_Actors

    drop table if exists jah__Film_Directors

    drop table if exists jah__Film_EducationalGoals

    drop table if exists jah__Film_Executives

    drop table if exists jah__Film_Senarists

    drop table if exists jah__Film_Speakers

    drop table if exists jah__Film_TechnicalExperts

    drop table if exists jah__Film_Writers

    drop table if exists jah__MagazineType

    drop table if exists jah__MagazineTypeLog

    drop table if exists jah__MagNo

    drop table if exists jah__MagNoLog

    drop table if exists jah__Matter

    drop table if exists jah__MatterLog

    drop table if exists jah__PictureFormat

    drop table if exists jah__PictureFormatLog

    drop table if exists jah__PictureType

    drop table if exists jah__PictureTypeLog

    drop table if exists jah__Resulation

    drop table if exists jah__ResulationLog

    drop table if exists jah__Size

    drop table if exists jah__SizeLog

    drop table if exists jah__State

    drop table if exists jah__StateLog

    drop table if exists jah__Subject

    drop table if exists jah__SubjectLog

    drop table if exists jah__Title

    drop table if exists jah__TitleLog

    drop table if exists jah__TVRD

    drop table if exists jah__TVRDLog

    drop table if exists jah__Year

    drop table if exists jah__YearLog

    drop table if exists irerp__sys__Menu

    drop table if exists irerp__sys__User

    create table irerp__bases__CallInfoLog_Tb (
        LogId VARCHAR(40) not null,
       LogDate DATETIME,
       id VARCHAR(40),
       CallNumber VARCHAR(255) not null,
       Type VARCHAR(40) not null,
       IsDeleted TINYINT(1),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       CharacterID VARCHAR(40),
       primary key (LogId)
    )

    create table irerp__bases__CallInfo (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       CallNumber VARCHAR(255) not null,
       IsDeleted TINYINT(1),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       Type VARCHAR(40),
       CharacterID VARCHAR(40),
       primary key (id)
    )

    create table irerp__bases__CharacterLog (
        LogId VARCHAR(40) not null,
       LogDate DATETIME,
       id VARCHAR(40),
       CharacterName VARCHAR(40),
       NickName VARCHAR(255),
       IsDeleted TINYINT(1),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       CellNumber VARCHAR(255),
       Email VARCHAR(255),
       Address VARCHAR(255),
       PostalCode VARCHAR(255),
       TellNumber VARCHAR(255),
       Natinality VARCHAR(40),
       primary key (LogId)
    )

    create table irerp__bases__Character (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       NickName VARCHAR(255),
       IsDeleted TINYINT(1),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       CellNumber VARCHAR(255),
       Email VARCHAR(255),
       Address VARCHAR(255),
       PostalCode VARCHAR(255),
       TellNumber VARCHAR(255),
       CharacterName VARCHAR(40),
       Natinality VARCHAR(40),
       primary key (id)
    )

    create table irerp__bases__CharacterRoleLog (
        LogId VARCHAR(40) not null,
       LogDate DATETIME,
       id VARCHAR(40),
       RoleName VARCHAR(255) not null,
       IsDeleted TINYINT(1),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       primary key (LogId)
    )

    create table irerp__bases__CharacterRole (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       RoleName VARCHAR(255) not null,
       IsDeleted TINYINT(1),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       primary key (id)
    )

    create table irerp__bases__GenderLog (
        LogId VARCHAR(40) not null,
       LogDate DATETIME,
       id VARCHAR(40),
       GenderName VARCHAR(255) not null,
       IsDeleted TINYINT(1),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       primary key (LogId)
    )

    create table irerp__bases__Gender (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       GenderName VARCHAR(255) not null,
       IsDeleted TINYINT(1),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       primary key (id)
    )

    create table irerp__bases__HelpLog (
        LogId VARCHAR(40) not null,
       LogDate DATETIME,
       id VARCHAR(40),
       HelpText VARCHAR(255),
       HelpKey VARCHAR(255),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       IsDeleted TINYINT(1),
       Description VARCHAR(255),
       primary key (LogId)
    )

    create table irerp__bases__Help (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       HelpText VARCHAR(255),
       HelpKey VARCHAR(255),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       IsDeleted TINYINT(1),
       Description VARCHAR(255),
       Language VARCHAR(40),
       primary key (id)
    )

    create table irerp__bases__IdentificationLog (
        LogId VARCHAR(40) not null,
       IdentificationType VARCHAR(40),
       IsDeleted TINYINT(1),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       LogDate DATETIME,
       id VARCHAR(40),
       primary key (LogId)
    )

    create table irerp__bases__Identification (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       fileuploadtest VARCHAR(255),
       IsDeleted TINYINT(1),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       _____IdentificationType_id VARCHAR(40),
       _____Character_id VARCHAR(40),
       TestFile_FiN VARCHAR(40),
       TestFile_FiS BIGINT,
       TestFile_FiC DATETIME,
       TestFile_FiCC VARCHAR(255),
       TestFile_FiR VARCHAR(255),
       TestFile_FiT VARCHAR(255),
       TestAddress_Addr VARCHAR(255),
       TestAddress_AptNo VARCHAR(255),
       TestAddress_GAddr VARCHAR(255),
       TestAddress_Lat DOUBLE,
       TestAddress_Lng DOUBLE,
       TestAddress_Roof VARCHAR(255),
       Identification VARCHAR(40),
       primary key (id)
    )

    create table irerp__bases__IdentificationTypeLog (
        LogId VARCHAR(40) not null,
       Name VARCHAR(255),
       Description VARCHAR(255),
       IsDeleted TINYINT(1),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       LogDate DATETIME,
       id VARCHAR(40),
       primary key (LogId)
    )

    create table irerp__bases__IdentificationType (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       Name VARCHAR(255),
       Description VARCHAR(255),
       IsDeleted TINYINT(1),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       primary key (id)
    )

    create table irerp__bases__LanguageLog (
        LogId VARCHAR(40) not null,
       LogDate DATETIME,
       id VARCHAR(40),
       LanguageName VARCHAR(255),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       IsDeleted TINYINT(1),
       Description VARCHAR(255),
       primary key (LogId)
    )

    create table irerp__bases__Language (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       LanguageName VARCHAR(255),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       IsDeleted TINYINT(1),
       Description VARCHAR(255),
       primary key (id)
    )

    create table irerp__bases__LegalBranchLog (
        LogId VARCHAR(40) not null,
       LogDate DATETIME not null,
       id VARCHAR(40) not null,
       Name VARCHAR(255) not null,
       Description VARCHAR(255),
       IsDeleted TINYINT(1),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       primary key (LogId)
    )

    create table irerp__bases__LegalBranch (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       Name VARCHAR(255) not null,
       Description VARCHAR(255),
       IsDeleted TINYINT(1),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       primary key (id)
    )

    create table irerp__bases__LegalCharacterLog (
        LogId VARCHAR(40) not null,
       id VARCHAR(40),
       NationalIdentifier VARCHAR(255),
       RegistrationNumber VARCHAR(255),
       EconomicNumber VARCHAR(255),
       AgentId VARCHAR(40),
       LegalCharacterTypeId VARCHAR(40),
       ChairMan VARCHAR(255),
       RegistrationPlace VARCHAR(40),
       LegalBranchId VARCHAR(40),
       DependentCompany VARCHAR(40),
       IsDeleted TINYINT(1),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       primary key (LogId)
    )

    create table irerp__bases__LegalCharacter (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       NationalIdentifier VARCHAR(255),
       RegistrationNumber VARCHAR(255),
       EconomicNumber VARCHAR(255),
       ChairMan VARCHAR(255),
       IsDeleted TINYINT(1),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       LegalBranchId VARCHAR(40),
       LegalCharacterTypeId VARCHAR(40),
       RegistrationPlace VARCHAR(40),
       AgentId VARCHAR(40),
       DependentCompany VARCHAR(40),
       primary key (id)
    )

    create table irerp__bases__LegalCharacterTypelog (
        Logid VARCHAR(40) not null,
       LogDate DATETIME not null,
       id VARCHAR(40) not null,
       Name VARCHAR(255) not null,
       Description VARCHAR(255),
       IsDeleted TINYINT(1),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       primary key (Logid)
    )

    create table irerp__bases__LegalCharacterType (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       Name VARCHAR(255) not null,
       Description VARCHAR(255),
       IsDeleted TINYINT(1),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       primary key (id)
    )

    create table irerp__bases__MessagingInfoLog (
        LogId VARCHAR(40) not null,
       LogDate DATETIME,
       id VARCHAR(40),
       CharacterID VARCHAR(40),
       MessagingAddress VARCHAR(255) not null,
       RelationType VARCHAR(40) not null,
       Type VARCHAR(40) not null,
       IsDeleted TINYINT(1),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       primary key (LogId)
    )

    create table irerp__bases__MessagingInfo (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       MessagingAddress VARCHAR(255),
       IsDeleted TINYINT(1),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       Type VARCHAR(40),
       RelationType VARCHAR(40),
       CharacterID VARCHAR(40),
       primary key (id)
    )

    create table irerp__bases__MessagingInfoTypeLog (
        LogId VARCHAR(40) not null,
       MessagingType VARCHAR(255) not null,
       LogDate DATETIME not null,
       id VARCHAR(40) not null,
       IsDeleted TINYINT(1),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       primary key (LogId)
    )

    create table irerp__bases__MessagingInfoType (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       MessagingType VARCHAR(255) not null,
       IsDeleted TINYINT(1),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       primary key (id)
    )

    create table irerp__bases__NationalityLog (
        LogId VARCHAR(40) not null,
       Name VARCHAR(255),
       Description VARCHAR(255),
       IsDeleted TINYINT(1),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       primary key (LogId)
    )

    create table irerp__bases__Nationality (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       Name VARCHAR(255),
       Description VARCHAR(255),
       IsDeleted TINYINT(1),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       primary key (id)
    )

    create table irerp__bases__PlacesLog (
        Logid VARCHAR(40) not null,
       LocationName VARCHAR(255) not null,
       LogDate DATETIME not null,
       id VARCHAR(40) not null,
       Pid VARCHAR(40),
       Description VARCHAR(255),
       IsDeleted TINYINT(1),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       primary key (Logid)
    )

    create table irerp__bases__Places (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       LocationName VARCHAR(255),
       Pid VARCHAR(40),
       Description VARCHAR(255),
       IsDeleted TINYINT(1),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       primary key (id)
    )

    create table irerp__bases__CallInfoTypeLog (
        Logid VARCHAR(40) not null,
       TypeName VARCHAR(255) not null,
       IsDeleted TINYINT(1),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       LogDate DATETIME not null,
       id VARCHAR(40) not null,
       primary key (Logid)
    )

    create table irerp__bases__CallInfoType (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       TypeName VARCHAR(255) not null,
       IsDeleted TINYINT(1),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       primary key (id)
    )

    create table irerp__bases__MessagingRelationTypeLog (
        Logid VARCHAR(40) not null,
       id VARCHAR(40),
       RelationName VARCHAR(255) not null,
       IsDeleted TINYINT(1),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       LogDate DATETIME,
       primary key (Logid)
    )

    create table irerp__bases__MessagingRelationType (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       RelationName VARCHAR(255) not null,
       IsDeleted TINYINT(1),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       primary key (id)
    )

    create table irerp__bases__PostalAddressLog (
        LogId VARCHAR(40) not null,
       LogDate DATETIME,
       id VARCHAR(40),
       CharacterID VARCHAR(40) not null,
       PostalAddressType VARCHAR(40) not null,
       PostalCode VARCHAR(255) not null,
       Address VARCHAR(255) not null,
       KMZ VARCHAR(255),
       IsDeleted TINYINT(1),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       primary key (LogId)
    )

    create table irerp__bases__PostalAddress (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       PostalCode VARCHAR(255),
       Address VARCHAR(255),
       KMZ VARCHAR(255),
       IsDeleted TINYINT(1),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       PostalAddressType VARCHAR(40),
       CharacterID VARCHAR(40),
       primary key (id)
    )

    create table irerp__bases__PostalAddressTypeLog (
        Logid VARCHAR(40) not null,
       Name VARCHAR(255) not null,
       Description VARCHAR(255),
       IsDeleted TINYINT(1),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       LogDate DATETIME,
       id VARCHAR(40) not null,
       primary key (Logid)
    )

    create table irerp__bases__CharacterTypeLog (
        Logid VARCHAR(40) not null,
       id VARCHAR(40) not null,
       CharacterTypeName VARCHAR(255) not null,
       IsDeleted TINYINT(1),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       LogDate DATETIME,
       Description VARCHAR(255),
       primary key (Logid)
    )

    create table irerp__bases__CharacterType (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       CharacterTypeName VARCHAR(255) not null,
       IsDeleted TINYINT(1),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       primary key (id)
    )

    create table irerp__bases__RightFulCharacterLog (
        LogId VARCHAR(40) not null,
       LogDate DATETIME,
       id VARCHAR(40),
       Fname VARCHAR(255),
       LName VARCHAR(255),
       NationalCode VARCHAR(255),
       FatherName VARCHAR(255),
       BirthCertificateSerial VARCHAR(255),
       Gender VARCHAR(40),
       BrithDayYear VARCHAR(255),
       BrithdayPlaceId VARCHAR(40),
       BirthCertificateNumber VARCHAR(255),
       IsDeleted TINYINT(1),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       primary key (LogId)
    )

    create table irerp__bases__RightFulCharacter (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       Fname VARCHAR(255),
       LName VARCHAR(255),
       NationalCode VARCHAR(255),
       FatherName VARCHAR(255),
       BirthCertificateSerial VARCHAR(255),
       BrithDayYear VARCHAR(255),
       BirthCertificateNumber VARCHAR(255),
       IsDeleted TINYINT(1),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       Description VARCHAR(255),
       Gender VARCHAR(40),
       BrithdayPlaceId VARCHAR(40),
       primary key (id)
    )

    create table irerp__bases__RoleOfCharacterLog (
        LogId VARCHAR(40) not null,
       LogDate DATETIME,
       id VARCHAR(40),
       CharacterID VARCHAR(40),
       RoleID VARCHAR(40),
       Description VARCHAR(255),
       IsDeleted TINYINT(1),
       Version BIGINT,
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       primary key (LogId)
    )

    create table irerp__bases__RoleOfCharacter (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       Description VARCHAR(255),
       IsDeleted TINYINT(1),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       RoleID VARCHAR(40),
       CharacterID VARCHAR(40),
       primary key (id)
    )

    create table irerp__sys__Group (
        id VARCHAR(40) not null,
       IsDeleted TINYINT(1) not null,
       GroupName VARCHAR(150) not null,
       Description TEXT,
       primary key (id)
    )

    create table irerp__sys__GroupUser (
        Id VARCHAR(40) not null,
       IsDeleted TINYINT(1) not null,
       UserID VARCHAR(40),
       GroupId VARCHAR(40),
       primary key (Id)
    )

    create table irerp__sys__GroupMenu (
        id VARCHAR(40) not null,
       IsDeleted TINYINT(1) not null,
       WithChildren TINYINT(1) not null,
       MenuId VARCHAR(40),
       GroupId VARCHAR(40),
       primary key (id)
    )

    create table irerp__bases__PostalAddressType (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       Name VARCHAR(255) not null,
       Description VARCHAR(255),
       IsDeleted TINYINT(1),
       AddBy VARCHAR(40),
       ModifiedID VARCHAR(40),
       AddByDAte DATETIME,
       ModifiyDate DATETIME,
       primary key (id)
    )

    create table jah__Auidunce (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (id)
    )

    create table jah__AuidunceLog (
        Logid VARCHAR(40) not null,
       id VARCHAR(40),
       Version BIGINT,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (Logid)
    )

    create table jah__FilmContentlist (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       ContentTitle VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       Film VARCHAR(40),
       primary key (id)
    )

    create table jah__FilmEducationalGoal (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (id)
    )

    create table jah__FilmEducationalGoalLog (
        Logid VARCHAR(40) not null,
       id VARCHAR(40),
       Version BIGINT,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (Logid)
    )

    create table jah__Film (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       FilmName VARCHAR(255),
       FilmTime VARCHAR(255),
       ProductionDate DATETIME,
       PersianProductionDate VARCHAR(255),
       Montage VARCHAR(255),
       FilmCode VARCHAR(255),
       FilmabstracFile VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       ProductionFormat VARCHAR(40),
       Client VARCHAR(40),
       SystemType VARCHAR(40),
       primary key (id)
    )

    create table jah__FilmProductionFormat (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (id)
    )

    create table jah__FilmProductionFormatLog (
        Logid VARCHAR(40) not null,
       id VARCHAR(40),
       Version BIGINT,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (Logid)
    )

    create table jah__FilmSystemType (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (id)
    )

    create table jah__FilmSystemTypeLog (
        Logid VARCHAR(40) not null,
       id VARCHAR(40),
       Version BIGINT,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (Logid)
    )

    create table jah__Film_Actors (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       Film VARCHAR(40),
       CharacterID VARCHAR(40),
       primary key (id)
    )

    create table jah__Film_Directors (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       Film VARCHAR(40),
       CharacterID VARCHAR(40),
       primary key (id)
    )

    create table jah__Film_EducationalGoals (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       Film VARCHAR(40),
       FilmEducationalGoal VARCHAR(40),
       primary key (id)
    )

    create table jah__Film_Executives (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       Film VARCHAR(40),
       CharacterID VARCHAR(40),
       primary key (id)
    )

    create table jah__Film_Senarists (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       Film VARCHAR(40),
       CharacterID VARCHAR(40),
       primary key (id)
    )

    create table jah__Film_Speakers (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       Film VARCHAR(40),
       CharacterID VARCHAR(40),
       primary key (id)
    )

    create table jah__Film_TechnicalExperts (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       Film VARCHAR(40),
       CharacterID VARCHAR(40),
       primary key (id)
    )

    create table jah__Film_Writers (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       Film VARCHAR(40),
       CharacterID VARCHAR(40),
       primary key (id)
    )

    create table jah__MagazineType (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (id)
    )

    create table jah__MagazineTypeLog (
        Logid VARCHAR(40) not null,
       id VARCHAR(40),
       Version BIGINT,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (Logid)
    )

    create table jah__MagNo (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (id)
    )

    create table jah__MagNoLog (
        Logid VARCHAR(40) not null,
       id VARCHAR(40),
       Version BIGINT,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (Logid)
    )

    create table jah__Matter (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (id)
    )

    create table jah__MatterLog (
        Logid VARCHAR(40) not null,
       id VARCHAR(40),
       Version BIGINT,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (Logid)
    )

    create table jah__PictureFormat (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (id)
    )

    create table jah__PictureFormatLog (
        Logid VARCHAR(40) not null,
       id VARCHAR(40),
       Version BIGINT,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (Logid)
    )

    create table jah__PictureType (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (id)
    )

    create table jah__PictureTypeLog (
        Logid VARCHAR(40) not null,
       id VARCHAR(40),
       Version BIGINT,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (Logid)
    )

    create table jah__Resulation (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (id)
    )

    create table jah__ResulationLog (
        Logid VARCHAR(40) not null,
       id VARCHAR(40),
       Version BIGINT,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (Logid)
    )

    create table jah__Size (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (id)
    )

    create table jah__SizeLog (
        Logid VARCHAR(40) not null,
       id VARCHAR(40),
       Version BIGINT,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (Logid)
    )

    create table jah__State (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (id)
    )

    create table jah__StateLog (
        Logid VARCHAR(40) not null,
       id VARCHAR(40),
       Version BIGINT,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (Logid)
    )

    create table jah__Subject (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (id)
    )

    create table jah__SubjectLog (
        Logid VARCHAR(40) not null,
       id VARCHAR(40),
       Version BIGINT,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (Logid)
    )

    create table jah__Title (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (id)
    )

    create table jah__TitleLog (
        Logid VARCHAR(40) not null,
       id VARCHAR(40),
       Version BIGINT,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (Logid)
    )

    create table jah__TVRD (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (id)
    )

    create table jah__TVRDLog (
        Logid VARCHAR(40) not null,
       id VARCHAR(40),
       Version BIGINT,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (Logid)
    )

    create table jah__Year (
        id VARCHAR(40) not null,
       Version BIGINT not null,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (id)
    )

    create table jah__YearLog (
        Logid VARCHAR(40) not null,
       id VARCHAR(40),
       Version BIGINT,
       IsDeleted TINYINT(1),
       AddDate DATETIME,
       LastModifyDate DATETIME,
       Description VARCHAR(255),
       Name VARCHAR(255),
       AddedBy VARCHAR(40),
       ModifyBy VARCHAR(40),
       primary key (Logid)
    )

    create table irerp__sys__Menu (
        id VARCHAR(40) not null,
       IsDeleted TINYINT(1),
       EnName VARCHAR(50) not null,
       Title VARCHAR(50) not null,
       HasChild TINYINT(1) not null,
       Description VARCHAR(100),
       URL VARCHAR(100),
       ParentID VARCHAR(40),
       MethodToCall VARCHAR(150),
       primary key (id)
    )

    create table irerp__sys__User (
        id VARCHAR(40) not null,
       Username VARCHAR(100) not null,
       Password VARCHAR(255),
       IsDeleted TINYINT(1) not null,
       primary key (id)
    )

    alter table irerp__bases__CallInfo 
        add index (Type), 
        add constraint FKAB5194AA92876635 
        foreign key (Type) 
        references irerp__bases__CallInfoType (id)

    alter table irerp__bases__CallInfo 
        add index (CharacterID), 
        add constraint FKAB5194AA79D46C19 
        foreign key (CharacterID) 
        references irerp__bases__Character (id)

    alter table irerp__bases__Character 
        add index (Natinality), 
        add constraint FK6DB62DD5F65B3F33 
        foreign key (Natinality) 
        references irerp__bases__Nationality (id)

    alter table irerp__bases__Character 
        add index (CharacterName), 
        add constraint FK6DB62DD5955C57DA 
        foreign key (CharacterName) 
        references irerp__bases__CharacterType (id)

    alter table irerp__bases__Help 
        add index (Language), 
        add constraint FKA14D3E525E52E543 
        foreign key (Language) 
        references irerp__bases__Language (id)

    alter table irerp__bases__Identification 
        add index (_____IdentificationType_id), 
        add constraint FK9423D09D6484BA36 
        foreign key (_____IdentificationType_id) 
        references irerp__bases__IdentificationType (id)

    alter table irerp__bases__Identification 
        add index (_____Character_id), 
        add constraint FK9423D09DA84F2D7 
        foreign key (_____Character_id) 
        references irerp__bases__Character (id)

    alter table irerp__bases__Identification 
        add index (Identification), 
        add constraint FK9423D09D2421BCE8 
        foreign key (Identification) 
        references irerp__bases__Character (id)

    alter table irerp__bases__LegalCharacter 
        add index (AgentId), 
        add constraint FK84F663A9748BDB39 
        foreign key (AgentId) 
        references irerp__bases__Character (id)

    alter table irerp__bases__LegalCharacter 
        add index (LegalBranchId), 
        add constraint FK84F663A912058E8E 
        foreign key (LegalBranchId) 
        references irerp__bases__LegalBranch (id)

    alter table irerp__bases__LegalCharacter 
        add index (LegalCharacterTypeId), 
        add constraint FK84F663A943AAA5E1 
        foreign key (LegalCharacterTypeId) 
        references irerp__bases__LegalCharacterType (id)

    alter table irerp__bases__LegalCharacter 
        add index (RegistrationPlace), 
        add constraint FK84F663A9671C100F 
        foreign key (RegistrationPlace) 
        references irerp__bases__Places (id)

    alter table irerp__bases__MessagingInfo 
        add index (Type), 
        add constraint FK2C0CD681E77BBF21 
        foreign key (Type) 
        references irerp__bases__MessagingInfoType (id)

    alter table irerp__bases__MessagingInfo 
        add index (RelationType), 
        add constraint FK2C0CD681A44761E6 
        foreign key (RelationType) 
        references irerp__bases__MessagingRelationType (id)

    alter table irerp__bases__MessagingInfo 
        add index (CharacterID), 
        add constraint FK2C0CD68179D46C19 
        foreign key (CharacterID) 
        references irerp__bases__Character (id)

    alter table irerp__bases__PostalAddress 
        add index (PostalAddressType), 
        add constraint FKEE6E4137A76F51A6 
        foreign key (PostalAddressType) 
        references irerp__bases__PostalAddressType (id)

    alter table irerp__bases__PostalAddress 
        add index (CharacterID), 
        add constraint FKEE6E413779D46C19 
        foreign key (CharacterID) 
        references irerp__bases__Character (id)

    alter table irerp__bases__RightFulCharacter 
        add index (BrithdayPlaceId), 
        add constraint FKBDD49F1CD38FB382 
        foreign key (BrithdayPlaceId) 
        references irerp__bases__Places (id)

    alter table irerp__bases__RoleOfCharacter 
        add index (RoleID), 
        add constraint FK80044390140100F 
        foreign key (RoleID) 
        references irerp__bases__CharacterRole (id)

    alter table irerp__bases__RoleOfCharacter 
        add index (CharacterID), 
        add constraint FK8004439079D46C19 
        foreign key (CharacterID) 
        references irerp__bases__Character (id)

    alter table irerp__sys__GroupUser 
        add index (UserID), 
        add constraint FKF45B09B143A093C7 
        foreign key (UserID) 
        references irerp__sys__User (id)

    alter table irerp__sys__GroupUser 
        add index (GroupId), 
        add constraint FKF45B09B14493F486 
        foreign key (GroupId) 
        references irerp__sys__Group (id)

    alter table irerp__sys__GroupMenu 
        add index (MenuId), 
        add constraint FK1E223C9478C8102B 
        foreign key (MenuId) 
        references irerp__sys__Menu (id)

    alter table irerp__sys__GroupMenu 
        add index (GroupId), 
        add constraint FK1E223C944493F486 
        foreign key (GroupId) 
        references irerp__sys__Group (id)

    alter table jah__FilmContentlist 
        add index (Film), 
        add constraint FKEBF3417B78CA35F0 
        foreign key (Film) 
        references jah__Film (id)

    alter table jah__Film_Actors 
        add index (CharacterID), 
        add constraint FK44847B7A7DD459C 
        foreign key (CharacterID) 
        references jah__Film (id)

    alter table jah__Film_Directors 
        add index (CharacterID), 
        add constraint FK1D6B105A7DD459C 
        foreign key (CharacterID) 
        references jah__Film (id)

    alter table jah__Film_EducationalGoals 
        add index (Film), 
        add constraint FK57F802EE78CA35F0 
        foreign key (Film) 
        references jah__Film (id)

    alter table jah__Film_Executives 
        add index (CharacterID), 
        add constraint FK6F6C65E97DD459C 
        foreign key (CharacterID) 
        references jah__Film (id)

    alter table jah__Film_Senarists 
        add index (CharacterID), 
        add constraint FKA4AC0B647DD459C 
        foreign key (CharacterID) 
        references jah__Film (id)

    alter table jah__Film_Speakers 
        add index (CharacterID), 
        add constraint FK3C823E97DD459C 
        foreign key (CharacterID) 
        references jah__Film (id)

    alter table jah__Film_TechnicalExperts 
        add index (CharacterID), 
        add constraint FK4A03E9147DD459C 
        foreign key (CharacterID) 
        references jah__Film (id)

    alter table jah__Film_Writers 
        add index (CharacterID), 
        add constraint FK725C756A7DD459C 
        foreign key (CharacterID) 
        references jah__Film (id)
