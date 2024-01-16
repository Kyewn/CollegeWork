##(a)	Display id, name, date of birth, today’s date, and age in years for those patients who are under the age of 30 and who have received a given vaccination in 2011 or later. The name should be displayed in upper case. All dates should be displayed in full (e.g., 31-Jan-2011). The age in years should be a whole number, i.e., any fractions should be removed. 

SELECT DISTINCT patient_id AS id, UPPER(patient_name) AS name, DATE_FORMAT(STR_TO_DATE(patient_birth,"%d-%b-%Y"), "%d-%b-%Y") AS date_of_birth, DATE_FORMAT(CURRENT_DATE, "%d-%b-%Y") AS today, TIMESTAMPDIFF(YEAR, STR_TO_DATE(patient_birth,"%d-%b-%Y"), CURRENT_DATE) AS age
FROM patient INNER JOIN vaccinations ON (patient_id = vac_patient_id)
GROUP BY vac_date
HAVING age < 30 AND YEAR(STR_TO_DATE(vac_date,"%d-%b-%Y")) >= 2011
ORDER BY id;