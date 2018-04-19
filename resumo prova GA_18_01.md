#Resumo aula 

#Aula 1 

* o que é rede de computadores? 
  - Conjunto de dispositivos interconectados para trocar informacoes e compartilhar recursos 

* Papeis importantes de uma rede 
  - Transmissor(origem)
  - Receptor(destino)
  - Dado a ser enviado/recebido
  - Canal de comunicacao
  - interface de rede 

 * Lan(Local area network) 
    - Redes privadas 
      - Caracteristicas 
        - Possuem poucos km de extensao 
        - Alta taxa de transferencia 
        - Baixa ocorrencia de erros 
        - Sem roteamento da informacao 

    * Topologia de redes locais 
      - Estrela (todos ligado em nodo central) 
      - Barra (Todos ligados em um em forma de barra) 
      - Anel (Maquinas ligadas nas do lado ) 
      
 * MAN(Metropolitan area network)
    - Abrange uma regiao metropolitana de uma cidade 
    - Versao ampliada de uma LAN 
    - utilizam o padrao DQBD(Distributed queue dual bus) 
      - Dois cabos interligam os computadores, um para cada direcao 
      
 * WAN(Wide area network) 
    - Engloba uma grande regiao 
    - pais, continente 
    - Transmissao baixa(comparada as LANs)
    - Alta taixa de errros 
    - Possui roteamente de informacao 
 
 * Internet x Intranet 
    - Internet: 
        - Rede publica(global) 
    - Intranet: 
        - Redes Privadas(somente computadores que estao na mesma rode podem acessar) 
        
 * Tipos de Servicos 
    - Orientado a conexao
      - Garante o envio correto das informacoes 
    - Nao orienteado a conexao 
      - Nao garante a entraga das informacoes(os pacote podem chegar faltando parte no destino) 
      
 * Host Podem ser divididos em duas categorias 
    - Cliente
      - Estacoes de trabalho 
      - Pedem/Solicitam/Requisitam determinado servico 
    - Servidor 
      - Maquinas com poder de processamento maior que as do cliente 
      - Fornecem determinado servico(webService, Facebook...) 
      
 * Meios de transmissao 
    - Sao os caminhos fisicos atraves dos quais ocorre a comunicacao entre servidor/cliente(remetende/destinatario)
    - Meios Guiados 
        - Meios fizicos: 
          - Cabo coaxiais, fibra optica, pares trancados 
        - Capacidade limitada pelos parametros de distancia e tipo de rede 
          - Restrição de largura de banda
          - Restrição na taxa de transmissão (em bits/segundo)
    - Meios nao Guiados 
        - Usa a atmosfera terrestre ou o espaco 
          - Satelites, microondas, infravermelho 
          
 * Camadas de Protocolos 
    - Aplicacao: 
      - FTP, SMTP, HTTP
    - Transporte: Transferencia de dados entre sistemas terminais 
      - TCP, UDP
    - Rede: Roteamento de datagramas da origem ao destino 
      - IP 
    - Enlace: Transferencia de dados entre elementos de rede vizinho 
      - PPP, Ethernet 
    - Fisica: Bit "nos fios", trafegando a informacao na internet ate o destinatario 
      

#Aula 2
  
  * Protocolos
      - Conjunto de regras que determinan como devem ocorrer a comunicacao entre duas estacoes em uma rede 
  
  * Camadas de protocolos 
      - Host 
      - Roteadores 
      - Enlaces 
      - Aplicacoes 
      - Protocolos 
      - Hardware/Software 
      
  * Modelo de Referencia camada OSI
      - Nao obteve exito comercial 
      - Modelo Internet cresceu mais rapidamente 
          - Mais simples e eficiente, abrange um numero maaior de aplicacoes 
      - Modelo osi é muito complexo 
      - Nem sempre precisamos utilizar todas as camadas de aplicacao 
      - Software de rede nao deve exigir tantos requisitos para a sua utilizacao 
  
      - Camada OSI estrutura
        - Nivel Fisico 
            - Transmissao de bits atraves do canal de comunicacao 
            - Move os bits atraves do meio de transmissao 
      
        - Nivel de Enlace 
            - Transmite/Recebe conjunto de bits 
            - Detecta/corrige erros do meio de transmissao 
            - Implementa parte em software, parte em firmware(placa de rede) 
          
        - Nivel de Rede 
            - Permite que pacotes(frames) sejam enviados a outros dispositivos que nao estejam na mesma rede 
                - Roteamento 
                - Localizacao de computadores na internet 
        
        - Nivel de Transporte
            - Prove comunicacao transparente e confiavel entre os pontos envolvidos na comunicacao
            - Prove ordenacao 
      
        - Nivel de sessao: 
            - Tempo/periodo na qual o usuario interage com o sistema 
          
        - Nivel de Apresentacao:
            - Prove independencia para as aplicacoes em relacao aos diferentes formas de representacao de dados 
                - Responsavel por fazer a conversao de um tipo de dados desconhecido em conhecido 
                
        - Nivel de Aplicacao: 
             - Email, Transferencia de arquivos, servico de diretorios, ... 
         
   * Modelos de Camadas 
      - Aplicacao 
      - Transporte 
      - Rede 
      - Enlace
      - Fisica 
    
      - Comunicao Vertical 
          - Cada nivel comunicase apenas com camadas adjacentes 
          - Dentro do mesmo dispositivo
      
      - Comunicao Horizontal  
          - Camadas   adicionam informacoes de controle no cabecalho da mensagem 
          - No destino, cada camada processa o cabecalho referente a sua camada no host de origem 
          
   
   * Atrasos de comunicacao 
      
      - Processamento 
          - Dproc: Tempo para o processamento do cabecalho do pacote 
      
      - Enfileramento 
          - Dqueue: Tempo que o pacote fica na fila ate entrar no processo de Transmissao do pacote 
      
      - Transmissao 
          - Dtrans: Tempo que leva para todo o pacote estar ponto para ser transmitido(L/R)                    
      
      - Propagacao 
           - Dprop: Tempo que o pacote leva para chegar do roteador(A) no reteador(B), 
                    varia de acordo com o meio fisico utilizado para fazer a propagacao. 
                    Calculo: Distancia entre os dois roteadores(A,B) dividida pela velocidade de propagacao do meio fisico
                    Calculo: D/S /// D == Distancia //// S = Velocidade 
                    
      - Atraso nodal é igual a soma de todos os atrasos acima 
      
   * Atraso de Transmissão x Atraso de Propagação
          – Atraso de transmissão: 
             - quantidade de tempo exigida para o roteador “empurrar” o pacote. 
             É uma função do comprimento do pacote e da taxa de transmissão do link, 
             mas não tem relação com a distância entre dois roteadores.
        
        – Atraso de propagação: 
             - tempo que um bit leva para propagar de um roteador ao seguinte. 
             É uma função da distância entre os dois roteadores, 
             mas não tem relação com o comprimento do pacote, nem com a taxa de transmissão da ligação.
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      
      



