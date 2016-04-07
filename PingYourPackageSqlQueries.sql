create table [dbo].[Shipments]
(
	[Id] int not null primary key identity,
	[TrackingNbr] int not null,	
	[ShippingAddress] varchar(250) null,
	[Zipcode] varchar(10) null,
	[AffiliateReferenceNbr] int null,
	[PackageReceiverNbr] int null,
	[ShipmentTypeId] int null,
)

create table [dbo].[Affiliates]
(
	[Id] int not null identity,
	[ReferenceNbr] int not null primary key,
	[Name] varchar(50) null,
	[Address] varchar(250) null,
	[Zipcode] varchar(10) null,
	[EmailAddress] varchar(50) null,
	[PhoneNumber] varchar(20) null,
	[FaxNumber] varchar(20) null,
)

create table [dbo].[PackageReceivers]
(
	[Id] int not null identity,
	[ReceiverNbr] int not null primary key,
	[LastName] varchar(50) null,
	[FirstName] varchar(50) null,
	[MiddleName] varchar(50) null,
	[Address] varchar(250) null,
	[Zipcode] varchar(10) null,
	[EmailAddress] varchar(50) null,
	[PhoneNumber] varchar(20) null,
)

create table [dbo].[ShipmentTypes]
(
	[Id] int not null primary key identity,
	[Type] varchar(20) null,
	[Description] varchar(500) null,
)

alter table [dbo].[Shipments]
add constraint FK_AffiliateReferenceNbr foreign key (AffiliateReferenceNbr)
references [dbo].[Affiliates](ReferenceNbr)

alter table [dbo].[Shipments]
add constraint FK_PackageReceiverNbr foreign key (PackageReceiverNbr)
references [dbo].[PackageReceivers](ReceiverNbr)

alter table [dbo].[Shipments]
add constraint FK_ShipmentTypeId foreign key (ShipmentTypeId)
references [dbo].[ShipmentTypes](Id)