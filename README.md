# Calculatrice RPN - Guide de Projet

## Introduction

Dans le cadre de cette mission, l'objectif est de concevoir et de mettre en œuvre une calculatrice utilisant la notation polonaise inversée (RPN) en mode client/serveur. La notation RPN est un modèle mathématique dans lequel les opérations sont effectuées en plaçant les opérandes avant les opérateurs, offrant ainsi une manière efficace de résoudre des expressions mathématiques. Ce guide détaille les étapes à suivre pour réaliser ce projet.

## Langages et Technologies Utilisés

- **Backend** : L'infrastructure côté serveur sera mise en place en utilisant .NET Core pour développer une API REST. .NET Core est une plateforme de développement robuste et évolutive pour la création d'applications web.

- **Frontend** : L'interface utilisateur sera réalisée à l'aide de Swagger, qui fournit une documentation interactive et un environnement de test pour l'API REST.

## Fonctionnalités Demandées

Le projet nécessite la mise en œuvre des fonctionnalités suivantes :

1. **Ajout d'un Élément dans une Pile** : Les utilisateurs doivent pouvoir ajouter des éléments à la pile de la calculatrice en entrant des valeurs numériques.

2. **Récupération de la Pile** : La calculatrice doit être capable de renvoyer l'état actuel de la pile sous forme de liste.

3. **Nettoyage de la Pile** : Une fonctionnalité permettant de vider complètement la pile.

4. **Opération +** : Implémentation de l'opération d'addition en utilisant la notation RPN.

5. **Opération -** : Implémentation de l'opération de soustraction en utilisant la notation RPN.

6. **Opération *** : Implémentation de l'opération de multiplication en utilisant la notation RPN.

7. **Opération /** : Implémentation de l'opération de division en utilisant la notation RPN.

## Livrables

À la fin de la mission, vous devez fournir les éléments suivants :

- **Code** : Vous devez livrer le code source complet du projet sur un référentiel GitHub (repo) que vous communiquerez à votre client. Assurez-vous que le code est bien organisé et commenté pour une compréhension facile.

- **ToDo** : Créez un fichier "todo.md" qui répertorie toutes les améliorations possibles ou les raccourcis pris en raison des contraintes de temps. Cela aidera à identifier les domaines où le projet peut être amélioré à l'avenir.

- **Roadmap** : Créez un fichier "roadmap.md" qui répertorie quelques fonctionnalités potentielles qui pourraient être ajoutées au projet à l'avenir. Cela constituera une première backlog pour les développements futurs.

## Ressources Additionnelles

- Pour en savoir plus sur la notation polonaise inverse (RPN), consultez [ce lien](https://fr.wikipedia.org/wiki/Notation_polonaise_inverse).

- Pour des informations sur Swagger et comment documenter une API ASP.NET Core, référez-vous à [ce tutoriel](https://rdonfack.developpez.com/tutoriels/documenter-web-api-aspnet-core-swagger/).

## Première Étape du Code : 30/09/2023

Pour démarrer le projet, suivez ces étapes :

1. **Création d'un Git Privé** :

   - Utilisez l'adresse e-mail `mftrade@live.fr` pour créer un compte GitHub si vous n'en avez pas déjà un.

   - Créez un nouveau référentiel Git privé pour votre projet de calculatrice RPN.

   - Invitez Christophe et Grégoire à collaborer sur ce référentiel en leur fournissant l'accès avec l'adresse e-mail et le mot de passe que vous avez fournis.

2. **Installation de GitHub Desktop** :

   - Téléchargez et installez [GitHub Desktop](https://desktop.github.com/) pour faciliter la gestion de votre référentiel Git.

3. **Set Up de Visual Studio 2022** :

   - Assurez-vous d'avoir installé Visual Studio 2022 sur votre machine.

4. **Création d'un Nouveau Projet** :

   - Créez un nouveau projet "API Web ASP.NET CORE" dans Visual Studio 2022 pour le backend de l'API REST.

   - Ajoutez Swagger à votre projet pour créer une documentation interactive pour l'API. Pour installer Swagger, utilisez la commande `dotnet add package Swashbuckle.AspNetCore`.

   - Une fois Swagger installé, créez un dossier Swagger avec un fichier JSON associé pour configurer Swagger.

   - À l'aide de http://localhost:5000/swagger, vous pouvez accéder à l'API en local avec une interface Swagger pour une meilleure visualisation et test.
  
5. **Premiere requete PUSH ET PILE** :
   
   - Actuellement, l'API permet d'ajouter des éléments à la pile et de récupérer l'état actuel de la pile sous forme de liste, avec un affichage des index.
   - J'utilise également la fonction FromBody pour éviter d'ajouter des informations inutiles à la requête API.
   - J'ai rencontré un problème où l'ajout d'éléments n'enregistrait pas les informations correctement, ce qui écrasait la pile existante. J'ai donc ajouté une classe PileElement pour corriger ce problème.
  

