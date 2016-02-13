using Singl.Models;

namespace Singl.Database.Migrations
{
    internal static class InstituicaoMigration
    {
        public static void Create(DatabaseContext context)
        {
            context.Instituicao.Add(new Instituicao
            {
                Nome = "Universidade Estadual do Centro-Oeste",
                Sigla = "UNICENTRO",
                Endereco = $"Rua Padre Salvador, 875 – Santa Cruz - Cx. Postal 730" +
                           $" CEP 85015-430 – Guarapuava – PR",
                Telefone = "+55 (42) 3621-1000",
                Fax = "+55 (42) 3621-1090",
                Email = "contato@unicentro.br",
                UrlOuvidoria="http://www2.unicentro.br/ouvidoria/",
                UrlFaleConosco = "http://www2.unicentro.br/fale-conosco/",
                UrlFaleComReitoria = "http://www2.unicentro.br/fale-com-o-reitor/",
                Sobre = @"Localizada na região centro-sul do Paraná, a Unicentro é reconhecida pelos trabalhos desenvolvidos nas áreas do ensino, 
                          da pesquisa e da extensão universitárias. Com a união da Fafig de Guarapuava e da Fecli de Irati, a Unicentro teve sua 
                          criação no ano de 1990 e foi reconhecida pelo governo do Paraná 7 anos mais tarde. A partir de então, os trabalhos voltados 
                          para a pesquisa e o ensino têm como foco o preparo dos estudantes para o mundo.",
                Historico = @"A UNICENTRO é uma das mais jovens Universidades do Estado do Paraná. Ela surgiu da fusão de duas Faculdades: a Faculdade de Filosofia, Ciências e Letras de Guarapuava e a Faculdade de Educação, Ciências e Letras de Irati. A partir do ano de 1997, após concluído seu processo de reconhecimento a instituição iniciou seu processo de expansão, implantando novos cursos em diversas áreas do conhecimento, contanto, atualmente, com 59 ofertas de cursos, sendo 28 em Guarapuava, 16 Irati, 2 em Chopinzinho, 5 em Laranjeiras do Sul, 3 em Pitanga e 5 em Prudentópolis. Instalada na região Central do Estado, a UNICENTRO conta com mais de cinqüenta municípios em sua região da abrangência, compreendendo uma população de mais de 1 milhão de habitantes, para os quais oferece, além das oportunidades de formação superior com cursos de Graduação, Seqüenciais e de Especialização, uma variada gama de serviços que propiciam maior desenvolvimento regional. O processo de consolidação da UNICENTRO está em pleno desenvolvimento, o que se evidencia tanto pelo reconhecimento da comunidade que a procura, como pelo reconhecimento dos órgãos oficiais encarregados da gestão das políticas de Ensino Superior no País. Neste processo merece destaque a implantação, no ano de 2006, dos 4 primeiros programas de Pós-Graduação stricto sensu da Universidade, a saber, os Mestrados nas áreas de Química , Engenharia Florestal, Agronomia e Biologia.
"
            });
        }
    }


}