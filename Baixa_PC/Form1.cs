using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using ClosedXML.Excel;
using MySql.Data.MySqlClient;

namespace Baixa_PC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();  // Garante que a base de dados foi criada
        }


        // 🚀 MÉTODO PARA GERAR PDF COM TODOS OS CAMPOS
        private void btnGerarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files|*.pdf";
                saveFileDialog.Title = "Salvar Ficha do Aluno";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Document doc = new Document(PageSize.A4);
                    PdfWriter.GetInstance(doc, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    doc.Open();

                    // 🔹 1️⃣ Carregar as imagens
                    string caminhoImagem1 = @"C:\Users\Ambrosio\source\repos\Baixa_PC\Baixa_PC\RPE.png";
                    string caminhoImagem2 = @"C:\Users\Ambrosio\source\repos\Baixa_PC\Baixa_PC\ESPN.png";

                    iTextSharp.text.Image imagem1 = iTextSharp.text.Image.GetInstance(caminhoImagem1);
                    iTextSharp.text.Image imagem2 = iTextSharp.text.Image.GetInstance(caminhoImagem2);

                    // 🔹 2️⃣ Ajustar tamanho das imagens
                    imagem1.ScaleAbsolute(130f, 50f); // Largura x Altura
                    imagem2.ScaleAbsolute(230f, 50f);

                    // 🔹 3️⃣ Criar tabela para organizar as imagens
                    PdfPTable tabelaCabecalho = new PdfPTable(2);
                    tabelaCabecalho.WidthPercentage = 100;
                    tabelaCabecalho.DefaultCell.Border = PdfPCell.NO_BORDER;

                    PdfPCell cell1 = new PdfPCell(imagem1) { Border = PdfPCell.NO_BORDER, HorizontalAlignment = Element.ALIGN_LEFT };
                    PdfPCell cell2 = new PdfPCell(imagem2) { Border = PdfPCell.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT };

                    tabelaCabecalho.AddCell(cell1);
                    tabelaCabecalho.AddCell(cell2);

                    // 🔹 4️⃣ Adicionar a tabela ao documento
                    doc.Add(tabelaCabecalho);

                    // 🔹 5️⃣ Adicionar título abaixo do cabeçalho
                    Font tituloFonte = FontFactory.GetFont(FontFactory.HELVETICA, "16", Font.Bold);
                    Paragraph titulo = new Paragraph("📌 Programa Escola Digital - Entrega de Equipamento\n\n", tituloFonte);
                    titulo.Alignment = Element.ALIGN_CENTER;
                    doc.Add(titulo);

                    // 🔹 6️⃣ Continuar com os dados do aluno...
                    doc.Add(new Paragraph("\n Dados Aluno:"));
                    doc.Add(new Paragraph($"🔹 NIF Aluno: {txtNIFAluno.Text}"));
                    doc.Add(new Paragraph($"🔹 Nome Aluno: {txtNomeAluno.Text}"));
                    doc.Add(new Paragraph($"🔹 Ano Escolar: {txtAnoEscolaridade.Text}"));
                    doc.Add(new Paragraph($"🔹 Turma: {txtTurma.Text}"));
                    doc.Add(new Paragraph($"🔹 NIF Encarregado Educação: {txtNIFEE.Text}"));
                    doc.Add(new Paragraph($"🔹 Nome Encarregado Educação: {txtNomeEE.Text}"));

                    doc.Add(new Paragraph("\nDados Computador:"));
                    doc.Add(new Paragraph($"🔹 Tipo Portátil: {txtPortTipo.Text}"));
                    doc.Add(new Paragraph($"🔹 Nº Série Portátil: {txtPortNumSer.Text}"));
                    doc.Add(new Paragraph($"🔹 Portátil Imobilizado: {txtPortImobilizado.Text}"));
                    doc.Add(new Paragraph($"🔹 Nº Série Hostpot: {txtHostPotNumSer.Text}"));
                    doc.Add(new Paragraph($"🔹 Nº Série SIM: {txtSimNumSer.Text}"));
                    doc.Add(new Paragraph($"🔹 Estado do Computador: {cmbEstado.Text}"));

                    doc.Add(new Paragraph($"✅ 2ª Via SIM: {(chkSegundaViaSim.Checked ? "Sim" : "Não")}"));
                    doc.Add(new Paragraph($"✅ PC Entregue: {(chkPcEntregue.Checked ? "Sim" : "Não")}"));
                    doc.Add(new Paragraph($"✅ Mochila Entregue: {(chkMochilaEntregue.Checked ? "Sim" : "Não")}"));
                    doc.Add(new Paragraph($"✅ Fones Entregue: {(chkFonesEntregue.Checked ? "Sim" : "Não")}"));
                    doc.Add(new Paragraph($"✅ Possível Abertura e Fecho da Tampa do PC: {(chkAberturaFecho.Checked ? "Sim" : "Não")}"));
                    doc.Add(new Paragraph($"✅ Apresenta Ecrã de Login: {(chkEcraLogin.Checked ? "Sim" : "Não")}"));
                    doc.Add(new Paragraph($"✅ Formatado: {(chkFormatado.Checked ? "Sim" : "Não")}"));

                    doc.Add(new Paragraph("\n📝 Observações:"));
                    doc.Add(new Paragraph($"{txtObservacoes.Text}"));

                    doc.Add(new Paragraph("\n📝 Assinatura do Encarregado de Educação: __________________________"));
                    doc.Add(new Paragraph($"\n📅 Data: {dtpDataEntrega.Text}"));

                    // 🔹 Finalizar documento
                    doc.Close();

                    MessageBox.Show("📄 PDF gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar PDF: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento ao clicar no botão "Inserir"
        private void btnInserir_Click_1(object sender, EventArgs e)
        {
            try
            {
                string nifPesquisa = txtPesquisaNIF.Text.Trim();
                if (string.IsNullOrEmpty(nifPesquisa))
                {
                    MessageBox.Show("Digite um NIF para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                // Primeiro, tenta buscar na base de dados
                DataTable resultado = DatabaseHelper.PesquisarProcesso(nifPesquisa);
             



                if (resultado != null && resultado.Rows.Count > 0)
                {
                    // Se encontrou na base de dados, preenche os campos
                    PreencherCampos(resultado.Rows[0]);
                    MessageBox.Show("✅ Dados carregados da base de dados!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Se não encontrou na base de dados, tenta buscar no Excel
                    DataRow dadosExcel = ExcelHelper.PesquisarPorNIF(nifPesquisa);

                    if (dadosExcel != null)
                    {
                        // Inserir os dados na base de dados corretamente
                        DatabaseHelper.InserirProcesso(
                            dadosExcel["_NIFALUNO_"].ToString(),
                            dadosExcel["_NOMEALUNO_"].ToString(),
                            dadosExcel["_ANOESCOLARIDADE_"].ToString(),
                            dadosExcel["TURMA"].ToString(),
                            dadosExcel["_NIFEE_"].ToString(),
                            dadosExcel["_NOMEEE_"].ToString(),
                            dadosExcel["_PORTTIPO_"].ToString(),
                            dadosExcel["_PORTNUMSER_"].ToString(),
                            dadosExcel["_PORTIMOBILIZADO_"].ToString(),
                            dadosExcel["_HOSTPOTNUMSER_"].ToString(),
                            dadosExcel["_SIMNUMSER_"].ToString(),
                            StringParaBoolean(dadosExcel["2ª Via SIM"].ToString()),
                            StringParaBoolean(dadosExcel["PC Entregue"].ToString()),
                            StringParaBoolean(dadosExcel["Mochila Entregue"].ToString()),
                            StringParaBoolean(dadosExcel["Fones Entregue"].ToString()),
                            StringParaBoolean(dadosExcel["Possivel Abertura e fecho da tampa do PC"].ToString()),
                            StringParaBoolean(dadosExcel["Apresenta Ecrã de Login"].ToString()),
                            StringParaBoolean(dadosExcel["Formatado"].ToString()),
                            dadosExcel["observacoes"].ToString(),
                            "Em análise",  // Estado padrão se não estiver no Excel
                            DateTime.Now
                        );

                        // Agora busca os dados novamente para garantir que foram inseridos corretamente
                        resultado = DatabaseHelper.PesquisarProcesso(nifPesquisa);

                        if (resultado != null && resultado.Rows.Count > 0)
                        {
                            PreencherCampos(resultado.Rows[0]);
                            MessageBox.Show("✅ Dados importados do Excel e armazenados na base de dados!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("⚠️ Dados inseridos na base, mas não foram recuperados corretamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("❌ Nenhum registro encontrado no Excel!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao pesquisar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool StringParaBoolean(string valor)
        {
            if (string.IsNullOrEmpty(valor)) return false; // Caso esteja vazio, assume falso
            valor = valor.Trim().ToLower();

            return valor == "1" || valor == "true" || valor == "sim"; // Aceita "1", "true" e "sim" como verdadeiro
        }

        private void PreencherCampos(DataRow row)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<DataRow>(PreencherCampos), row);
                return;
            }

            txtNIFAluno.Text = row["nif_aluno"].ToString();
            txtNomeAluno.Text = row["nome_aluno"].ToString();
            txtAnoEscolaridade.Text = row["ano_escolaridade"].ToString();
            txtTurma.Text = row["turma"].ToString();
            txtNIFEE.Text = row["nif_ee"].ToString();
            txtNomeEE.Text = row["nome_ee"].ToString();
            txtPortTipo.Text = row["tipo_computador"].ToString();
            txtPortNumSer.Text = row["numero_serie"].ToString();
            txtPortImobilizado.Text = row["portatil_imobilizado"].ToString();
            txtHostPotNumSer.Text = row["hostpot_num_serie"].ToString();
            txtSimNumSer.Text = row["sim_num_serie"].ToString();


            // CheckBoxes
            chkSegundaViaSim.Checked = Convert.ToBoolean(row["segunda_via_sim"]);
            chkPcEntregue.Checked = Convert.ToBoolean(row["pc_entregue"]);
            chkMochilaEntregue.Checked = Convert.ToBoolean(row["mochila_entregue"]);
            chkFonesEntregue.Checked = Convert.ToBoolean(row["fones_entregue"]);
            chkAberturaFecho.Checked = Convert.ToBoolean(row["abertura_fecho_tampa"]);
            chkEcraLogin.Checked = Convert.ToBoolean(row["apresenta_ecra_login"]);
            chkFormatado.Checked = Convert.ToBoolean(row["formatado"]);

            cmbEstado.SelectedItem = row["estado"].ToString();
            txtObservacoes.Text = row["observacoes"].ToString();
            dtpDataEntrega.Value = Convert.ToDateTime(row["data_entrega"]);
        }

        private void AtualizarExcel(string nif, string nomeAluno, string turma, string observacoes)
        {
            string filePath = @"C:\Users\Ambrosio\source\repos\Baixa_PC\Baixa_PC\Livro1.xlsx";

            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("❌ Arquivo Excel não encontrado.");
                    return;
                }

                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1); // Assume que os dados estão na primeira planilha
                    var lastRow = worksheet.LastRowUsed().RowNumber();
                    bool encontrado = false;

                    // Percorre as linhas para encontrar o NIF correspondente
                    for (int row = 2; row <= lastRow; row++) // Começa na linha 2 para ignorar cabeçalho
                    {
                        if (worksheet.Cell(row, 1).GetString() == nif) // Supondo que a coluna 1 seja o NIF
                        {
                            worksheet.Cell(row, 9).Value = txtPortImobilizado.Text;  // Atualizando portátil imobilizado
                            worksheet.Cell(row, 20).Value = cmbEstado.Text;

                            workbook.Save();
                            MessageBox.Show("✅ Atualização do Excel concluída.");
                            encontrado = true;
                            break;
                        }
                    }

                    // Se o NIF não for encontrado, insere um novo registro no final
                    if (!encontrado)
                    {
                        lastRow++;
                        worksheet.Cell(lastRow, 1).Value = nif;
                        worksheet.Cell(lastRow, 2).Value = nomeAluno;
                        worksheet.Cell(lastRow, 4).Value = turma;
                        worksheet.Cell(lastRow, 9).Value = txtPortImobilizado.Text;
                        worksheet.Cell(lastRow, 20).Value = cmbEstado.Text;

                        workbook.Save();
                        MessageBox.Show("✅ Novo NIF adicionado ao Excel.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erro ao atualizar o Excel: {ex.Message}");
            }
        }


        public static void AtualizarProcesso(string nifAluno, string nomeAluno, string anoEscolaridade, string turma, string nifEE, string nomeEE,
    string tipoComputador, string numeroSerie, string portatilImobilizado, string hostpotNumSerie, string simNumSerie,
    bool segundaViaSim, bool pcEntregue, bool mochilaEntregue, bool fonesEntregue, bool aberturaFechoTampa,
    bool apresentaEcraLogin, bool formatado, string observacoes, string estado)
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = @"
            UPDATE processoss SET 
                nome_aluno = @nomeAluno,
                ano_escolaridade = @anoEscolaridade,
                turma = @turma,
                nif_ee = @nifEE,
                nome_ee = @nomeEE,
                tipo_computador = @tipoComputador,
                numero_serie = @numeroSerie,
                portatil_imobilizado = @portatilImobilizado,  -- Certifique-se de que este campo existe no SQL
                hostpot_num_serie = @hostpotNumSerie,
                sim_num_serie = @simNumSerie,
                segunda_via_sim = @segundaViaSim,
                pc_entregue = @pcEntregue,
                mochila_entregue = @mochilaEntregue,
                fones_entregue = @fonesEntregue,
                abertura_fecho_tampa = @aberturaFechoTampa,
                apresenta_ecra_login = @apresentaEcraLogin,
                formatado = @formatado,
                observacoes = @observacoes,
                estado = @estado
            WHERE nif_aluno = @nifAluno;";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nifAluno", nifAluno);
                        command.Parameters.AddWithValue("@nomeAluno", nomeAluno);
                        command.Parameters.AddWithValue("@anoEscolaridade", anoEscolaridade ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@turma", turma ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@nifEE", nifEE);
                        command.Parameters.AddWithValue("@nomeEE", nomeEE);
                        command.Parameters.AddWithValue("@tipoComputador", tipoComputador);
                        command.Parameters.AddWithValue("@numeroSerie", numeroSerie);
                        command.Parameters.AddWithValue("@portatilImobilizado", portatilImobilizado ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@hostpotNumSerie", hostpotNumSerie ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@simNumSerie", simNumSerie ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@segundaViaSim", segundaViaSim);
                        command.Parameters.AddWithValue("@pcEntregue", pcEntregue);
                        command.Parameters.AddWithValue("@mochilaEntregue", mochilaEntregue);
                        command.Parameters.AddWithValue("@fonesEntregue", fonesEntregue);
                        command.Parameters.AddWithValue("@aberturaFechoTampa", aberturaFechoTampa);
                        command.Parameters.AddWithValue("@apresentaEcraLogin", apresentaEcraLogin);
                        command.Parameters.AddWithValue("@formatado", formatado);
                        command.Parameters.AddWithValue("@observacoes", observacoes ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@estado", estado ?? (object)DBNull.Value);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("✅ Processo atualizado com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("⚠️ Nenhuma alteração realizada.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Erro ao atualizar o processo: {ex.Message}");
            }
        }

        private void btnAtualizarr_Click(object sender, EventArgs e)
        {
            lblStatus.Visible = true;
            // Verifica se o NIF já existe no banco de dados
            bool nifExisteNoBanco = DatabaseHelper.PesquisarProcesso(txtNIFAluno.Text)?.Rows.Count > 0;

            if (!nifExisteNoBanco)
            {
                // Se o NIF não existir, insere no banco de dados
                DatabaseHelper.InserirProcesso(
                    txtNIFAluno.Text, txtNomeAluno.Text, txtAnoEscolaridade.Text, txtTurma.Text,
                    txtNIFEE.Text, txtNomeEE.Text, txtPortTipo.Text, txtPortNumSer.Text, txtPortImobilizado.Text,
                    txtHostPotNumSer.Text, txtSimNumSer.Text, chkSegundaViaSim.Checked, chkPcEntregue.Checked,
                    chkMochilaEntregue.Checked, chkFonesEntregue.Checked, chkAberturaFecho.Checked,
                    chkEcraLogin.Checked, chkFormatado.Checked, txtObservacoes.Text, cmbEstado.Text, DateTime.Now
                );

                MessageBox.Show("✅ Novo NIF inserido no banco de dados!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Se o NIF existir, apenas atualiza os dados no banco
                AtualizarProcesso(
                    txtNIFAluno.Text, txtNomeAluno.Text, txtAnoEscolaridade.Text, txtTurma.Text,
                    txtNIFEE.Text, txtNomeEE.Text, txtPortTipo.Text, txtPortNumSer.Text, txtPortImobilizado.Text,
                    txtHostPotNumSer.Text, txtSimNumSer.Text, chkSegundaViaSim.Checked, chkPcEntregue.Checked,
                    chkMochilaEntregue.Checked, chkFonesEntregue.Checked, chkAberturaFecho.Checked,
                    chkEcraLogin.Checked, chkFormatado.Checked, txtObservacoes.Text, cmbEstado.Text
                );

                MessageBox.Show("✅ Dados atualizados no banco de dados!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Agora atualiza também o Excel
            ExcelHelper.AtualizarExcel(txtNIFAluno.Text, txtNomeAluno.Text, txtTurma.Text, txtObservacoes.Text);

            lblStatus.Visible = false;

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }


        // Método para limpar os campos do formulário
        private void LimparCampos()
        {
            txtPesquisaNIF.Clear();
            txtNIFAluno.Clear();
            txtPortNumSer.Clear();
            txtPortTipo.Clear();
            txtNomeAluno.Clear();
            txtAnoEscolaridade.Clear();
            txtTurma.Clear();
            txtNIFEE.Clear();
            txtNomeEE.Clear();
            txtPortImobilizado.Clear();
            txtHostPotNumSer.Clear();
            txtSimNumSer.Clear();
            txtObservacoes.Clear();

            chkSegundaViaSim.Checked = false;
            chkMochilaEntregue.Checked = false;
            chkFonesEntregue.Checked = false;
            chkPcEntregue.Checked = false;
            chkAberturaFecho.Checked = false;
            chkEcraLogin.Checked = false;
            chkFormatado.Checked = false;

            cmbEstado.SelectedIndex = 0;
            dtpDataEntrega.Value = DateTime.Now;
        }
    }
}