CREATE TABLE IF NOT EXISTS tbl_school_schedule 
(
    id BIGSERIAL PRIMARY KEY,
	lesson VARCHAR(255) NOT NULL,
    day VARCHAR(2) NOT NULL,
    start_of_lesson TIME NOT NULL,
    end_of_lesson TIME NOT NULL
);