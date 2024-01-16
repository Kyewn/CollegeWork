DROP TABLE IF EXISTS publication_master;

CREATE TABLE publication_master (
    pub_id VARCHAR(10),
    type VARCHAR(20) NOT NULL,
    year INT(11) NOT NULL,
    title VARCHAR(70),
    author VARCHAR(500),
    publisher VARCHAR(50),
    volume INT(11),
    num INT(11),
    appears_in VARCHAR(10),
    start_page INT(11),
    end_page INT(11),
    CONSTRAINT pk_publication_master PRIMARY KEY (pub_id)
);


DROP PROCEDURE IF EXISTS merge_publication;
DELIMITER //
CREATE PROCEDURE merge_publication()
BEGIN
	DECLARE exit handler for SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE,
		@errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
		SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
		SELECT @full_error;
	END;
	
	DROP TABLE IF EXISTS all_result;
	CREATE TEMPORARY TABLE all_result (
		records INT,
		record_type char(70)
	);

	/* Insert proceedings data */
	INSERT INTO publication_master(`pub_id`, `type`, `title`, `year`)
	SELECT proceedings.pubid AS pubid, 'proceedings' AS `type`, title, year
	FROM proceedings
	INNER JOIN publication ON (proceedings.pubid = publication.pubid);

	INSERT INTO all_result(records, record_type)
	VALUES(ROW_COUNT(), 'proceedings');

	/* Insert journal data */
	INSERT INTO publication_master(`pub_id`, `type`, `title`, `year`, `volume`, `num`)
	SELECT journal.pubid AS pubid, 'journal' AS `type`, title, `year`, volume, num 
	FROM journal
	INNER JOIN publication ON (journal.pubid = publication.pubid);

	INSERT INTO all_result(records, record_type)
	VALUES(ROW_COUNT(), 'journal');

	/* Insert book data */
	INSERT INTO publication_master(`pub_id`, `type`, `year`, `title`, `publisher`, `author`)
	SELECT book.pubid AS pubid, 'book' AS `type`, `year`, title, publisher, GROUP_CONCAT(REPLACE(author.name, '_', ' ') ORDER BY aorder SEPARATOR ", ") AS author_line 
	FROM book 
	INNER JOIN publication ON (book.pubid = publication.pubid)
	LEFT JOIN wrote ON (book.pubid = wrote.pubid)
	LEFT JOIN author ON (wrote.aid = author.aid)
	GROUP BY pubid;

	INSERT INTO all_result(records, record_type)
	VALUES(ROW_COUNT(), 'book');

	/* Insert article data */
	INSERT INTO publication_master(`pub_id`, `type`, `title`, `year`, `appears_in`, `start_page`, `end_page`, `author`)
	SELECT article.pubid AS pubid, 'article' AS `type`, title, COALESCE(proceedings.`year`, journal.`year`) AS year, article.appearsin, startpage, endpage,
	GROUP_CONCAT(REPLACE(author.name, '_', ' ') ORDER BY aorder SEPARATOR ", ") AS author_line
	FROM article 
	LEFT JOIN journal ON (appearsin = journal.pubid)
	LEFT JOIN proceedings ON (appearsin = proceedings.pubid)
	INNER JOIN publication ON (article.pubid = publication.pubid)
	LEFT JOIN wrote ON (article.pubid = wrote.pubid)
	LEFT JOIN author ON (wrote.aid = author.aid)
	GROUP BY pubid;

	INSERT INTO all_result(records, record_type)
	VALUES(ROW_COUNT(), 'article');

	/* Insert info for sum of all results */
	INSERT INTO all_result(records, record_type)
	SELECT SUM(records), 'all' AS `type` FROM all_result;

	SELECT * FROM all_result;

END//

DELIMITER ;

CALL merge_publication();
