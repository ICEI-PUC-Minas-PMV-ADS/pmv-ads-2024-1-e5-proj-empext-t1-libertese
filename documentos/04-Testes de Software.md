# Plano de Testes de Software

## Objetivo

Garantir a funcionalidade, confiabilidade e segurança das telas de: 
- Cadastro de Usuário Administrador  
- Cadastro de Funcionário 
- Login

Os testes funcionais a serem realizados no aplicativo são descritos a seguir:  
 
  
| Caso de Teste           | Cadastro de Usuário Administrador                                                                                             |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Requisitos Associados    | RF-001	 - Permitir cadastro de usuário administrador        | 
|Objetivo do Teste        | Verificar se se o cadastro está sendo realizado corretamente.                                                            | 
|Passos                   | Acessar a tela de novo cadastro de administrador.                                                                       |
|Critérios de Êxito       | Inserir as informações nos padrões corretos.  |


| Caso de Teste           | Cadastro de Funcionário                                                                                           |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Requisitos Associados    | RF-002	Permitir cadastro de funcionários          | 
|Objetivo do Teste        | Verificar se se o cadastro está sendo realizado corretamente.                                                            | 
|Passos                   | Acessar a tela de novo cadastro de funcionário.                                                                       |
|Critérios de Êxito       | Inserir as informações nos padrões corretos.  |


| Caso de Teste           | Login                                                                                             |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Requisitos Associados    | RF-003	 - Login na plataforma        | 
|Objetivo do Teste        | Verificar se o login está sendo realizado corretamente                                                            | 
|Passos                   | Acessar a tela de login da aplicação                                                                   |
|Critérios de Êxito       | Inserir email/usuario e senha cadastrados na aplicação  |  

 
# Evidências de Testes de Software

## RF-001	 - Permitir cadastro de usuário administrador / RF-002	Permitir cadastro de funcionários 
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Cadastro1.jpeg)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Cadastro2.jpeg)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Cadastro3.jpeg)

## RF-003	 - Login na plataforma
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Login1.jpeg)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Login2.jpeg)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/NovaSenha1.jpeg)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/NovaSenha2.jpeg)


# Plano de Testes de Software (Em pares)

Teste da tela Empresas Parceiras | Feita por Cesar Luis Costa Moreira | Testes feitos por Douglas Delareti Simões

## Objetivo

Garantir a funcionalidade, confiabilidade e segurança das telas de: 
- CRUD Empresas Parceiras

Os testes funcionais a serem realizados no aplicativo são descritos a seguir:  
 
| Caso de Teste           | CT001 – Criar nova empresa parceira                                                                                             |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Empresas Parceiras       | 
|Procedimento             | 1. No menu selecione a opção “Empresas Parceiras”. |
|                         | 2. Na tela Empresas Parceiras, clique no botão “Cadastrar Empresa Parceira”. |
|                         | 3. Na tela de cadastro preencher todas as informações necessárias. |
|                         | 4. Clica em “Confirmar”. |
|Resultado Esperado       | A nova empresa parceira deve ser cadastrada com sucesso.                                                                       |
|Dados de Entrada         | Informações solicitadas no campo de cadastro.  |


| Caso de Teste           | CT002 – Criar nova empresa parceira com campos em branco ou dados inválidas                                                                                       |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Empresas Parceiras      | 
|Procedimento             | 1. No menu selecione a opção “Empresas Parceiras”. |
|                         | 2. Na tela Empresas Parceiras, clique no botão “Cadastrar Empresa Parceira”. |
|                         | 3. Na tela de cadastro preencher com informações invalidas ou deixar campos em branco. |
|                         | 4. Clica em “Salvar”. |
|Resultado Esperado       | Devem ser exibidas mensagens de erro na tela indicando campos em branco ou dados inválidos.                                                                      |
|Dados de Entrada         | Informações em branco ou dados inválidos.  |

| Caso de Teste           | CT003 – Visualizar Empresas Parceiras                                                                                     |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Empresas Parceiras      | 
|Procedimento             | 1. No menu seleciona a opção “Empresas Parceiras”. |
|Resultado Esperado       | Todas as informações das Empresas Parceiras serão exibidas.                                                                  |
|Dados de Entrada         |   |


| Caso de Teste | CT004 – Editar informações da Empresa Parceira |
|----------------|-------------------------|
| Pré Condições | Estar na tela de Empresas Parceiras   |
| Procedimento  | 1) No menu, selecione a opção “Empresas Parceiras”. |
|               | 3) Na tela de Empresas Parceiras, selecione a opção “Editar”. |
|               | 4) Na tela de Editar Empresa Parceira, edite a(s) informação(ões) desejada(as). |
|               | 5) Clique em “Salvar”. |
| Resultado esperado | As informações editadas devem ser atualizadas com sucesso e a data de atualização deve constar na tabela das Empresas Parceiras. |
| Dados de entrada | Informações que deseja atualizar |

| Caso de Teste | CT005 – Editar informações da Empresa Parceira com campos em branco ou dados inválidos |
|----------------|-------------------------|
| Pré Condições | Estar na tela de Empresas Parceiras   |
| Procedimento  | 1) No menu, selecione a opção “Empresas Parceiras”. |
|               | 3) Na tela de Empresas Parceiras, selecione a opção “Editar”. |
|               | 4) Na tela de Editar Empresa Parceira, deixe um ou mais campos em branco ou coloque dados inválidos. |
|               | 5) Clique em “Salvar”. |
| Resultado esperado |  Devem ser exibidas mensagens de erro na tela indicando campos em branco ou dados inválidos.  |
| Dados de entrada | Informações em branco ou dados inválidos.|


