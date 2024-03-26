insert into albums (date, title) values ('1973-03-01', 'The Dark Side of the Moon');

do 
$$
    declare 
        current_album_id int;
    begin
      	select album_id into current_album_id from albums
          	where title = 'The Dark Side of the Moon';

        insert into songs (album_id, title, duration) values (current_album_id, 'Speak To Me', '00:01:05');
        insert into songs (album_id, title, duration) values (current_album_id, 'On the Run', '00:03:36');
        insert into songs (album_id, title, duration) values (current_album_id, 'Breathe', '00:02:43');
	    insert into songs (album_id, title, duration) values (current_album_id, 'Time', '00:06:53');
        insert into songs (album_id, title, duration) values (current_album_id, 'The Great Gig in the Sky', '00:04:36');
        insert into songs (album_id, title, duration) values (current_album_id, 'Money', '00:06:23');
        insert into songs (album_id, title, duration) values (current_album_id, 'Us and Them', '00:07:49');
        insert into songs (album_id, title, duration) values (current_album_id, 'Any Colour You Like', '00:03:26');
        insert into songs (album_id, title, duration) values (current_album_id, 'Brain Damage', '00:03:49');
        insert into songs (album_id, title, duration) values (current_album_id, 'Eclipse', '00:02:03');
    end
$$;


insert into albums (date, title) values ('1967-05-26', 'Sgt. Pepper''s Lonely Hearts Club Band')

do 
$$
    declare 
        current_album_id int;
    begin
        select album_id into current_album_id from albums
            where title = 'Sgt. Pepper''s Lonely Hearts Club Band';

        insert into songs (album_id, title, duration) values (current_album_id, 'Sgt. Pepper''s Lonely Hearts Club Band', '00:02:00');
        insert into songs (album_id, title, duration) values (current_album_id, 'With a Little Help from My Friends', '00:02:42');
        insert into songs (album_id, title, duration) values (current_album_id, 'Lucy in the Sky with Diamonds', '00:03:28');
        insert into songs (album_id, title, duration) values (current_album_id, 'Getting Better', '00:02:48');
        insert into songs (album_id, title, duration) values (current_album_id, 'Fixing a Hole', '00:02:36');
        insert into songs (album_id, title, duration) values (current_album_id, 'She''s Leaving Home', '00:03:35');
        insert into songs (album_id, title, duration) values (current_album_id, 'Being for the Benefit of Mr. Kite!', '00:02:37');
        insert into songs (album_id, title, duration) values (current_album_id, 'Within You Without You', '00:05:05');
        insert into songs (album_id, title, duration) values (current_album_id, 'When I''m Sixty-Four', '00:02:37');
        insert into songs (album_id, title, duration) values (current_album_id, 'Lovely Rita', '00:02:42');
        insert into songs (album_id, title, duration) values (current_album_id, 'Good Morning Good Morning', '00:02:42');
        insert into songs (album_id, title, duration) values (current_album_id, 'Sgt. Pepper''s Lonely Hearts Club Band (Reprise)', '00:01:18');
        insert into songs (album_id, title, duration) values (current_album_id, 'A Day in the Life', '00:05:38');
        
    end
$$;

insert into albums (date, title) values ('1971-10-08', 'Led Zeppelin IV')

do 
$$
    declare 
        current_album_id int;
    begin
        select album_id into current_album_id from albums
            where title = 'Led Zeppelin IV';

            insert into songs (album_id, title, duration) values (current_album_id, 'Black Dog', '00:04:54');
            insert into songs (album_id, title, duration) values (current_album_id, 'Rock and Roll', '00:03:40');
            insert into songs (album_id, title, duration) values (current_album_id, 'The Battle of Evermore', '00:05:51');
            insert into songs (album_id, title, duration) values (current_album_id, 'Stairway to Heaven', '00:08:02');
            insert into songs (album_id, title, duration) values (current_album_id, 'Misty Mountain Hop', '00:04:38');
            insert into songs (album_id, title, duration) values (current_album_id, 'Four Sticks', '00:04:44');
            insert into songs (album_id, title, duration) values (current_album_id, 'Going to California', '00:03:31');
            insert into songs (album_id, title, duration) values (current_album_id, 'When the Levee Breaks', '00:07:07');
    end
$$;
