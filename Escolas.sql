/*
 Navicat Premium Dump SQL

 Source Server         : _SIAR
 Source Server Type    : SQL Server
 Source Server Version : 11006020 (11.00.6020)
 Source Host           : sosdados.com.br:11433
 Source Catalog        : bd_siar
 Source Schema         : siar_sa_sql

 Target Server Type    : SQL Server
 Target Server Version : 11006020 (11.00.6020)
 File Encoding         : 65001

 Date: 08/12/2025 13:46:37
*/


-- ----------------------------
-- Table structure for Escolas
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[siar_sa_sql].[Escolas]') AND type IN ('U'))
	DROP TABLE [siar_sa_sql].[Escolas]
GO

CREATE TABLE [siar_sa_sql].[Escolas] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Inep] nvarchar(8) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Nome] nvarchar(300) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [KitEscolar] bit  NOT NULL,
  [DataEntregaKitEscolar] datetime2(7)  NULL,
  [CompetenciaId] int  NOT NULL,
  [DataCriacao] datetime2(7)  NOT NULL,
  [DataUltimaAtualizacao] datetime2(7)  NULL,
  [FonteDados] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [CodigoMunicipio] nvarchar(7) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [CEP] nvarchar(8) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Endereco] nvarchar(500) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Localizacao] int DEFAULT 0 NOT NULL,
  [LocalizacaoDiferenciada] int DEFAULT 0 NOT NULL,
  [ParceriaPoderPublico] int DEFAULT 0 NOT NULL,
  [SituacaoEscola] int DEFAULT 0 NOT NULL,
  [Bairro] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Latitude] float(53)  NULL,
  [Longitude] float(53)  NULL
)
GO

