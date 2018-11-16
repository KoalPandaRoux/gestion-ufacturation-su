using System;
using MySql.Data.MySqlClient;
using Clients.cs;

namespace Facturation
{
    public class Bdd
    {

        private MySqlConnection connection;

        // Constructeur
        public Bdd()
        {
            this.InitConnexion();
        }

        // Méthode pour initialiser la connexion
        private void InitConnexion()
        {
            // Création de la chaîne de connexion
            string connectionString = "server=localhost;user=root;database=gestion-facturation;password=root";
            this.connection = new MySqlConnection(connectionString);
        }

        // Méthode pour ajouter un contact
        public void AddClients(Clients clients)
        {
            try
            {
                // Ouverture de la connexion SQL
                this.connection.Open();

                // Création d'une commande SQL en fonction de l'objet connection
                MySqlCommand cmd = this.connection.CreateCommand();

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

                Affichage();

            }
            catch (Exception ex)
            {
                // Gestion des erreurs :
                // Possibilité de créer un Logger pour les exceptions SQL reçus
                // Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.
                Console.WriteLine(ex.ToString());
            }
        }

        public void Affichage()
        {
            // Ouverture de la connexion SQL
            this.connection.Open();


            // Création d'une commande SQL en fonction de l'objet connection
            MySqlCommand cmd = this.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * FROM CLIENT";
            cmd.ExecuteNonQuery();


            MySqlDataReader rdr2 = cmd.ExecuteReader();

            while (rdr2.Read())
            {

                int ID = int.Parse(rdr2[0].ToString());
                string NOM = rdr2[1].ToString();
                string PRENOM = rdr2[2].ToString();
                string NUMERO_TELEPHONE = rdr2[3].ToString();
                string ADRESSE = rdr2[4].ToString();
                Console.WriteLine("Id : " + ID + "\n Nom : " + NOM + "\n Prenom : " + PRENOM + "\n numero de telephone : " + NUMERO_TELEPHONE + "\n Adresse : " + ADRESSE + "\n\n\n");
            }

            // Fermeture de la connexion
            this.connection.Close();


        }
    }
}