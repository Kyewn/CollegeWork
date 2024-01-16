DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `print_article`(IN `pub_id` VARCHAR(255))
BEGIN
	DECLARE results INT;
	DECLARE exit handler for SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1 @sqlstate = RETURNED_SQLSTATE,
		@errno = MYSQL_ERRNO, @text = MESSAGE_TEXT;
		SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
		SELECT @full_error;
	END;
	
    SELECT COUNT(publication_master.type) INTO results FROM publication_master WHERE 	   publication_master.appears_in = pub_id AND publication_master.type = "article";
    
    IF results =0 THEN
    	SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Publication Id do not have any article in it.';
    ELSE
		SELECT * FROM publication_master WHERE appears_in = pub_id AND type ="article" ORDER BY start_page ASC;
	
	END IF;
 END$$
DELIMITER ;