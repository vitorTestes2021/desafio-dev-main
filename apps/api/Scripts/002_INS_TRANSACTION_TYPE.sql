DELETE FROM db_dev.tb_cnab;
TRUNCATE TABLE db_dev.tb_cnab;

DELETE FROM db_dev.tb_transaction_type;
SET FOREIGN_KEY_CHECKS = 0;
TRUNCATE TABLE db_dev.tb_transaction_type;
SET FOREIGN_KEY_CHECKS = 1;

INSERT INTO tb_transaction_type (nm_description, nm_type, vl_signal)
VALUES ('DÉBITO', 'ENTRADA', 1);

INSERT INTO tb_transaction_type (nm_description, nm_type, vl_signal)
VALUES ('BOLETO', 'SAÍDA', -1);

INSERT INTO tb_transaction_type (nm_description, nm_type, vl_signal)
VALUES ('FINANCIAMENTO', 'SAÍDA', -1);

INSERT INTO tb_transaction_type (nm_description, nm_type, vl_signal)
VALUES ('CRÉDITO', 'ENTRADA', 1);

INSERT INTO tb_transaction_type (nm_description, nm_type, vl_signal)
VALUES ('RECEBIMENTO EMPRÉSTIMO', 'ENTRADA', 1);

INSERT INTO tb_transaction_type (nm_description, nm_type, vl_signal)
VALUES ('VENDAS', 'ENTRADA', 1);

INSERT INTO tb_transaction_type (nm_description, nm_type, vl_signal)
VALUES ('RECEBIMENTO TED', 'ENTRADA', 1);

INSERT INTO tb_transaction_type (nm_description, nm_type, vl_signal)
VALUES ('RECEBIMENTO DOC', 'ENTRADA', 1);

INSERT INTO tb_transaction_type (nm_description, nm_type, vl_signal)
VALUES ('ALUGUEL', 'SAÍDA', -1);