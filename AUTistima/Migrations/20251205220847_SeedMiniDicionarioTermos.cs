using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AUTistima.Migrations
{
    /// <inheritdoc />
    public partial class SeedMiniDicionarioTermos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(590));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1040));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1040));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1040));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1050));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1060));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1100));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DataCriacao", "ExplicacaoSimples", "TermoTecnico" },
                values: new object[] { new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1110), "Plano de Atendimento Educacional ou Plano Educacional Individualizado - documento que a escola deve fazer para adaptar o ensino às necessidades do aluno. É um direito!", "PAE/PEI" });

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DataCriacao", "ExplicacaoSimples" },
                values: new object[] { new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1120), "Análise do Comportamento Aplicada - terapia comportamental para desenvolver habilidades. Deve ser aplicada de forma ética, respeitosa e naturalista." });

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1150));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 11,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1030));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 12,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1160));

            migrationBuilder.InsertData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                columns: new[] { "Id", "Ativo", "Categoria", "DataCriacao", "ExemploUso", "ExplicacaoSimples", "Fonte", "TermoTecnico" },
                values: new object[,]
                {
                    { 13, true, "Diagnóstico", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1030), null, "Manual de Diagnóstico e Estatística dos Transtornos Mentais, 5ª edição. É o livro que os profissionais usam para diagnosticar autismo e outras condições.", null, "DSM-5" },
                    { 14, true, "Diagnóstico", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1030), null, "Classificação Internacional de Doenças da OMS. Usada para registro médico oficial. O código do autismo é 6A02.", null, "CID-11" },
                    { 15, true, "Diagnóstico", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1030), null, "Classificação de quanto apoio a pessoa autista precisa: Nível 1 (precisa de apoio), Nível 2 (precisa de apoio substancial), Nível 3 (precisa de apoio muito substancial).", null, "Nível de Suporte" },
                    { 16, true, "Diagnóstico", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1040), null, "Quando a pessoa descobre que é autista na adolescência ou idade adulta. Muitas mulheres recebem diagnóstico tardio porque os sinais são diferentes dos meninos.", null, "Diagnóstico Tardio" },
                    { 17, true, "Diagnóstico", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1040), null, "Quando a pessoa autista 'esconde' seus traços para parecer neurotípica. É muito cansativo e pode causar burnout. Comum em mulheres autistas.", null, "Masking/Camuflagem" },
                    { 18, true, "Comportamento", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1050), null, "Comportamentos de autoestimulação como balançar, girar, apertar objetos. Ajuda a pessoa autista a se regular. Não deve ser proibido, apenas redirecionado se necessário.", null, "Stimming" },
                    { 19, true, "Comportamento", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1050), null, "Necessidade de manter as coisas sempre iguais. Mudanças inesperadas podem causar muita ansiedade. Ajuda ter um calendário visual e preparar antecipadamente.", null, "Rotina Rígida" },
                    { 20, true, "Comportamento", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1050), null, "Padrões de comportamento repetitivos e interesses muito específicos. Faz parte do autismo e pode ser uma grande força quando direcionado.", null, "Comportamento Restritivo" },
                    { 21, true, "Comportamento", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1050), null, "Esgotamento extremo causado pelo esforço de se adaptar ao mundo neurotípico. Sintomas: cansaço extremo, perda de habilidades, aumento de crises.", null, "Burnout Autista" },
                    { 22, true, "Comportamento", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1050), null, "Quando a pessoa se machuca durante uma crise ou sobrecarga. Não é 'querer atenção' - é uma resposta à dor interna. Precisa de acompanhamento profissional.", null, "Autolesão" },
                    { 23, true, "Sensorial", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1060), null, "Quando os sentidos são MUITO aguçados. Luzes parecem mais fortes, sons mais altos, toques mais intensos. Pode ser doloroso.", null, "Hipersensibilidade" },
                    { 24, true, "Sensorial", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1060), null, "Quando os sentidos são menos sensíveis. A pessoa pode não sentir dor, frio, ou buscar sensações intensas como pular, girar, apertar forte.", null, "Hipossensibilidade" },
                    { 25, true, "Sensorial", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1090), null, "Quando há estímulos demais ao mesmo tempo (barulho, luz, cheiros, pessoas). Causa muito desconforto e pode levar a meltdown ou shutdown.", null, "Sobrecarga Sensorial" },
                    { 26, true, "Sensorial", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1100), null, "Programa de atividades sensoriais personalizado para ajudar a pessoa autista a se regular. Inclui coisas como massagens, balanços, música.", null, "Dieta Sensorial" },
                    { 27, true, "Sensorial", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1100), null, "Sentido que nos diz onde nosso corpo está no espaço. Pessoas autistas podem ter dificuldade com isso, parecendo 'desajeitadas' ou buscando abraços apertados.", null, "Propriocepção" },
                    { 28, true, "Sensorial", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1100), null, "Sentido do equilíbrio e movimento. Algumas pessoas autistas adoram girar e balançar, outras têm muito medo de movimento.", null, "Sistema Vestibular" },
                    { 29, true, "Comunicação", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1100), null, "Comunicação Aumentativa e Alternativa - formas de comunicação além da fala, como pranchas de imagens, aplicativos, linguagem de sinais. Não impede a fala!", null, "CAA" },
                    { 30, true, "Comunicação", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1110), null, "Sistema de Comunicação por Troca de Figuras. A pessoa usa cartões com imagens para se comunicar. Muito usado com crianças que ainda não falam.", null, "PECS" },
                    { 31, true, "Comunicação", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1110), null, "Pessoa que não usa a fala para se comunicar. Não significa que não entende ou não tem o que dizer - usa outras formas de comunicação.", null, "Não-Verbal" },
                    { 32, true, "Comunicação", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1110), null, "Entender as coisas ao pé da letra. Expressões como 'estou morrendo de fome' ou 'chovendo canivetes' podem confundir. Seja claro e direto!", null, "Literalidade" },
                    { 33, true, "Comunicação", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1110), null, "Dificuldade com as 'regras sociais' da comunicação: quando falar, como manter uma conversa, entender sarcasmo, expressões faciais.", null, "Dificuldade Pragmática" },
                    { 34, true, "Educação", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1110), null, "Atendimento Educacional Especializado - apoio extra que a escola oferece no contraturno. Inclui sala de recursos e profissionais especializados.", null, "AEE" },
                    { 35, true, "Educação", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1120), null, "Espaço na escola com materiais e profissionais especializados para apoiar alunos com deficiência. O aluno frequenta no contraturno.", null, "Sala de Recursos" },
                    { 36, true, "Educação", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1120), null, "Pessoa que acompanha o aluno autista na escola para ajudar nas atividades e adaptações. Também chamado de mediador ou acompanhante.", null, "Profissional de Apoio" },
                    { 37, true, "Educação", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1120), null, "Mudanças no conteúdo, metodologia ou avaliação para que o aluno autista possa aprender. Não é facilitar - é ensinar de forma diferente.", null, "Adaptação Curricular" },
                    { 38, true, "Educação", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1120), null, "Direito de estudar em escola regular com os devidos apoios. A escola deve se adaptar ao aluno, não o contrário. Garantido pela Lei Berenice Piana.", null, "Inclusão Escolar" },
                    { 39, true, "Terapia", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1120), null, "Trabalha habilidades do dia-a-dia, coordenação motora e integração sensorial. Ajuda a criança a ser mais independente nas atividades.", null, "Terapia Ocupacional" },
                    { 40, true, "Terapia", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1130), null, "Trabalha fala, linguagem, comunicação e alimentação. Fundamental para desenvolver a comunicação, seja verbal ou alternativa.", null, "Fonoaudiologia" },
                    { 41, true, "Terapia", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1140), null, "Terapia que ajuda o cérebro a processar melhor os sentidos. Usa atividades como balanços, texturas, massagens para regular os sentidos.", null, "Integração Sensorial" },
                    { 42, true, "Terapia", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1150), null, "Método de ensino estruturado para pessoas autistas. Usa apoios visuais, rotinas previsíveis e ambiente organizado.", null, "TEACCH" },
                    { 43, true, "Terapia", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1150), null, "Abordagem que segue os interesses da criança brincando no chão. Foca no desenvolvimento emocional e na relação, não em comportamentos.", null, "Floortime/DIR" },
                    { 44, true, "Geral", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1150), null, "Pessoa cujo cérebro funciona de forma 'típica' ou 'padrão'. Não é melhor nem pior, apenas diferente do neurodivergente.", null, "Neurotípico" },
                    { 45, true, "Geral", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1150), null, "Ideia de que diferenças neurológicas (autismo, TDAH, etc.) são variações naturais do cérebro humano, não doenças a serem curadas.", null, "Neurodiversidade" },
                    { 46, true, "Geral", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1150), null, "Preconceito contra pessoas com deficiência. Inclui baixas expectativas, exclusão, falar 'você nem parece autista' como elogio.", null, "Capacitismo" },
                    { 47, true, "Geral", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1160), null, "Algumas pessoas preferem 'pessoa com autismo' (pessoa em primeiro lugar), outras preferem 'pessoa autista' (identidade). Pergunte como a pessoa prefere!", null, "Pessoa com Autismo vs Pessoa Autista" },
                    { 48, true, "Alimentação", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1160), null, "Transtorno Alimentar Restritivo Evitativo - quando a seletividade alimentar é tão intensa que afeta a saúde ou crescimento. Precisa de acompanhamento.", null, "ARFID" },
                    { 49, true, "Direitos", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1160), null, "Lei 12.764/2012 que garante direitos às pessoas autistas no Brasil: diagnóstico precoce, tratamento, educação inclusiva, trabalho.", null, "Lei Berenice Piana" },
                    { 50, true, "Direitos", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1160), null, "Lei 13.977/2020 que criou a CIPTEA - carteira de identificação para pessoa autista - facilitando atendimento prioritário.", null, "Lei Romeo Mion" },
                    { 51, true, "Direitos", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1160), null, "Carteira de Identificação da Pessoa com Transtorno do Espectro Autista. Documento que facilita acesso a direitos e atendimento prioritário.", null, "CIPTEA" },
                    { 52, true, "Direitos", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1170), null, "Benefício de Prestação Continuada - um salário mínimo mensal para pessoas com deficiência de baixa renda. Não precisa ter contribuído ao INSS.", null, "BPC/LOAS" },
                    { 53, true, "Direitos", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1170), null, "Quando um juiz determina que outra pessoa (curador) tome decisões pela pessoa autista. Só em casos extremos de incapacidade civil.", null, "Curatela" },
                    { 54, true, "Direitos", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1170), null, "Alternativa à curatela onde a pessoa autista escolhe apoiadores para ajudar em decisões específicas, mantendo sua autonomia.", null, "Tomada de Decisão Apoiada" },
                    { 55, true, "Aprendizagem", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1980), "Não é letra feia, é disgrafia.", "Dificuldade na escrita manual, com traçado irregular, cansaço e lentidão. Não é letra feia - é disgrafia.", "Mini Dicionário AUTistima", "Disgrafia" },
                    { 56, true, "Aprendizagem", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1990), "Não é burrice, é discalculia.", "Transtorno específico da aprendizagem matemática, afetando a compreensão de números e operações. Não é burrice - é discalculia.", "Mini Dicionário AUTistima", "Discalculia" },
                    { 57, true, "Aprendizagem", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(1990), "Não é falta de atenção, pode ser dislexia.", "Dificuldade na leitura, decodificação de palavras e compreensão escrita. Não é falta de atenção - pode ser dislexia.", "Mini Dicionário AUTistima", "Dislexia" },
                    { 58, true, "Aprendizagem", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(2020), "Não é atraso escolar, é perfil de aprendizagem atípico.", "Desempenho irregular entre diferentes áreas de conhecimento. A criança pode ser excelente em uma matéria e ter muita dificuldade em outra.", "Mini Dicionário AUTistima", "Perfil de Aprendizagem Atípico" },
                    { 59, true, "Processamento", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(2020), "Não é desorganização, é déficit visoespacial.", "Dificuldade em perceber relações espaciais e organizar informações visuais. Não é desorganização - é déficit visoespacial.", "Mini Dicionário AUTistima", "Déficit Visoespacial" },
                    { 60, true, "Processamento", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(2020), "Não é dificuldade isolada, é déficit em funções executivas.", "Dificuldade de planejamento, organização, foco e controle emocional. Afeta a capacidade de iniciar e completar tarefas.", "Mini Dicionário AUTistima", "Déficit em Funções Executivas" },
                    { 61, true, "Comportamento", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(2030), "Não é birra, é desregulação emocional.", "Dificuldade de regular emoções diante de frustrações e estímulos. Não é birra - é desregulação emocional.", "Mini Dicionário AUTistima", "Desregulação Emocional" },
                    { 62, true, "Comportamento", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(2030), "Não é teimosia, é rigidez cognitivo-comportamental.", "Dificuldade em lidar com mudanças de rotina ou padrões estabelecidos. Não é teimosia - é rigidez cognitivo-comportamental.", "Mini Dicionário AUTistima", "Rigidez Cognitivo-Comportamental" },
                    { 63, true, "Comportamento", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(2030), "Não é fixação, é interesse restrito.", "Interesses muito intensos e específicos por determinados temas. Pode ser uma grande força quando bem direcionado.", "Mini Dicionário AUTistima", "Interesse Restrito" },
                    { 64, true, "Comportamento", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(2030), "Não é frescura, é necessidade de previsibilidade.", "Apego intenso a rotinas e necessidade de saber o que vai acontecer. Mudanças inesperadas causam grande ansiedade.", "Mini Dicionário AUTistima", "Necessidade de Previsibilidade" },
                    { 65, true, "Socialização", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(2030), "Não é isolamento, é interação social atípica.", "Preferência por interação previsível ou por brincar sozinho. Não é isolamento - é uma forma diferente de interagir.", "Mini Dicionário AUTistima", "Interação Social Atípica" },
                    { 66, true, "Socialização", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(2040), "Não é falta de educação, é dificuldade de habilidades sociais.", "Desafio em compreender regras sociais implícitas e expressões emocionais. Não é falta de educação - é dificuldade de habilidades sociais.", "Mini Dicionário AUTistima", "Dificuldade de Habilidades Sociais" },
                    { 67, true, "Socialização", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(2040), "Não é indiferença, é dificuldade de contato visual.", "Padrão atípico de atenção visual. Olhar nos olhos pode ser desconfortável ou difícil para pessoas autistas.", "Mini Dicionário AUTistima", "Dificuldade de Contato Visual" },
                    { 68, true, "Socialização", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(2040), "Não é falta de afeto, é expressão afetiva atípica.", "Formas diferentes de demonstrar carinho e afeto. A pessoa pode amar muito, mas expressar de maneira diferente.", "Mini Dicionário AUTistima", "Expressão Afetiva Atípica" },
                    { 69, true, "Sensorial", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(2040), "Não é frescura, é defesa sensorial alimentar.", "Restrição alimentar causada por sensibilidade a textura, cheiro, cor ou consistência dos alimentos.", "Mini Dicionário AUTistima", "Defesa Sensorial Alimentar" },
                    { 70, true, "Sensorial", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(2040), "Não é descontrole, é busca sensorial.", "Necessidade intensa de estímulos físicos como pular, girar, apertar. O corpo precisa dessa entrada sensorial.", "Mini Dicionário AUTistima", "Busca Sensorial" },
                    { 71, true, "Comunicação", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(2040), "Não é timidez, é apraxia da fala.", "Dificuldade na programação motora da fala - o cérebro tem dificuldade em coordenar os movimentos para produzir sons.", "Mini Dicionário AUTistima", "Apraxia da Fala" },
                    { 72, true, "Comunicação", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(2050), "Não é atraso simples, pode ser transtorno do desenvolvimento da linguagem.", "Dificuldades persistentes na compreensão e expressão verbal que não são explicadas por outras condições.", "Mini Dicionário AUTistima", "Transtorno do Desenvolvimento da Linguagem" },
                    { 73, true, "Motor", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(2050), "Não é preguiça, pode ser dispraxia.", "Dificuldades de planejamento e execução de movimentos coordenados. Afeta tarefas como escrever, amarrar sapato, andar de bicicleta.", "Mini Dicionário AUTistima", "Dispraxia" },
                    { 74, true, "Motor", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(2050), "Não é preguiça, é fadiga motora fina.", "Cansaço rápido em tarefas que exigem movimentos precisos das mãos, como escrever ou recortar.", "Mini Dicionário AUTistima", "Fadiga Motora Fina" },
                    { 75, true, "Motor", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(2050), "Não é falta de jeito, pode ser alteração motora global.", "Dificuldades em movimentos amplos como correr, pular, subir escadas. Pode parecer desajeitado ou descoordenado.", "Mini Dicionário AUTistima", "Alteração Motora Global" },
                    { 76, true, "Diagnóstico", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(2050), "Não é contradição, é dupla excepcionalidade.", "Quando coexistem superdotação/altas habilidades e um transtorno como autismo. A pessoa pode ter talentos extraordinários e desafios significativos.", "Mini Dicionário AUTistima", "Dupla Excepcionalidade" },
                    { 77, true, "Neurodivergência", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(2060), "Não é distração, pode ser TDAH.", "Transtorno do Déficit de Atenção e Hiperatividade - condição que afeta atenção, controle de impulsos e nível de atividade. Frequentemente coexiste com autismo.", "Mini Dicionário AUTistima", "TDAH" },
                    { 78, true, "Tratamento", new DateTime(2025, 12, 5, 22, 8, 46, 974, DateTimeKind.Utc).AddTicks(2060), "Não é esperar crescer - intervenção precoce é fundamental.", "Estimulação e terapias iniciadas nos primeiros anos de vida. Quanto mais cedo começar, melhores os resultados do desenvolvimento.", "Mini Dicionário AUTistima", "Intervenção Precoce" }
                });

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 977, DateTimeKind.Utc).AddTicks(1020));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 977, DateTimeKind.Utc).AddTicks(1440));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 977, DateTimeKind.Utc).AddTicks(1440));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 977, DateTimeKind.Utc).AddTicks(1440));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 977, DateTimeKind.Utc).AddTicks(1450));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 977, DateTimeKind.Utc).AddTicks(1450));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 977, DateTimeKind.Utc).AddTicks(1450));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 977, DateTimeKind.Utc).AddTicks(1840));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 977, DateTimeKind.Utc).AddTicks(1850));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 977, DateTimeKind.Utc).AddTicks(2230));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 11,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 977, DateTimeKind.Utc).AddTicks(2240));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 12,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 22, 8, 46, 977, DateTimeKind.Utc).AddTicks(2240));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8260));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8710));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8710));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8710));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8720));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8720));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8720));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DataCriacao", "ExplicacaoSimples", "TermoTecnico" },
                values: new object[] { new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8720), "Plano de Atendimento Educacional - documento que a escola deve fazer para adaptar o ensino às necessidades do aluno autista. É um direito garantido por lei.", "PAE" });

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DataCriacao", "ExplicacaoSimples" },
                values: new object[] { new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8720), "Análise do Comportamento Aplicada - uma terapia comportamental usada para desenvolver habilidades. Deve ser aplicada de forma ética e respeitosa." });

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8730));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 11,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8730));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "GlossaryTerms",
                keyColumn: "Id",
                keyValue: 12,
                column: "DataCriacao",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 625, DateTimeKind.Utc).AddTicks(8730));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(6400));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(6850));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(6850));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(6850));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(6860));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(6860));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(6860));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(7280));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(7290));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(7700));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 11,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(7710));

            migrationBuilder.UpdateData(
                schema: "autistima_sa_sql",
                table: "Services",
                keyColumn: "Id",
                keyValue: 12,
                column: "DataCadastro",
                value: new DateTime(2025, 12, 5, 20, 53, 15, 628, DateTimeKind.Utc).AddTicks(7710));
        }
    }
}
