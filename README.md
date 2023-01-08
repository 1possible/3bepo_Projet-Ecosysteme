*Projet réalisé par **Emilie Van Bogaert** (21258) et **Corentin Thibaut** (195038)*
---
# 3bepo_Projet-Ecosysteme

## UML de Class
![Alt text](UML/DiagrammeClass.jpg?raw=true "UML de class")
---
## UML de sequence
![Alt text](UML/DiagramSequenceUpdateSimulation.jpg?raw=true "UML Sequence de la fonction update de Simulation")
![Alt text](UML/DiagramsSequenceMeatUpdate.jpg?raw=true "UML Sequence de la fonction update de Meat")
---
## Principe SOLID
### Principe de substitution de Liskov
énoncé du principe:
>Tout Type devrait pouvoir être remplacé par un sous-type, sans que le programme devienne sémantiquement incorrect.

Dans notre code on défini beaucoup d'argument pour les constructeurs de sous-classe, de cette manière on maintient le code flexible et sémantiquement correcte.

### Principe Ouvert/Fermé
énoncé du principe:
>Une classe doit être ouvert à l'extension, mais fermé à la modification.

Par exemple, dans notre projet, il est possible de rajouter des espèces d'animaux et de plantes facilement, sans devoir modifier les superclasses Animaux, LifeForm, etc...
