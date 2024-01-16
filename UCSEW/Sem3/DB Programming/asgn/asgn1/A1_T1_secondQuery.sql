#(b)	Display details about patients who have received a vaccination given in 2011 or later and are under the age of 30 such that their vaccinations are still valid.

#The details should include id, name, date of registration of patients, the date the patient visited the doctor, the name of the doctor who saw the patient, the name and action number of the vaccination, the number of years the vaccination is valid for, and the time left that the vaccination is still valid. The action number will replace with more human-readable form value such as “1” represents Dose 1, “2” represents Dose 2 and other numbers represent Booster.  


SELECT patient_id, UPPER(patient_name) AS patient_name, TIMESTAMPDIFF(YEAR, STR_TO_DATE(patient_birth,"%d-%b-%Y"), CURRENT_DATE) AS age, STR_TO_DATE(patient_reg_date, "%d-%b-%Y") AS patient_registration_date, STR_TO_DATE(visits_date, "%d-%b-%Y") AS patient_visit_and_vac_date, doctor_name, vac_valid_type AS vac_type, 
CASE 
	WHEN vac_count NOT IN(1,2) THEN "Booster"
	WHEN vac_count = 1 THEN "Dose 1"
    ELSE "Dose 2"
END AS vac_action,
valid_volume AS vac_valid_years, TIMESTAMPDIFF(YEAR, CURRENT_DATE, DATE_ADD(STR_TO_DATE(vac_date, "%d-%b-%Y"), INTERVAL valid_volume YEAR)) AS remaining_valid_years 
FROM patient INNER JOIN vaccinations ON (patient_id = vac_patient_id) 
			 INNER JOIN visits ON (patient_id = visits_patient_id AND vac_date = visits_date)
			 INNER JOIN doctor ON (visits_doctor_id = doctor_id)
			 INNER JOIN valid_for ON (vac_valid_type = valid_type)
HAVING YEAR(patient_visit_and_vac_date) >= 2011 AND
       age < 30 AND
       remaining_valid_years > 0
ORDER BY patient_id, patient_visit_and_vac_date, vac_action, remaining_valid_years;