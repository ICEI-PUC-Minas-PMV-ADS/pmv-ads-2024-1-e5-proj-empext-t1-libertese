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

# Testes Automatizados

## Ferramenta de testes: NUnit.net (disponilizada para aplicações do .NET Framework)

Foram implementados testes de unidade automatizados, que cobrem os principais métodos das entidades de Categorias e Materiais.

| Caso de Teste           | CRUD de Materiais                                                                                           |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Requisitos Associados    | RF-007	Permitir criar,visualizar,editar e deletar Materiais.          | 
|Objetivo do Teste        | Verificar se as ações estão sendo realizadas corretamente.                                                            | 
|Passos                   | Acessar a tela de Produtos e clicar em "+ Materiais".                                                                       |
|Critérios de Êxito       | Inserir as informações nos padrões corretos.  |

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/dac92363-10b1-4480-aff2-c0c47e33f5af)

| Caso de Teste           | CRUD de Categorias                                                                                         |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Requisitos Associados    | RF-007	Permitir criar,visualizar,editar e deletar Categorias de Produtos.          | 
|Objetivo do Teste        | Verificar se as ações estão sendo realizadas corretamente.                                                            | 
|Passos                   | Acessar a tela de Produtos e clicar em "+ Categorias".                                                                       |
|Critérios de Êxito       | Inserir as informações nos padrões corretos.  |

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/7d043237-ddfa-4d4f-8132-445d7b65340b)

| Caso de Teste           | CRUD de Produtos                                                                                         |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Requisitos Associados    | RF-007	Permitir criar,visualizar,editar e deletar Produtos.          | 
|Objetivo do Teste        | Verificar se as ações estão sendo realizadas corretamente.                                                            | 
|Passos                   | Acessar a tela de Produtos e clicar em "+ Produtos".                                                                       |
|Critérios de Êxito       | Inserir as informações nos padrões corretos.  |

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/892388f9-0978-440c-9a07-569e5a61fc1f)




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
- CRUD de Materiais

## Ferramentas utilizadas para os testes
- Visual studio 2021
- Google Chrome

## Responsáveis pelos testes e pelas funcionalidades desenvolvidas
- Responsável pelos testes a seguir: Rafael de Oliveira
- Telas desenvolvidas: CRUD Forma de Pagamento; CRUD Contas Bancárias; CRUD Classificação de Receita e Despesas - Testadas por: Thais
- Funcionalidades testadas: Despesas (Telas desenvolvidas por Vinicíus Ponciano)

## Testes Funcionais Realizados

Os testes funcionais a serem realizados no sistema Libertese são descritos a seguir:
- Funcionalidades desenvolvidas por: Vinicius Ponciano
 
| Caso de Teste           | CT001 – Poder inserir uma nova classificação de Despesas - RF-010                                                            |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Despesas       | 
|Procedimento             | 1. No menu selecione a opção “+Classificação”. |
|                         | 2. Na tela Classificação de Despesas, insira o nome da Classificação e clique no botão "+". |
|                         | 3. Clicar em voltar, o sistema deve retornar para a tela de Despesas |
|Resultado Esperado       | A nova classificação deve ser inserida com sucesso, e o sistema deverá retornar para a página de Despesas                     |
|Dados de Entrada         | Informações solicitadas no campo de Classificação.  |


| Caso de Teste           | CT002 – Poder inserir uma nova Despesa - RF-010                                                                               |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Despesas       | 
|Procedimento             | 1. No menu selecione a opção “+Nova Despesa”. |
|                         | 2. Na tela Cadastro de Despesas, insira o nome da Despesa, selecione a classificação |
|                         | 3. Selecione o tipo de Despesas |
|                         | 4. Preencha o restante dos campos a serem informados |
|                         | 5. Clicar em "Confirmar" |
|Resultado Esperado       | Deverá ser inserido uma nova Despesa no sistema|
|Dados de Entrada         | Informações solicitadas no campo de Despesas.  |


| Caso de Teste           | CT003 – Permitir editar uma Despesa já cadastrada - RF-010                                                                   |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Despesas       | 
|Procedimento             | 1. Identificar a Despesa a ser alterada |
|                         | 2. Clicar no botão com o "lápis" para editar uma Despesa desejada|
|                         | 3. A tela de Editar Despesas deverá ser mostrada |
|                         | 4. Modificar as informações conforme desejado |
|                         | 5. Clicar em "Confirmar" |
|Resultado Esperado       | Deverá ser modificado uma Despesa no sistema|
|Dados de Entrada         | Informações solicitadas no campo Editar Despesas.  |


| Caso de Teste           | CT004 – Permitir apagar uma Despesa já cadastrada - RF-010                                                                   |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Despesas       | 
|Procedimento             | 1. Identificar a Despesa a ser apagada |
|                         | 2. Clicar no botão com uma "lixeira" para apagar uma Despesa desejada|
|                         | 3. Uma tela de "Ecluir Despesa" deverá ser mostrada |
|                         | 4. Clicar em "Cancelar" para retornar, ou em "Excluir" para confirmar a exclusão |
|Resultado Esperado       | Deverá ser excluído uma Despesa no sistema |
|Dados de Entrada         | Informações solicitadas na tela de Despesas |


| Caso de Teste           | CT005 – Inserir informações de Despesas com campos em branco ou dados inválidos- RF-010                                      |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Despesas       | 
|Procedimento             | 1. No menu selecione a opção “+Nova Despesa”. |
|                         | 2. Na tela de Despesas, verificar as informações necessárias |
|                         | 4. Clicar em "Confirmar" para salvar as alterações |
|Resultado Esperado       | Deverá ser informado os campos que não podem ficar em branco ou campos inválidos |
|Dados de Entrada         | Informações solicitadas na tela de Despesas |


- CRUD Materais

| Caso de Teste           | CT001 – Poder inserir uma novo Material - RF-005 / RF-006                                                                    |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Materiais        | 
|Procedimento             | 1. No menu selecione a opção “+Criar Material”. |
|                         | 2. Na tela de Novo Material, inserir as informações: Nome e preço|
|                         | 3. Clicar em "Salvar" |
|Resultado Esperado       | Deverá ser inserido uma novo Material no sistema|
|Dados de Entrada         | Informações solicitadas no campo de Materiais.  |


