using static System.Net.Mime.MediaTypeNames;

namespace DesafioUBC.Model
{
    public class StudentModel
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int Serie { get; set; }
        public string Endereco { get; set; }
        public double NotaMedia { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public DateTime DataNascimento { get; set; }

        public StudentModel(string nome, int serie, double notaMedia,string endereco, string nomePai, string nomeMae, DateTime dataNascimento)
        {
            Nome = nome;
            Idade = DateTime.Today.Year - dataNascimento.Year - (dataNascimento>DateTime.Today.AddYears(-(DateTime.Today.Year - dataNascimento.Year))?1:0);
            Serie = serie;
            NotaMedia = notaMedia;
            Endereco = endereco;
            NomePai = nomePai;
            NomeMae = nomeMae;
            DataNascimento = dataNascimento;
        }


    //int Id(identificador único)
    //string Nome(nome do estudante)
    //int Idade(idade do estudante)
    //int Serie(série do estudante)
    //double NotaMedia(nota média do estudante)
    //string Endereco(endereço do estudante)
    //string NomePai(nome do pai do estudante)
    //string NomeMae(nome da mãe do estudante)
    //DateTime DataNascimento(data de nascimento do estudante)
}
}
