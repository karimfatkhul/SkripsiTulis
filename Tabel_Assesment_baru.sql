

create table DataGuru (
Guru_Id nvarchar (128) not null,
primary key clustered (Guru_Id),
foreign key (Guru_Id) references[AspNetUsers](Id) on update no action on delete cascade,
Nama_Guru varchar (50),
Mata_Pelajaran varchar (15),
Jenis_kelamin char(1) constraint checkJenis_kelamin check(Jenis_kelamin in('L','P')),
Email varchar (20),
Alamat varchar (255)
);

create table DataSiswa (
Siswa_Id nvarchar (128) not null,
primary key clustered (Siswa_Id),
foreign key (Siswa_Id) references[AspNetUsers](Id) on update no action on delete cascade,
Nama_Siswa varchar (50),
Jenis_kelamin varchar(1),
Sekolah varchar (30),
Email varchar (20),
Alamat varchar (255)
);

/*create table DataAdmin (
Admin_Id nvarchar (128) not null,
primary key clustered (Admin_Id),
foreign key (Admin_Id) references[AspNetUsers](Id) on update no action on delete cascade,
Nama_Admin varchar (50),
Email varchar (20),
Alamat varchar (255)
); */

create table MataPelajaran (
MP_Id int not null primary key,
Nama_MP varchar (15),
Guru_Id nvarchar (128) foreign key references DataGuru(Guru_Id)
);

create table Ujian (
Ujian_Id int not null primary key,
Createdby nvarchar (128) not null,
foreign key (Createdby) references[DataGuru](Guru_Id) on update no action on delete cascade,
MP_Id int foreign key references MataPelajaran(MP_Id),
EnrolmentKey varchar (10),
Tanggal date,
Waktu_pembuatan time,
Durasi_pengerjaan time,
Batas_ujian time,
);

create table Tag (
Tag_Id int not null primary key,
Tag_1 varchar (20),
Tag_2 varchar (50),
Tanggal date,
Waktu time
);

create table Soal (
Soal_Id int not null primary key,
Createdby nvarchar (128) not null,
foreign key (Createdby) references[DataGuru](Guru_Id) on update no action on delete cascade,
Tag_Id int foreign key references Tag(Tag_Id),
Soal varchar (max),
A varchar (max),
B varchar (max),
C varchar (max),
D varchar (max),
E varchar (max),
Jawaban varchar (1),
Tanggal date
);

create table EventUjian(
EventUjian_Id int not null primary key,
Soal_Id int foreign key references Soal(Soal_Id),
Ujian_Id int foreign key references Ujian(Ujian_Id),
Createdby nvarchar (128)  not null,
foreign key (Createdby) references[DataSiswa](Siswa_Id) on update no action on delete cascade,
);


create table TagSoal (
TagSoal_Id int not null primary key,
Tag_Id int foreign key references Tag(Tag_Id),
Soal_Id int foreign key references Soal(Soal_Id)
);

create table Nilai (
Nilai_Id int not null primary key,
EventUjian_Id int foreign key references EventUjian(EventUjian_Id),
Jawaban_Siswa char (1) constraint checkJawaban_Siswa check(Jawaban_Siswa in('A','a','B','b','C','c')),
Nilai varchar (5) 
);

create table PreviewUjian(
PreviewUjian_Id int not null primary key,
Ujian_Id int foreign key references Ujian(Ujian_Id),
Createdby nvarchar (128) not null,
foreign key (Createdby) references[DataSiswa](Siswa_Id) on update no action on delete cascade,
Tag_Id int foreign key references Tag(Tag_Id),
Soal varchar (max),
Jawaban varchar (1),
);
create table Rekap (
Rekap_Id int not null primary key,
Createdby nvarchar (128) not null,
foreign key (Createdby) references[DataSiswa](Siswa_Id) on update no action on delete cascade,
Tag_Id int foreign key references Tag(Tag_Id),
MP_Id int foreign key references MataPelajaran(MP_Id),
Tanggal date
);