ALTER TABLE [siar_sa_sql].[Escolas] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Escolas
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [siar_sa_sql].[Escolas] ON
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'238', N'27034755', N'ESCOLA MUNICIPAL DOUTOR HENRIQUE EQUELMAN', N'0', NULL, N'4', N'2025-12-04 21:28:50.4287810', NULL, N'SISLAME', NULL, N'57041620', N'RUA 56 COHAB -  - JACINTINHO - Maceió', N'1', N'0', N'2', N'1', N'Jacintinho', N'-9.6365709', N'-35.7110774')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'239', N'27035441', N'ESCOLA DE ENSINO FUNDAMENTAL SAGRADO CORAÇÃO DE JESUS', N'0', NULL, N'4', N'2025-12-04 21:28:50.4288460', NULL, N'SISLAME', NULL, N'57038260', N'RUA DELMIRO GOUVEIA - SN - CRUZ DAS ALMAS - Maceió', N'1', N'0', N'2', N'1', N'Cruz das Almas', N'-9.6647625', N'-35.708704')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'240', N'27036049', N'ESCOLA MUNICIPAL ZANELI CALDAS', N'0', NULL, N'4', N'2025-12-04 21:28:50.4288500', NULL, N'SISLAME', NULL, N'57025860', N'PRAÇA DA MARAVILHA - 87 - POÇO - Maceió', N'1', N'0', N'2', N'1', N'Poço', N'-9.6586248', N'-35.717677')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'241', N'27036065', N'ESCOLA MUNICIPAL DOUTOR ORLANDO ARAÚJO', N'0', NULL, N'4', N'2025-12-04 21:28:50.4288530', NULL, N'SISLAME', NULL, N'57035260', N'RUA DR. JOSÉ SAMPAIO LUZ -  - PONTA VERDE - Maceió', N'1', N'0', N'2', N'1', N'Ponta Verde', N'-9.6586543', N'-35.7108819')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'242', N'27036081', N'ESCOLA MUNICIPAL ANTÔNIO SEMEÃO LAMENHA LINS ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4288560', NULL, N'SISLAME', NULL, N'57041580', N'RUA MAJOR JOSÉ JOAQUIM CALHEIROS -  - JACINTINHO - Maceió', N'1', N'0', N'2', N'1', N'Jacintinho', N'-9.6365709', N'-35.7110774')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'243', N'27036090', N'ESCOLA MUNICIPAL ARNON AFONSO FARIAS DE MELO ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4288590', NULL, N'SISLAME', NULL, N'57041132', N'CONJ. JOSÉ DA SILVA PEIXOTO  -  - JACINTINHO - Maceió', N'1', N'0', N'2', N'1', N'Jacintinho', N'-9.6365709', N'-35.7110774')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'244', N'27036103', N'ESCOLA MUNICIPAL CLETO MARQUES LUZ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4288610', NULL, N'SISLAME', NULL, N'57063650', N'RUA LUIS ALVES DA SILVA - S/N - SANTA AMELIA  - Maceió', N'1', N'0', N'2', N'1', NULL, NULL, NULL)
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'245', N'27036120', N'ESCOLA MUNICIPAL DOM ANTÔNIO BRANDÃO ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4288640', NULL, N'SISLAME', NULL, N'57061120', N'R. DO QUADRO  - SN - TABULEIRO - Maceió', N'1', N'0', N'2', N'1', N'Tabuleiro do Martins', N'-9.57362400002035', N'-35.7636198712411')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'246', N'27036138', N'ESCOLA MUNICIPAL DOUTOR POMPEU SARMENTO', N'0', NULL, N'4', N'2025-12-04 21:28:50.4288660', NULL, N'SISLAME', NULL, N'57071130', N'AVENIDA MUNIZ FALCÃO -  - BARRO DURO - Maceió', N'1', N'0', N'2', N'1', N'Clima Bom', N'-9.58332718157225', N'-35.7396590577506')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'247', N'27036146', N'CMEI GRACILIANO RAMOS', N'0', NULL, N'4', N'2025-12-04 21:28:50.4288690', NULL, N'SISLAME', NULL, N'57073020', N'AV.DR. JOSÉ HAILTON DOS SANTOS - S/N - CIDADE UNIVERSITARIA - Maceió', N'1', N'0', N'2', N'1', N'Cidade Universitária', N'-9.5539008', N'-35.7461255')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'248', N'27036154', N'CMEI JOÃO XXIII', N'0', NULL, N'4', N'2025-12-04 21:28:50.4288710', NULL, N'SISLAME', NULL, N'57040090', N'RUA DR JOSE JOAQUIM ARAÚJO - 57 - JACINTINHO - Maceió', N'1', N'0', N'2', N'1', N'Jacintinho', N'-9.6365709', N'-35.7110774')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'249', N'27036189', N'ESCOLA MUNICIPAL DOUTOR JOSÉ HAROLDO DA COSTA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4288740', NULL, N'SISLAME', NULL, N'57081395', N'RUA DR. JÚLIO CÉSAR MENDONÇA UCHÔA -  - TABULEIRO DO MARTINS - Maceió', N'1', N'0', N'2', N'1', N'Tabuleiro do Martins', N'-9.5685551869336', N'-35.7569707024559')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'250', N'27036197', N'ESCOLA MUNICIPAL PROFESSOR LENILTO ALVES SANTOS', N'0', NULL, N'4', N'2025-12-04 21:28:50.4288760', NULL, N'SISLAME', NULL, N'57041430', N'RUA ENFERMEIRO MARIANO -  - JACINTINHO - Maceió', N'1', N'0', N'2', N'1', N'Jacintinho', N'-9.6365709', N'-35.7110774')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'251', N'27036200', N'ESCOLA MUNICIPAL LUÍZA  OLIVEIRA SURUAGY ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4288790', NULL, N'SISLAME', NULL, N'57045815', N'RUA PADRE CÍCERO -  - OURO PRETO - Maceió', N'1', N'0', N'2', N'1', N'Ouro Preto', N'-9.56843676193485', N'-35.7474719326071')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'252', N'27036219', N'CMEI LUIZ CALHEIROS JÚNIOR', N'0', NULL, N'4', N'2025-12-04 21:28:50.4288810', NULL, N'SISLAME', NULL, N'57046770', N'RUA LOURIVAL DE AGUIAR PESSOA - 400 - SERRARIA - Maceió', N'1', N'0', N'2', N'1', N'Serraria', N'-9.5945808', N'-35.7280492')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'253', N'27036227', N'ESCOLA MUNICIPAL MAJOR BONIFÁCIO SILVEIRA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4288840', NULL, N'SISLAME', NULL, N'57052645', N'AV JORNALISTA JOSÉ BATISTA - 277 - GRUTA DE LOURDES - Maceió', N'1', N'0', N'2', N'1', N'Gruta de Lourdes', N'-9.6125541', N'-35.7380054')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'254', N'27036235', N'ESCOLA MUNICIPAL MARECHAL FLORIANO PEIXOTO', N'0', NULL, N'4', N'2025-12-04 21:28:50.4288860', NULL, N'SISLAME', NULL, N'57039800', N'R. DA IGREJA -  - IPIOCA - Maceió', N'1', N'0', N'2', N'1', N'Ipioca', N'-9.54659151427341', N'-35.626679153327')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'255', N'27036251', N'ESCOLA MUNICIPAL PADRE PINHO', N'0', NULL, N'4', N'2025-12-04 21:28:50.4288980', NULL, N'SISLAME', NULL, N'57038460', N'RUA QUEBRANGULO - SN - CRUZ DAS ALMAS - Maceió', N'1', N'0', N'2', N'1', N'Cruz das Almas', N'-9.6647625', N'-35.708704')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'256', N'27036260', N'ESCOLA MUNICIPAL PEDRO CAFÉ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289000', NULL, N'SISLAME', NULL, N'57070570', N'Praça leonidio Cardoso -  - RIO NOVO - Maceió', N'1', N'0', N'2', N'1', N'Rio Novo', N'-9.59813271385177', N'-35.7716783890176')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'257', N'27036278', N'ESCOLA MUNICIPAL PEDRO SURUAGY', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289020', NULL, N'SISLAME', NULL, N'57061110', N'AV. MACEIÓ -  - TABULEIRO - Maceió', N'1', N'0', N'2', N'1', N'Tabuleiro do Martins', N'-9.56831453902831', N'-35.7574474398445')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'258', N'27036286', N'ESCOLA MUNICIPAL ALMEIDA LEITE ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289050', NULL, N'SISLAME', NULL, N'57014002', N'R. VIRGÍLIO GUEDES - S/N - PONTA GROSSA - Maceió', N'1', N'0', N'2', N'1', NULL, NULL, NULL)
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'259', N'27036294', N'ESCOLA MUNICIPAL PROFESSOR DONIZETTE CALHEIROS ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289070', NULL, N'SISLAME', NULL, N'57082010', N'RUA JOSE HERMES DAMASCENO - S/N - SANTA LUCIA - Maceió', N'1', N'0', N'2', N'1', N'Santa Lúcia', N'-9.5865536', N'-35.7586476')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'260', N'27036308', N'ESCOLA MUNICIPAL PROFESSORA EULINA RIBEIRO ALENCAR', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289100', NULL, N'SISLAME', NULL, N'57040080', N'R. COARACY FONSECA -  - JACINTINHO - Maceió', N'1', N'0', N'2', N'1', N'Jacintinho', N'-9.6365709', N'-35.7110774')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'261', N'27036324', N'ESCOLA MUNICIPAL SUZEL DANTAS', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289120', NULL, N'SISLAME', NULL, N'57060020', N'RUA ANTONIO MONTEIRO DE CARVALHO -  - TABULEIRO DO MARTINS - Maceió', N'1', N'0', N'2', N'1', N'Tabuleiro do Martins', N'-9.57132539272584', N'-35.7567229102561')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'262', N'27036332', N'ESCOLA MUNICIPAL RUI PALMEIRA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289150', NULL, N'SISLAME', NULL, N'57015130', N'AV. MONTE CASTELO - SN - VERGEL DO LAGO - Maceió', N'1', N'0', N'2', N'1', N'Vergel do Lago', N'-9.66782895040456', N'-35.7468942394374')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'263', N'27036340', N'ESCOLA MUNICIPAL SÉRGIO LUIZ PESSOA BRAGA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289170', NULL, N'SISLAME', NULL, N'57018550', N'AV. GOVERNADOR LAMENHA FILHO -  - CHÃ DA JAQUEIRA - Maceió', N'1', N'0', N'2', N'1', N'Chã da Jaqueira', N'-9.6191507', N'-35.7463003')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'264', N'27036359', N'ESCOLA MUNICIPAL SILVESTRE PÉRICLES', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289200', NULL, N'SISLAME', NULL, N'57010830', N'PRAÇA DR. CAIO PORTO -  - PONTAL DA BARRA - Maceió', N'1', N'0', N'2', N'1', N'Pontal da Barra', N'-9.68905306290598', N'-35.7381565498812')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'265', N'27036375', N'ESCOLA MUNICIPAL JAIME DE ALTAVILLA ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289220', NULL, N'SISLAME', NULL, N'57082045', N'Rua Dilermando Reis -  - Santa Lúcia - Maceió', N'1', N'0', N'2', N'1', N'Santa Lúcia', N'-9.5865536', N'-35.7586476')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'266', N'27036391', N'ESCOLA MUNICIPAL PROFESSOR CORINTHO DA PAZ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289250', NULL, N'SISLAME', NULL, N'57072014', N'CONJ. CIDADE UNIVERSITÁRIA -  - CIDADE UNIVERSITÁRIA - Maceió', N'1', N'0', N'2', N'1', N'Cidade Universitária', N'-9.5539008', N'-35.7461255')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'267', N'27036405', N'ESCOLA MUNICIPAL PROFESSOR ANTÍDIO VIEIRA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289270', NULL, N'SISLAME', NULL, N'57010380', N'R. PAULO NETO  - SN - TRAPICHE - Maceió', N'1', N'0', N'2', N'1', N'Trapiche da Barra', N'-9.68545252498964', N'-35.7448549331619')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'268', N'27036413', N'ESCOLA MUNICIPAL HIGINO BELO ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289300', NULL, N'SISLAME', NULL, N'57051600', N'AV. SANTA RITA DE CÁSSIA  -  - FAROL - Maceió', N'1', N'0', N'2', N'1', N'Farol', N'-9.6555093', N'-35.7336269')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'269', N'27036804', N'CMEI NOSSA SENHORA DA GUIA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289320', NULL, N'SISLAME', NULL, N'57010645', N'AV. SIQUEIRA CAMPOS - 24/27 - TRAPICHE - Maceió', N'1', N'0', N'2', N'1', N'Trapiche da Barra', N'-9.68892362672242', N'-35.7481439418075')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'270', N'27036839', N'ESCOLA MUNICIPAL DOUTOR JOSÉ BANDEIRA DE MEDEIROS', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289350', NULL, N'SISLAME', NULL, N'57014080', N'GUAICURUS - 77 - PONTA GROSSA - Maceió', N'1', N'0', N'2', N'1', NULL, NULL, NULL)
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'271', N'27036863', N'ESCOLA MUNICIPAL PROFESSOR DERALDO CAMPOS', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289370', NULL, N'SISLAME', NULL, N'57015050', N'PÇ. MOISES S. FIRMINO -  - VERGEL DO LAGO - Maceió', N'1', N'0', N'2', N'1', N'Vergel do Lago', N'-9.66792821447216', N'-35.7516651215879')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'272', N'27036880', N'CMEI PROFESSORA MARIA DE LOURDES VIEIRA ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289490', NULL, N'SISLAME', NULL, N'57020050', N'PRAÇA GONÇALVES LEDO - s/n - FAROL - Maceió', N'1', N'0', N'2', N'1', N'Centro', N'-9.6647296', N'-35.7385312')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'273', N'27036898', N'CMEI MARECHAL JOÃO BATISTA MASCARENHAS DE MORAES ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289520', NULL, N'SISLAME', NULL, N'57052320', N'PRAÇA DR. OSÓRIO CALHEIROS GATTO - S/N - PITANGUINHA - Maceió', N'1', N'0', N'2', N'1', N'Pitanguinha', N'-9.64815558700123', N'-35.7249056351096')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'274', N'27036901', N'CMEI MONSENHOR LUIS BARBOSA ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289540', NULL, N'SISLAME', NULL, N'57073595', N'RUA DIVALDO SURUAGY - 98 - VILLAGE CAMPESTRE II - Maceió', N'1', N'0', N'2', N'1', N'Cidade Universitária', N'-9.5539008', N'-35.7461255')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'275', N'27036910', N'CMEI DOUTOR ANTÔNIO MÁRIO MAFRA ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289570', NULL, N'SISLAME', NULL, N'57010000', N'RUA 15 DE MARÇO  - S /N - LEVADA - Maceió', N'1', N'0', N'2', N'1', N'Prado', N'-9.68324801296178', N'-35.7348842416203')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'276', N'27037525', N'ESCOLA MUNICIPAL DE ENSINO FUNDAMENTAL SANTO ANTONIO', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289590', NULL, N'SISLAME', NULL, N'57084304', N'AV. CACHOEIRA DO MEIRIM /LIRA  -  - BENEDITO BENTES - Maceió', N'2', N'0', N'2', N'1', N'Benedito Bentes', N'-9.5859671', N'-35.7150116')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'277', N'27037568', N'ESCOLA MUNICIPAL DOUTOR BALTAZAR DE MENDONÇA ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289620', NULL, N'SISLAME', NULL, N'57040780', N'TEN. CEL. EXERC. BRAS. PEDRO JERONIMO DOS SANTOS - S/N - JACINTINHO - Maceió', N'1', N'0', N'2', N'1', N'Jacintinho', N'-9.6365709', N'-35.7110774')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'278', N'27037614', N'ESCOLA MUNICIPAL JOSÉ CORREIA COSTA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289640', NULL, N'SISLAME', NULL, N'57046770', N'AV EMPRESARIO VALENTIM DOS SANTOS DINIZ - s/n - SERRARIA - Maceió', N'1', N'0', N'2', N'1', N'Serraria', N'-9.5945808', N'-35.7280492')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'279', N'27037681', N'ESCOLA MUNICIPAL DOUTOR JOSÉ CARNEIRO ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289670', NULL, N'SISLAME', NULL, N'57057030', N'RUA BERNADES LOPES - SN - Pinheiro - Maceió', N'1', N'0', N'2', N'1', N'Pinheiro', N'-9.6276873', N'-35.7384062')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'280', N'27037800', N'ESCOLA MUNICIPAL KÁTIA PIMENTEL ASSUNÇÃO ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289690', NULL, N'SISLAME', NULL, N'57041300', N'RUA BRENO CANSANÇAO - 788 - JACINTINHO - Maceió', N'1', N'0', N'2', N'1', N'Jacintinho', N'-9.6365709', N'-35.7110774')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'281', N'27037860', N'ESCOLA MUNICIPAL MANOEL PEDRO DOS SANTOS', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289710', NULL, N'SISLAME', NULL, N'57071230', N'AV. CORINTHO CAMPELO DA PAZ -  - SANTOS DUMONT - Maceió', N'1', N'0', N'2', N'1', N'Clima Bom', N'-9.57988003593628', N'-35.7407534811977')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'282', N'27038068', N'CMEI WALTER PITOMBO LARANJEIRAS', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289740', NULL, N'SISLAME', NULL, N'57015852', N'AV GOVERNADOR TEOBALDO BARBOSA - 434 - VERGEL DO LAGO - Maceió', N'1', N'0', N'2', N'1', N'Vergel do Lago', N'-9.66860487301587', N'-35.7516751257093')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'283', N'27038084', N'CMEI PROFESSOR MANOEL COELHO NETO ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289770', NULL, N'SISLAME', NULL, N'57057380', N'RUA MANOEL FLORENTINO DA SILVA - 190 - PINHEIRO - Maceió', N'1', N'0', N'2', N'1', N'Pinheiro', N'-9.6276873', N'-35.7384062')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'284', N'27038645', N'ESCOLA MUNICIPAL TEREZA DE JESUS', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289790', NULL, N'SISLAME', NULL, N'57010200', N'RUA SARGENTO JAYME PANTALEÃO - 75 - PRADO - Maceió', N'1', N'0', N'2', N'1', N'Prado', N'-9.68347570688572', N'-35.7375529017152')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'285', N'27038980', N'ESCOLA MUNICIPAL HERMÍNIO CARDOSO', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289820', NULL, N'SISLAME', NULL, N'57070540', N'R. BARÃO DE JARAGUÁ - SN - FERNÃO VELHO - Maceió', N'1', N'0', N'2', N'1', N'Rio Novo', N'-9.59236622216535', N'-35.7722544631193')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'286', N'27046397', N'ESCOLA MUNICIPAL PROFESSORA JAREDE VIANA DE OLIVEIRA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289840', NULL, N'SISLAME', NULL, N'57071051', N'R. SÃO JOSÉ  - 888A - CLIMA BOM - Maceió', N'1', N'0', N'2', N'1', N'Clima Bom', N'-9.57904535898876', N'-35.7398666194959')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'287', N'27047466', N'CMEI PROFESSORA MARIA IVONE SANTOS DE OLIVEIRA ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289870', NULL, N'SISLAME', NULL, N'57086131', N'CONJ. CIDADE SORRISO I - S/N - BENEDITO BENTES II - Maceió', N'1', N'0', N'2', N'1', N'Benedito Bentes', N'-9.5859671', N'-35.7150116')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'288', N'27048438', N'CMEI GOVERNADOR LUIS ABILIO DE SOUSA NETO ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289890', NULL, N'SISLAME', NULL, N'57010000', N'RUA P, CONJ CIDADE SORRISO QD E - SN - BENEDITO BENTES II - Maceió', N'1', N'0', N'2', N'1', N'Prado', N'-9.68251005449854', N'-35.7314684278412')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'289', N'27049213', N'CMEI PROFESSORA MARIA APARECIDA BEZERRA NUNES', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289920', NULL, N'SISLAME', NULL, N'57010386', N'CONJ. RES. DOS PESCADORES RUA ARY PITOMBO - s n - TRAPICHE DA BARRA - Maceió', N'1', N'0', N'2', N'1', N'Trapiche da Barra', N'-9.68537541686846', N'-35.7437112752662')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'290', N'27051684', N'ESCOLA MUNICIPAL GASTONE LÚCIA DE CARVALHO BELTRÃO', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289940', NULL, N'SISLAME', NULL, N'57010000', N'CONJ. RES. JARDIM ROYAL II NÚMERO DO INEP 27051684 - SN - CIDADE UNIVERSITÁRIA - Maceió', N'1', N'0', N'2', N'1', N'Prado', N'-9.67704557311937', N'-35.7318550477701')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'291', N'27051692', N'CMEI PROFESSORA SÔNIA MARIA SOUZA CAVALCANTI', N'0', NULL, N'4', N'2025-12-04 21:28:50.4289970', NULL, N'SISLAME', NULL, N'57017201', N'RUA GENERAL  HERMES - S/N - BOM PARTO - Maceió', N'1', N'0', N'2', N'1', NULL, NULL, NULL)
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'292', N'27051706', N'CMEI JOSÉ MADLTTON VITOR DA SILVA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290090', NULL, N'SISLAME', NULL, N'57085540', N'Loteamento Bela Vista II - s/n - Benedito Bentes - Maceió', N'1', N'0', N'2', N'1', N'Benedito Bentes', N'-9.5859671', N'-35.7150116')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'293', N'27051714', N'CMEI PROFESSORA FÚLVIA MARIA DE BARROS MOTT ROSEMBERG', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290110', NULL, N'SISLAME', NULL, N'57073415', N'Avenida Alice Karoline -  - Cidade Universitária - Maceió', N'1', N'0', N'2', N'1', N'Cidade Universitária', N'-9.5539008', N'-35.7461255')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'294', N'27051722', N'CMEI ANA CAROLINA GALINA FORTES FERREIRA SANTIAGO', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290140', NULL, N'SISLAME', NULL, N'57072362', N'Conjunto Novo Jardim  - S/N - Cidade Universitária - Maceió', N'1', N'0', N'2', N'1', N'Cidade Universitária', N'-9.5539008', N'-35.7461255')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'295', N'27051781', N'CMEI PROFESSORA MARIA SALETE DA SILVA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290160', NULL, N'SISLAME', NULL, N'57085160', N'AVENIDA ANTÔNIO LISBOA DE AMORIM - S/N - BENEDITO BENTES - Maceió', N'1', N'0', N'2', N'1', N'Benedito Bentes', N'-9.5859671', N'-35.7150116')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'296', N'27052389', N'ESCOLA MUNICIPAL JOÃO FEITOSA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290190', NULL, N'SISLAME', NULL, N'57010000', N'Rua da Areia -  - Rio novo - Maceió', N'1', N'0', N'2', N'1', N'Prado', N'-9.6765943717195', N'-35.7332280898501')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'297', N'27052397', N'CMEI PROFESSORA MARIA JOSÉ DE OLIVEIRA ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290210', NULL, N'SISLAME', NULL, N'57073383', N'AVENIDA TANCREDO NEVES - SN - BENEDITO BENTES  - Maceió', N'1', N'0', N'2', N'1', N'Cidade Universitária', N'-9.5539008', N'-35.7461255')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'298', N'27052400', N'CMEI MESTRA VIRGÍNIA MORAES DA SILVA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290240', NULL, N'SISLAME', NULL, N'57070630', N'RUA SÃO LUIZ, CONJ. VALE DO TOCANTINS -  - RIO NOVO - Maceió', N'1', N'0', N'2', N'1', N'Rio Novo', N'-9.59582303089602', N'-35.7726717319441')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'299', N'27053369', N'CMEI PROFESSOR SILVÂNIO BARBOSA DOS SANTOS', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290260', NULL, N'SISLAME', NULL, N'57032070', N'CONJ RESIDENCIAL JOSÉ APRIGIO VILELA - s/n - JACARECICA - Maceió', N'1', N'0', N'2', N'1', N'Jacarecica', N'-9.62121532659095', N'-35.6994860589119')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'300', N'27053385', N'CMEI PROFESSORA DULCINETE BARROS ALVES', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290290', NULL, N'SISLAME', NULL, N'57048166', N'LOTEAMENTO CASA FORTE - S/N - ANTARES - Maceió', N'1', N'0', N'2', N'1', N'Antares', N'-9.54722220350484', N'-35.7121137160267')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'301', N'27053806', N'CMEI MARTHA CÉLIA DE VASCONCELLOS BERNARDES', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290310', NULL, N'SISLAME', NULL, N'57072040', N'RUA DR. JURACY PEREIRA - S/N - CIDADE UNIVERSITÁRIA - Maceió', N'1', N'0', N'2', N'1', N'Cidade Universitária', N'-9.5539008', N'-35.7461255')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'302', N'27054136', N'ESCOLA MUNICIPAL PROFESSORA MARIA DE LOURDES BEZERRA NUNES', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290340', NULL, N'SISLAME', NULL, N'57037574', N'RUA DR WALDEMIRO DE ALENCAR JR - 100 - MANGABEIRAS - Maceió', N'1', N'0', N'2', N'1', N'Mangabeiras', N'-9.6478561', N'-35.7147108')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'303', N'27054802', N'CMEI PROFESSOR EDVALDO ALBUQUERQUE DOS SANTOS', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290360', NULL, N'SISLAME', NULL, N'57073633', N'RUA D  - S/N - CIDADE UNIVERSITARIA - Maceió', N'1', N'0', N'2', N'1', N'Cidade Universitária', N'-9.5539008', N'-35.7461255')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'304', N'27054829', N'CMEI JOSE ORLANDO CAJE', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290390', NULL, N'SISLAME', NULL, N'57072170', N'Avenida B - S/N - CIDADE UNIVERSITARIA - Maceió', N'1', N'0', N'2', N'1', N'Cidade Universitária', N'-9.5539008', N'-35.7461255')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'305', N'27054837', N'ESCOLA MUNICIPAL PROFESSORA MARIA DA GRACAS SILVA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290410', NULL, N'SISLAME', NULL, N'57073130', N'Avenida Dr André Papini de Gois - 177 - Cidade Universitária - Maceió', N'1', N'0', N'2', N'2', N'Cidade Universitária', N'-9.5539008', N'-35.7461255')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'306', N'27055647', N'CMEI PROFESSORA ALBENE CLARINDO DUARTE ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290440', NULL, N'SISLAME', NULL, N'57045450', N'RUA DR FRANCISCO AGUIRRE CAMARGO - S/N - BARRO DURO - Maceió', N'1', N'0', N'2', N'1', N'Barro Duro', N'-9.65018809363235', N'-35.7435216350656')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'307', N'27055655', N'CMEI PROFESSORA MARIA ELISABETE DOS SANTOS VASCONCELOS ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290460', NULL, N'SISLAME', NULL, N'57075970', N'Av. Lourival Melo Mota - S/N - SANTOS DUMONT - Maceió', N'1', N'0', N'1', N'1', N'Santos Dumont', N'-9.5320076', N'-35.795684')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'308', N'27055663', N'CMEI PROFESSORA SIMONE FERREIRA SIMÃO ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290490', NULL, N'SISLAME', NULL, N'57061110', N'Avenida Maceió - 863 - TABULEIRO DO MARTINS - Maceió', N'1', N'0', N'2', N'1', N'Tabuleiro do Martins', N'-9.57157438499642', N'-35.7591512682408')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'309', N'27055671', N'CMEI PROFESSORA ANNE CLEIDE PIMENTEL BEZERRA ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290560', NULL, N'SISLAME', NULL, N'57083410', N'Avenida Menino Marcelo - 247 - ANTARES - Maceió', N'1', N'0', N'1', N'1', N'Antares', N'-9.55366498233322', N'-35.7093820021919')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'310', N'27055680', N'CMEI PROFESSORA ZAIRA NASCIMENTO DE OLIVEIRA - 27055680 INEP ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290590', NULL, N'SISLAME', NULL, N'57018534', N'Travessa Jatobá - 37 - Chã da Jaqueira - Maceió', N'1', N'0', N'2', N'1', N'Chã da Jaqueira', N'-9.6191507', N'-35.7463003')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'311', N'27055698', N'CMEI PROFESSORA IVANEIDE MARIA SANTANA FARIAS ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290610', NULL, N'SISLAME', NULL, N'57086037', N'Conjunto Cidade Sorriso 1 - S/N - BENEDITO BENTES - Maceió', N'1', N'0', N'2', N'1', N'Benedito Bentes', N'-9.5859671', N'-35.7150116')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'312', N'27055701', N'CMEI PROFESSORA NADIR BRANDÃO CAVALCANTE ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290640', NULL, N'SISLAME', NULL, N'57039800', N'RUA DA IGREJA - SN - IPIOCA - Maceió', N'1', N'0', N'2', N'1', N'Ipioca', N'-9.5525095118403', N'-35.6285154292651')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'313', N'27055710', N'CMEI PROFESSORA CLEIDE GOMES CORDEIRO DA SILVA ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290660', NULL, N'SISLAME', NULL, N'57030592', N'RUA ANGELO MARTINS - 270 - PONTA DA TERRA - Maceió', N'1', N'0', N'1', N'1', NULL, NULL, NULL)
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'314', N'27055728', N'CMEI ESTUDANTE JOAO PEDRO DA SILVA BERNARDINO ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290690', NULL, N'SISLAME', NULL, N'57045811', N'Rua Boa Vista - S/N - OURO PRETO - Maceió', N'1', N'0', N'1', N'1', N'Ouro Preto', N'-9.57104080676541', N'-35.7451496927926')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'315', N'27055736', N'CMEI DESEMBARGADOR JOSE FERNANDO DE LIMA SOUZA ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290710', NULL, N'SISLAME', NULL, N'57020510', N'RUA BARÃO DE ATALAIA - 823 - CENTRO - Maceió', N'1', N'0', N'1', N'1', N'Centro', N'-9.6647296', N'-35.7385312')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'316', N'27056511', N'CMEI PROFESSORA LUCINEIDE GOMES FLOR', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290740', NULL, N'SISLAME', NULL, N'57017692', N'RUA FAUSTINO DA SILVEIRA - 68 - BEBEDOURO - Maceió', N'1', N'0', N'2', N'1', N'Bebedouro', N'-9.6232608', N'-35.7516398')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'317', N'27056520', N'CMEI PROFESSORA CLAUDIA MARIA DA SILVA BRASIL', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290760', NULL, N'SISLAME', NULL, N'57073000', N'AV EMPRESÁRIO NELSON OLIVEIRA MENEZES - 1323 - CIDADE UNIVERSITARIA - Maceió', N'1', N'0', N'1', N'1', N'Cidade Universitária', N'-9.5539008', N'-35.7461255')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'318', N'27215253', N'CMEI PADRE SILVESTRE VREDEGOOR', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290790', NULL, N'SISLAME', NULL, N'57010020', N'PARQUE AFRÂNIO JORGE - S/N - PRADO - Maceió', N'1', N'0', N'2', N'1', N'Prado', N'-9.6823321378845', N'-35.7375926223515')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'319', N'27215873', N'ESCOLA MUNICIPAL LINDOLFO COLLOR ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290810', NULL, N'SISLAME', NULL, N'57014510', N'AV. GOV. THEOBALDO BARBOSA - S/N - VERGEL DO LAGO - Maceió', N'1', N'0', N'2', N'1', NULL, NULL, NULL)
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'320', N'27216179', N'ESCOLA MUNICIPAL DOM MIGUEL FENELLON CÂMARA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290840', NULL, N'SISLAME', NULL, N'57062417', N'CONJ. JARDIM PETRÓPOLIS II - SN - PETRÓPOLIS - Maceió', N'1', N'0', N'2', N'1', N'Petrópolis', N'-9.56526147296053', N'-35.7192611198076')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'321', N'27216390', N'ESCOLA MUNICIPAL ZUMBI DOS PALMARES', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290860', NULL, N'SISLAME', NULL, N'57071470', N'CONJ. ROSANE COLLOR QD M - SN - CLIMA BOM - Maceió', N'1', N'0', N'2', N'1', N'Clima Bom', N'-9.58177105810685', N'-35.7375960983266')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'322', N'27216446', N'ESCOLA MUNICIPAL MARIA CARMELITA CARDOSO GAMA ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290880', NULL, N'SISLAME', NULL, N'57072900', N'CAMPUS A.C. SIMÕES -  - CIDADE UNIVERSITÁRIA - Maceió', N'1', N'0', N'2', N'1', N'Cidade Universitária', N'-9.5552291', N'-35.7781208')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'323', N'27216489', N'ESCOLA MUNICIPAL PROFESSORA NEIDE DE FREITAS FRANÇA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290910', NULL, N'SISLAME', NULL, N'57039703', N'POVOADO SAÚDE - IPIOCA - 303 - IPIOCA - Maceió', N'1', N'0', N'2', N'1', N'Ipioca', N'-9.54774201029977', N'-35.630462718136')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'324', N'27216977', N'ESCOLA MUNICIPAL TRADUTOR JOÃO SAMPAIO', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290930', NULL, N'SISLAME', NULL, N'57062636', N'RUA PERIMETRAL 5 - S/N - CONJ. JOÃO SAMPAIO I - Maceió', N'1', N'0', N'2', N'1', N'Petrópolis', N'-9.56240286716157', N'-35.7170995366023')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'325', N'27217221', N'ESCOLA DE ENSINO FUNDAMENTAL NOSSA SENHORA APARECIDA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290950', NULL, N'SISLAME', NULL, N'57010324', N'RUA PROFESSORA MARIA JOSÉ LOUREIRO LIMA - 200 - PRADO - Maceió', N'1', N'0', N'2', N'1', N'Prado', N'-9.67897980407205', N'-35.7341752064409')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'326', N'27218155', N'ESCOLA DE ENSINO FUNDAMENTAL LUIZ PEDRO DA SILVA I ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4290980', NULL, N'SISLAME', NULL, N'57062195', N'RUA DEPUTADO JOSÉ BERNARDES - 10 - PETRÓPOLIS - Maceió', N'1', N'0', N'2', N'1', N'Petrópolis', N'-9.56780593897751', N'-35.7237040532976')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'327', N'27219585', N'ESCOLA MUNICIPAL PROFESSORA HÉVIA VALÉRIA MAIA AMORIM', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291000', NULL, N'SISLAME', NULL, N'57073490', N'CONJ. VILLAGE CAMPESTRE I -  - TABULEIRO - Maceió', N'1', N'0', N'2', N'1', N'Cidade Universitária', N'-9.5539008', N'-35.7461255')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'328', N'27222373', N'ESCOLA DE ENSINO FUNDAMENTAL NOSSO LAR I', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291080', NULL, N'SISLAME', NULL, N'57014830', N'RUA PROFESSOR MARIO BROAD - 36 - LEVADA - Maceió', N'1', N'0', N'2', N'1', NULL, NULL, NULL)
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'329', N'27222446', N'CMEI BRENO AGRA ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291100', NULL, N'SISLAME', NULL, N'57084048', N'AV. ARTHUR VALENTE JUCÁ -  - BENEDITO BENTES I - Maceió', N'1', N'0', N'2', N'1', N'Benedito Bentes', N'-9.5859671', N'-35.7150116')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'330', N'27222454', N'CMEI LEDA COLLOR DE MELLO ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291120', NULL, N'SISLAME', NULL, N'57010000', N'RUA EM PROJETO, CONJ. OSMAN LOUREIRO - s/n - TABULEIRO DO MARTINS - Maceió', N'1', N'0', N'2', N'1', N'Prado', N'-9.68180775542992', N'-35.7314916418578')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'331', N'27222462', N'CRECHE LINDOLFO COLLOR', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291150', NULL, N'SISLAME', NULL, N'57014618', N'AVENIDA THEOBALDO BARBOSA - S/N - Vergel do Lago - Maceió', N'1', N'0', N'2', N'1', NULL, NULL, NULL)
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'332', N'27222470', N'CMEI BENEVIDES EPAMINONDAS DA SILVA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291170', NULL, N'SISLAME', NULL, N'57039230', N'AVENIDA GENERAL DE FRANÇA - 1585   - RIACHO DOCE - Maceió', N'1', N'0', N'2', N'1', N'Riacho Doce', N'-9.5818942343826', N'-35.648209337093')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'333', N'27222489', N'CRECHE ROSANE COLLOR', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291200', NULL, N'SISLAME', NULL, N'57041540', N'RUA JOSE REIS CAMPOS - s/n - JACINTINHO - Maceió', N'1', N'0', N'2', N'1', N'Jacintinho', N'-9.6365709', N'-35.7110774')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'334', N'27222497', N'CMEI MARIA LIEGE TAVARES DE ALBUQUERQUE', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291220', NULL, N'SISLAME', NULL, N'57040510', N'RUA SÃO JOSÉ - SN - JACINTINHO - Maceió', N'1', N'0', N'2', N'1', N'Jacintinho', N'-9.6365709', N'-35.7110774')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'335', N'27222500', N'CMEI TEREZA DE LISIEUX', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291250', NULL, N'SISLAME', NULL, N'57017140', N'RUA CÍCERO TORRES - S/N - LEVADA - Maceió', N'1', N'0', N'2', N'1', N'Levada', N'-9.67517454245763', N'-35.7400560480257')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'336', N'27222519', N'CRECHE SUZANA PALMEIRA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291270', NULL, N'SISLAME', NULL, N'57010050', N'RUA ALVARO MARINHO - 855/2 - PRADO - Maceió', N'1', N'0', N'2', N'1', N'Prado', N'-9.6792718577233', N'-35.7372654201523')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'337', N'27222527', N'CMEI HERMÉ MIRANDA  ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291290', NULL, N'SISLAME', NULL, N'57081510', N'R. PEDROSA - 203 - TABULEIRO - Maceió', N'1', N'0', N'2', N'1', N'Tabuleiro do Martins', N'-9.5683657871304', N'-35.7562344588648')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'338', N'27222861', N'CMEI AGENOR FERNANDES PONTES ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291320', NULL, N'SISLAME', NULL, N'57070440', N'VILA GOIABEIRA - 132 - FERNÃO VELHO - Maceió', N'1', N'0', N'2', N'1', N'Fernão Velho', N'-9.60386220532486', N'-35.7820709277773')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'339', N'27222900', N'ESCOLA MUNICIPAL DRA ELIZABETH ANNE LYRA LOPES DE FARIAS', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291340', NULL, N'SISLAME', NULL, N'57015320', N'R. ROBERT LYRA - 04 - BENEDITO BENTES - Maceió', N'1', N'0', N'2', N'1', N'Vergel do Lago', N'-9.67346743474962', N'-35.7538300209766')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'340', N'27222926', N'CMEI JOSÉ MARIA DE MELO ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291370', NULL, N'SISLAME', NULL, N'57084780', N' RUA BELO HORIZONTE - SN - BENEDITO BENTES - Maceió', N'1', N'0', N'2', N'1', N'Benedito Bentes', N'-9.5859671', N'-35.7150116')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'341', N'27222934', N'CMEI VICE-GOVERNADOR FRANCISCO MELLO', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291390', NULL, N'SISLAME', NULL, N'57010480', N'CONJ. VIRGEM DOS POBRES - S/N - VERGEL DO LAGO - Maceió', N'1', N'0', N'2', N'1', N'Trapiche da Barra', N'-9.68700456795329', N'-35.7471657410068')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'342', N'27222942', N'ESCOLA MUNICIPAL DOM HELDER CÂMARA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291420', NULL, N'SISLAME', NULL, N'57043230', N'RUA ACRE - S/N - FEITOSA - Maceió', N'1', N'0', N'2', N'1', N'Feitosa', N'-9.6306916', N'-35.7256452')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'343', N'27224660', N'ESCOLA MUNICIPAL SELMA BANDEIRA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291440', NULL, N'SISLAME', NULL, N'57086236', N'CONJ SELMA BANDEIRA -  - BENEDITO BENTES - Maceió', N'1', N'0', N'2', N'1', N'Benedito Bentes', N'-9.5859671', N'-35.7150116')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'344', N'27224775', N'ESCOLA MUNICIPAL DOUTORA NISE DA SILVEIRA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291460', NULL, N'SISLAME', NULL, N'57048140', N'LOTEAMENTO TERRA DE ANTARES I - SN - SERRARIA - Maceió', N'1', N'0', N'2', N'1', N'Antares', N'-9.54823278541899', N'-35.7094791621512')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'345', N'27224783', N'ESCOLA MUNICIPAL CÍCERA LUCIMAR DE SENA SANTOS', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291490', NULL, N'SISLAME', NULL, N'57025570', N'Rua José Maria de Lima, antiga 26 de abril - 222 - Poço - Maceió', N'1', N'0', N'2', N'1', N'Poço', N'-9.6586248', N'-35.717677')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'346', N'27225011', N'ESCOLA MUNICIPAL PROFESSORA ELMA MARQUES CURTI', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291510', NULL, N'SISLAME', NULL, N'57084649', N'AV. BENEDITO BENTES -  - BENEDITO BENTES II - Maceió', N'1', N'0', N'2', N'1', N'Benedito Bentes', N'-9.5859671', N'-35.7150116')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'347', N'27225283', N'CMEI PROFESSORA MARIA NILDA DOS SANTOS SILVA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291580', NULL, N'SISLAME', NULL, N'57018445', N'RUA SÃO FRANCISCO DE ASSIS -  - CHÃ DA JAQUEIRA - Maceió', N'1', N'0', N'2', N'1', N'Chã da Jaqueira', N'-9.616444', N'-35.7459655')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'348', N'27225291', N'CMEI PROFESSORA RUTH BRAGA QUINTELA CAVALCANTE', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291610', NULL, N'SISLAME', NULL, N'57041620', N'RUA PASTOR EURICO CALHEIROS - 502 - JACINTINHO - Maceió', N'1', N'0', N'2', N'1', N'Jacintinho', N'-9.6384785', N'-35.7124853')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'349', N'27225348', N'CMEI PROFESSOR PAULO FREIRE', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291630', NULL, N'SISLAME', NULL, N'57044098', N'AV. JOSÉ AIRTON GONDIM LAMENHA -  -  SÃO JORGE - Maceió', N'1', N'0', N'2', N'1', NULL, NULL, NULL)
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'350', N'27225542', N'ESCOLA MUNICIPAL PROFESSOR PETRÔNIO VIANA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291660', NULL, N'SISLAME', NULL, N'57010000', N'CONJUNTO CARMINHA -  - BENEDITO BENTES - Maceió', N'1', N'0', N'2', N'1', N'Prado', N'-9.67895638898082', N'-35.7384799754209')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'351', N'27225879', N'ESCOLA MUNICIPAL PROFESSOR AURÉLIO BUARQUE DE HOLANDA FERREIRA ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291680', NULL, N'SISLAME', NULL, N'57086412', N'CONJ. FREITAS NETO - S/N - BENEDITO BENTES - Maceió', N'1', N'0', N'2', N'1', N'Benedito Bentes', N'-9.5859671', N'-35.7150116')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'352', N'27226298', N'ESCOLA DE ENSINO FUNDAMENTAL LUIZ PEDRO DA SILVA II ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291710', NULL, N'SISLAME', NULL, N'57010000', N'RUA NADJA ABYS FRANÇA - 32 - CLIMA BOM - Maceió', N'1', N'0', N'2', N'1', N'Prado', N'-9.68302957795266', N'-35.7367306974047')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'353', N'27226301', N'ESCOLA DE ENSINO FUNDAMENTAL LUIZ PEDRO DA SILVA IV', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291730', NULL, N'SISLAME', NULL, N'57082000', N'COMPLEXO RESIDENCIAL GAMA LINS -  - CIDADE UNIVERSITÁRIA - Maceió', N'1', N'0', N'2', N'1', N'Santa Lúcia', N'-9.5865536', N'-35.7586476')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'354', N'27226360', N'ESCOLA MUNICIPAL PROFESSORA GERUZA COSTA LIMA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291760', NULL, N'SISLAME', NULL, N'57010000', N'RUA SANTA MARGARIDA - 222 - JACINTINHO - Maceió', N'1', N'0', N'2', N'1', N'Prado', N'-9.68111673153711', N'-35.7347595358972')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'355', N'27226379', N'ESCOLA MUNICIPAL FREI DAMIÃO', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291780', NULL, N'SISLAME', NULL, N'57085778', N'AV MUNDAÚ - 120 - BENEDITO BENTES - Maceió', N'1', N'0', N'2', N'1', N'Benedito Bentes', N'-9.5859671', N'-35.7150116')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'356', N'27226409', N'ESCOLA MUNICIPAL DOUTOR DENISSON LUIZ CERQUEIRA MENEZES', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291800', NULL, N'SISLAME', NULL, N'57073639', N'CONJ. DENISSON MENEZES -  - TABULEIRO - Maceió', N'1', N'0', N'2', N'1', N'Cidade Universitária', N'-9.5539008', N'-35.7461255')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'357', N'27226417', N'ESCOLA MUNICIPAL PROFESSORA MARIA JOSÉ CARRASCOSA ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291830', NULL, N'SISLAME', NULL, N'57025650', N'RUA DIEGUES JUNIOR - 224 - POÇO - Maceió', N'1', N'0', N'2', N'1', N'Poço', N'-9.6586248', N'-35.717677')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'358', N'27226425', N'CMEI MESTRE MÁRIO IZALDINO', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291850', NULL, N'SISLAME', NULL, N'57010000', N'AV SENADOR ARNON DE MELLO - 25 - PONTAL DA BARRA - Maceió', N'1', N'0', N'2', N'1', N'Prado', N'-9.68172969643873', N'-35.738029356439')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'359', N'27226506', N'CMEI PROFESSORA KYRA MARIA BARROS PAES ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291880', NULL, N'SISLAME', NULL, N'57071130', N'RUA MUNIZ FALCÃO -  - CLIMA BOM - Maceió', N'1', N'0', N'2', N'1', N'Clima Bom', N'-9.57691549313523', N'-35.741253467185')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'360', N'27226603', N'ESCOLA MUNICIPAL PAULO HENRIQUE COSTA BANDEIRA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291900', NULL, N'SISLAME', NULL, N'57084650', N'RUA NORMA PIMENTEL DA COSTA - 11 - BENEDITO BENTES - Maceió', N'1', N'0', N'2', N'1', N'Benedito Bentes', N'-9.5859671', N'-35.7150116')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'361', N'27226611', N'ESCOLA MUNICIPAL PROFESSORA NATALINA COSTA CAVALCANTE', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291930', NULL, N'SISLAME', NULL, N'57081132', N'RUA ROTARY -  - TABULEIRO DO MARTINS - Maceió', N'1', N'0', N'2', N'1', N'Tabuleiro do Martins', N'-9.56869944977204', N'-35.7598450289292')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'362', N'27226743', N'CMEI SÃO SEBASTIÃO', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291950', NULL, N'SISLAME', NULL, N'57010140', N'RUA EDGAR DE GOES MONTEIRO  - 817 - PRADO - Maceió', N'1', N'0', N'2', N'1', N'Prado', N'-9.68198684118247', N'-35.7383476048007')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'363', N'27226980', N'ESCOLA MUNICIPAL MARIA DE FÁTIMA LYRA ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4291970', NULL, N'SISLAME', NULL, N'57084025', N'BENEDITO BENTES I RUA A VINTE E CINCO - 310 - BENEDITO BENTES - Maceió', N'1', N'0', N'2', N'1', N'Benedito Bentes', N'-9.5859671', N'-35.7150116')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'364', N'27226999', N'ESCOLA MUNICIPAL MARIA DE LOURDES DE MELO PIMENTEL', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292000', NULL, N'SISLAME', NULL, N'57010000', N'RUA PADRE CÍCERO - 05 - CIDADE UNIVERSITARIA - Maceió', N'1', N'0', N'2', N'1', N'Prado', N'-9.68106434780435', N'-35.737972946011')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'365', N'27227073', N'ESCOLA MUNICIPAL OCTÁVIO BRANDÃO', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292020', NULL, N'SISLAME', NULL, N'57061100', N'RUA JOSE LOBO DE MEDEIROS -  - TABULEIRO - Maceió', N'1', N'0', N'2', N'1', N'Tabuleiro do Martins', N'-9.56848951767931', N'-35.7630101689275')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'366', N'27227081', N'CMEI CASA DA AMIZADE ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292040', NULL, N'SISLAME', NULL, N'57010000', N'AV. VEREADOR DARIO MARSIGLIA - 300 - TABULEIRO - Maceió', N'1', N'0', N'2', N'1', N'Prado', N'-9.67880392213741', N'-35.7377867045641')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'367', N'27227090', N'ESCOLA MUNICIPAL PADRE BRANDÃO LIMA ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292150', NULL, N'SISLAME', NULL, N'57084700', N'AVENIDA CACHOEIRA DO MEIRIM - S/N - BENEDITO BENTES - Maceió', N'1', N'0', N'2', N'1', N'Benedito Bentes', N'-9.5859671', N'-35.7150116')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'368', N'27230066', N'ESCOLA MUNICIPAL PIO X', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292170', NULL, N'SISLAME', NULL, N'57010324', N'RUA PROFESSORA MARIA JOSÉ LOUREIRO LIMA - 200 - PRADO - Maceió', N'1', N'0', N'2', N'1', N'Prado', N'-9.68208206861178', N'-35.7334387759458')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'369', N'27230074', N'ESCOLA MUNICIPAL PROFESSORA SILVIA CELINA NUNES LIMA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292200', NULL, N'SISLAME', NULL, N'57073510', N'RUA BENEDITO CALAÇA LOUREIRO - 2001 - CIDADE UNIVERSITÁRIA - Maceió', N'1', N'0', N'2', N'1', N'Cidade Universitária', N'-9.5539008', N'-35.7461255')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'370', N'27230082', N'ESCOLA MUNICIPAL MARCOS SORIANO', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292220', NULL, N'SISLAME', NULL, N'57062572', N'CONJ. JARDIM PETROPÓLIS II B -  - PETRÓPOLIS - Maceió', N'1', N'0', N'2', N'1', N'Petrópolis', N'-9.56889808179245', N'-35.7176014453428')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'371', N'27230090', N'ESCOLA MUNICIPAL BENEDITA DA SILVA SANTOS ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292250', NULL, N'SISLAME', NULL, N'57084610', N'AV ARTHUR VALENTE JUCA - 557 - BENEDITO BENTES - Maceió', N'1', N'0', N'2', N'1', N'Benedito Bentes', N'-9.5859671', N'-35.7150116')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'372', N'27230104', N'ESCOLA MUNICIPAL CESAR AUGUSTO DE OLIVEIRA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292270', NULL, N'SISLAME', NULL, N'57075570', N'R. BOA ESPERANÇA -  - SANTOS DUMONT - Maceió', N'1', N'0', N'2', N'1', N'Santos Dumont', N'-9.5320076', N'-35.795684')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'373', N'27230112', N'ESCOLA MUNICIPAL JAIME AMORIM MIRANDA ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292290', NULL, N'SISLAME', NULL, N'57082000', N'AV BELMIRO AMORIM  - 760 - TABULEIRO - Maceió', N'1', N'0', N'2', N'1', N'Santa Lúcia', N'-9.5865536', N'-35.7586476')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'374', N'27230120', N'ESCOLA MUNICIPAL OLAVO BILAC', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292320', NULL, N'SISLAME', NULL, N'57043000', N'RUA GOVERNADOR LAMENHA FILHO - SN - FEITOSA - Maceió', N'1', N'0', N'2', N'1', N'Feitosa', N'-9.6306916', N'-35.7256452')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'375', N'27230139', N'ESCOLA MUNICIPAL YEDA OLIVEIRA DOS SANTOS', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292340', NULL, N'SISLAME', NULL, N'57073360', N'AV JOSÉ CAMELO DE FREITAS - 595 - CIDADE UNIVERSITARIA - Maceió', N'1', N'0', N'2', N'1', N'Cidade Universitária', N'-9.5539008', N'-35.7461255')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'376', N'27230147', N'CMEI HELOÍSA MARINHO DE GUSMÃO MEDEIROS ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292370', NULL, N'SISLAME', NULL, N'57086171', N'AVENIDA MOACIR ANDRADE -  - BENEDITO BENTES II - Maceió', N'1', N'0', N'2', N'1', N'Benedito Bentes', N'-9.5859671', N'-35.7150116')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'377', N'27230155', N'ESCOLA MUNICIPAL PROFESSORA MARILUCIA MACEDO DOS SANTOS', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292390', NULL, N'SISLAME', NULL, N'57042030', N'RUA ANTÔNIO ZEFERINO DOS SANTOS - 20 - JACINTINHO - Maceió', N'1', N'0', N'2', N'1', N'Jacintinho', N'-9.6384785', N'-35.7124853')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'378', N'27230163', N'CMEI PROFESSORA MARIA DE FÁTIMA MELO DOS SANTOS ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292410', NULL, N'SISLAME', NULL, N'57061110', N'AVENIDA MACEIO       - 342 - TABULEIRO - Maceió', N'1', N'0', N'2', N'1', N'Tabuleiro do Martins', N'-9.57167852130199', N'-35.7601891326778')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'379', N'27230171', N'ESCOLA MUNICIPAL MONSENHOR ANTÔNIO ASSUNÇÃO ARAÚJO', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292440', NULL, N'SISLAME', NULL, N'57046161', N'RUA ARACI MARTINS DA SILVA - 04 - SERRARIA - Maceió', N'1', N'0', N'2', N'1', N'Serraria', N'-9.5945808', N'-35.7280492')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'380', N'27230201', N'ESCOLA MUNICIPAL PROFESSORA MARIZETTE CORREIA NUNES BRUNO', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292460', NULL, N'SISLAME', NULL, N'57010000', N'AVENIDA MENINO MARCELO LOTEAMENTO CASA FORTE  - 08 - SERRARIA - Maceió', N'1', N'0', N'2', N'1', N'Prado', N'-9.67841169043449', N'-35.7317200444119')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'381', N'27230236', N'ESCOLA MUNICIPAL PROFESSORA ZILKA DE OLIVEIRA GRAÇA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292530', NULL, N'SISLAME', NULL, N'57061060', N'RUA JOSÉ GONZAGA DE ALMEIDA - 276 - TABULEIRO DO MARTINS - Maceió', N'1', N'0', N'2', N'1', N'Tabuleiro do Martins', N'-9.56707308219645', N'-35.7594023343747')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'382', N'27230244', N'CMEI PROFESSORA MARIA DO SOCORRO TAVARES LIMA DA SILVA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292560', NULL, N'SISLAME', NULL, N'57010000', N'RUA CARLOS DE MIRANDA - 257 - POÇO - Maceió', N'1', N'0', N'2', N'1', N'Prado', N'-9.68233059517171', N'-35.7330946156743')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'383', N'27230376', N'ESCOLA MUNICIPAL CÍCERO DUÉ DA SILVA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292580', NULL, N'SISLAME', NULL, N'57073460', N'AV. MENINO MARCELO - 1391 - CIDADE UNIVERTÁRIA - Maceió', N'1', N'0', N'2', N'1', N'Cidade Universitária', N'-9.5539008', N'-35.7461255')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'384', N'27230384', N'CMEI JORGE DE LIMA ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292610', NULL, N'SISLAME', NULL, N'57082000', N'AV. BELMIRO AMORIM - 1750 - SANTA LÚCIA - Maceió', N'1', N'0', N'2', N'1', N'Santa Lúcia', N'-9.5865536', N'-35.7586476')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'385', N'27230392', N'ESCOLA MUNICIPAL PROFESSORA MARIA JOSÉ CLEMENTE ROCHA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292630', NULL, N'SISLAME', NULL, N'57025673', N'RUA A 5 - 47 - BENEDITO BENTES  - Maceió', N'1', N'0', N'2', N'1', N'Poço', N'-9.6586248', N'-35.717677')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'386', N'27230406', N'ESCOLA MUNICIPAL PROFESSORA CLAUDINETE BATISTA DA SILVA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292660', NULL, N'SISLAME', NULL, N'57010376', N'R. ARY PITOMBO - 290 - TRAPICHE - Maceió', N'1', N'0', N'2', N'1', N'Trapiche da Barra', N'-9.6880427971936', N'-35.7459263779812')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'387', N'27230422', N'CMEI TOBIAS GRANJA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292680', NULL, N'SISLAME', NULL, N'57071820', N'AV. JORN. TEOFILO A. LINS -  - CLIMA BOM - Maceió', N'1', N'0', N'2', N'1', N'Clima Bom', N'-9.58382324823213', N'-35.7360674005005')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'388', N'27230457', N'CMEI HERBERT DE SOUZA  ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292710', NULL, N'SISLAME', NULL, N'57010000', N'AV. GAL LUIZ DE FRANÇA ALBUQUERQUE - s/n - JACARECICA - Maceió', N'1', N'0', N'2', N'1', N'Prado', N'-9.68112661072629', N'-35.7314143293695')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'389', N'27230511', N'CMEI VEREADOR BRAGA NETO', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292730', NULL, N'SISLAME', NULL, N'57061070', N'RUA ELIETE ROLEMBERG DE FIGUEIREDO - 163 - TABULEIRO DOS MARTINS - Maceió', N'1', N'0', N'2', N'1', N'Tabuleiro do Martins', N'-9.56612851242515', N'-35.7637679909151')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'390', N'27230570', N'ESCOLA MUNICIPAL PEDRO BARBOSA JÚNIOR', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292750', NULL, N'SISLAME', NULL, N'57038130', N'RUA ARNALDO BRAGA  -  - CRUZ DAS ALMAS - Maceió', N'1', N'0', N'2', N'1', N'Cruz das Almas', N'-9.6647625', N'-35.708704')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'391', N'27230678', N'CMEI PROFESSORA ELZA LIRA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292780', NULL, N'SISLAME', NULL, N'57086281', N'CONJ SELMA BANDEIRA -  - BENEDITO BENTES - Maceió', N'1', N'0', N'2', N'1', N'Benedito Bentes', N'-9.5859671', N'-35.7150116')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'392', N'27238601', N'ESCOLA MUNICIPAL MARIA CECILIA PONTES CARNAÚBA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292800', NULL, N'SISLAME', NULL, N'57048260', N'AV. GILBERTO SOARES PINTO - 763 - ANTARES I - Maceió', N'1', N'0', N'2', N'1', N'Antares', N'-9.55004915985304', N'-35.7121244137866')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'393', N'27240606', N'ESCOLA MUNICIPAL AUDIVAL AMÉLIO DA SILVA ', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292830', NULL, N'SISLAME', NULL, N'57044132', N'RUA ANA PAULA - SN - SÃO JORGE - Maceió', N'1', N'0', N'2', N'1', NULL, NULL, NULL)
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'394', N'27240800', N'ESCOLA MUNICIPAL RADIALISTA EDÉCIO LOPES', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292850', NULL, N'SISLAME', NULL, N'57062200', N'ALAMEDA CELIA DOS ANJOS -  Nº 06 - PETROPOLIS - Maceió', N'1', N'0', N'2', N'1', N'Petrópolis', N'-9.56879731405515', N'-35.7238417636864')
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'395', N'27241009', N'CMEI PROFESSOR RANILSON FRANÇA DE SOUZA', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292870', NULL, N'SISLAME', NULL, N'57014530', N'RUA PROF. MARIO BROAD - 36 - LEVADA - Maceió', N'1', N'0', N'2', N'1', NULL, NULL, NULL)
GO