| Caso de Teste           | CT002 – Poder editar uma Material - RF-005 / RF-006                                                                         |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Materiais        | 
|Procedimento             | 1. No menu Index de Materiais, localizar qual material a ser editado |
|                         | 2. Clicar no botão "lápis" para editar um Material já existente|
|                         | 3. A tela Editar Material deverá ser criada|
|                         | 4. Clicar em "Salvar" para salvar as moficações no sistema |
|Resultado Esperado       | Deverá ser salvo uma modificação de Materiais no sistema|
|Dados de Entrada         | Informações solicitadas no campo de Materiais.  |


| Caso de Teste           | CT003 – Poder excluir uma Material - RF-005 / RF-006                                                                         |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Materiais        | 
|Procedimento             | 1. No menu Index de Materiais, localizar qual material a ser excluído |
|                         | 2. Clicar no botão "lixeira" para excluir um Material já existente|
|                         | 3. A tela de exclusão de Material deverá ser mostrada|
|                         | 4. Clicar em "Cancelar" para retornar, ou em "Excluir" para confirmar a exclusão |
|Resultado Esperado       | Deverá ser excluído um Material no sistema|
|Dados de Entrada         | Informações solicitadas no campo de Materiais.  |

| Caso de Teste           | CT004 – Poder Visualizar uma Material - RF-005 / RF-006                                                                         |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Materiais        | 
|Procedimento             | 1. No menu Index de Materiais, localizar qual material a ser visualizado |
|                         | 2. Clicar no botão "lupinha" para visualizar um Material já existente|
|                         | 3. A tela de visualização de Material deverá ser mostrada|
|Resultado Esperado       | Deverá ser somente mostrado um Material já cadastrado no sistema|
|Dados de Entrada         | Informações solicitadas no campo de Materiais.  |


## Evidências de Testes de Softwares - Tela Despesas

- CT001 – Poder inserir uma nova classificação de Despesas - RF-010
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/2705378f-0074-4061-b774-72bdd6e65eca)
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/5c29873b-c9f1-48a9-910d-56a74305a817)

- CT002 – Poder inserir uma nova Despesa - RF-010
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/321f2a3c-1877-451a-b99d-154ae3353cc5)

- CT003 – Permitir editar uma Despesa já cadastrada - RF-010
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/73b1a4a1-73d6-4f6f-9dcb-49200e1c4969)
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/4f957f46-1075-4377-a36e-819c47eddafc)

- CT004 – Permitir apagar uma Despesa já cadastrada - RF-010
  ![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/18bada74-1097-4f26-83bf-abd818a258d6)
  ![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/6d5e75a1-0248-4390-8d5c-daa6020b5a24)

- CT005 – Inserir informações de Despesas com campos em branco ou dados inválidos- RF-010
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/38623fbe-9e7c-4092-8fd4-ef99d525d7ce)


## Evidências de Testes de Softwares - CRUD de Materiais
- CT001 – Poder inserir uma novo Material - RF-005 / RF-006
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/5140a637-a656-4245-a480-4cd4f4b5db03)
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/0b16f555-fa64-4713-aac4-4eb7e7cb19af)

- CT002 – Poder editar uma Material - RF-005 / RF-006
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/b725b0cf-2f0e-486d-8722-8dea4275bcd1)
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/7b67dca2-34cd-4a91-8968-ab8fcd5154be)

- CT003 – Poder excluir uma Material - RF-005 / RF-006
- ![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/e7cd8a56-b702-40d9-8493-5fedc4bec121)
- ![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/a933d288-7b8f-4a13-8b48-ff45f3d0dd18)

- CT004 – Poder Visualizar uma Material - RF-005 / RF-006
- ![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/d7e2c900-bf35-4921-ae88-9e0c460bf569)
- ![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/f1476042-bf56-40c8-b174-0d71c8adb73b)



# Plano de Testes de Software (Em Pares)
##	Objetivo
Garantir a funcionalidade, confiabilidade e segurança nas telas de:
•	Relatórios

##	Ferramentas utilizadas para os testes
•	Visual Studio
•	Navegador Google Chrome

##	Responsáveis pelos testes e pelas funcionalidades desenvolvidas
Karinne Massensini, realizando testes nas funcionalidades desenvolvidas por: Pedro Ertal

##	Testes Unitários realizados
Os testes funcionais a serem realizados dentro do sistema Libertese são descritos a seguir:

| Caso de Teste           |	Relatório |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
| Requisitos Associados |	RF-014 Permitir gerar relatórios de venda |
| Objetivo do teste |	Verificar se as datas do campos na página de Relatório estão corretos |
| Passos e Procedimento |	Acessar a tela de Relatórios |
| Resultado esperado |	As datas estarem sincronizadas com os dados criados |

| Caso de Teste           |	Relatório Download |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
| Requisitos Associados |	RF-014 Permitir gerar relatórios de venda |
| Objetivo do teste |	Verificar se o arquivo com os dados do relatório desejado está sendo baixado |
| Passos e Procedimento |	Acessar a tela de Relatórios |
| Resultado esperado |	O arquivo será baixado com os dados esperados |

## Evidências de Testes de Softwares
RF-014 - Permitir gerar relatórios de venda

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/53317747/71e6b24b-56ba-4e6a-8708-1aef5489b084)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/53317747/53546f8f-23f4-482d-b20c-c939f522b3f1)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/53317747/00048b40-46aa-4c8c-af2b-96ea349691d2)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/53317747/1a771d29-c1f7-4671-81f4-5ab9b1d34b2d)



# Plano de Testes de Software (Em pares)

## Objetivo

Garantir a funcionalidade, confiabilidade e segurança das telas de: 
- CRUD Forma de Pagamento
- CRUD Contas Bancárias
- CRUD Classificação de Despesas e Receitas

## Ferramentas utilizadas para os testes
- Visual studio 2021
- Google Chrome

## Responsáveis pelos testes e pelas funcionalidades desenvolvidas
- Responsável pelos testes a seguir: Thaís Bezerra
- Telas desenvolvidas: Produtos e Materiais - Testadas por: Vinicius Ponciano
- Funcionalidades testadas: CRUD - Forma de Pagamento, Contas Bancárias, Classificação de Despesas e Receitas (Telas desenvolvidas por Rafael de Oliveira)

## Testes Funcionais Realizados - CRUD Forma de Pagamento

