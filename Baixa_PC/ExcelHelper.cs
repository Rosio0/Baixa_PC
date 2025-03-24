using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OfficeOpenXml; // Biblioteca EPPlus

public class ExcelHelper
{
    private static string caminhoExcel = @"C:\\Users\\Ambrosio\\source\\repos\\Baixa_PC\\Baixa_PC\\Livro1.xlsx";

    private static DataTable CarregarDadosExcel(out Dictionary<string, int> colunasMap)
    {
        colunasMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        DataTable dt = new DataTable();

        if (!File.Exists(caminhoExcel))
        {
            MessageBox.Show("❌ Arquivo do Excel não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        try
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(new FileInfo(caminhoExcel)))
            {
                ExcelWorksheet planilha = package.Workbook.Worksheets[0];
                if (planilha.Dimension == null || planilha.Dimension.Rows < 2)
                {
                    MessageBox.Show("⚠️ A planilha está vazia ou sem dados!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                int totalLinhas = planilha.Dimension.Rows;
                int totalColunas = planilha.Dimension.Columns;

                for (int col = 1; col <= totalColunas; col++)
                {
                    string colunaNome = planilha.Cells[1, col].Text.Trim().ToUpper();
                    if (string.IsNullOrEmpty(colunaNome)) colunaNome = $"Coluna{col}";
                    dt.Columns.Add(colunaNome);
                    colunasMap[colunaNome] = col;
                }

                for (int i = 2; i <= totalLinhas; i++)
                {
                    DataRow row = dt.NewRow();
                    for (int j = 1; j <= totalColunas; j++)
                    {
                        object cellValue = planilha.Cells[i, j].Value;
                        row[j - 1] = cellValue != null ? cellValue.ToString().Trim() : string.Empty;
                    }
                    dt.Rows.Add(row);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"❌ Erro ao carregar dados do Excel: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        return dt;
    }

    public static void AtualizarExcel(string nif, string nomeAluno, string turma, string observacoes)
    {
        

        if (!File.Exists(caminhoExcel))
        {
            MessageBox.Show("❌ Arquivo Excel não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo(caminhoExcel)))
            {
                var planilha = package.Workbook.Worksheets[0];
                if (planilha.Dimension == null || planilha.Dimension.Rows < 2)
                {
                    MessageBox.Show("⚠️ A planilha está vazia ou sem dados!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int totalLinhas = planilha.Dimension.Rows;
                bool nifEncontrado = false;

                // Percorre as linhas para encontrar o NIF correspondente
                for (int i = 2; i <= totalLinhas; i++)
                {
                    string cellValue = planilha.Cells[i, 1]?.Text?.Trim(); // Supondo que o NIF esteja na 1ª coluna
                    if (!string.IsNullOrEmpty(cellValue) && cellValue.Equals(nif.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        planilha.Cells[i, 2].Value = nomeAluno;  // Atualizando Nome
                        planilha.Cells[i, 4].Value = turma;      // Atualizando Turma
                        planilha.Cells[i, 20].Value = observacoes; // Atualizando Observações
                        nifEncontrado = true;
                        break;
                    }
                }

                if (!nifEncontrado)
                {
                    // Se o NIF não foi encontrado, adiciona uma nova linha
                    int novaLinha = totalLinhas + 1;
                    planilha.Cells[novaLinha, 1].Value = nif;
                    planilha.Cells[novaLinha, 2].Value = nomeAluno;
                    planilha.Cells[novaLinha, 4].Value = turma;
                    planilha.Cells[novaLinha, 20].Value = observacoes;
                    MessageBox.Show("✅ Novo NIF adicionado ao Excel!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                package.Save();
                MessageBox.Show("✅ Excel atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"❌ Erro ao atualizar Excel: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    public static DataRow PesquisarPorNIF(string nif)
    {
        var dt = CarregarDadosExcel(out var colunasMap);
        if (dt == null) return null;

        var colNIFAluno = colunasMap.FirstOrDefault(k => k.Key.Contains("NIFALUNO")).Key;
        var colNIFEE = colunasMap.FirstOrDefault(k => k.Key.Contains("NIFEE")).Key;

        if (string.IsNullOrEmpty(colNIFAluno) && string.IsNullOrEmpty(colNIFEE))
        {
            MessageBox.Show("❌ Nenhuma coluna de NIF encontrada (_NIFALUNO_ ou _NIFEE_).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        var resultado = dt.AsEnumerable().FirstOrDefault(r =>
            (!string.IsNullOrEmpty(colNIFAluno) && r[colNIFAluno].ToString().Trim().Equals(nif.Trim(), StringComparison.OrdinalIgnoreCase)) ||
            (!string.IsNullOrEmpty(colNIFEE) && r[colNIFEE].ToString().Trim().Equals(nif.Trim(), StringComparison.OrdinalIgnoreCase))
        );

        if (resultado == null)
        {
            MessageBox.Show("⚠️ NIF não encontrado no Excel, mas já está no banco de dados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        return resultado;
    }

}

