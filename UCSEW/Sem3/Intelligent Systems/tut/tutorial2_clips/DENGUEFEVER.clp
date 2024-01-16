;;;======================================================
;;;     Tropical Disease medical system
;;;
;;;     This medical system diagnoses mosquito borne
;;;     tropical disease.
;;;
;;;     CLIPS Version 6.0 Example
;;;
;;;     To execute, merely load, reset and run.
;;;======================================================

;;****************
;;* DEFFUNCTIONS *
;;****************

(deffunction ask-question (?question $?allowed-values)
   (printout t ?question)
   (bind ?answer (read))
   (if (lexemep ?answer) 
       then (bind ?answer (lowcase ?answer)))
   (while (not (member ?answer ?allowed-values)) do
      (printout t ?question)
      (bind ?answer (read))
      (if (lexemep ?answer) 
          then (bind ?answer (lowcase ?answer))))
   ?answer)

(deffunction yes-or-no-p (?question)
   (bind ?response (ask-question ?question yes no y n))
   (if (or (eq ?response yes) (eq ?response y))
       then TRUE 
       else FALSE))

;;;**********************
;;;* DISEASE STATE RULES *
;;;**********************

(defrule malaria-disease ""
   (declare (salience 30))
   (malaria-disease type)
   =>
   (assert (symptom "Detected."))
   (assert (dengue-state))
   (assert (vivax-type))
   (assert (plasmodium-falciparum))
   (assert (dengue-hemo1))
   (assert (plasmodium-state))
   (assert (falciparum-stage))
   (assert (plasmodium-ovale)))



;;;***************
;;;* QUERY RULES *
;;;***************


(defrule determine-malaria-disease ""
   (not (malaria-disease ?))
   (not (symptom ?))
   =>
   (if (yes-or-no-p "Do you have sudden high fever with flu-like illness, and headache (yes/no)? ") 
       then 
       (if (yes-or-no-p "Do you have symptom of nausea (yes/no)? ")
           then (assert (dengue-state))      
           else (assert (dengue-shock)))
       else (assert (symptom "You are not infected with Dengue Fever disease."))))


(defrule determine-dengue-stage ""
  (dengue-state)
  (not (dengue-state ?))
  (not (symptom ?))
  =>
  (if (yes-or-no-p "Do you vomit coffee colored matter (yes/no)? ")
      then
      (if (yes-or-no-p "Do you have any symptom of vomitting blood (yes/no)? ")
      then (assert (dengue-hemo))
      else (assert (dengue-state1)))
   else (assert (dengue-shock))))

(defrule detemine-dengue ""
  (dengue-state1)
  (not (symptom ?))
  =>
  (if (yes-or-no-p "Do you have have pain behind the eyes which worsens the eye movement(Retro-orbital) (yes/no)? ")
      then (assert (symptom "You are infected with Dengue Fever."))
       else (assert (dengue-hemo))))



(defrule determine-dengue-fever ""
  (dengue-hemo)
  (not (dengue-fever ?))
  (not (symptom ?))
  =>
  (if (yes-or-no-p "Do you have any symptom of Bleeding from Gums(mouth) or nose (yes/no)?")
      then
      (if (yes-or-no-p "Do you have any symptom of skin rashes or red tiny spots on skin(Petechiae) (yes/no)?")
      then (assert (dengue-hemo1))
      else (assert (dengue-hemo2)))
   else (assert (dengue-shock1))))


(defrule determine-dengue-hemorrhagic ""
  (dengue-hemo1)
  (not (dengue-hemorrhagic ?))
  (not (symptom ?))
  =>
  (if (yes-or-no-p "Are you going through severe continous pain in the abdomen (yes/no)? ")
   then (assert (dengue-hemo2))
   else (assert (dengue-shock1))))

(defrule determine-den-hemo-stage ""
  (dengue-hemo2)
  (not (den-hemo-stage ?))
  (not (symptom ?))
  =>
  (if (yes-or-no-p "Having pale/cold skin for the past few days (yes/no)?")
      then (assert (symptom "You are infected with Dengue Hemorrhagic Fever."))
      else (assert (dengue-shock1))))
  

(defrule determine-dengue-shock ""
  (dengue-shock1)
  (not (symptom ?))
  =>
  (if (yes-or-no-p "Do you vomit and feel so weak (yes/no)?")
      then (assert (dengue-shock))
      else (assert (symptom "You are not Infected with dengue fever."))))
      
(defrule determine-den-period ""
  (dengue-shock)
  (not (symptom ?))
  =>
  (if (yes-or-no-p "Do you have pain especially in bone/lumbar spine (yes/no)? ")
     then
     (if (yes-or-no-p "Are going through Blood stolid (yes/no)?")
       then (assert (symptom "You are infected with Dengue Shock Syndrome."))
       else (assert (dengue-shock2)))
   else (assert (symptom "You are not infected with Dengue fever."))))   


(defrule determine-dengue-sho ""
  (dengue-shock2)
  (not (symptom ?))
  =>
  (if (yes-or-no-p "Have you gone through shock symptom (yes/no)? ")
  then (assert (symptom "You are infected with Dengue Shock Syndrome disease."))
    else (assert (symptom "You are not infected with Dengue fever."))))


;;;****************************
;;;* STARTUP AND SYMPTOMS RULES *
;;;****************************

(defrule system-banner ""
  (declare (salience 10))
  =>
  (printout t crlf crlf)
  (printout t "Tropical Disease Medical System")
  (printout t crlf crlf))

(defrule print-symptom ""
  (declare (salience 10))
  (symptom ?item)
  =>
  (printout t crlf crlf)
  (printout t "Disease Infected:")
  (printout t crlf crlf)
  (format t " %s%n%n%n" ?item))
