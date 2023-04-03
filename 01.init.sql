CREATE DATABASE persons;
CREATE TABLE IF NOT EXISTS public.tbl_persons
(
    id bigserial NOT NULL,
    first_name character varying(100) NOT NULL,
    last_name character varying(100) NOT NULL,
    age smallint NOT NULL,
    gender character(1) NOT NULL,
    address character varying(255),
    CONSTRAINT tbl_persons_pkey PRIMARY KEY (id)
);