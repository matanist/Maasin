create table Branch
(
    Id   int identity
        constraint Branch_pk
            primary key nonclustered,
    Name nvarchar(255) not null
)
go

create table [User]
(
    Id       int identity
        constraint User_pk
            primary key nonclustered,
    Email    nvarchar(255) not null,
    Password nvarchar(255) not null
)
go

create table UserBranchMapping
(
    Id         int identity
        constraint UserBranchMapping_pk
            primary key nonclustered,
    UserId     int
        constraint UserBranchMapping_User_Id_fk
            references [User],
    BranchId   int
        constraint UserBranchMapping_Branch_Id_fk
            references Branch,
    Salary     money,
    UpdateDate datetime
)
go