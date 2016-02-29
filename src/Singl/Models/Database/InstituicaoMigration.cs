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
                MensagemReitoria = @"
                    <h3>Nosso desafio é fazer sempre melhor</h3>

                    <p>Caros(as) internautas,</p>

                    <p>A Universidade Estadual do Centro-Oeste (Unicentro) é uma instituição pulsante. No instante em que estamos prestes a fechar mais um ano letivo, registramos que nosso portal está consolidado como um dos canais mais diretos e eficientes de comunicação com nossos públicos-alvo – estudantes, agentes universitários, professores. Cuidadosamente projetado, o novo portal entrou no ar no em meados de 2013 e é também bastante voltado para a comunidade externa que contribui para o desenvolvimento da Universidade e tem especial interesse em saber como estamos indo e o que fazemos em favor da sociedade, a mesma sociedade que, neste ano, reconheceu publicamente a eficiência da Unicentro por meio de rankings educacionais nacionais e internacionais e de diversos prêmios, como a recente conquista (mês de novembro) da honraria Santander Universidade Solidária.</p>

                    <p>O novo portal está mais leve quanto ao design, mais interativo e mais funcional quanto à navegação pelos links. Está mais visual também. Está, enfim, mais transparente. Enquanto instituição pública, a Unicentro zela pela boa gestão dos recursos provenientes do Estado que, por sua vez, os recebe da sociedade em geral. Somos cerca de 15 mil pessoas ao todo, desde aqueles alunos que provêm dos mais distantes Estados da Federação (em relação ao Paraná) até docentes convidados de inúmeros países, passando também por estudantes estrangeiros. Este portal, diariamente atualizado, é um dos mecanismos da instituição para contar a riqueza do que aqui se produz em termos de Ensino, Pesquisa, Extensão, Inovação Tecnológica e muito mais. Diariamente, cerca de 6 mil pessoas cruzam por nosso portal. Nos últimos anos, em termos de Comunicação Institucional, investimos enormemente nas chamadas ‘redes sociais’, com resultados espetaculares em ferramentas como Facebook, Twitter, YouTube e outras. Deixamos aqui a convicção de que não nos desviaremos do caminho certo, em busca de uma Universidade mais fortalecida, geradora de desenvolvimento social e inteirada com sua comunidade. Afinal, fazer sempre melhor é nosso objetivo.</p>

                    <p>Continuem conosco!</p>

                    <p>Vice-Reitor Osmar Ambrósio de Souza<br>
                    Reitor Aldo Nelson Bona</p>

                    <p>Guarapuava/Irati, novembro de 2013.</p>                
                ",
                UrlFaleComReitoria = "http://www2.unicentro.br/fale-com-o-reitor/",
                Sobre = @"Localizada na região centro-sul do Paraná, a Unicentro é reconhecida pelos trabalhos desenvolvidos nas áreas do ensino, 
                          da pesquisa e da extensão universitárias. Com a união da Fafig de Guarapuava e da Fecli de Irati, a Unicentro teve sua 
                          criação no ano de 1990 e foi reconhecida pelo governo do Paraná 7 anos mais tarde. A partir de então, os trabalhos voltados 
                          para a pesquisa e o ensino têm como foco o preparo dos estudantes para o mundo.",
                Historico = @"
                    <p>A Unicentro, fundada em 1990, possui campi em Guarapuava (Santa Cruz e Cedeteg) e Irati (no Centro-Sul do Estado do Paraná), além de quatro Campi Avançados (municípios de Chopinzinho, Laranjeiras do Sul, Pitanga e Prudentópolis), uma Extensão (cidade de Coronel Vivida) e 27 polos de Educação a Distância (espalhados pelo Paraná). Esses locais oferecem ótima segurança, sendo caracterizados por diversidade étnica inerente aos imigrantes que desenvolveram a região, tais como alemães, suábios, poloneses, ucranianos e italianos. As belezas naturais agregam qualidade de vida, em tranquilas cidades do interior, mas de fácil acesso à capital, Curitiba, distante 150 km de Irati e 250 km de Guarapuava.</p>

                    <p>A Unicentro tem cursos bem conceituados e de excelência no Brasil, nas áreas das Ciências Exatas, Agrárias, Ambientais, Saúde, Sociais Aplicadas e Ciências Humanas, Letras e Artes. Aproximadamente 15 mil estudantes estão matriculados em 38 cursos de graduação e 20 de pós-graduação stricto sensu, além das ofertas de Educação a Distância (EaD). A instituição oferece quatro doutorados - em Química, Agronomia, Ciências Florestais e Ciências Farmacêuticas - e 16 mestrados, nas áreas de Agronomia, Química Aplicada, Bioenergia, Biologia Evolutiva, Educação, Ciências Farmacêuticas, Ciências Florestais, Geografia, História, Desenvolvimento Comunitário, Engenharia Sanitária e Ambiental, Administração, Letras, Ensino de Ciências Naturais e Matemática, Propriedade Intelectual e Transferência para Inovação e Ciências Veterinárias. Nossa editora universitária publica, atualmente, 6 revistas com distribuição nacional e internacional. Estabelecemos a primeira agência de inovação do Estado do Paraná e hoje temos mais de 20 patentes requeridas, com destaques para a área de Química e pesquisas premiadas em Nanotecnologia. Em 2013, a Unicentro venceu o prêmio Santander Universidade Solidária, enquanto um dos diversos reconhecimentos obtidos pela instituição, outorgados por organismos como L’Oreal do Brasil e Sociedade Brasileira de Estudos Interdisciplinares da Comunicação (Intercom), dentre outros.</p>

                    <p>O corpo docente é composto por cerca de 800 professores, com formação na Universidade de São Paulo (USP), Universidade Estadual Paulista (Unesp), Universidade Federal do Rio de Janeiro (UFRJ) e em outras universidades de prestígio no Brasil e no exterior. A colaboração com essas instituições vem permitindo o desenvolvimento da pós-graduação stricto sensu e de ações internacionais. A Unicentro mantém mais de 400 projetos extensionistas (atendimento às comunidades regionais), além de estar integrada com outras universidades do Estado do Paraná no Fórum de Internacionalização do Ensino Superior do Paraná. Mantemos, ainda, diversas parcerias para a organização conjunta de encontros, congressos e colóquios.</p>

                    <p>Firmamos convênios e temos parcerias de mobilidade docente e discente em 19 países, a saber: Alemanha, Argentina, Austrália, Bélgica, Canadá, Chile, Colômbia, Croácia, Espanha, Estados Unidos, França, Itália, México, Paraguai, Nova Zelândia, Portugal, República da Irlanda, Uruguai e Ucrânia. O programa PEC-G abrange países africanos. A mobilidade aumentou com os programas de bolsas da Capes e CNPq, desde os anos 1990, e com o Ciência Sem Fronteiras em 2010. Nossos bolsistas do programa Ciência Sem Fronteiras estão na Alemanha, na Austrália, no Canadá, na Espanha, nos Estados Unidos, na Holanda e na República da Irlanda.</p>

                    <p>A mobilidade internacional discente na graduação e na pós-graduação é regulamentada, facilitando o reconhecimento de graus, estágios e disciplinas, assim como a flexibilidade quanto a diferenças de calendário acadêmico. Quanto a receber professores, somos cadastrados nos Ministérios de Ciência e Tecnologia e do Trabalho, do Brasil, para a acolhida de pesquisadores e docentes, facilitando a obtenção de visto de trabalho. Temos acesso a bolsas e recursos financeiros para intercâmbio de pesquisadores, curta e longa duração, com apoio das agências brasileiras como a Capes, CNPq e a Fundação Araucária do Paraná, e estrangeiras como DAAD (Alemanha).</p>

                    <p>A nossa participação na Red Zicosur sul-americana, na Associação Brasileira de Reitores da Universidades Estaduais e Municipais (Abruem) e na AASCU (American Association of State Colleges and Universities) expandiu as possibilidades de intercâmbio e mobilidade docente e discente para mais de 400 instituições de ensino nas Américas, no Reino Unido e na Coréia do Sul. A nossa filiação ao Grupo Coimbra de Universidades Brasileiras (GCUB) trouxe novas conexões na internacionalização dos programas de pós-graduação. E, ademais, temos sido sempre reconhecidos em rankings educacionais brasileiros e internacionais, sempre com excelentes colocações. No final de 2015, por exemplo, o Ministério da Educação (Mec) do Brasil considerou a Unicentro a 25. melhor universidade do País por conta de seu desempenho acadêmico relativo ao ano de 2014. Menos de 03 anos antes, a Unicentro ocupava a 51. posição.</p>

                    <p>Todos estes resultados são fruto de contínuo esforço coletivo da comunidade acadêmica e da sociedade em geral ao longo de mais de 40 anos, uma vez que a instituição, criada oficialmente em 1990, é o resultado da fusão de duas faculdades: a Faculdade de Filosofia, Ciências e Letras de Guarapuava (Fafig) e a Faculdade de Educação, Ciências e Letras de Irati (Fecli).</p>

                    <p>A partir do ano de 1997, após concluído seu processo de reconhecimento, a instituição iniciou seu projeto de expansão, implantando novos cursos em diversas áreas do conhecimento. Instalada, portanto, na região Central do Estado, a Unicentro conta com mais de 50 municípios em sua região da abrangência direta. Ademais, por conta da Educação a Distância, a Unicentro chega praticamente a todos os 399 municípios do Estado do Paraná. Na esfera da EaD, cabe destacar que a matriz de cursos ofertados pela instituição desde 2005 indica o espírito de diversidade que também serve de norte para a Unicentro, em busca de qualificar distintos públicos. Da primeira oferta, de graduação em Ciências Biológicas (cuja turma iniciada em 2015 tem mais de 200 alunos) até a especialização em Intervenção Sociocultural em Contextos Escolares (igualmente a partir de 2015), o Núcleo de Educação a Distância (Nead) tem demonstrado disposição permanente em atender as demandas e desafios que recebe da sociedade.</p>

                    <p>Ao longo do último decênio, a Unicentro atendeu mais de 4 mil alunos na condição de matriculados em graduações (bacharelados e licenciaturas) e aproximadamente 6,2 mil estudantes de pós-graduação lato sensu, além de outros 400 em nível de aperfeiçoamento.</p>                
                "
            });
        }
    }


}