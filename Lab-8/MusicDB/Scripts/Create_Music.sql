
-- <summary>
-- 		Этот скрипт инициализирует таблицы в базе данных Music
-- 		В postgre клиенте, перед запуском скрипта нужно создать базу данных Music
-- </summary>


DROP TABLE IF EXISTS albums CASCADE;
CREATE TABLE albums(
	album_id SERIAL NOT NULL PRIMARY KEY,
	date DATE,
	title VARCHAR(255) NOT NULL
);

DROP TABLE IF EXISTS songs CASCADE;
CREATE TABLE songs(
	song_id SERIAL NOT NULL PRIMARY KEY,
	album_id INT NOT NULL,
	title VARCHAR(255) NOT NULL,
	duration TIME WITHOUT TIME ZONE NOT NULL,
	FOREIGN KEY (album_id) REFERENCES albums (album_id) ON DELETE CASCADE
);

CREATE OR REPLACE PROCEDURE usp_add_album(title VARCHAR(255), date DATE)
	LANGUAGE plpgsql
AS 
$$
	DECLARE 
        query  TEXT;
	BEGIN 
		query := 'INSERT INTO albums (title, date) VALUES (''' || title || ''', ''' || date || ''')';
		EXECUTE query;
	END;
$$;

CREATE OR REPLACE PROCEDURE usp_add_song(title VARCHAR(255), album_id INT, duration TIME) 
	LANGUAGE plpgsql
AS
$$
	DECLARE 
        query  TEXT;
	BEGIN
		query := 'INSERT INTO songs (album_id, title, duration) VALUES (' || album_id || ', ''' || title || ''', ''' || duration || ''')';
		EXECUTE query;
	END;
$$;