Os testes funcionais a serem realizados no sistema Libertese são descritos a seguir:
- Funcionalidades desenvolvidas por: Rafael de Oliveira
 
| Caso de Teste           | CT001 – Poder inserir uma nova Forma de Pagamento - RF-010 / RF-011                                                           |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela Forma de Pagamento | 
|Procedimento             | 1. No menu selecione a opção “Nova Forma de Pagamentos”. |
|                         | 2. Inserir as informações solicitadas |
|                         | 3. Clicar em salvar |
|Resultado Esperado       | A nova Forma de Pagamento deverá ser inserida com sucesso     |
|Dados de Entrada         | Informações solicitadas no campo de Forma de Pagamento.  |


| Caso de Teste           | CT002 – Inserir uma nova Forma de Pagamento com campos inválidos - RF-010 / RF-011                                            |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela Forma de Pagamento | 
|Procedimento             | 1. No menu selecione a opção “Nova Forma de Pagamentos”. |
|                         | 2. Inserir as informações solicitadas, ou deixar alguma informação em branco |
|                         | 3. Clicar em salvar |
|Resultado Esperado       | O sistema deverá retornar com os campos obrigatórios para as informações     |
|Dados de Entrada         | Informações solicitadas no campo de Forma de Pagamento.  |


| Caso de Teste           | CT003 – Poder excluir uma Forma de Pagamento - RF-010 / RF-011                                                           |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela Index Forma de Pagamento | 
|Procedimento             | 1. No menu clicar na opção "Excluir”. |
|                         | 2. O sistema deverá retornar uma caixa de confirmação da exclusão da Forma de Pagamento |
|                         | 3. Clicar em cancelar, para voltar, ou em "Excluir" para confirmar a ação |
|Resultado Esperado       | A exclusão deverá ser efetuada com sucesso |
|Dados de Entrada         | Informações solicitadas no campo de Forma de Pagamento.  |


| Caso de Teste           | CT004 – Poder editar uma Forma de Pagamento - RF-010 / RF-011                                                           |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela Index Forma de Pagamento | 
|Procedimento             | 1. No menu clicar na opção "Editar”. |
|                         | 2. O sistema deverá retornar já entrando no modo de edição |
|                         | 3. Editar as infomrações necessárias e clicar em "Salvar" |
|Resultado Esperado       | A modificação deverá ser efetuada com sucesso |
|Dados de Entrada         | Informações solicitadas no campo de Forma de Pagamento.  |


| Caso de Teste           | CT005 – Poder visualizar uma Forma de Pagamento - RF-010 / RF-011                                                           |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela Index Forma de Pagamento | 
|Procedimento             | 1. No menu clicar na opção "Detalhes” para visualizar uma Forma de Pagamento. |
|                         | 2. O sistema deverá retornar já entrando no modo de visualização |
|                         | 3. Visualizar as infomrações necessárias |
|Resultado Esperado       | A visualizaçaõ deverá ser mostrada com sucesso |
|Dados de Entrada         | Informações solicitadas no campo de Forma de Pagamento.  |


## Testes Funcionais Realizados - CRUD Contas Bancárias

| Caso de Teste           | CT001 – Poder inserir uma nova Conta Bancária - RF-010 / RF-011                                                           |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Contas Bancárias | 
|Procedimento             | 1. No menu selecione a opção “Criar Nova Conta Bancária”. |
|                         | 2. Inserir as informações solicitadas |
|                         | 3. Clicar em salvar |
|Resultado Esperado       | A nova Conta Bancária deverá ser inserida com sucesso     |
|Dados de Entrada         | Informações solicitadas no campo de Contas Bancárias.  |


| Caso de Teste           | CT002 – Inserir uma nova Conta Bancária com campos inválidos - RF-010 / RF-011                                            |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela Forma de Contas Bancárias | 
|Procedimento             | 1. No menu selecione a opção “Criar Nova Conta Bancária”. |
|                         | 2. Inserir as informações solicitadas, ou deixar alguma informação em branco |
|                         | 3. Clicar em salvar |
|Resultado Esperado       | O sistema deverá retornar com os campos obrigatórios para as informações     |
|Dados de Entrada         | Informações solicitadas no campo de Contas Bancárias.  |


| Caso de Teste           | CT003 – Poder excluir uma Conta Bancária - RF-010 / RF-011                                                              |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela Index Contas Bancárias | 
|Procedimento             | 1. No menu clicar na opção "Excluir”. |
|                         | 2. O sistema deverá retornar uma caixa de confirmação da exclusão da Conta Bancária |
|                         | 3. Clicar em cancelar, para voltar, ou em "Excluir" para confirmar a ação |
|Resultado Esperado       | A exclusão deverá ser efetuada com sucesso |
|Dados de Entrada         | Informações solicitadas no campo de Contas Bancárias.  |


| Caso de Teste           | CT004 – Poder editar uma Conta Bancária - RF-010 / RF-011                                                                  |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela Index Contas Bancárias | 
|Procedimento             | 1. No menu clicar na opção "Editar”. |
|                         | 2. O sistema deverá retornar já entrando no modo de edição |
|                         | 3. Editar as informações necessárias e clicar em "Salvar" |
|Resultado Esperado       | A modificação deverá ser efetuada com sucesso |
|Dados de Entrada         | Informações solicitadas no campo de Contas Bancárias.  |


| Caso de Teste           | CT005 – Poder visualizar uma Conta Bancária - RF-010 / RF-011                                                           |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela Index Contas Bancárias | 
|Procedimento             | 1. No menu clicar na opção "Detalhes” para visualizar uma Conta Bancária. |
|                         | 2. O sistema deverá retornar já entrando no modo de visualização |
|                         | 3. Visualizar as infomrações necessárias |
|Resultado Esperado       | A visualizaçaõ deverá ser mostrada com sucesso |
|Dados de Entrada         | Informações solicitadas no campo de Contas Bancárias.  |

## Testes Funcionais Realizados - CRUD Classificação de Despesas e Receitas

