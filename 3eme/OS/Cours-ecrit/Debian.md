## Paramétrages Linux

- On utilise toujours un compte à accès restreint et ensuite on exécute les commandes en mode superutilisateur. De cette façon, si l'on trouve le mot de passe de notre utilisateur, le "hacker" n'a aucun accès au superutilisateur.

- On choisit des mot de passe différents ainsi qu'un nom d'utilisateur assez dur à trouver pour garantir une sécurité maximale.

## Types de disques durs

    sda -> SCSI Disk A (pour le premier disque)
    de type:
        - ext4 : extended4 système de fichier journalisé.
        - swap : échange

On ajoute un UUID aux disques et aux partitions pour éviter de perdre nos données si nous changeons un disque dur d'emplacement SAS/SATA ou si l'on rajouter une partition entre deux déjà existantes.

* Chez Windows on travaille avec un fichier d'échange.

* Sous Linux on travaille avec une partition d'échange.

## Configuration IP

Il est important de configurer une IP statique à un serveur __le plus rapidement possible__ afin de pouvoir y accéder à distance et donc éviter d'aller en salle de serveur tout le temps.

Le nom des interfaces et changé, par exemple:

- lo : interface de loopback
- ens32 : interface réseau (adresse ip: 192.168.XXX.XXX) nommé inet
    - link/ether = adresse MAC
    - inet6 : réseau IPv6

## Commandes liés

- iproute : 
    - va retourner par exemple: "default via 192.168.64.2 dev ens32"
    - qui veut dire qu'on doit contacter la default gateway via notre interface ens32.

- _ip -4 a_ : n'affiche que la configuration IPv4
- _ip -6 a_ : n'affiche que la configuration IPv6
- _ip a show ens32_ : n'affiche les paramètres d'adresse de l'interface ens32.
- _ip link ls up_ : n'affiche que les interfaces qui sont "up".

- _ip a add 192.168.13.101/24 dev ens34_ : permet d'ajouter l'adresse IP à l'interface ens34.
- _ip a del 192.168.13.101/24 dev ens34_ : permet de supprimer l'adresse IP à l'interface ens34.
- _ip link set up dev ens34_ : permet de monter l'interface ens34.
- _ip link set down dev ens34_ : permet de démonter l'interface ens34.
- _ip link set mtu 1400 dev ens34_ : permet de modifier la MTU liée à une interface réseau.

## Fichiers Linux

- On peut modifier les configurations d'interfaces réseaux dans /etc/network/interfaces
```
allow-hotplug ens34
iface ens34 inet static
    address 192.168.13.101
    netmask 255.255.255.0
    network 192.168.13.0
    broadcast 192.168.13.255
    gateway 192.168.13.1
```

- Dans le fichier fstab (pour File System tab) (dans /etc/), on peut voir tous les points de montages, on peut aussi voir que chaque point de montage à un identifiant unique.
Pour éviter la casse (il est possible de ne plus du tout accèder au dossier racine) on peut faire : "cp /etc/fstab /etc/fstab.org"

- Dans le dossier /dev/, on peut trouver les différents points de montage du système qui correspondent à une interface physique. 

- Les fichiers cachés ont leur nom qui commence par un point.

- On peut aller voir le fichier "resolv.conf" (se trouvant dans /etc/).
    - On peut aller voir dedans les serveurs de noms qu'on devra / pourra contacter.
    - On peut par exemple ajouter le dns de google en ajoutant:
    ```
        dns-nameservers 8.8.8.8 8.8.4.4
    ```

- Dans le dossier _/etc/apt/_, on retrouve un fichier _sources.list_ qui contient l'adresse des serveurs 

## Elements linux

- '/' : répertoire racine, sommet d'arborescence unique.
- '.' : répertoire courant.
- '..' : lien vers le répertoire parent (est un fichier).
- $PATH : variable d'environnement comprenant l'ensemble des endroits à chercher pour un exécutable, si l'on tape une commande qui n'est pas liée aux commandes internes.

## Commandes linux

