# Plano de Testes Libertese

## Objetivo

Garantir a funcionalidade, confiabilidade e segurança das telas de: 
- Primeiro Acesso
- Esqueceu a Senha
- Login do sistema

## Foco

Validação: Verificar se as funcionalidades das telas e se atendem os requisitos especificados.
Usabilidade: Avaliar se as interfaces são amigáveis, intuitivas e fáceis de usar para o público-alvo.
Segurança: Testar a robustez do sistema contra ataques e a proteção dos dados das usuárias.

## Abrangência

Testes funcionais, de usabilidade e de segurança para as três telas.
Casos de teste específicos para cada tela, considerando diferentes cenários de uso.

# Estrutura do Plano

## 1. Definição do Ambiente de Testes

Navegadores: Chrome, Firefox, Edge (últimas versões).
Dispositivos: Desktop, tablet, smartphone.
Conexões: Internet rápida, internet lenta.

## 2. Criação de Casos de Teste

## Tela - Primeiro Acesso
- Funcional
Validar o registro de novas usuárias com dados válidos e inválidos.
Verificar o envio de e-mail de confirmação de registro.
Testar a ativação da conta através do link no e-mail.
Validar o redirecionamento para a tela de login após a ativação.

- Usabilidade
Avaliar a clareza e o tamanho das instruções.
Testar a facilidade de navegação na tela.
Verificar a acessibilidade para diferentes perfis de usuárias.

- Segurança
Testar a proteção contra ataques de força bruta.
Validar a criptografia de dados durante o registro.
Verificar a segurança do envio de e-mail.

## Tela - Esqueceu a Senha
- Funcional
Validar o processo de recuperação de senha com e-mail e telefone.
Verificar o envio de e-mail com instruções para redefinição de senha.
Testar a redefinição de senha com sucesso e com dados inválidos.
Validar o redirecionamento para a tela de login após a redefinição.

- Usabilidade
Avaliar a clareza das instruções e formulários.
Testar a facilidade de recuperação de senha.
Verificar a acessibilidade para diferentes perfis de usuárias.

- Segurança
Testar a proteção contra ataques de força bruta.
Validar a criptografia de dados durante a recuperação de senha.
Verificar a segurança do envio de e-mail.

## Tela - Login
- Funcional
Validar o login com dados válidos e inválidos.
Testar o acesso ao sistema após o login.
Validar o bloqueio de conta após tentativas inválidas.
Verificar a persistência da autenticação após o login.

- Usabilidade
Avaliar a clareza dos campos de login e senha.
Testar a facilidade de login no sistema.
Verificar a acessibilidade para diferentes perfis de usuárias.

- Segurança
Testar a proteção contra ataques de força bruta.
Validar a criptografia de dados durante o login.
Verificar a segurança da autenticação e do armazenamento de cookies.

## 3. Execução dos Testes

Execução manual e automatizada casos de testes;
Registro de resultados e falhas em planilha ou ferramenta de gestão de testes;
Captura de screenshots e vídeos para evidenciar falhas;

## 4. Análise dos Resultados

Identificação de falhas e bugs;
Priorização das correções de acordo com a severidade das falhas;
Reteste dos casos de teste após as correções;

## 5. Documentação

Relatório de testes detalhado com os resultados obtidos.
Recomendações para melhorias na usabilidade e segurança das telas.
Ferramentas de Testes: Cypress
Planilhas de Testes: Google Sheets, Excel.
____________________________________________

# APAGAR DEPOIS
# Planos de Testes de Software

Apresente os cenários de testes utilizados na realização dos testes da sua aplicação. Escolha cenários de testes que demonstrem os requisitos sendo satisfeitos.

Enumere quais cenários de testes foram selecionados para teste. Neste tópico o grupo deve detalhar quais funcionalidades avaliadas, o grupo de usuários que foi escolhido para participar do teste e as ferramentas utilizadas.
 
# Evidências de Testes de Software

Apresente imagens e/ou vídeos que comprovam que um determinado teste foi executado, e o resultado esperado foi obtido. Normalmente são screenshots de telas, ou vídeos do software em funcionamento.
