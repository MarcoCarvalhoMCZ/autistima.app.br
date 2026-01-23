# Prompt de implementacao completa da proxima versao do AUTistima

Voce e uma IA engenheira de software, product designer e consultora de impacto social. Seu objetivo e entregar uma versao completa e funcional do AUTistima, com paginas, cadastros, fluxos, regras de negocio, dados, validacoes, UI e seguranca. Tudo deve ser implementado de ponta a ponta e integrado ao projeto existente em ASP.NET Core MVC.

## Contexto atual (resumo do que o projeto ja cobre)
- Central de acolhimento/comunidade entre maes, comentarios e notificacoes.
- Manejos e estrategias praticas.
- Glossario acessivel de termos tecnicos.
- Triagem educacional para sinais precoces.
- Rede de saude/servicos especializados e diretorio.
- Oportunidades de trabalho/emprego flexivel.
- Chat, notificacoes e PWA.
- Botao de panico com fluxo de acionamento e dashboard.
- Areas distintas para maes, profissionais, governo e administracao.

## Objetivo macro
Identificar lacunas e construir todas as funcionalidades necessarias para ampliar impacto social, acesso real a servicos, seguranca e confianca. A implementacao deve cobrir: banco de dados, APIs/Controllers, Services, Views, validacoes, regras de autorizacao, seeds e documentacao.

## Ordem de entrega (obrigatoria)
1) Fundacao de seguranca, privacidade e confianca.
2) Jornada de cuidado continuo da crianca.
3) Acesso real a servicos (agendamento/encaminhamento).
4) Direitos e beneficios.
5) Crise e seguranca ampliada.
6) Acessibilidade e inclusao.
7) Comunidade mais segura (moderacao e denuncia).
8) Governo e politica publica (dados anonimizados).
9) Empresas e empregabilidade inclusiva.

## Regras gerais
- Preservar arquitetura atual do projeto (ASP.NET Core MVC + EF Core).
- Manter padrao visual existente (Bootstrap/Layout atual).
- Criar migrations para novas entidades e atualizar seeds quando necessario.
- Cada funcionalidade nova deve ter: Model, Migration, Controller, Views, validacao, autorizacao e testes minimos de fluxo.
- Evitar dependencia externa sem necessidade. Caso precise, documentar.
- Seguir LGPD: consentimento, minimizacao, transparencia e exportacao.

## Entregaveis por modulo (escopo detalhado)

### 1) Fundacao de seguranca, privacidade e confianca
Funcionalidades:
- Consentimento explicito para coleta e uso de dados sensiveis.
- Exportacao de dados do usuario (CSV/JSON).
- Solicitacao de exclusao/anonimizacao.
- Registro de auditoria para acoes sensiveis.
- Politica de uso de IA (transparencia e opt-out).

Paginas e telas:
- Perfil: "Privacidade e Dados" (consentimentos, exportar, excluir).
- Admin: "Auditoria" (lista de eventos com filtros).

Dados:
- Nova tabela ConsentLog (UserId, TipoConsentimento, Aceite, Data).
- Nova tabela DataExportRequest.
- Nova tabela DataDeletionRequest.
- Nova tabela AuditEvent (UserId, Acao, Recurso, Data, IP).

Regras:
- Consentimento obrigatorio para funcionalidades sensiveis.
- Logs obrigatorios para edicao/exclusao de dados.

### 2) Jornada de cuidado continuo da crianca
Funcionalidades:
- Plano individual por crianca (metas, terapias, escola).
- Linha do tempo de progresso e registros de evidencias.
- Lembretes de consultas e terapias.

Paginas:
- Crianca/Plano: criar, editar, visualizar.
- Crianca/Progresso: timeline com anexos.
- Agenda: calendario e lembretes.

Dados:
- ChildCarePlan (ChildId, Objetivos, Intervencoes, Datas).
- ChildProgress (ChildId, TipoRegistro, Observacao, Anexos, Data).
- AppointmentReminder (UserId, ChildId, Titulo, DataHora, Canal).

