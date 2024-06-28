using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using DesafioUBC.Model;
using DesafioUBC.Uteis;
using DesafioUBC.DataModel;
using DesafioUBC.Repository;
using DesafioUBC.Interfaces;

namespace DesafioUBC.Uteis
{
    public class CsvReaderHelper
    {
        private readonly IStudentRepository _repository;

        public CsvReaderHelper()
        {
        }

        public CsvReaderHelper(IStudentRepository repository)
            => _repository = repository;
        public List<StudentDataModel> LerDadosDoCSV(string caminhoArquivo)
        {
      
            try
            {
                int id = 0;
                List<StudentDataModel> lstStudents = new List<StudentDataModel>();
                var linhasCSV = File.ReadAllLines(caminhoArquivo).Skip(1).ToList();
                foreach (var item in linhasCSV)
                {
                    var colunas = item.Split(',');
                    lstStudents.Add(new StudentDataModel()
                    {
                        Id = ++id,
                        Nome = colunas[0].ToString(),
                        Idade = int.Parse(colunas[1]),
                        Serie = int.Parse(colunas[2]),
                        NotaMedia = double.Parse(colunas[3]),
                        Endereco = colunas[4].ToString(),
                        NomePai = colunas[5].ToString(),
                        NomeMae = colunas[6].ToString(),
                        DataNascimento =Convert.ToDateTime(colunas[7].Replace("\"", ""))
                    });
                }
                //List<StudentDataModel> estudantes = File.ReadAllLines(caminhoArquivo)
                //    .Skip(1) // Pule a primeira linha se ela contiver cabeçalhos
                //    .Select(linha =>
                //    {
                //        string[] colunas = linha.Split(','); // Use o separador correto (por exemplo, ';')
                //        return new StudentDataModel
                //        {
                //            Id = ++id,
                //            Nome = colunas[1].ToString(),
                //            Idade = int.Parse(colunas[2]),
                //            Serie = int.Parse(colunas[3]),
                //            NotaMedia = int.Parse(colunas[4]),
                //            Endereco = colunas[5].ToString(),
                //            NomePai = colunas[6].ToString(),
                //            NomeMae = colunas[7].ToString(),
                //            DataNascimento = DateTime.Parse(colunas[8])
                //        };
                //    })
                //    .ToList();

                return lstStudents;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
                return new List<StudentDataModel>();
            }
        }
    }
}

