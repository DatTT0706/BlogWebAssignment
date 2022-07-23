exec sp_rename 'post_comment.parentId', userId, 'COLUMN'
go

alter table post_comment
    alter column userId int not null
go

alter table post_comment
    add constraint post_comment_user_id_fk
        foreign key (userId) references [user]
go

UPDATE PRN231_Blog.dbo.post_comment  userId = 1, WHERE id = 1;
UPDATE PRN231_Blog.dbo.post_comment  userId = 2, WHERE id = 2;
UPDATE PRN231_Blog.dbo.post_comment  userId = 3, WHERE id = 3;
UPDATE PRN231_Blog.dbo.post_comment  userId = 4, WHERE id = 4;
UPDATE PRN231_Blog.dbo.post_comment  userId = 4, WHERE id = 5;
