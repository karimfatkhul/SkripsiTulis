use niitcare
use basmallah
create table Program
(
ProgramID int not null identity(1,1),
primary key clustered (ProgramID),
NamaProgram varchar (280)
)
create table Modul
(
ModulID int not null identity(1,2),
primary key clustered (ModulID),
ProgramID int foreign key references Program(ProgramID) on update no action on delete cascade,
JudulModul varchar (280) not null unique
)
create table Instansi
(
InstansiID int not null identity(1,3),
primary key clustered (InstansiID),
NamaInstansi varchar (280) unique not null,
Alamat varchar (max),
Email varchar (120),
Phone char (15)
)
create table Departement
(
DepartementID int not null identity(1,4),
primary key clustered (DepartementID),
NamaDepartement varchar (280) not null,
InstansiID int foreign key references Instansi(InstansiID) on update no action on delete cascade,
NamaManager varchar (max),
EmailManager varchar (120),
PhoneManager char (15),
JumlahSiswa int
UNIQUE (NamaDepartement, InstansiID)
)

create table Targets
(InstansiID int  references Instansi(InstansiID)on update no action on delete no action,
DepartementID int foreign key references Departement(DepartementID)on update no action on delete no action,
constraint TargetsID primary key (InstansiID,DepartementID)
)

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