\connect tododb
CREATE TABLE public.patients
(
    id character varying(50) NOT NULL,    
    name character varying(200) NOT NULL,    
    address character varying(500),    
    city character varying(100),    
    age numeric NOT NULL,    
    gender character varying(10),    
    CONSTRAINT patient_pkey PRIMARY KEY (id)
);
ALTER TABLE public.patients OWNER TO todouser;

CREATE TABLE public.items
(
    id character varying(50) NOT NULL,    
    name character varying(200) NOT NULL,
    secret character varying(100),   
    CONSTRAINT items_pkey PRIMARY KEY (id)
);
ALTER TABLE public.items OWNER TO todouser;