CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `ExceptionLog` (
    `ID` bigint NOT NULL AUTO_INCREMENT,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `IsActive` tinyint(1) NOT NULL,
    `ExceptionResult` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_ExceptionLog` PRIMARY KEY (`ID`)
);

CREATE TABLE `Lexicons` (
    `ID` bigint NOT NULL AUTO_INCREMENT,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `IsActive` tinyint(1) NOT NULL,
    `Key` longtext CHARACTER SET utf8mb4 NULL,
    `Value` longtext CHARACTER SET utf8mb4 NULL,
    `LaunguageCode` longtext CHARACTER SET utf8mb4 NULL,
    `Type` int NOT NULL,
    CONSTRAINT `PK_Lexicons` PRIMARY KEY (`ID`)
);

CREATE TABLE `Pages` (
    `ID` bigint NOT NULL AUTO_INCREMENT,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `IsActive` tinyint(1) NOT NULL,
    `PageName` longtext CHARACTER SET utf8mb4 NULL,
    `PageDescription` longtext CHARACTER SET utf8mb4 NULL,
    `Url` longtext CHARACTER SET utf8mb4 NULL,
    `Content` longtext CHARACTER SET utf8mb4 NULL,
    `MetaTitle` longtext CHARACTER SET utf8mb4 NULL,
    `MetaDescription` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Pages` PRIMARY KEY (`ID`)
);

CREATE TABLE `ServiceCategories` (
    `ID` bigint NOT NULL AUTO_INCREMENT,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `IsActive` tinyint(1) NOT NULL,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `Url` longtext CHARACTER SET utf8mb4 NULL,
    `MetaTitle` longtext CHARACTER SET utf8mb4 NULL,
    `MetaDescription` longtext CHARACTER SET utf8mb4 NULL,
    `Description` longtext CHARACTER SET utf8mb4 NULL,
    `CategoryPhotoAltTag` longtext CHARACTER SET utf8mb4 NULL,
    `CategoryPhoto` longtext CHARACTER SET utf8mb4 NULL,
    `ParentServiceCategoryID` bigint NULL,
    CONSTRAINT `PK_ServiceCategories` PRIMARY KEY (`ID`),
    CONSTRAINT `FK_ServiceCategories_ServiceCategories_ParentServiceCategoryID` FOREIGN KEY (`ParentServiceCategoryID`) REFERENCES `ServiceCategories` (`ID`) ON DELETE RESTRICT
);

CREATE TABLE `Users` (
    `ID` bigint NOT NULL AUTO_INCREMENT,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `IsActive` tinyint(1) NOT NULL,
    `FirstName` longtext CHARACTER SET utf8mb4 NULL,
    `LastName` longtext CHARACTER SET utf8mb4 NULL,
    `Password` longtext CHARACTER SET utf8mb4 NULL,
    `Email` longtext CHARACTER SET utf8mb4 NULL,
    `Phone` longtext CHARACTER SET utf8mb4 NULL,
    `UserType` int NOT NULL,
    `ProfilePhoto` longtext CHARACTER SET utf8mb4 NULL,
    `IsMailActivated` tinyint(1) NOT NULL,
    `IsMobileActivated` tinyint(1) NOT NULL,
    CONSTRAINT `PK_Users` PRIMARY KEY (`ID`)
);

CREATE TABLE `ServiceCategoryProperties` (
    `ID` bigint NOT NULL AUTO_INCREMENT,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `IsActive` tinyint(1) NOT NULL,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `ServiceCategoryID` bigint NOT NULL,
    CONSTRAINT `PK_ServiceCategoryProperties` PRIMARY KEY (`ID`),
    CONSTRAINT `FK_ServiceCategoryProperties_ServiceCategories_ServiceCategoryID` FOREIGN KEY (`ServiceCategoryID`) REFERENCES `ServiceCategories` (`ID`) ON DELETE CASCADE
);

CREATE TABLE `OtpTransactions` (
    `ID` bigint NOT NULL AUTO_INCREMENT,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `IsActive` tinyint(1) NOT NULL,
    `OTPType` int NOT NULL,
    `OTPCode` longtext CHARACTER SET utf8mb4 NULL,
    `IsUsed` tinyint(1) NOT NULL,
    `ExpireDate` datetime(6) NOT NULL,
    `UserID` bigint NOT NULL,
    CONSTRAINT `PK_OtpTransactions` PRIMARY KEY (`ID`),
    CONSTRAINT `FK_OtpTransactions_Users_UserID` FOREIGN KEY (`UserID`) REFERENCES `Users` (`ID`) ON DELETE CASCADE
);

CREATE TABLE `UserAddresses` (
    `ID` bigint NOT NULL AUTO_INCREMENT,
    `CreateDate` datetime(6) NOT NULL,
    `UpdateDate` datetime(6) NULL,
    `IsActive` tinyint(1) NOT NULL,
    `AddressType` int NOT NULL,
    `ZoneNumber` longtext CHARACTER SET utf8mb4 NULL,
    `StreetNumber` longtext CHARACTER SET utf8mb4 NULL,
    `BuildingNumber` longtext CHARACTER SET utf8mb4 NULL,
    `UnitNumber` longtext CHARACTER SET utf8mb4 NULL,
    `Description` longtext CHARACTER SET utf8mb4 NULL,
    `UserID` bigint NULL,
    CONSTRAINT `PK_UserAddresses` PRIMARY KEY (`ID`),
    CONSTRAINT `FK_UserAddresses_Users_UserID` FOREIGN KEY (`UserID`) REFERENCES `Users` (`ID`) ON DELETE RESTRICT
);

CREATE INDEX `IX_OtpTransactions_UserID` ON `OtpTransactions` (`UserID`);

CREATE INDEX `IX_ServiceCategories_ParentServiceCategoryID` ON `ServiceCategories` (`ParentServiceCategoryID`);

CREATE INDEX `IX_ServiceCategoryProperties_ServiceCategoryID` ON `ServiceCategoryProperties` (`ServiceCategoryID`);

CREATE INDEX `IX_UserAddresses_UserID` ON `UserAddresses` (`UserID`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20201116125550_dbinit', '3.1.9');

