#Write a stored procedure called add_vaccine with appropriate input parameters. Execute this procedure will insert both vaccination and visit records to the database. You are required to prompt the users to enter relevant vaccination details with appropriate messages. You are also required to add the following requirements in this procedure:

DELIMITER //
CREATE PROCEDURE add_vaccine(IN pat_id INT(10), IN vac_type VARCHAR(255), IN doc_id INT(10))
BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
	BEGIN
		GET DIAGNOSTICS CONDITION 1 
            @sqlstate = RETURNED_SQLSTATE,
            @errno = MYSQL_ERRNO, 
            @text = MESSAGE_TEXT;
		
        SET @full_error = CONCAT("ERROR ", @errno, " (", @sqlstate, "): ", @text);
		SELECT @full_error;
	END;
    
    #	Verify reference integrity for 3 inputs
    SELECT 
    	COUNT(*) INTO @isPatientFound
    FROM patient
    WHERE patient_id = pat_id;
    
    IF (@isPatientFound = 0) THEN
    	SIGNAL SQLSTATE
    		'45000'
		SET
    		MESSAGE_TEXT = "Patient ID does not exist in the database, unable to add new vaccination record";
    END IF;
    
    SELECT 
        COUNT(*) INTO @isDoctorFound
    FROM doctor
    WHERE doctor_id = doc_id;
    
    IF (@isDoctorFound = 0) THEN
		SIGNAL SQLSTATE
    		'45000'
		SET
    		MESSAGE_TEXT = "Doctor ID does not exist in the database, unable to add new vaccination record.";
    END IF;
    
    SELECT 
    	COUNT(*) INTO @isVacTypeFound
    FROM valid_for
    WHERE valid_type = vac_type;
    
    IF (@isVacTypeFound = 0) THEN
		SIGNAL SQLSTATE
    		'45000'
		SET
    		MESSAGE_TEXT = "Vaccine type does not exist in the database, unable to add new vaccination record.";
    END IF;
    
    #	A business rule that no more than two vaccinations are allowed per patient per day.
    SELECT 
    	MAX(vac_count) INTO @sameDayVaccinationCount
    FROM vaccinations
    WHERE vac_patient_id = pat_id AND STR_TO_DATE(vac_date, "%d-%b-%Y") = CURRENT_DATE;
    
    IF (@sameDayVaccinationCount > 1) THEN
    	SIGNAL SQLSTATE
    		'45000'
		SET
    		MESSAGE_TEXT = "Patient have reached the maximum daily vaccination dosage count, unable to add new vaccination record.";
    END IF;
    
    #Check if patient-date pair exist in visits
    SELECT
    	 COUNT(*) INTO @isVisitRecorded
    FROM visits
    WHERE visits_patient_id = pat_id AND STR_TO_DATE(visits_date, "%d-%b-%Y") = CURRENT_DATE;
    
    #INSERT for visits relation only if current visit does not exist yet
    IF (@isVisitRecorded = 0) THEN
    	INSERT INTO visits (visits_patient_id, visits_doctor_id, visits_date)
        VALUES (pat_id, doc_id, DATE_FORMAT(CURRENT_DATE, "%d-%b-%Y"));
    END IF;
    
    #-	A business rule that the first vaccination for a given patient on a given visit date has an action number 1 and the second vaccination have 		action no 2 on the same date for the same patient. 
    
    SELECT 
        CASE
        	WHEN MAX(vac_count) IS NULL THEN 1
        	ELSE 2
       	END INTO @newActionNumber
    FROM vaccinations
    WHERE vac_patient_id = pat_id AND STR_TO_DATE(vac_date, "%d-%b-%Y") = CURRENT_DATE;
    
    
    #INSERT for vaccination relation
    INSERT INTO vaccinations (vac_patient_id, vac_date, vac_count, vac_valid_type)
    VALUES (pat_id, DATE_FORMAT(CURRENT_DATE, "%d-%b-%Y"), @newActionNumber, vac_type);
END//
DELIMITER ;