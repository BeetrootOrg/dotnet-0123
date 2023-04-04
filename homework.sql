-- Initial database creation script
CREATE TABLE IF NOT EXISTS tbl_books 
(
    id BIGSERIAL PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    author VARCHAR(255),
    isbn VARCHAR(255) NOT NULL,
    genre VARCHAR(255) NOT NULL,
    year INT NOT NULL
);

insert into tbl_books(title, author, isbn, genre , year)
values ('title1','author1','1','genre',1980),('title1','author1','1','genre',1980),('title2','author2','2','genre',1980),
('title3','author3','3','genre',1980),('title4','author4','4','genre',1980),('title5','author5','5','genre1',1980),
('title6','author6','6','genre1',1980),('title7','author7','8','genre1',1980),('title9','author9','9','genre1',1980),
('title0','author0','0','genre1',1980),('title1','author1','1','genre1',1980),('title11','author11','11','genre1',1980),
('title12','author12','12','genre1',1980),('title13','author13','13','genre1',1980),('title14','author14','14','genre1',1980);

-- group by genre and count books in every group
select count(1), genre from tbl_books group by genre;

-- select all books with titles having the letter 'a'
select * from tbl_books where title like '%a%';

-- select all books without an author
select * from tbl_books where author is NULL;

-- update the year of every book, add 1 year
update tbl_books set year=year+1;

-- delete all books without the author
delete tbl_books where author is NULL;

-- count the number of rows in the table with the author having the letter 'o'
select count(1) from tbl_books  where author like 'o';

-- group books by year and show how many books in the same year
select count(1), year from tbl_books group by year;