| Caso de Teste           | CT001 – Poder inserir uma nova Classificação de Despesas ou Receita - RF-010 / RF-011                                     |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Classificação de Despesas ou Receitas | 
|Procedimento             | 1. No menu, inserir o nome da Classifiação e clicar no botão "+". |
|                         | 2. O nome da Classificação deverá ser inserida para baixo da tela, e deverá ser mostrado |
|                         | 3. O sistema retorna mostrando a nova classificação |
|Resultado Esperado       | A nova Classificação deverá ser inserida com sucesso     |
|Dados de Entrada         | Informações solicitadas no campo de Classificação.  |


| Caso de Teste           | CT002 – Inserir uma nova Classificação com campos inválidos - RF-010 / RF-011                                            |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela Index de Classificação | 
|Procedimento             | 1. No menu selecione a opção “Nova Classificação”. |
|                         | 2. Inserir as informações solicitadas, ou deixar alguma informação em branco |
|                         | 3. Clicar em salvar |
|Resultado Esperado       | O sistema deverá retornar com os campos obrigatórios para as informações     |
|Dados de Entrada         | Informações solicitadas no campo de Classificação.  |


| Caso de Teste           | CT003 – Poder excluir uma Classificação - RF-010 / RF-011                                                              |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela Index Classificação | 
|Procedimento             | 1. No menu clicar na opção "Excluir”. |
|                         | 2. O sistema deverá retornar uma caixa de confirmação da exclusão da Classificação |
|                         | 3. Clicar em cancelar, para voltar, ou em "Excluir" para confirmar a ação |
|Resultado Esperado       | A exclusão deverá ser efetuada com sucesso |
|Dados de Entrada         | Informações solicitadas no campo de Classificação.  |


| Caso de Teste           | CT004 – Poder editar uma Classificação - RF-010 / RF-011                                                                  |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela Index classificação | 
|Procedimento             | 1. No menu clicar na opção "Editar”. |
|                         | 2. O sistema deverá retornar já entrando no modo de edição |
|                         | 3. Editar as informações necessárias e clicar em "Salvar" |
|Resultado Esperado       | A modificação deverá ser efetuada com sucesso |
|Dados de Entrada         | Informações solicitadas no campo de Classificação.  |


| Caso de Teste           | CT005 – Poder visualizar uma Classificação - RF-010 / RF-011                                                           |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela Index Classificação| 
|Procedimento             | 1. No menu clicar na opção "Detalhes” para visualizar uma Classificação. |
|                         | 2. O sistema deverá retornar já entrando no modo de visualização |
|                         | 3. Visualizar as infomrações necessárias |
|Resultado Esperado       | A visualizaçaõ deverá ser mostrada com sucesso |
|Dados de Entrada         | Informações solicitadas no campo de Classificação.  |

# Evidências de Testes de Softwares - CRUD Forma de Pagamentos

## CT001 – Poder inserir uma nova Forma de Pagamento - RF-010 / RF-011
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/91369ffd-c3d1-47bd-9bf0-dd7893776cc1)
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/658d8556-20f4-4445-be61-e9ef1ded24fb)

## CT002 – Inserir uma nova Forma de Pagamento com campos inválidos - RF-010 / RF-011
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/cd5a1e6d-4546-41c6-a9a5-4081f06af6b4)

## CT003 – Poder excluir uma Forma de Pagamento - RF-010 / RF-011
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/7ee417c0-a543-4698-94e7-a6d99736e56c)

## CT004 – Poder editar uma Forma de Pagamento - RF-010 / RF-011
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/9f1ef47d-5d84-47c3-abdd-b70a14ddab2b)

## CT005 – Poder visualizar uma Conta Bancária - RF-010 / RF-011
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/e30167e5-23da-4b77-b4ea-dadd7a96f107)

# Evidências de Testes de Softwares - CRUD Contas Bancárias

## CT001 – Poder inserir uma nova Conta Bancária - RF-010 / RF-011
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/375c8def-6862-4298-8805-0a9d509b59dd)
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/1d0d5233-63e9-4ffb-a841-e29c1faeaece)

## CT002 – Inserir uma nova Conta Bancária com campos inválidos - RF-010 / RF-011
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/3397ec20-de20-45e5-bec1-ab2cfeac7eb6)

## CT003 – Poder excluir uma Conta Bancária - RF-010 / RF-011
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/07cdb378-74b5-44da-95dd-868409c8e387)
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/5c6f6efe-bb7a-43ae-b3fb-6f083ca458cd)
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/d7d394b2-40ff-4e27-b8ae-045f84e536fb)

## CT004 – Poder editar uma Classificação - RF-010 / RF-011
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/12f93860-d94e-4cb3-8664-0ebe42a6fa93)
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/18cf4481-d017-471a-9838-feda93ef1369)

## CT005 – Poder visualizar uma Classificação - RF-010 / RF-011 
 ![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/7f71f900-2f57-4fb3-9d3a-b0b757091f36)

 ## Evidências de Testes de Softwares - CRUD Contas Bancárias

 ## CT001 – Poder inserir uma nova Classificação de Despesas ou Receita - RF-010 / RF-011  
 ![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/2310b129-0e42-42f4-8f07-575385158f7d)
 ![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/cdf284d6-e8c4-43c3-b0bd-171e20b72656) 
 
 ## CT002 – Inserir uma nova Classificação com campos inválidos - RF-010 / RF-011 (não informa ao usuário o erro ao inserir)
 ![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/38ae725b-5195-4270-81d2-c7829eff30f8)

 ## CT003 – Poder excluir uma Classificação - RF-010 / RF-011 (botão de excluir não funciona, e não informa nenhum possível erro)    
 ![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/e6130c39-1081-4a9b-9526-f1698c35cf17)

 ## CT004 – Poder editar uma Classificação - RF-010 / RF-011 ( ao editar a data de inclusão pode ser manipulada, e redireciona para uma outra tela de classificação)
 ![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/4741fe57-ee84-4e0d-a7b5-f9f1a9aa60ff)
 ![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/afb157db-8227-46d1-9ff6-a8a336d3c7f1)

 ## CT005 – Poder visualizar uma Classificação - RF-010 / RF-011 (não existe botão para exibir detalhes na tela de classificação)
 ![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/096110f9-09d4-4ca4-82ea-9bf69965233a)
 

# Plano de Testes de Software (Em pares)

Teste da tela de Funcionários | Feita por Douglas Delareti Simões | Testes feitos por César Luis Costa Moreira


## Objetivo

Garantir a funcionalidade, confiabilidade e segurança das telas de: 
- Implementar controle da inclusão, deleção e edição de funcionários

