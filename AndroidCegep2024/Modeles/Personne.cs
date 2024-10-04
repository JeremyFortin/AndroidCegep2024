
/// <summary>
/// Namespace pour les classes de type Modèle.
/// </summary>
namespace AndroidCegep2024.Modeles
{
    /// <summary>
    /// Classe de type Modele représentant un personne.
    /// </summary>
    public class Personne
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant le prénom d'une personne.
        /// </summary>
        private string prenom;
        /// <summary>
        /// Propriété représentant le prénom d'une personne.
        /// </summary>
        public string Prenom
        {
            get { return prenom; }
            set
            {
                if (value.Length <= 50)
                    prenom = value;
                else
                    throw new Exception("Le prénom d'une personne doit avoir un maximum de 50 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant le nom d'une personne.
        /// </summary>
        private string nom;
        /// <summary>
        /// Propriété représentant le nom d'une personne.
        /// </summary>
        public string Nom
        {
            get { return nom; }
            set
            {
                if (value.Length <= 50)
                    nom = value;
                else
                    throw new Exception("Le nom d'une personne doit avoir un maximum de 50 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant l'adresse d'une personne.
        /// </summary>
        private string adresse;
        /// <summary>
        /// Propriété représentant l'adresse d'une personne.
        /// </summary>
        public string Adresse
        {
            get { return adresse; }
            set
            {
                if (value.Length <= 100)
                    adresse = value;
                else
                    throw new Exception("L'adresse d'une personne doit avoir un maximum de 100 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant la ville d'une personne.
        /// </summary>
        private string ville;
        /// <summary>
        /// Propriété représentant la ville d'une personne.
        /// </summary>
        public string Ville
        {
            get { return ville; }
            set
            {
                if (value.Length <= 100)
                    ville = value;
                else
                    throw new Exception("La ville d'une personne doit avoir un maximum de 100 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant la province d'une personne.
        /// </summary>
        private string province;
        /// <summary>
        /// Propriété représentant la province d'une personne.
        /// </summary>
        public string Province
        {
            get { return province; }
            set
            {
                if (value.Length <= 50)
                    province = value;
                else
                    throw new Exception("La province d'une personne doit avoir un maximum de 50 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant le code postal d'une personne.
        /// </summary>
        private string codePostal;
        /// <summary>
        /// Propriété représentant le code postal d'une personne.
        /// </summary>
        public string CodePostal
        {
            get { return codePostal; }
            set
            {
                if (value.Length <= 7)
                    codePostal = value;
                else
                    throw new Exception("Le code postal d'une personne doit avoir un maximum de 7 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant le téléphone d'une personne.
        /// </summary>
        private string telephone;
        /// <summary>
        /// Propriété représentant le téléphone d'une personne.
        /// </summary>
        public string Telephone
        {
            get { return telephone; }
            set
            {
                if (value.Length <= 12)
                    telephone = value;
                else
                    throw new Exception("Le téléphone d'une personne doit avoir un maximum de 12 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant le courriel d'une personne.
        /// </summary>
        private string courriel;
        /// <summary>
        /// Propriété représentant le courriel d'une personne.
        /// </summary>
        public string Courriel
        {
            get { return courriel; }
            set
            {
                if (value.Length <= 100)
                    courriel = value;
                else
                    throw new Exception("Le courriel d'une personne doit avoir un maximum de 100 caractères.");
            }
        }

        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur avec paramètres.
        /// </summary>
        /// <param name="unPrenom">Le prénom d'une personne.</param>
        /// <param name="unNom">Le nom d'une personne.</param>
        /// <param name="uneAdresse">L'adresse d'une personne.</param>
        /// <param name="uneVille">La ville d'une personne.</param>
        /// <param name="uneProvince">La province d'une personne.</param>
        /// <param name="unCodePostal">Le code postal d'une personne.</param>
        /// <param name="unTelephone">Le téléphone d'une personne.</param>
        /// <param name="unCourriel">Le courriel d'une personne.</param>
        public Personne(string unPrenom="", string unNom="", string uneAdresse="", string uneVille="", string uneProvince="", string unCodePostal="", string unTelephone="", string unCourriel="")
        {
            Prenom = unPrenom;
            Nom = unNom;
            Adresse = uneAdresse;
            Ville = uneVille;
            Province = uneProvince;
            CodePostal = unCodePostal;
            Telephone = unTelephone;
            Courriel = unCourriel;
        }

        #endregion Constructeurs
    }
}
