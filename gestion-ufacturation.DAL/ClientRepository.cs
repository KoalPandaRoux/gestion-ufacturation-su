using gestion_ufacturation.SHARED;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_ufacturation.DAL
{
    public class ClientRepository : BaseRepository
    {
        public void Ajouter(Clients clients)
        {
            // Ajouter en base
            // Méthode pour ajouter un contact

            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();

                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = base.connection.CreateCommand();

                // Requête SQL
                cmd.CommandText = "INSERT INTO client (nom,prenom,numero_telephone,adresse) VALUES (@nom,@prenom,@numero_telephone,@adresse)";


                // utilisation de l'objet contact passé en paramètre
                cmd.Parameters.AddWithValue("@nom", clients.nom);
                cmd.Parameters.AddWithValue("@prenom", clients.prenom);
                cmd.Parameters.AddWithValue("@numero_telephone", clients.numero_telephone);
                cmd.Parameters.AddWithValue("@adresse", clients.adresse);

                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();

                // Fermeture de la connexion
                this.connection.Close();

            }
            catch (Exception ex)
            {
                // Gestion des erreurs :
                // Possibilité de créer un Logger pour les exceptions SQL reçus
                // Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.
                Console.WriteLine(ex.ToString());
            }
        }

        public List<Clients> GetClients()
        {
            List<Clients> clients = new List<Clients>();
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();

                // Création d'une commande SQL en fonction de l'objet connection
                // Requête SQL

                MySqlCommand cmd = base.connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM client";

                MySqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    {
                        clients.Add(
                                new Clients
                                {
                                    id = Convert.ToInt16(rdr[0].ToString()),
                                    nom = rdr[1].ToString(),
                                    prenom = rdr[2].ToString(),
                                    numero_telephone = rdr[3].ToString(),
                                    adresse = rdr[4].ToString()
                                });
                        rdr.Close();
                    }

                    // Exécution de la commande SQL
                    cmd.ExecuteNonQuery();

                    // Fermeture de la connexion
                    this.connection.Close();

                }
            }
            catch (Exception ex)
            {
                // Gestion des erreurs :
                // Possibilité de créer un Logger pour les exceptions SQL reçus
                // Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.
                Console.WriteLine(ex.ToString());
            }
            return clients;
        }

    }

}
