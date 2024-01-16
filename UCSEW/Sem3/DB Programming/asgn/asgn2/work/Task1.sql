DELIMITER //
CREATE PROCEDURE print_publication(IN authorName VARCHAR(22))
BEGIN
    DECLARE results INT;
    DECLARE exit handler for SQLEXCEPTION
    BEGIN
        GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE,
        @errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
        SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
        SELECT @full_error;
    END;

    SELECT COUNT(*) INTO results
    FROM author a
    LEFT JOIN wrote w ON (a.aid = w.aid)
    LEFT JOIN publication p ON (w.pubid = p.pubid)
    WHERE a.name = authorName;

    IF results = 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'No publications found for the specified author';

    ELSE
        SELECT p.pubid AS 'Publication ID', p.title AS 'Publication Title', b.`year` AS 'Publication Year'
        FROM author a
        LEFT JOIN wrote w ON (a.aid = w.aid)
        LEFT JOIN publication p ON (w.pubid = p.pubid)
        INNER JOIN book b ON (b.pubid = p.pubid)
        WHERE a.name = authorName

        UNION

        SELECT p.pubid AS 'Publication ID', p.title AS 'Publication Title', COALESCE(pc.`year`, jc.`year`) AS 'Publication Year'
        FROM author a
        LEFT JOIN wrote w ON (a.aid = w.aid)
        LEFT JOIN publication p ON (w.pubid = p.pubid)
        INNER JOIN article aa ON (aa.pubid = p.pubid)
        LEFT JOIN proceedings pc ON (pc.pubid = aa.appearsin)
        LEFT JOIN journal jc ON (jc.pubid = aa.appearsin)
        WHERE a.name = authorName

        ORDER BY 'Publication Year' ASC;
    END IF;
END //
DELIMITER ;
