# ProcessCellularBehavior
Este código simula o processo de vida, de multiplicação. De uma Célula de forma bem simples, utilizando o conceito básico de divisão celular. O Código funciona da seguinte forma:

Todas as células quando surgem tem 45,5% de chance de morrer e 15,2% de chance de evoluir em outro espécie. Toda célula tem ciclos cognitivos que tem um tempo para ser completado, esse ciclo começa com 15 segundos de duração. A cada ciclo a célula pode MORRER (De acordo com a % de chance de morrer) ou se REPRODUZIR, quando a célula se reproduz ela pode gerar outra célula da mesma espécie ou de uma espécie evoluida (Essa Parte foi feita para simular a evolução, pois na natureza o processo de evolução é mais complexo). 

Quando uma nova célula surge, se ela for de outra ESPÉCIE, ela tem menos chance de morrer e o seu ciclo cognitivo acontece mais rápido. 

Se a celula tiver mais de 15 ciclos cognitivos, elas se torna velha e tem grande chance de morrer. 

**Ajustes para tornar o processo evolutivo mais rápido da simulação:

A Primeira Celula não pode morrer até que se torne velha.
As Primeiras 5 Células tem menos chance de morrer. 

### Atenção
Cada célula é um PROCESSO no Sistema Operacional, então, isso funciona como um Virus no Sistema Operacional, e o crescimento exponencial pode levar a sua máquina a travar!

## Próximos Passos
- Implementar Ambiente
- Implementar Fontes de Energia
- Implementar processo de troca de energia
- Controle Populacional Relativa ao Consumo de Energia
- Melhorar o Processo Celular para se Aproximar ao Real. 

## Porque?
Essa foi a melhor maneira de implementar um software que simune situações de PROCESS OVERFLOW de forma aleatório no nossos servidores, para assim implementarmos medidas de controle. 