CREATE DATABASE pension_grant_db;
USE pension_grant_db;

CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password_hash VARCHAR(64) NOT NULL
) ENGINE=InnoDB;

CREATE TABLE pay_points (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    district VARCHAR(50) NOT NULL
) ENGINE=InnoDB;

CREATE TABLE beneficiaries (
    id INT AUTO_INCREMENT PRIMARY KEY,
    full_name VARCHAR(100) NOT NULL,
    national_id VARCHAR(20) NOT NULL UNIQUE,
    phone VARCHAR(20) NULL,
    district VARCHAR(50) NOT NULL,
    village VARCHAR(50) NOT NULL,
    grant_type VARCHAR(30) NOT NULL,
    monthly_amount DECIMAL(10,2) NOT NULL,
    status VARCHAR(10) NOT NULL DEFAULT 'Active',
    pay_point_id INT NOT NULL,
    FOREIGN KEY (pay_point_id) REFERENCES pay_points(id)
) ENGINE=InnoDB;

CREATE TABLE payments (
    id INT AUTO_INCREMENT PRIMARY KEY,
    beneficiary_id INT NOT NULL,
    payment_month CHAR(7) NOT NULL,
    amount DECIMAL(10,2) NOT NULL,
    status VARCHAR(10) NOT NULL DEFAULT 'Pending',
    paid_date DATE NULL,
    delay_reason VARCHAR(200) NULL,
    FOREIGN KEY (beneficiary_id) REFERENCES beneficiaries(id),
    UNIQUE (beneficiary_id, payment_month)
) ENGINE=InnoDB;

INSERT INTO users (username, password_hash) VALUES ('officer', SHA2('officer123', 256));
