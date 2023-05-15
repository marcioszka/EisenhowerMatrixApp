DROP TABLE IF EXISTS item;

CREATE TABLE item (
    id int IDENTITY(1,1) PRIMARY KEY,
    title VARCHAR(50) NOT NULL,
    deadline DATE NOT NULL,
    is_done TINYINT DEFAULT 0,
    CONSTRAINT ck_testbool_ischk CHECK (is_done IN (1,0))
    );