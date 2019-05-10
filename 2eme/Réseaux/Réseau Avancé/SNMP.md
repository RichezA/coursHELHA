# SNMP:
    Simple Network Management Protocol : Protocole simple de gestion de réseau

## DFT:
    protocole de communication permettant aux administrateurs réseaux de gérer les équipements du réseau, de superviser et de diagnostiquer des problèmes réseaux et matériels à distance.
    Utilise les ports 161 (pour les envois aux agents) et 162 (pour les envois au serveur manager) en UDP.

## Les principes
    Basé sur trois éléments principaux:
    - Un manager -> souvent employé comme superviseur
    - des nodes
    - des agents

## Superviseur
    Console qui permet à l'administratuer réseau d'exécuter des requêtes de gestion (de management).

## Agents
    Les agents sont des logiciels qui se trouvent au niveau de chaque interface, connectant au réseau l'équipement géré (nodes) et permettant de récupérer des informations sur différents objets.

## Les équipements gérables
    Les switches, ponts, routeurs, workstation, serveurs (physiques ou virtuels) font partie de ces équipements contenant des objets gérables. Ces objets peuvent être:
    -   Des informations matérielles
    -   Des paramètres de configuration
    -   Des statistiques de performance
    -   Autres objets directement liés au comportement en cours de l'équipement en question
  
    Les objets sont classés dans une base de données définie par l'ISO appelée MIB (Management Information Base). SNMP permet le dialogue entre le manager et les agents en recevant les attributs spécifiques aux équipements gérables dans la MIB.

    Un object Identifier, un composant de la MIB contenant une collection d'attributs qui peuvent ensuite faire l'objet de requêtes ou configuré par un Manager SNMP

## L'architecture de gestion du réseau proposée par le protocole SNMP est donc fondée sur trois éléments principaux:
    - Les équipements gérés sont des éléments du réseau contenant des `objets de gestion` pouvant être des informations sur le matériel, des éléments de configuration ou des informations statiques.
    - Les agents, c-à-d les applications de gestion de réseau résidant dans un périphérique, sont chargés de transmettre les données locales de gestion au format SNMP
    - Les systèmes de gestion de réseau c-à-d les consoles à travers lesquelles les admins peuvent réaliser des tâches d'administration.

## Trap
    Notifications pouvant être envoyés depuis un agent vers le manager sur le port 162 du serveur.

## Versions
    1.0 => Les communautés: Communauté publique (read-only), Communauté privée (read-write) -> problème de sécurité car les utilisateurs mettaient pratiquement toujours les mêmes mots de passe (par défaut public: public, private: private).
    2.C => Toujours des communautés mais upgrade de la 1.0 -> e.g.: beaucoup plus d'informations grâce à une seule requête.
    3.0 => encryptage grâce au DES avec deux mots de passes ou clés sur 64 bits partagés entre l'agent et le manager (authentification/chiffrement) mais cryptage DES dépassé => RFC 3826 implémente AES. On check aussi l'intégrité du paquet (S'assure de l'intégrité du paquet durant son transit), il y'a aussi la mise en place d'un service d'authentification (définit les objets du MIB disponible pour chaque utilisateur ou groupe d'utilisateurs).

## Sources
    [Wikipedia France](https://fr.wikipedia.org/wiki/Simple_Network_Management_Protocol)
    [Wikipedia](https://en.wikipedia.org/wiki/Simple_Network_Management_Protocol)
    [Cisco](https://www.cisco.com/c/en/us/td/docs/ios-xml/ios/snmp/configuration/xe-3se/3850/snmp-xe-3se-3850-book/nm-snmp-snmpv3.pdf)
    [Kevin Wallace](https://www.youtube.com/watch?v=tg47MZdtcAE)