Os testes funcionais a serem realizados no aplicativo são descritos a seguir:  
 
| Caso de Teste           | CT001 – Criar novo funcionário                                                                                             |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Funcionários       | 
|Procedimento             | 1. No menu selecione a opção “Funcionários”. |
|                         | 2. Na tela Funcionários, clique no botão “Cadastrar Funcionário”. |
|                         | 3. Na tela de cadastro preencher todas as informações necessárias. |
|                         | 4. Clicar em “Confirmar”. |
|                         | 5. Caso deseje retornar para a tela inicial, clique em "Voltar". |
|Resultado Esperado       | O novo funcionário deve ser cadastrada com sucesso.                                                                       |
|Dados de Entrada         | Informações solicitadas no campo de cadastro.  |


| Caso de Teste           | CT002 – Cadastrar novo funcionário com o número de Celular no formato incorreto                                                      |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Funcionários      | 
|Procedimento             | 1. No menu selecione a opção “Funcionários”. |
|                         | 2. Na tela Empresas Parceiras, clique no botão “Cadastrar Funcionário”. |
|                         | 3. Na tela de cadastro preencher com informações invalidas ou vazias o campo de celular. |
|                         | 4. Clicar em Confirmar. |
|Resultado Esperado       | Devem ser exibidas mensagens de erro na tela indicando campos em branco ou dados inválidos.                                                                      |
|Dados de Entrada         | Informações em branco ou dados inválidos.  |

| Caso de Teste           | CT003 – Cadastrar novo funcionário com o campo CPF em branco ou no formato incorreto                                                  |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Funcionários      | 
|Procedimento             | 1. No menu selecione a opção “Funcionários”. |
|                         | 2. Na tela Empresas Parceiras, clique no botão “Cadastrar Funcionário”. |
|                         | 3. Na tela de cadastro preencher com informações invalidas ou vazias o campo de CPF. |
|                         | 4. Clicar em Confirmar. |
|Resultado Esperado       | Devem ser exibidas mensagens de erro na tela indicando campos em branco ou dados inválidos.                                                                      |
|Dados de Entrada         | Informações em branco ou dados inválidos.  |

| Caso de Teste           | CT004 – Cadastrar novo funcionário com os campos em branco                                                 |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Funcionários      | 
|Procedimento             | 1. No menu selecione a opção “Funcionários”. |
|                         | 2. Na tela Funcionários, clique no botão “Cadastrar Funcionário”. |
|                         | 3. Na tela de cadastro preencher com informações vazias nos campos. |
|                         | 4. Clicar em Confirmar. |
|Resultado Esperado       | Devem ser exibidas mensagens de erro na tela indicando campos em branco ou dados inválidos.                                                                      |
|Dados de Entrada         | Informações em branco ou dados inválidos.  |

| Caso de Teste           | CT005 – Visualizar os funcionários cadastrados                                              |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Funcionários      | 
|Procedimento             | 1. No menu selecione a opção “Funcionários”. |
|Resultado Esperado       | Devem ser exibidas mensagens de erro na tela todos os funcionários cadastrados no banco de dados.                                                                      |
|Dados de Entrada         | Informações em branco ou dados inválidos.  |


| Caso de Teste           | CT006 – Editar funcionário                                                                                             |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Funcionários      | 
|Procedimento             | 1. No menu selecione a opção “Funcionários”. |
|                         | 2. Na tela Funcionários, clique no botão Editar Funcionário”. |
|                         | 3. Na tela de editar, preencher com as informações que deseja alterar no funcionário. |
|                         | 4. Clicar em Confirmar. |
|Resultado Esperado       | Os dados devem ser alterados e aparecer na tela principal atualizados.                                                                      |
|Dados de Entrada         | Informações solicitadas no campo de edição.  |


| Caso de Teste           | CT007 – Editar funcionário com campo em branco ou inválido                                                                                     |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Funcionários      | 
|Procedimento             | 1. No menu selecione a opção “Funcionários”. |
|                         | 2. Na tela Funcionários, clique no botão Editar Funcionário”. |
|                         | 3. Na tela de editar, preencher com as informações inválidas ou campos em branco. |
|                         | 4. Clicar em Confirmar. |
|Resultado Esperado       | Um erro deve aparecer na tela mostrando os campos vazios e/ou inválidos.                                                                      |
|Dados de Entrada         | Informações em branco ou dados inválidos.  |


| Caso de Teste           | CT008 – Excluir funcionário cadastrado                                                                                    |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Funcionários      | 
|Procedimento             | 1. No menu selecione a opção “Funcionários”. |
|                         | 2. Na tela Funcionários, clique no botão Excluir Funcionário”. |
|                         | 4. Clicar em Excluir. |
|Resultado Esperado       | Excluir o usuário da tabela.                                                                      |
|Dados de Entrada         | N/A |

 
# Evidências de Testes de Software - Funcionários

## CT001 – Criar novo funcionário
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Home%20Funcion%C3%A1rios.png)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Tela%20de%20Cadastro.png)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Evidencia%20cadastro%20feito.png)

## CT002 – Cadastrar novo funcionário com o número de Celular no formato incorreto
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Home%20Funcion%C3%A1rios.png)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Cadastro%20-%20Erro%20Celular.png)

## CT003 – Cadastrar novo funcionário com o campo CPF em branco ou no formato incorreto  
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Home%20Funcion%C3%A1rios.png)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Tela%20CPF%20invalido.png)

## CT004 – Cadastrar novo funcionário com os campos em branco
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Home%20Funcion%C3%A1rios.png)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Cadastro%20-%20Erro%20campo%20vazio.png)

## CT005 – Visualizar os funcionários cadastrados
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Evidencia%20cadastro%20feito.png)

## CT006 – Editar funcionário
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Evidencia%20cadastro%20feito.png)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Tela%20Editar%20Funcion%C3%A1rio.png)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Evidencia%20Funcionario%20Editado.png)

## CT007 – Editar funcionário com campo em branco ou inválido  
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Evidencia%20cadastro%20feito.png)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Editar%20-%20campo%20errado%20ou%20vazio.png)

## CT008 – Excluir funcionário cadastrado   
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Evidencia%20cadastro%20feito.png)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Tela%20Excluir.png)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/blob/main/documentos/img/Evidencia%20Funcion%C3%A1rio%20Exclu%C3%ADdo.png)


 # Plano de Testes de Software (Em Pares)
