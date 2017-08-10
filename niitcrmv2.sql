use niitcarev2
use niitcare
use basmallah
create table Program
(
ProgramID int not null identity(1,1),
primary key clustered (ProgramID),
ProgramName varchar (50)
)
create table Modul
(
ModulID int not null identity(1,2),
primary key clustered (ModulID),
ProgramID int foreign key references Program(ProgramID) on update no action on delete cascade,
ModulTitle varchar (50) not null unique
)
create table Instance
(
InstanceID int not null identity(1,3),
primary key clustered (InstanceID),
InstanceName varchar (50) unique not null,
InstanceAddress varchar (max),
InstanceEmail varchar (50),
InstancePhone char (15)
)
create table Departement
(
DepartementID int not null identity(1,4),
primary key clustered (DepartementID),
DepartementName varchar (50) not null,
InstanceID int foreign key references Instance(InstanceID) on update no action on delete cascade,
KeyContactName varchar (max),
KeyContactEmail varchar (50),
KeyContactPhone char (15),
NumberOfStudent int
UNIQUE (DepartementName, InstanceID)
)

/*create table Targets
(InstansiID int  references Instansi(InstansiID)on update no action on delete no action,
DepartementID int foreign key references Departement(DepartementID)on update no action on delete no action,
constraint TargetsID primary key (InstansiID,DepartementID)
)*/

create table Bidding
(
BiddingID int not null identity(5,5),
primary key clustered (BiddingID),
InstanceID int not null references Instance(InstanceID)on update no action on delete cascade,
DepartementID int references Departement(DepartementID),
ProgramID int not null foreign key references Program(ProgramID) on update no action on delete cascade,
ModulID int references Modul(ModulID),
BiddingStatus varchar (7) constraint checkStatusof_Bidding check(BiddingStatus in('Active','Allowed','Pending','Failed','Success')),
BiddingInformationDetail varchar (max),
BiddingStage varchar (7) constraint checkStageof_Bidding check(BiddingStage in('Stage1','Stage2','Stage3','Stage4','Stage5','Stage6')),
DateOfCurrentBidStatus datetime,
NextStep varchar (50),
DateOfNextStep datetime
UNIQUE (BiddingID, InstanceID,ProgramID,DepartementID,ModulID)
)
ALTER TABLE Bidding ADD Qualified varchar (4)constraint checkQualifiedof_Bidding check(Qualified in('Cold','Warm','Hot'));
insert into Modul values ('Modul tiga euy')

insert into Program values (1,'Program satu')

select * from Program
select * from Modul

delete from Modul where JudulModul='Modul dua euy'

update Program set ModulID=3 where ProgramID=8use niitcare
use basmallah
create table Program
(
ProgramID int not null identity(1,1),
primary key clustered (ProgramID),
NamaProgram varchar (50)
)
create table Modul
(
ModulID int not null identity(1,2),
primary key clustered (ModulID),
ProgramID int foreign key references Program(ProgramID) on update no action on delete cascade,
JudulModul varchar (50) not null unique
)
create table Instansi
(
InstansiID int not null identity(1,3),
primary key clustered (InstansiID),
NamaInstansi varchar (50) unique not null,
Alamat varchar (max),
Email varchar (50),
Phone char (15)
)
create table Departement
(
DepartementID int not null identity(1,4),
primary key clustered (DepartementID),
NamaDepartement varchar (50) not null,
InstansiID int foreign key references Instansi(InstansiID) on update no action on delete cascade,
NamaManager varchar (max),
EmailManager varchar (50),
PhoneManager char (15),
JumlahSiswa int
UNIQUE (NamaDepartement, InstansiID)
)

/*create table Targets
(InstansiID int  references Instansi(InstansiID)on update no action on delete no action,
DepartementID int foreign key references Departement(DepartementID)on update no action on delete no action,
constraint TargetsID primary key (InstansiID,DepartementID)
)*/

create table Bidding
(
BiddingID int not null identity(5,5),
primary key clustered (BiddingID),
InstansiID int references Instansi(InstansiID)on update no action on delete cascade,
DepartementID int references Departement(DepartementID)on update no action on delete no action,
ProgramID int foreign key references Program(ProgramID) on update no action on delete cascade,
ModulID int references Modul(ModulID)on update no action on delete no action,
States varchar (max),
Keterangan varchar (max),
TanggalMulai time,
TanggalKonfirm time
)

insert into Modul values ('Modul tiga euy')

insert into Program values (1,'Program satu')

select * from Program
select * from Modul

delete from Modul where JudulModul='Modul dua euy'

update Program set ModulID=3 where ProgramID=8