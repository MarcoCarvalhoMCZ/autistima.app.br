-- Verificar tabela ProfessionalSpecialties
SELECT TOP 20 * FROM [autistima_sa_sql].[ProfessionalSpecialties];

-- Contar registros
SELECT COUNT(*) AS TotalEspecialidades FROM [autistima_sa_sql].[ProfessionalSpecialties];

-- Verificar FK em Services (primeiros 5 com especialidade)
SELECT TOP 5 s.Id, s.NomeProfissional, s.EspecialidadeId, p.Nome AS NomeEspecialidade 
FROM [autistima_sa_sql].[Services] s
LEFT JOIN [autistima_sa_sql].[ProfessionalSpecialties] p ON s.EspecialidadeId = p.Id
WHERE s.EspecialidadeId IS NOT NULL;

-- Verificar FK em Users (primeiros 5 profissionais com especialidade)
SELECT TOP 5 u.Id, u.NomeCompleto, u.EspecialidadeId, p.Nome AS NomeEspecialidade, u.TipoPerfil
FROM [autistima_sa_sql].[Users] u
LEFT JOIN [autistima_sa_sql].[ProfessionalSpecialties] p ON u.EspecialidadeId = p.Id
WHERE u.EspecialidadeId IS NOT NULL;