INSERT INTO [siar_sa_sql].[Escolas] ([Id], [Inep], [Nome], [KitEscolar], [DataEntregaKitEscolar], [CompetenciaId], [DataCriacao], [DataUltimaAtualizacao], [FonteDados], [CodigoMunicipio], [CEP], [Endereco], [Localizacao], [LocalizacaoDiferenciada], [ParceriaPoderPublico], [SituacaoEscola], [Bairro], [Latitude], [Longitude]) VALUES (N'396', N'27245004', N'CMEI PRESIDENTE FRANCISCO DE PAULA RODRIGUES ALVES', N'0', NULL, N'4', N'2025-12-04 21:28:50.4292900', NULL, N'SISLAME', NULL, N'57084700', N'AV. CACHOEIRA DO MEIRIM -  - BENEDITO BENTES - Maceió', N'1', N'0', N'2', N'1', N'Benedito Bentes', N'-9.5859671', N'-35.7150116')
GO

SET IDENTITY_INSERT [siar_sa_sql].[Escolas] OFF
GO

COMMIT
GO


-- ----------------------------
-- Auto increment value for Escolas
-- ----------------------------
DBCC CHECKIDENT ('[siar_sa_sql].[Escolas]', RESEED, 396)
GO


-- ----------------------------
-- Indexes structure for table Escolas
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_Escolas_CompetenciaId]
ON [siar_sa_sql].[Escolas] (
  [CompetenciaId] ASC
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Escolas_InepCompetencia]
ON [siar_sa_sql].[Escolas] (
  [Inep] ASC,
  [CompetenciaId] ASC
)
WHERE ([Inep] IS NOT NULL)
GO


-- ----------------------------
-- Primary Key structure for table Escolas
-- ----------------------------
ALTER TABLE [siar_sa_sql].[Escolas] ADD CONSTRAINT [PK_Escolas] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table Escolas
-- ----------------------------
ALTER TABLE [siar_sa_sql].[Escolas] ADD CONSTRAINT [FK_Escolas_Competencias_CompetenciaId] FOREIGN KEY ([CompetenciaId]) REFERENCES [siar_sa_sql].[Competencias] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