| Caso de Teste | CT006 – Deletar Empresa Parceira |
|----------------|-------------------------|
| Pré Condições | Estar na tela de Empresas Parceiras   |
| Procedimento  | 1) No menu, selecione a opção “Empresas Parceiras”. |
|               | 3) Na tela de Empresas Parceiras, selecione a opção “Deletar”. |
|               | 4) Na mensagem de confirmação clicar em “Excluir” confirmando assim a remoção do registro. |
| Resultado esperado | A empresa parceira selecionada deve ser removida da lista na página inicial |
| Dados de entrada | |

 
# Evidências de Testes de Software

## CT001 – Criar nova empresa parceira 
![Menu Empresa Parceira](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225367/6dffc46b-0b93-4967-af2b-db583fab75f7) 

![Cadastro Empresa Parceira](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225367/11e9d8e4-81aa-46be-9194-b30e3e69c242) 

![Cadastro Correto Empresa Parceira](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225367/a43a119d-35ae-4b85-b56c-51aeeaae22da) 

![Evidencia Cadastro Correto Empresa Parceira](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225367/b80d7e60-3289-4390-aa98-8a48d09191fa) 

## CT002 – Criar nova empresa parceira com campos em branco ou dados inválidas
![Menu Empresa Parceira](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225367/819e4df3-426f-4129-9eef-c10c8e640e53) 

![Erro Cadastro Empresa Parceira](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225367/a3404600-7a9a-4159-b242-a9d6b0d17948) 

## CT003 – Visualizar Empresas Parceiras
![Menu Empresa Parceira Editar](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225367/55dc99f5-eea3-44d9-8d47-e2a7e6f829b7) 

## CT004 – Editar informações da Empresa Parceira
![Menu Empresa Parceira Editar](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225367/d113ca74-e6b4-4226-8c1c-5edbcc15011a)

![Editar Correto Empresa Parceira](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225367/9a65b38b-b8a2-4e19-8b7c-7f8cfd179608)

![Evidencia Editar Correto Empresa Parceira](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225367/9fac8b50-2e16-4569-85fb-1cce177d508c)

## CT005 – Editar informações da Empresa Parceira com campos em branco ou dados inválidos
![Menu Empresa Parceira Atualizado](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225367/97523060-ba95-4837-89c1-d2ffae09c1ad)

![Erro Editar Empresa Parceira](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225367/7ad2a1e2-e9e4-4cd0-9d64-90647c308ff8)

## CT006 – Deletar Empresa Parceira
![Menu Empresa Parceira Atualizado](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225367/17f2047b-faf6-4f73-bf1c-867de88d845f)

![Deletar Empresa Parceira](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225367/54b0529b-b482-4f36-91ec-97bd2ec5abd9)

![Deletar Realizado](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225367/4c70f47e-7b8b-4b9a-a647-74279fc42cfd)


# Plano de Testes de Software (Em pares)

## Objetivo

Garantir a funcionalidade, confiabilidade e segurança das telas de: 
- DESPESAS

## Ferramentas utilizadas para os testes
- Visual studio 2021
- Google Chrome
- Cypress

## Responsáveis pelos testes e pelas funcionalidades desenvolvidas
- Responsável pelos testes a seguir: Rafael de Oliveira
- Telas desenvolvidas: CRUD Forma de Pagamento; CRUD Contas Bancárias; CRUD Classificação de Receita e Despesas - Testadas por: Thais
- Funcionalidades testadas: Despesas (Telas desenvolvidas por Vinicíus Ponciano)

## Testes Funcionais Realizados

Os testes funcionais a serem realizados no sistema Libertese são descritos a seguir:
Funcionalidades desenvolvidas por: Vinicius Ponciano
 
| Caso de Teste           | CT001 – Poder inserir uma nova classificação de Despesas - RF-XXXXX                                                           |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Despesas       | 
|Procedimento             | 1. No menu selecione a opção “+Classificação”. |
|                         | 2. Na tela Classificação de Despesas, insira o nome da Classificação e clique no botão "+". |
|                         | 3. Clicar em voltar, o sistema deve retornar para a tela de Despesas |
|Resultado Esperado       | A nova classificação deve ser inserida com sucesso, e o sistema deverá retornar para a página de Despesas                     |
|Dados de Entrada         | Informações solicitadas no campo de cadastro.  |


| Caso de Teste           | CT001 – Poder inserir uma nova Despesa - RF-XXXXX                                                                             |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Despesas       | 
|Procedimento             | 1. No menu selecione a opção “+Nova Despesa”. |
|                         | 2. Na tela Cadastro de Despesas, insira o nome da Despesa, selecione a classificação |
|                         | 3. Selecione o tipo de Despesas |
|                         | 4. Preencha o restante dos campos a serem informados |
|                         | 5. Clicar em "Confirmar" |
|Resultado Esperado       | Deverá ser inserido uma nova Despesa no sistema|
|Dados de Entrada         | Informações solicitadas no campo de Despesas.  |









