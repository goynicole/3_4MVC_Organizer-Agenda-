# Agenda d'un cabinet de courtiers

>Les exercices sont à faire sur **Visual Studio**, dans une **Application web ASP.NET (.NET Framework)** en utilisant un modèle **Vide** et en ajoutant des **dossiers et des références de base** pour **MVC** afin de respecter une architecture Model-View-Controller.  
*Attention : penser à soigner le style de votre application.*  

## Exercice 1  
Créer le MCD de l'Agenda.  
Il doit contenir 3 tables.  
1. Table **brokers** contenant les éléments suivants :  

| Colonne     | Type      | Attributs                     |
|-------------|-----------|-------------------------------|
| idBroker    | INT       | Auto-incrémenté, clé primaire |
| lastname    | NVARCHAR  | 50 |
| firstname   | NVARCHAR  | 50 |
| mail        | VARCHAR   | 100 |
| phoneNumber | VARCHAR   | 10 |

2. Table **customers** contenant les éléments suivants :

| Colonne       | Type      | Attributs                     |
| ------------- | --------- | ----------------------------- |
| idCustomer    | INT       | Auto-incrémenté, clé primaire |
| lastname      | NVARCHAR  | 50 |
| firstname     | NVARCHAR  | 50 |
| mail          | VARCHAR   | 100 |
| phoneNumber   | VARCHAR   | 10 |
| budget        | INT       | |
| subject       | TEXT      | |

3. Table **appointments** contenant les éléments suivants :  

| Colonne       | Type        | Attributs                     |
| ------------- | ----------- | ----------------------------- |
| idAppointment | INT         | Auto-incrémenté, clé primaire |
| dateHour      | DATETIME    | |

## Exercice 2  
Créer une base de données **agenda** et y insérer le script SQL Server généré avec le logiciel JMerise à partir de l'exercice précédent.

## Exercice 3  
Faire la maquette de la page index de votre agenda.  
La page index devra contenir :  
  * Une zone avec la date du jour  
  * Une zone permettant d'afficher la liste des rendez-vous

Depuis la page index on pourra se rendre sur les pages :  
  * addBroker  
  * addCustomer
  * addAppointment  
  * listBrokers  
  * listCustomers  

## Exercice 4  
Créer une page **addBroker** comportant un formulaire permettant à la secrétaire du cabinet de courtiers de créer un nouveau collaborateur.  
Cette page doit être accessible depuis la page **index**.  

## Exercice 5  
Créer une page **listBrokers** et y afficher la liste des courtiers. La page doit être accessible depuis la page **index**.  
Ajouter un lien vers la page **addBroker**.

## Exercice 6  
Créer une page **profilBroker** permettant d'afficher toutes les informations d'un courtier.  
Cette page doit être accessible depuis la page **listBrokers** et elle doit afficher les informations du courtier sélectionné.

## Exercice 7  
Depuis la page **profilBroker** permettre la modification de ce courtier.

## Exercice 8  
Créer une page **addCustomer** comportant un formulaire permettant à la secrétaire du cabinet de courtiers de créer un nouveau client.  
Cette page doit être accessible depuis la page **index**.

## Exercice 9  
Créer une page **listCustomers** et y afficher la liste des clients. La page doit être accessible depuis la page **index**.  
Ajouter un lien vers la page **addCustomer**.

## Exercice 10  
Créer une page **profilCustomer** permettant d'afficher toutes les informations d'un client.  
Cette page doit être accessible depuis la page **listCustomers** et elle doit afficher les informations du client sélectionné.  

## Exercice 11  
Depuis la page **profilCustomer** permettre la modification de ce client.  

## Exercice 12  
Depuis la page **listCustomers** permettre la suppression d'un client.  
*Attention : pensez à demander la confirmation de l'action de suppression*  

## Exercice 13  
Créer une page **addAppointment** comportant un formulaire permettant à la secrétaire du cabinet de courtiers de créer un rendez-vous pour un des clients enregistrés avec l'un des courtiers du cabinet.
Cette page doit être accessible depuis la page **index**.  
**Bonus :** ajouter un lien sur la page **listBrokers** permettant de créer un rendez-vous pour le courtier sélectionné.  
*Attention : un courtier ne peut pas avoir 2 rendez-vous en même temps (même jour et même heure)*

## Exercice 14  
Dans la page **index** afficher la liste des rendez-vous. Permettre à la secrétaire du cabinet de courtiers d'avoir des informations supplémentaires sur le rendez-vous sélectionné (*objet du rendez-vous notamment*).  

## Exercice 15  
Depuis la page **index** permettre la suppression d'un rendez-vous.  
*Attention : pensez à demander la confirmation de l'action de suppression*  

## Exercice 16 (bonus)  
Dans la page **listCustomers** ajouter un champ de recherche permettant à la secrétaire du cabinet de courtiers de retrouver plus rapidement un client.  

## Exercice 17 (bonus)  
Créer une pagination dans la page **listCustomers**.
