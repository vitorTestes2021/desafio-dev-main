using System.Collections.Generic;
using MySqlConnector;
using Dapper;
using api.Model;
using System.Threading.Tasks;

namespace api.Repository
{
    public class CNABRepository : ICNABRepository
    {
        private readonly string _connectionString;

        public CNABRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<CNABModel> GetAll()
        {
            using(var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<CNABModel>(
                    @"
                        SELECT
                            cnab.id AS 'Id',
                            id_transaction_type AS 'IdTransactionType',
                            (vl_total * cnabType.vl_signal) AS 'Value',
                            nm_cpf AS 'Cpf',
                            nm_card AS 'Card',
                            nm_store AS 'NameStore',
                            nm_store_owner AS 'NameStoreOwner',
                            dt_occurrence AS 'DateOccurrence',
                            dt_occurrence_hour AS 'DateOccurrenceHour'
                        FROM tb_cnab AS cnab
                        INNER JOIN tb_transaction_type AS cnabType
                            ON cnab.id_transaction_type = cnabType.id
                    "
                );
            }
        }

         public async Task SaveAll(List<CNABModel> cnabList)
         {
            using(var connection = new MySqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(
                    @"
                        INSERT INTO tb_cnab (
                            id_transaction_type,
                            vl_total,
                            nm_cpf,
                            nm_card,
                            nm_store,
                            nm_store_owner,
                            dt_occurrence,
                            dt_occurrence_hour
                        )
                        VALUES (
                            @IdTransactionType,
                            @Value,
                            @Cpf,
                            @Card,
                            @NameStore,
                            @NameStoreOwner,
                            @DateOccurrence,
                            @DateOccurrenceHour
                        )
                    ",
                    cnabList
                );
            }
        }
    }
}