- _cd_ -> Change Directory -> Changement absolu, on ne peut accéder à des dossiers qui font parti du dossier courant. L'usage de la commande `cd` toute seule permet à l'utilisateur de se déplacer dans son fichier racine.
- _ls [-al]_ -> Montre ___tous___ (grâce à -al) les nodes du répertoire courant.
    - Grâce à cette commande, on peut voir les droits en lecture / écriture sur les différents dossiers / fichiers du répertoire visé. 
    - exemple:
        - -rwx--r--r-- root root : Le super utilisateur `root` à les droits en lecture/écriture, le groupe utilisateur `root` à les droits en lecture. Les autres utilisateurs ont le droit de lecture.
- _pwd_ -> print working directory.
- _cp_ -> Copy, permet de copier un fichier ou alors d'effectuer une sauvegarde, exemple: `cp interfaces interfaces.org`. interfaces.org contient donc le backup de notre fichier interfaces.
- _shutdown -h now_ : Eteint le serveur.
- _su_ Permet de devenir le `superutilisateur` de l'environnment de travail.
- _find / -name iptables_ Permet de trouver le chemin, ici, à partir du sommet de l'arborescence jusqu'à iptables. 
- _ip link set up <interface>_ Permet, ici, de connecter la couche de liaison liée à l'interface.
- _apt-get [install/remove/purge/...] <package>_ Permet d'installer, de modifier, de supprimer un package. _remove_ et _purge_ suppriment tout deux un package mais la commande _purge_ enlève aussi les fichiers de configuration associé au package.
- _grep_ Permet de rechercher un pattern à l'intérieur d'un fichier


Si on est connecté comme root, les dossiers personnels sont dans le dossier `/root`.

Si l'on est connecté comme un utilisateur normal, les dossiers personnels sont localisés dans `/home/$USER`.

## Les Manpages

Soit X, une commande dont on désire connaître le fonctionnement.

Nous pouvons accéder à son manuel en tapant dans notre console _man X_.

## Iptables

Firewall : Le firewall est un peu fait à la sauce Microsoft, il n'est pas stateful

On peut démontrer qu'iptables est par défaut stateless, nous pouvons vérifier cela en tapant la commande : "/usr/sbin/iptables -L"

Pour transformer iptables en firewall stateful.

Pour dropper tous les paquets en entrée on peut taper la commande : "./iptables -P INPUT DROP"
Pour les accepter : "iptables -P INPUT ACCEPT"

## SSH

Le daemon SSHD n'est pas protégé de base, on peut aller éditer la configuration dans : "/etc/ssh/sshd_config"

Nous avons par exemple les propriétés:
- Port <int> : Permet de configurer le port sur lequel on va accéder pour ssh.
- ListenAddress 0.0.0.0 | :: : Permet de set l'adresse réseau sur laquelle écouter IPv4 et/ou IPv6.
- MaxAuthTries <int> : Permet de configurer un nombre d'essais d'authentification de base.
- MaxSessions <int> : Permet de configurer un nombre de sessions simultanées par défaut.
- LoginGraceTime 2m : Permet de configurer un temps maximal pour se connecter à un utilisateur.

## Créer une partition

Comme dit plus haut, on peut trouver les points de montage dans le dossier `/dev/` la structure d'un disque est comme celle-là:
S
D
X : Lettre (a,b,...) désignant le numéro du disque physique
<Number> : Numéro de partition

Il n'y a pas de nombre pour un disque non partitionné.
On va donc le partition et ensuite le formater dans le système de fichier journalisé ext4 puis monter la partition pour pouvoir utiliser l'espace de stockage.

On utilisera l'utilitaire fdisk pour le partitioner `/usr/sbin/fdisk /dev/sdb`, on peut créer une nouvelle partition avec la touche `n` on suit ensuite les consignes données et on peut par après sauvegarder nos changements avec la touche `w`.

On peut ensuite le formater en ext4 avec la commande `/usr/sbin/mkfs.ext4 /dev/sdb1`.

Pour la monter, on peut faire `mount -t ext4 /dev/sd1 <dir>` : Dir est le dossier à partir duquel on pourra accèder à notre partition.
Si l'on veut enlever le montage, on peut utiliser la commande `umount <dir>`.

## Les principaux dossiers Linux

/dev -> devices.
/home -> fichiers des utilisateurs.
/var -> fichiers temporaires ou qui vont changer au fil du temps.
/root -> fichiers du super utilisateur?
/bin & /sbin -> binaire -> exécutables (soit du système d'exploitation ou alors des commandes externes utilisables par les utilisateurs).
/media -> répertoire contenant des points de montage pour des cd.


# Pour la prochaine fois -> RAID 