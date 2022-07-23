use PRN231_Blog
alter table post_category
    alter column postId int not null
go

alter table post_category
    alter column categoryId int not null
go

alter table post_category
    add constraint post_category_pk
        primary key (postId, categoryId)
go