##	Objetivo
Garantir a funcionalidade, confiabilidade e segurança nas telas de:
•	Receitas (inicio)

##	Ferramentas utilizadas para os testes
•	Visual Studio
•	Navegador Google Chrome

##	Responsáveis pelos testes e pelas funcionalidades desenvolvidas
Pedro Ertal, realizando testes nas funcionalidades desenvolvidas por: Karinne Massensini

##	Testes Unitários realizados
Os testes funcionais a serem realizados dentro do sistema Libertese são descritos a seguir:

| Caso de Teste           |	Receita |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
| Requisitos Associados |	RF-011	Permitir cadastro de receita |
| Objetivo do teste |	Verificar se os dados inseridos na tabela retornam na tela |
| Passos e Procedimento |	Acessar a tela de Receitas pelo menu lateral |
| Resultado esperado |	Retornar page receita estilizada  |
| Retorno  | ok  |

| Caso de Teste           |	Create new Receita |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
| Requisitos Associados |	RF-011	Permitir cadastro de receita |
| Objetivo do teste |	Verificar CRUD de receitas |
| Passos e Procedimento |	Acessar a tela de CREATE receita clicando no botão |
| Resultado esperado |	Retornar a page de create e salvar dados|
| Retorno  | Não é possivel salvar os dados, pois a um erro no item status |

## Evidências de Testes de Softwares

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/60409021/95466d34-ef28-4cbd-81f3-d316b1f32864)
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/60409021/685cdfe5-b5ec-40f2-89e2-24917c5cb59a)


## Objetivo

Garantir a funcionalidade, confiabilidade e segurança das telas de: 
- CRUD Produtos - RF 005


## Ferramentas utilizadas para os testes
- Visual studio 2021
- Google Chrome

## Responsáveis pelos testes e pelas funcionalidades desenvolvidas
- Responsável pelas telas a seguir: Thaís Gurgel
- Telas desenvolvidas: Produtos
- Testadas por: 
- Funcionalidades testadas: 

### CT001 - Criar novo Produto

| Casos de Teste      | CT001 - Criar novo Produto                                                                                   |
|---------------------|--------------------------------------------------------------------------------------------------------------|
| **Pré Condições**   | Estar na tela de Produtos                                                                                   |
| **Procedimento**    | 1. No menu, selecionar a opção “Produtos”.                                                                  |
|                     | 2. Na tela de Produto, selecionar a opção “Novo Produto”.                                                    |
|                     | 3. Na tela de Novo Produto, preencher todas as informações necessárias.                                      |
|                     | 4. Clicar em “Salvar”.                                                                                      |
| **Resultado Esperado** | O novo produto deve ser cadastrado e deverá constar na tabela de produtos.                                   |
| **Dados de Entrada** | Informações solicitadas nos campos de cadastro.                                                              |

### CT002 - Criar produto com campos em branco ou inválidos

| Casos de Teste      | CT002 - Criar produto com campos em branco ou inválidos.                                                     |
|---------------------|--------------------------------------------------------------------------------------------------------------|
| **Pré Condições**   | Estar na tela de Produtos                                                                                   |
| **Procedimento**    | 1. No menu, selecionar a opção “Produtos”.                                                                  |
|                     | 2. Na tela de Produto, selecionar a opção “Novo Produto”.                                                    |
|                     | 3. Na tela de Novo Produto deixe um ou mais campos em branco ou insira dados inválidos.                      |
|                     | 4. Clicar em “Salvar”.                                                                                      |
| **Resultado Esperado** | Devem ser exibidas mensagens de erro na tela indicando campos em branco ou inválidos.                       |
| **Dados de Entrada** | Informações em branco ou inválidos.                                                                         |

### CT003 - Visualizar Produto

| Casos de Teste      | CT003 - Visualizar Produto                                                                                   |
|---------------------|--------------------------------------------------------------------------------------------------------------|
| **Pré Condições**   | Estar na tela de Produtos                                                                                   |
| **Procedimento**    | 1. No menu, selecionar a opção “Produtos”.                                                                  |
|                     | 2. Na tela de Produto, selecionar a opção “Visualizar Produto”.                                             |
| **Resultado Esperado** | Todas as informações corretas referentes ao produto selecionado devem ser exibidas.                        |
|                     |                                                                                                              |

### CT004 - Editar produto

| Casos de Teste      | CT004 - Editar produto.                                                                                     |
|---------------------|--------------------------------------------------------------------------------------------------------------|
| **Pré Condições**   | Estar na tela de Produtos                                                                                   |
| **Procedimento**    | 1. No menu, selecionar a opção “Produtos”.                                                                  |
|                     | 2. Na tela de Produto, selecionar a opção “Editar Produto”.                                                 |
|                     | 3. Na tela de Editar Produto, edite a informação desejada.                                                   |
|                     | 4. Clicar em “Salvar”.                                                                                      |
| **Resultado Esperado** | As informações editadas devem ser atualizadas com sucesso e a data de atualização deve constar na tabela de produtos. |
| **Dados de Entrada** | Informações que deseja atualizar.                                                                          |

### CT005 - Editar produto com campos em branco ou inválidos

| Casos de Teste      | CT005 - Editar produto com campos em branco ou inválidos.                                                   |
|---------------------|--------------------------------------------------------------------------------------------------------------|
| **Pré Condições**   | Estar na tela de Produtos                                                                                   |
| **Procedimento**    | 1. No menu, selecionar a opção “Produtos”.                                                                  |
|                     | 2. Na tela de Produto, selecionar a opção “Editar Produto”.                                                 |
|                     | 3. Na tela de Editar Produto, deixe um ou mais campos em branco ou insira dados inválidos.                  |
|                     | 4. Clicar em “Salvar”.                                                                                      |
| **Resultado Esperado** | Devem ser exibidas mensagens de erro na tela indicando campos em branco ou inválidos.                       |
| **Dados de Entrada** | Informações em branco ou inválidos.                                                                         |

### CT006 - Deletar produto

