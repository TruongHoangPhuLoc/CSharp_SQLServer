use gymstore


create table account (
account_id int not null identity(1,1),
username nvarchar(255) not null unique,
pass nvarchar(255),
PRIMARY KEY (account_id)
);

create table kindOfProduct(
kind_id int not null identity(1,1) Primary Key,
name_of_kind nvarchar(50),
)


create table product(
product_id int not null identity(1,1) Primary Key,
product_name nvarchar(255),
product_kindID int,
price int,
Constraint FK_KindID FOREIGN KEY(product_kindID) REFERENCES kindOfProduct(id)
)



insert into account(username,pass)
values('PhuLoc','123')

select * from account

insert into kindOfProduct(name_of_kind)
values(N'Chất Xơ')

insert into kindOfProduct(name_of_kind)
values(N'Whey Protein')

insert into kindOfProduct(name_of_kind)
values(N'Tăng Sức Mạnh')

insert into kindOfProduct(name_of_kind)
values(N'Tăng Sức Bền')

insert into kindOfProduct(name_of_kind)
values(N'Hỗ Trợ Giảm Mỡ')

insert into kindOfProduct(name_of_kind)
values(N'Sức Khỏe Toàn Diện')

insert into kindOfProduct(name_of_kind)
values(N'Testosterone Booster')

insert into kindOfProduct(name_of_kind)
values(N'Phụ Kiện Thể Thao')

insert into kindOfProduct(name_of_kind)
values(N'Gia Vị Và Chế Biến')

insert into kindOfProduct(name_of_kind)
values(N'Sữa Tăng Cân')


insert into product(product_name,product_kindID,price)
values (N'PVL WHEY GOLD - 100% WHEY PROTEIN SHAKE MIX, 6LBS (72 SERVINGS)',2,1490000)
insert into product(product_name,product_kindID,price)
values (N'RULE1 WHEY BLEND 5 LBS (2.3KG) - 70 SERVINGS',2,1050000)

insert into product(product_name,product_kindID,price)
values (N'CHẤT XƠ DẠNG VIÊN NOW PSYLLIUM HUSK CAPS, 500MG (500 CAPSULES)',1,560000)

insert into product(product_name,product_kindID,price)
values (N'YẾN MẠCH QUAKER OATS OLD FASHION, 10 LBS (4.54 KG)',1,290000)


select * from kindOfProduct

select * from [dbo].[account]
where username = 'phuloc' and pass = '123'

select product.product_id,product.product_name,product.price,kindOfProduct.name_of_kind 
from product JOIN kindOfProduct 
on product.product_kindID = kindOfProduct.kind_id


                
