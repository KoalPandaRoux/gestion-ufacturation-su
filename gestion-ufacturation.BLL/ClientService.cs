using gestion_ufacturation.DAL;
using gestion_ufacturation.SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_ufacturation.BLL
{

    public class ClientService
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Logiciel de facturation");

            Console.WriteLine("Inscription :");


            // Création d'un contact
            Clients clients = new Clients();
            Console.WriteLine("Entrez un nom");
            clients.nom = Console.ReadLine();
            Console.WriteLine("Entrez un prenom");
            clients.prenom = Console.ReadLine();
            Console.WriteLine("Entrez un numéro de téléphone");
            clients.numero_telephone = Console.ReadLine();
            Console.WriteLine("Entrez une adresse");
            clients.adresse = Console.ReadLine();
            //this.Valider.


            // Création de l'objet Bdd pour l'intéraction avec la base de donnée MySQL
            ClientRepository bdd = new ClientRepository();
            bdd.Ajouter(clients);
            bdd.GetClients();

        }

        public void Ajouter(Clients clients)
        {
            // Ajouter client
            clients.DateAjout = DateTime.Now;
            ClientRepository clientRepository = new ClientRepository();
            clientRepository.Ajouter(clients);
        }

        public List<Clients> GetClients()
        {
            ClientRepository clientRepository = new ClientRepository();
            return clientRepository.GetClients();
        }

    }
}