| Casos de Teste      | CT006 - Deletar produto.                                                                                    |
|---------------------|--------------------------------------------------------------------------------------------------------------|
| **Pré Condições**   | Estar na tela de Produtos                                                                                   |
| **Procedimento**    | 1. No menu, selecionar a opção “Produtos”.                                                                  |
|                     | 2. Na tela de Produto, selecionar a opção “Deletar Produto”.                                                |
|                     | 3. Na mensagem de confirmação, clicar em “Deletar” confirmando assim a remoção do registro.               |
| **Resultado Esperado** | O produto selecionado deve ser removido da lista de produtos na página inicial.                            |
|                     |                                                                                                              |

# Plano de teste - (Em apres)
Teste da tela Vendas | Desenvolvidas por Thaís Gurgel | Testes feitos por Rafael de Oliveira

## Objetivo:

Garantir a funcionalidade, confiabilidade e segurança das telas de: 
- Registro de Vendas - RF 014


## Ferramentas utilizadas para os testes
- Visual studio 2021
- Google Chrome

## Responsáveis pelos testes e pelas funcionalidades desenvolvidas
- Responsável pelos telas a seguir: Thaís Gurgel
- Telas desenvolvidas: Registro de Vendas
- Testadas por: Rafael de Oliveira
- Funcionalidades testadas: Registrar Nova Venda; Venda com campos em branco ou inválidos; Visualizar Venda; Cancelar Venda


### CT001 - Registrar Nova Venda

| Casos de Teste      | CT001 - Registrar Nova Venda                                                                               |
|---------------------|------------------------------------------------------------------------------------------------------------|
| **Pré Condições**   | Estar na tela de Vendas                                                                                    |
| **Procedimento**    | 1. No menu, selecionar a opção “Venda”.                                                                    |
|                     | 2. Na tela de Venda, selecionar a opção “Novo Registro Venda”.                                             |
|                     | 3. Na tela de Nova Venda, registrar todas as informações necessárias.                                       |
|                     | 4. Clicar em “Confirmar”.                                                                                  |
| **Resultado Esperado** | A nova venda deve ser registrada com sucesso e deverá constar na lista de vendas.                          |
| **Dados de Entrada** | Informações necessárias para o registro da venda.                                                           |

### CT002 - Registrar Nova Venda com Campos em Branco ou Inválidos

| Casos de Teste      | CT004 - Registrar Nova Venda com Campos em Branco ou Inválidos                                             |
|---------------------|------------------------------------------------------------------------------------------------------------|
| **Pré Condições**   | Estar na tela de Vendas                                                                                    |
| **Procedimento**    | 1. No menu, selecionar a opção “Venda”.                                                                    |
|                     | 2. Na tela de Venda, selecionar a opção “Novo Registro Venda”.                                             |
|                     | 3. Na tela de Nova Venda, deixar um ou mais campos em branco ou inserir dados inválidos.                   |
|                     | 4. Clicar em “Confirmar”.                                                                            |
| **Resultado Esperado** | Devem ser exibidas mensagens de erro indicando campos em branco ou inválidos.                             |
| **Dados de Entrada** | Informações em branco ou inválidos.                                                                        |



### CT003 - Visualizar Venda

| Casos de Teste      | CT002 - Visualizar Venda                                                                                   |
|---------------------|------------------------------------------------------------------------------------------------------------|
| **Pré Condições**   | Estar na tela de Vendas                                                                                    |
| **Procedimento**    | 1. No menu, selecionar a opção “Venda”.                                                                    |
|                     | 2. Na tela de Venda, selecionar a opção “Visualizar Venda”.                                                |
|                     | 3. Selecionar a venda desejada para visualização.                                                          |
| **Resultado Esperado** | Todas as informações referentes à venda selecionada devem ser exibidas corretamente.                      |
|                     |                                                                                                            |

### CT004 - Cancelar Venda

| Casos de Teste      | CT003 - Cancelar Venda                                                                                     |
|---------------------|------------------------------------------------------------------------------------------------------------|
| **Pré Condições**   | Estar na tela de Vendas                                                                                    |
| **Procedimento**    | 1. No menu, selecionar a opção “Venda”.                                                                    |
|                     | 2. Na tela de Venda, selecionar a opção “Cancelar Venda”.                                                  |
|                     | 3. Confirmar a operação de cancelamento.                                                                   |
| **Resultado Esperado** | A venda selecionada deve ser cancelada e na lista de vendas deverá constar status cancelado.               |
|                     |                                                                                                            |

# Evidências de Testes de Softwares

### CT001 - Registrar Nova Venda
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/30164682-11fd-460a-a433-0915a42cb3cd)
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/af745118-1414-4e60-8a62-678c0e922779)
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/b280733c-1e49-4e90-9290-1001b4c66528)

### CT002 - Registrar Nova Venda com Campos em Branco ou Inválidos
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/070b11dd-c8e1-4784-a77c-e622bc682452)

### CT003 - Visualizar Venda
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/e456140b-c551-4269-b58e-3e698d18e8a1)
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/cdcd6432-ffef-4c13-a0ab-ffcd032875dd)

### CT004 - Cancelar Venda
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/c6097195-14ee-4d2b-aa68-041a1c1d9ef3)
![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/1a5d0223-e94a-4f3c-bbb9-a4b1ac7a802c)


# Plano de Testes de Software (Em pares)

Teste da tela de Fornecedores | Feita por Vinicius de Souza Ponciano | Testes feitos por Thaís Gurgel


## Objetivo

Garantir a funcionalidade, confiabilidade e segurança das telas de: 
- Implementar controle da inclusão, deleção e edição de fornecedores

Os testes funcionais a serem realizados no aplicativo são descritos a seguir:  
 
| Caso de Teste           | CT001 – Criar novo fornecedor                                                                                             |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Fornecedores       | 
|Procedimento             | 1. No menu selecione a opção “Fornecedores”. |
|                         | 2. Na tela Funcionários, clique no botão “Novo Fornecedor”. |
|                         | 3. Na tela de cadastro preencher todas as informações necessárias. |
|                         | 4. Clicar em “Confirmar”. |
|                         | 5. Caso deseje retornar para a tela inicial, clique em "Voltar". |
|Resultado Esperado       | O novo fornecedor deve ser cadastrado com sucesso.                                                                       |
|Dados de Entrada         | Informações solicitadas no campo de cadastro.  |


