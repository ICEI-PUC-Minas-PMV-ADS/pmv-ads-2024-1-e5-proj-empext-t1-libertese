# Especificações do Projeto

## Arquitetura e Tecnologias

Descrição Detalhada das Tecnologias Utilizadas no Libertese

### JavaScript:
Linguagem de programação de alto nível, versátil e interpretada, utilizada para adicionar interatividade e dinamismo às páginas web.
Permite a criação de interfaces de usuário complexas e responsivas, animações, jogos e muito mais.
No sistema, o JavaScript será usado para:
- Validar formulários e entradas de dados.
- Manipular elementos da DOM (Document Object Model) dinamicamente.
- Criar gráficos e visualizações interativas de dados.
- Implementar funcionalidades complexas do sistema, como chat em tempo real, notificações e filtros de pesquisa.
- Integrar com APIs externas para ampliar as funcionalidades do sistema.

### CSS
Linguagem de estilo que define a aparência das páginas web, como cores, fontes, layout e posicionamento de elementos.
Permite criar interfaces de usuário bonitas, consistentes e acessíveis em diferentes dispositivos.
No sistema, o CSS será usado para:
- Definir a identidade visual do sistema, como cores, tipografia e logotipo.
- Criar layouts responsivos que se adaptam a diferentes tamanhos de tela.
- Estilizar elementos da interface para melhorar a usabilidade e a experiência do usuário.
- Implementar animações e transições para tornar o sistema mais interativo e agradável.
- Criar diferentes temas visuais para personalizar a experiência do usuário.

### HTML
Linguagem de marcação que define a estrutura básica das páginas web, como cabeçalhos, parágrafos, imagens e links.
É a base de toda página web e define o conteúdo que será exibido ao usuário.
No sistema, o HTML será usado para:
- Definir a estrutura das páginas do sistema, como menus, seções e áreas de conteúdo.
- Inserir texto, imagens, vídeos e outros elementos multimídia.
- Criar links para outras páginas do sistema e para sites externos.
- Implementar formulários para coleta de dados do usuário.
- Organizar o conteúdo de forma clara e acessível para o usuário.

### Figma
Ferramenta de design de interface de usuário que permite criar protótipos interativos de alta qualidade.
Facilita a visualização e o teste do sistema antes de sua implementação final.
No sistema, o Figma será usado para:
- Criar protótipos das interfaces do sistema, incluindo telas, menus e funcionalidades.
- Testar a usabilidade e a interatividade do sistema com usuários reais.
- Colaborar com designers e desenvolvedores para aprimorar o design do sistema.
- Criar um sistema visual consistente e intuitivo para o usuário.
- Gerar assets de design para o desenvolvimento do sistema.

### PostgreSQL
Sistema de gerenciamento de banco de dados relacional open-source, robusto e escalável.
Permite armazenar e gerenciar os dados do sistema de forma segura e eficiente.
No sistema, o PostgreSQL será usado para:
- Armazenar todos os dados do sistema, como informações de usuários, produtos, pedidos e configurações.
- Gerenciar as transações de dados do sistema de forma segura e confiável.
- Implementar consultas complexas para recuperar e analisar dados do sistema.
- Garantir a integridade e a consistência dos dados do sistema.
- Escalar a capacidade de armazenamento e processamento de acordo com o crescimento do sistema.

### C#
Linguagem de programação de alto nível, moderna e versátil, utilizada para desenvolver aplicações web, desktop e mobile.
Permite criar aplicações robustas, escaláveis e seguras.
No sistema, o C# será usado para:
- Desenvolver a lógica de negócio do sistema, como regras de validação, cálculos e processamento de dados.
- Criar APIs para integração com outros sistemas e serviços.
- Implementar funcionalidades complexas do sistema, como relatórios e dashboards.
- Garantir a segurança e a confiabilidade do sistema.
- Facilitar a manutenção e o desenvolvimento futuro do sistema.


## Project Model Canvas

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/60409021/b274fdfd-8fdb-4b8e-84f1-e1d01c3a56ab)

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto. Para determinar a prioridade de requisitos, aplicar uma técnica de priorização de requisitos e detalhar como a técnica foi aplicada.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| Permitir cadastro de usuário administrador  | ALTA | 
|RF-002| Permitir cadastro de funcionários  | ALTA |
|RF-003| Login na plataforma  | ALTA |
|RF-004| Implementar controle de inclusão, deleção e edição de funcionários  | MÉDIA |
|RF-005| Permitir cadastro de produtos, categorias e materiais  | ALTA |
|RF-006| Permitir controle de inclusão, deleção e edição de produtos, categorias e materiais| ALTA |
|RF-007| Implementar precificação de produtos e materiais | MÉDIA |
|RF-008| Permitir cadastro de patrocinadores | MÉDIA |
|RF-009| Permitir cadastro de fornecedores | MÉDIA |
|RF-010| Cadastrar despesas | MÉDIA |
|RF-011| Permitir cadastro de receita | MÉDIA |
|RF-012| Implementar fluxo de caixa  | ALTA |
|RF-013| Implementar calculadora de gestão financeira | BAIXA |
|RF-014| Permitir registro de venda | MÉDIA |
|RF-015| Permitir gerar relatórios de venda |  BAIXA | 

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| O sistema deve ser responsivo para rodar em um dispositivos móvel | MÉDIA | 
|RNF-002| Deve processar requisições do usuário em no máximo 3s |  BAIXA | 
|RNF-003| O sistema deve realizar autenticação e autorização ao acessar como administrador | ALTA | 
|RNF-004| O sistema deve solicitar autenticação de administrador ao realizar qualquer exclusão |  BAIXA | 


## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até 26 de julho de 2024 |
|02| Não deve ser incluído nenhuma nova funcionalidade a partir da etapa 2 |
|03| Funcionalidades não testadas, não devem ir para a versão final |


## Diagrama de Casos de Uso
![Diagrama de Casos de Uso](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/86004024/ada7e19e-022d-4f29-8a8d-9f2f00f456c1)

## Modelo ER (Projeto Conceitual)

![Modelo ER - MER](https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/main/documentos/img/MER_Libertese.jpg)

## Projeto da Base de Dados

![Diagrama Base de Dados - DER](https://raw.githubusercontent.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/main/documentos/img/DER%20_LIbertese.jpg)

## Diagrama de Classe

![libertese3](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-empext-t1-libertese/assets/103225367/51c20fa7-9d13-47d2-821a-c04cc4fbfc4b)




