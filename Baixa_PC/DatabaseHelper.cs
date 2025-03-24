using System;
using System.Data;
using MySql.Data.MySqlClient;

public static class DatabaseHelper
{
    private static readonly string connectionString = "Server=localhost;Database=computadores_db;User Id=root;Password=mysql;";

    public static MySqlConnection GetConnection() => new MySqlConnection(connectionString);

    private static void ExecuteNonQuery(string query, Action<MySqlCommand> parameterSetter = null)
    {
        try
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand(query, connection))
            {
                parameterSetter?.Invoke(command);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"⚠️ Erro no MySQL: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Erro geral: {ex.Message}");
        }
    }

    public static void InitializeDatabase()
    {
        string query = @"CREATE TABLE IF NOT EXISTS processoss (
                id INT AUTO_INCREMENT PRIMARY KEY,
                nif_aluno VARCHAR(20) NOT NULL UNIQUE,
                nome_aluno VARCHAR(100) NOT NULL,
                ano_escolaridade VARCHAR(20) NULL,
                turma VARCHAR(20) NULL,
                nif_ee VARCHAR(20) NOT NULL,
                nome_ee VARCHAR(100) NOT NULL,
                tipo_computador VARCHAR(50) NOT NULL,
                numero_serie VARCHAR(50) NOT NULL,
                portatil_imobilizado VARCHAR(50) NOT NULL,
                hostpot_num_serie VARCHAR(50) NULL,
                sim_num_serie VARCHAR(50) NULL,
                segunda_via_sim BOOLEAN DEFAULT FALSE,
                pc_entregue BOOLEAN DEFAULT FALSE,
                mochila_entregue BOOLEAN DEFAULT FALSE,
                fones_entregue BOOLEAN DEFAULT FALSE,
                abertura_fecho_tampa BOOLEAN DEFAULT FALSE,
                apresenta_ecra_login BOOLEAN DEFAULT FALSE,
                formatado BOOLEAN DEFAULT FALSE,
                observacoes TEXT NULL,
                estado VARCHAR(50) NOT NULL,
                data_entrega DATETIME DEFAULT CURRENT_TIMESTAMP
            );";

        ExecuteNonQuery(query);
        Console.WriteLine("✅ Banco de dados inicializado com sucesso.");
    }

    public static DataTable PesquisarProcesso(string nif)
    {
        string query = "SELECT * FROM processoss WHERE nif_aluno = @nif OR nif_ee = @nif;";
        return ExecuteQuery(query, command => command.Parameters.AddWithValue("@nif", nif));
    }

    private static DataTable ExecuteQuery(string query, Action<MySqlCommand> parameterSetter = null)
    {
        DataTable resultTable = new DataTable();
        try
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand(query, connection))
            {
                parameterSetter?.Invoke(command);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    resultTable.Load(reader);
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"⚠️ Erro no MySQL: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Erro geral: {ex.Message}");
        }
        return resultTable;
    }

    public static void InserirProcesso(
     string nifAluno, string nomeAluno, string anoEscolaridade, string turma, string nifEE, string nomeEE,
     string tipoComputador, string numeroSerie, string portatilImobilizado, string hostpotNumSerie, string simNumSerie,
     bool segundaViaSim, bool pcEntregue, bool mochilaEntregue, bool fonesEntregue, bool aberturaFechoTampa,
     bool apresentaEcraLogin, bool formatado, string observacoes, string estado, DateTime? dataEntrega = null)

    {
        string query = @"INSERT INTO processoss (
            nif_aluno, nome_aluno, ano_escolaridade, turma, nif_ee, nome_ee, tipo_computador, numero_serie, 
            portatil_imobilizado, hostpot_num_serie, sim_num_serie, segunda_via_sim, pc_entregue, mochila_entregue, 
            fones_entregue, abertura_fecho_tampa, apresenta_ecra_login, formatado, observacoes, estado, data_entrega) 
        VALUES (
            @nifAluno, @nomeAluno, @anoEscolaridade, @turma, @nifEE, @nomeEE, @tipoComputador, @numeroSerie, 
            @portatilImobilizado, @hostpotNumSerie, @simNumSerie, @segundaViaSim, @pcEntregue, @mochilaEntregue, 
            @fonesEntregue, @aberturaFechoTampa, @apresentaEcraLogin, @formatado, @observacoes, @estado, @dataEntrega)
        ON DUPLICATE KEY UPDATE
            nome_aluno = VALUES(nome_aluno),
            ano_escolaridade = VALUES(ano_escolaridade),
            turma = VALUES(turma),
            nif_ee = VALUES(nif_ee),
            nome_ee = VALUES(nome_ee),
            tipo_computador = VALUES(tipo_computador),
            numero_serie = VALUES(numero_serie),
            portatil_imobilizado = VALUES(portatil_imobilizado),
            hostpot_num_serie = VALUES(hostpot_num_serie),
            sim_num_serie = VALUES(sim_num_serie),
            segunda_via_sim = VALUES(segunda_via_sim),
            pc_entregue = VALUES(pc_entregue),
            mochila_entregue = VALUES(mochila_entregue),
            fones_entregue = VALUES(fones_entregue),
            abertura_fecho_tampa = VALUES(abertura_fecho_tampa),
            apresenta_ecra_login = VALUES(apresenta_ecra_login),
            formatado = VALUES(formatado),
            observacoes = VALUES(observacoes),
            estado = VALUES(estado),
            data_entrega = COALESCE(@dataEntrega, data_entrega);";

        DatabaseHelper.ExecuteNonQuery(query, command =>
        {
            command.Parameters.AddWithValue("@nifAluno", nifAluno);
            command.Parameters.AddWithValue("@nomeAluno", nomeAluno);
            command.Parameters.AddWithValue("@anoEscolaridade", (object)anoEscolaridade ?? DBNull.Value);
            command.Parameters.AddWithValue("@turma", (object)turma ?? DBNull.Value);
            command.Parameters.AddWithValue("@nifEE", nifEE);
            command.Parameters.AddWithValue("@nomeEE", nomeEE);
            command.Parameters.AddWithValue("@tipoComputador", tipoComputador);
            command.Parameters.AddWithValue("@numeroSerie", numeroSerie);
            command.Parameters.AddWithValue("@portatilImobilizado", portatilImobilizado ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@hostpotNumSerie", (object)hostpotNumSerie ?? DBNull.Value);
            command.Parameters.AddWithValue("@simNumSerie", (object)simNumSerie ?? DBNull.Value);
            command.Parameters.AddWithValue("@segundaViaSim", segundaViaSim);
            command.Parameters.AddWithValue("@pcEntregue", pcEntregue);
            command.Parameters.AddWithValue("@mochilaEntregue", mochilaEntregue);
            command.Parameters.AddWithValue("@fonesEntregue", fonesEntregue);
            command.Parameters.AddWithValue("@aberturaFechoTampa", aberturaFechoTampa);
            command.Parameters.AddWithValue("@apresentaEcraLogin", apresentaEcraLogin);
            command.Parameters.AddWithValue("@formatado", formatado);
            command.Parameters.AddWithValue("@observacoes", (object)observacoes ?? DBNull.Value);
            command.Parameters.AddWithValue("@estado", string.IsNullOrEmpty(estado) ? (object)DBNull.Value : (object)estado);
            command.Parameters.AddWithValue("@dataEntrega", (object)dataEntrega ?? DBNull.Value);
        });
    }



}