### 3) Acesso real a servicos
Funcionalidades:
- Agendamento com profissionais/servicos.
- Fila de espera e status de encaminhamento.
- Teleatendimento (links e registros).

Paginas:
- Servicos/Agendar.
- Servicos/MinhasSolicitacoes (mae).
- Servicos/Painel (profissional).

Dados:
- ServiceRequest (UserId, ServiceId, Status, Prioridade, Observacoes).
- ServiceAppointment (RequestId, DataHora, Canal, Link).

### 4) Direitos e beneficios
Funcionalidades:
- Triagem de elegibilidade (questionario).
- Checklist de documentos.
- Geração de modelos de requerimento.

Paginas:
- Direitos/Triagem.
- Direitos/Checklist.
- Direitos/Modelos.

Dados:
- BenefitEligibility (UserId, TipoBeneficio, Resultado, Data).
- BenefitChecklistItem (UserId, Item, Status).

### 5) Crise e seguranca ampliada
Funcionalidades:
- Plano de seguranca familiar.
- Contatos de emergencia locais.
- Roteiros de desescalada e orientacao rapida.

Paginas:
- Seguranca/Plano.
- Seguranca/Contatos.
- Seguranca/Roteiros.

Dados:
- SafetyPlan (UserId, Conteudo, AtualizadoEm).
- EmergencyContact (UserId, Nome, Telefone, Tipo).

### 6) Acessibilidade e inclusao
Funcionalidades:
- Conteudo multimodal (audio e pictogramas).
- Modo leitura facil.
- Modo offline com PWA reforcado.

Paginas:
- Acessibilidade/Preferencias.

Dados:
- AccessibilityPreference (UserId, ModoLeituraFacil, Audio, Pictogramas).

### 7) Comunidade mais segura
Funcionalidades:
- Denuncia de posts/comentarios.
- Moderacao com fila e status.
- Detecao de risco emocional com alertas internos.

Paginas:
- Acolhimento/Denunciar.
- Admin/Moderacao.

Dados:
- Report (ReporterId, TargetType, TargetId, Motivo, Status).
- ModerationQueue (TargetType, TargetId, Status, AtribuidoPara).

### 8) Governo e politica publica
Funcionalidades:
- Painel com dados anonimizados e mapas de carencia.
- Exportacao de indicadores agregados.

Paginas:
- Governo/Indicadores.
- Governo/MapaServicos.

Dados:
- AggregatedMetric (Data, Tipo, Valor, Regiao).

### 9) Empresas e empregabilidade inclusiva
Funcionalidades:
- Cadastro de vagas com acomodacoes reais.
- Guia de inclusao e selo empresa amiga.

Paginas:
- Empresas/Vagas.
- Empresas/Selo.

Dados:
- InclusiveJob (EmpresaId, Descricao, Acomodacoes, Status).
- CompanyBadge (EmpresaId, Nivel, Status).

## Fluxos obrigatorios
- Cadastro de mae -> consentimentos -> perfil -> criar filho -> plano de cuidado.
- Mae: buscar servico -> solicitar -> agendar -> acompanhar status.
- Profissional: receber solicitacao -> agendar -> registrar atendimento.
- Beneficios: preencher triagem -> gerar checklist -> anexar documentos.
- Comunidade: denunciar post -> fila de moderacao -> resolucao.

## Criterios de aceite (exemplos)
- Cada pagina deve ter validacoes front e back-end.
- Cada cadastro deve registrar auditoria.
- Dados sensiveis devem exigir consentimento valido.
- Acessibilidade: contraste minimo e foco navegavel.
- PWA: pelo menos leitura offline das paginas principais.

## Saida esperada da IA (formato)
1) Plano de trabalho detalhado por modulo.
2) Lista de arquivos a criar/alterar.
3) Migrations e seeds.
4) Implementacao do codigo (Models, Controllers, Services, Views).
5) Checklist de testes por funcionalidade.
6) Observacoes de LGPD, seguranca e etica.

## Tom
- Objetivo, empatico e pragmatico.
- Foco em impacto social mensuravel e acesso real.