| Caso de Teste           | CT002 – Cadastrar novo fornecedor com os campos em branco                                                 |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Fornecedores      | 
|Procedimento             | 1. No menu selecione a opção “Fornecedores”. |
|                         | 2. Na tela Funcionários, clique no botão “Novo Fornecedores”. |
|                         | 3. Na tela de cadastro preencher com informações vazias nos campos. |
|                         | 4. Clicar em Confirmar. |
|Resultado Esperado       | Devem ser exibidas mensagens de erro na tela indicando campos em branco ou dados inválidos.                                                                      |
|Dados de Entrada         | Informações em branco ou dados inválidos.  |

| Caso de Teste           | CT003 – Visualizar os fornecedor cadastrados                                              |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Fornecedores      | 
|Procedimento             | 1. No menu selecione a opção “Fornecedores”. |
|Resultado Esperado       | Devem ser exibidas mensagens de erro na tela todos os funcionários cadastrados no banco de dados.                                                                      |
|Dados de Entrada         | Informações em branco ou dados inválidos.  |


| Caso de Teste           | CT004 – Editar fornecedor                                                                                             |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Fornecedores      | 
|Procedimento             | 1. No menu selecione a opção “Fornecedores”. |
|                         | 2. Na tela Fornecedores, clique no ícone de caneta em um dos cards de fornecedor. |
|                         | 3. Na tela de editar, preencher com as informações que deseja alterar no fornecedor. |
|                         | 4. Clicar em Confirmar. |
|Resultado Esperado       | Os dados devem ser alterados e aparecer na tela principal atualizados.                                                                      |
|Dados de Entrada         | Informações solicitadas no campo de edição.  |


| Caso de Teste           | CT005 – Editar fornecedor com campo em branco ou inválido                                                                                     |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Fornecedores      | 
|Procedimento             | 1. No menu selecione a opção “Fornecedores”. |
|                         | 2. Na tela Fornecedores, clique no ícone de caneta em um dos cards de fornecedor. |
|                         | 3. Na tela de editar, preencher com as informações inválidas ou campos em branco. |
|                         | 4. Clicar em Confirmar. |
|Resultado Esperado       | Um erro deve aparecer na tela mostrando os campos vazios e/ou inválidos.                                                                      |
|Dados de Entrada         | Informações em branco ou dados inválidos.  |


| Caso de Teste           | CT008 – Excluir fornecedor cadastrado                                                                                    |
|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------|
|Pre Condições            | Estar na tela de Fornecedores      | 
|Procedimento             | 1. No menu selecione a opção “Fornecedores”. |
|                         | 2. Na tela Funcionários, clique no ícone de lixeira em um dos cards de fornecedor. |
|                         | 4. Clicar em Excluir. |
|Resultado Esperado       | Excluir o fornecedor da tabela.                                                                      |
|Dados de Entrada         | N/A |

 
# Evidências de Testes de Software - Fornecedores

### CT001 - Criar novo Fornecedor 

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/040bae9e-6198-4c77-bea3-92308e01d840)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/06ca8a10-4750-4c3e-92f2-a66691e43168)

### CT002 - Criar novo Fornecedor com campos em branco ou inválidos

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/8146b45e-5860-469d-93db-3508121e7074)

### CT003 - Visualizar fornecedores cadastrados

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/7b2c340a-b412-4936-95e6-8abf333b27ab)

### CT004 - Editar fornecedor
Fornecedor editado: Sodine Papelaria (campos: nome e segunda opção telefone)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/026f6c7e-926c-4e61-8add-257c2aec2844)

### CT005 - Editar fornecedor com campo em branco ou inválido
Obs: Não é possível editar sem registrar o CNPJ.

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/dba6d59f-7fde-4ee4-b509-50159e2f6552)

### CT005 - Excluir fornecedor cadastrado

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/9fcfec68-e7e5-4225-8947-7092e405ac6d)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/59944150/32248dcc-1aa0-485a-ace6-9224b7439830)


# Evidências de Testes de Software - Atualização de Layout CRUD Formas de Pagamento e Contas Bancárias 

Para todas as funções abaixo apresentadas, não houve mudança do Plano de Testes, somente o laytout das telas foram alterados.

- Forma de Pagamentos

A função Forma de Pagamentos se encontra em "Vendas" no menu lateral:

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/9409758c-7d9a-4639-858e-b0a84b644f8e)

A tela exibe todas as opções cadastradas, para inserrir uma nova forma de pagamento, clicar em "Nova Forma de Pagamento":

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/a4ddaa0e-be82-4ffb-957c-f6b211731aec)

As opções de edição, visualização e exclusão são mostradas abaixo:

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/49264a44-04a0-477c-82f3-966c52583cf5)

Editar Forma de Pagamento:

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/18f9c25a-fe4b-4693-93a4-e978fb4ffc9b)

Visualizar Forma de Pagamento:

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/30b31d4f-2a3d-4315-a170-08524fe179af)

Excluir Forma de Pagamento:

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/68f31528-b21e-466c-9e54-934d0d39ec09)

- Contas Bancárias

Função Contas Bancárias se encontra em "Vendas" no menu lateral:

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/ce518a98-013b-4259-932f-9c4b25019147)

A tela exibe todas as contas cadastradas, para inserir uma nova Conta Bancária, clicar em "Nova Conta Bancária", preencher e salvar:

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/a4fc52b6-c0c8-4bd7-a8ee-b39a0a2f88cd)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/cd403abb-a0bf-4bf7-9476-c06cdc5d27f5)

As opções de edição, visualização e exclusão são mostradas abaixo:

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/fe2b40ec-460d-41f0-9a3d-76127a3891a3)

Editar Conta Bancária:

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/fbe50512-d17f-4b10-a0a9-9522f5105b7f)

Visualizar Conta Bancária:

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/6f3c3885-a223-424b-a330-0f2dda91b104)

Excluir Conta Bancária:

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/d74b0bb1-f736-463c-8300-9679fbfc3845)


# Evidências de Testes de Software - Página "Início" do sistema Libertese

Na página de Início "Home", é exibida o logotipo da Libertese, e todas as funções do sistema de forma resumnida, conforme imagem abaixo:

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/b99e4453-11f0-4334-a91f-604da4bc09c2)

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225907/4928fbdb-3a9a-45d6-ae2b-8cc945100409)

Lembrando que a exibição na Home, é somente um formato resumido para o gerenciamento do negócio, não é valido como uma documentação técnica do Sistema.






















