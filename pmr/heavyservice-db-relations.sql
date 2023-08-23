BEGIN;


CREATE TABLE IF NOT EXISTS public.users
(
    id bigint generated always as identity,
    first_name text,
    last_name text,
    email text,
    email_confirmed bool,
    password_hash text,
    salt text,
    created_at timestamp without time zone,
    updated_at timestamp without time zone,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS public.roles
(
    id bigint generated always as identity ,
    name text,
    created_at timestamp without time zone,
    updated_at timestamp without time zone,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS public.user_roles
(
    id bigint generated always as identity,
    role_id bigint,
    user_id bigint,
    created_at timestamp without time zone,
    updated_at timestamp without time zone,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS public.instruments
(
    id bigint generated always as identity ,
    name text,
    description text,
    image_path text,
    price_per_day double precision,
    region text,
    district text,
    address text,
    status text,
    created_at timestamp without time zone,
    updated_at timestamp without time zone,
    user_id bigint,
    phone_number character varying(13),
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS public.transports
(
    id bigint generated always as identity,
    user_id bigint,
    name text,
    description text,
    image_path text,
    price_per_hours double precision,
    region text,
    district text,
    address text,
    status text,
    created_at timestamp without time zone,
    updated_at timestamp without time zone,
    phone_number character varying(13),
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS public.transport_comments
(
    id bigint generated always as identity,
    user_id bigint,
    transport_id bigint,
    comment text,
    created_at timestamp without time zone,
    updated_at timestamp without time zone,
    is_edited boolean,
    reply_id bigint,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS public.instrument_comments
(
    id bigint generated always as identity,
    user_id bigint,
    instrument_id bigint,
    comment text,
    created_at timestamp without time zone,
    updated_at timestamp without time zone,
    is_edited boolean,
    reply_id bigint,
    PRIMARY KEY (id)
);

ALTER TABLE IF EXISTS public.user_roles
    ADD FOREIGN KEY (role_id)
    REFERENCES public.roles (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS public.user_roles
    ADD FOREIGN KEY (user_id)
    REFERENCES public.users (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS public.instruments
    ADD FOREIGN KEY (user_id)
    REFERENCES public.users (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS public.transports
    ADD FOREIGN KEY (user_id)
    REFERENCES public.users (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS public.transport_comments
    ADD FOREIGN KEY (transport_id)
    REFERENCES public.transports (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS public.transport_comments
    ADD FOREIGN KEY (user_id)
    REFERENCES public.users (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS public.instrument_comments
    ADD FOREIGN KEY (user_id)
    REFERENCES public.users (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;


ALTER TABLE IF EXISTS public.instrument_comments
    ADD FOREIGN KEY (instrument_id)
    REFERENCES public.instruments (id) MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;

END;