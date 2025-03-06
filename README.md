Arquitetura Microkernel (Plugins)
O padrão de arquitetura microkernel, também conhecido como padrão de arquitetura de plugin, permite você adicionar novas features a aplicação como plugins ao core da aplicação, fornecendo extensibilidade, além de isolamento e separação das features (exemplos clássicos de aplicações que usam esse padrão, são IDEs como Eclipse e Intellij).

Descrição do Padrão
O padrão de arquitetura microkernel é caracterizado por dois componentes principais: core system e plugin modules. A lógica da aplicação é dividida entre módulos independentes de plugins e o core system, promovendo a extensibilidade, flexibilidade e isolamento das features e lógicas de processamento da aplicação.

![image](https://github.com/user-attachments/assets/e42f896d-8013-4e6a-80c2-18dbe414a514)

O core system no padrão de arquitetura microkernel normalmente contém somente as funcionalidades mínimas necessárias para tornar o sistema "operacional". Muitos sistemas operacionais implementam o padrão de arquitetura microkernel, de onde vem a origem do nome desse padrão. De uma perspectiva de aplicações corporativas, o core system contém somente a lógica básica de negócio (sem casos especiais ou funcionalidades adicionais mais complexas).

Os módulos de plugins são stand-alone, dado que são componentes independentes que contém funcionalidades adicionais, algum tipo especializado de processamento e código customizado que extendem as funcionalidades básicas do core para agregar novas lógicas de negócio à aplicação. No geral, os módulos de plugins devem ser independentes de outros módulos de plug-ins, mas você pode optar por desenhar plugins que dependem da presença de outros plugins para funcionar. De qualquer forma, é importante manter o mínimo de comunicação entre os plugins para evitar possíveis problemas de dependência.

O core system precisa saber quais módulos de plugins estão disponíveis e como chegar até eles. Uma abordagem comum de implementação de fazer isso é utilizar uma espécie de registro de plugins. Esse registro contém informações sobre cada módulo de plugin, incluindo coisas como nome, contrato, detalhes sobre acesso remoto (dependendo de como o plug-in é conectado ao core system).

Os módulos de plugins podem ser conectados ao core system de diferentes formas, troca de mensagens, serviços, ou até mesmo através de uma conexão direta instanciando objetos, por exemplo. O tipo de conexão que você utiliza depende do tipo da aplicação que você está construindo (pequenos produtos ou grandes aplicações corporativas) e as suas necessidades específicas (único deploy ou deploy distribuído). O padrão de arquitetura por si só não especifica qualquer detalhe sobre implementação, apenas diz que os módulos de plugins devem ser independentes uns dos outros.

Considerações
Algo muito bom sobre o padrão de arquitetura microkernel é que ele pode ser usado como parte de outro padrão de arquitetura. Por exemplo, se esse padrão resolve um problema que você tem em uma área muito volátil da aplicação, você pode descobrir que não pode implementar a arquitetura inteira utilizando esse padrão. Nesse caso, você pode escolher um padrão e implementá-lo junto com outro, por exemplo, você pode implementar o padrão de arquitetura de microsserviços usando o padrão de arquitetura em camadas, ou implementar os componentes event processors (arquitetura orientada a eventos), usando o padrão de arquitetura de microsserviços.

Análise do Padrão
Agilidade Geral
Classificação: ALTA

Agilidade geral é a capacidade de responder rapidamente em um ambiente de constantes mudanças. As mudanças podem ser isoladas e implementadas rapidamente através de módulos de plugins altamente desacoplados. Em geral, o core system de uma arquitetura microkernel se torna estável rapidamente, e com o passar do tempo raramente precisa de mudanças.

Fácil de Implantar
Classificação: ALTA

Dependendo de como o padrão é implementado, os módulos de plugins podem ser adicionados dinamicamente ao core system em tempo de execução, minimizando o tempo que a aplicação fica indisponível durante o deploy.

Testabilidade
Classificação: ALTA

Os módulos de plugins podem ser testados de maneira isolada e podem ser facilmente "mockados" pelo core system para demonstrar ou prototipar uma feature particular com o mínimo de alterações no core system.

Desempenho
Classificação: ALTA

Embora o padrão de arquitetura microkernel por si só não entrega aplicações com alto desempenho, a maioria das aplicações construídas com esse padrão tende a ter alta performance devido a capacidade de customização, incluindo somente as features que você precisa, reduzindo o consumo de memória e CPU.

Escalabilidade
Classificação: BAIXA

Dependendo de como você implementa os módulos de plugins, você pode às vezes prover escalabilidade a nível de feature ou do plugin em si, mas no geral, esse padrão não é conhecido por produzir aplicações altamente escaláveis.

Fácil de Desenvolver
Classificação: BAIXA

O padrão de arquitetura microkernel requer um trabalho considerável de design e governança de contrato dos plugins, o que torna a sua implementação um tanto complexa. O versionamento de contrato, os registros internos dos plugins, a granularidade dos plugins e as escolhas de como se conectar a cada plugin são fatores que contribuem diretamente para o aumento da complexidade envolvida na implementação desse padrão.

Fonte https://jeziellago.medium.com/padr%C3%B5es-de-arquitetura-de-software-parte-iii-9e2fae850b5
