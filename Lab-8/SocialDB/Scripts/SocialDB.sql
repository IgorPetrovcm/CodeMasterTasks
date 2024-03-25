-- <summary>
-- 		Этот скрипт инициализирует таблицы в базе данных Social
-- 		В postgre клиенте, перед запуском скрипта нужно создать базу данных Social
-- </summary>


DROP TABLE IF EXISTS users CASCADE;
CREATE TABLE users(
	user_id SERIAL UNIQUE PRIMARY KEY,
	gender BOOLEAN,
	date_of_birth TIMESTAMP WITH TIME ZONE,
	is_online BOOLEAN NOT NULL DEFAULT false,
	name VARCHAR(128) NOT NULL
);

DROP TABLE IF EXISTS friends CASCADE;
CREATE TABLE friends(
	friend_id SERIAL NOT NULL PRIMARY KEY,
	user_from INT,
	user_to INT,
	friend_status SMALLINT,
	send_date TIMESTAMP WITH TIME ZONE,
	FOREIGN KEY (user_from) REFERENCES Users (user_id) ON DELETE CASCADE,
	FOREIGN KEY (user_to) REFERENCES Users (user_id) ON DELETE CASCADE
);

DROP TABLE IF EXISTS messages CASCADE;
CREATE TABLE messages(
	message_id SERIAL NOT NULL PRIMARY KEY,
	author_id INT NOT NULL,
	send_date TIMESTAMP WITH TIME ZONE NOT NULL,
	message_text TEXT,
	FOREIGN KEY (author_id) REFERENCES Users (user_id) ON DELETE CASCADE
);

DROP TABLE IF EXISTS likes CASCADE;
CREATE TABLE Likes(
	user_id INT NOT NULL,
	message_id INT NOT NULL,
	FOREIGN KEY (user_id) REFERENCES Users (user_id) ON DELETE CASCADE,
	FOREIGN KEY (message_id) REFERENCES Messages (message_id) ON DELETE CASCADE
);