
/// <summary>
/// Namespace pour les classes de type Modèle.
/// </summary>
namespace AndroidCegep2024.Modeles
{
    /// <summary>
    /// Classe représentant un Cégep.
    /// </summary>
    public class Cegep
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant le nom du Cégep.
        /// </summary>
        private string nom;
        /// <summary>
        /// Propriété représentant le nom du Cégep.
        /// </summary>
        public string Nom
        {
            get { return nom; }
            set {
                    if (value.Length <= 50)
                        nom = value;
                    else
                        throw new Exception("Le nom du Cégep doit avoir un maximum de 50 caractères.");
                }
        }

        /// <summary>
        /// Attribut représentant l'adresse du Cégep.
        /// </summary>
        private string adresse;
        /// <summary>
        /// Propriété représentant l'adresse du Cégep.
        /// </summary>
        public string Adresse
        {
            get { return adresse; }
            set
            {
                if (value.Length <= 100)
                    adresse = value;
                else
                    throw new Exception("L'adresse du Cégep doit avoir un maximum de 100 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant la ville du Cégep.
        /// </summary>
        private string ville;
        /// <summary>
        /// Propriété représentant la ville du Cégep.
        /// </summary>
        public string Ville
        {
            get { return ville; }
            set
            {
                if (value.Length <= 75)
                    ville = value;
                else
                    throw new Exception("La ville du Cégep doit avoir un maximum de 75 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant la province du Cégep.
        /// </summary>
        private string province;
        /// <summary>
        /// Propriété représentant la province du Cégep.
        /// </summary>
        public string Province
        {
            get { return province; }
            set
            {
                if (value.Length <= 50)
                    province = value;
                else
                    throw new Exception("La province du Cégep doit avoir un maximum de 50 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant le code postal du Cégep.
        /// </summary>
        private string codePostal;
        /// <summary>
        /// Propriété représentant le code postal du Cégep.
        /// </summary>
        public string CodePostal
        {
            get { return codePostal; }
            set
            {
                if (value.Length <= 7)
                    codePostal = value;
                else
                    throw new Exception("Le code postal du Cégep doit avoir un maximum de 7 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant le telephone du Cégep.
        /// </summary>
        private string telephone;
        /// <summary>
        /// Propriété représentant le telephone du Cégep.
        /// </summary>
        public string Telephone
        {
            get { return telephone; }
            set
            {
                if (value.Length <= 12)
                    telephone = value;
                else
                    throw new Exception("Le téléphone du Cégep doit avoir un maximum de 12 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant le courriel du Cégep.
        /// </summary>
        private string courriel;
        /// <summary>
        /// Propriété représentant le courriel du Cégep.
        /// </summary>
        public string Courriel
        {
            get { return courriel; }
            set
            {
                if (value.Length <= 100)
                    courriel = value;
                else
                    throw new Exception("Le courriel du Cégep doit avoir un maximum de 100 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant la liste des départements du Cégep.
        /// </summary>
        public List<Departement> listeDepartement;

        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur paramétré
        /// </summary>
        /// <param name="unNom">Le nom du cégep</param>
        /// <param name="uneAdresse">L'adresse du cégep</param>
        /// <param name="uneVille">La ville du cégep</param>
        /// <param name="uneProvince">La province du cégep</param>
        /// <param name="unCodePostal">Le code postal du cégep</param>
        /// <param name="unTelephone">Le téléphone du cégep</param>
        /// <param name="unCourriel">Le courriel du cégep</param>
        public Cegep(string unNom="", string uneAdresse="", string uneVille="", string uneProvince="", string unCodePostal="", string unTelephone="", string unCourriel="")
        {
            Nom = unNom;
            Adresse = uneAdresse;
            Ville = uneVille;
            Province = uneProvince;
            CodePostal = unCodePostal;
            Telephone = unTelephone;
            Courriel = unCourriel;
            listeDepartement = new List<Departement>();
        }

        #endregion Constructeurs

        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des départements du cégep.
        /// </summary>
        /// <returns>Un tableau de départements</returns>
        public Departement[] ObtenirListeDepartement()
        {
            return listeDepartement.ToArray();
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un département.
        /// </summary>
        /// <param name="unDepartement">L'objet département que l'on veut avoir en fournissant les informations nécessaire dans le Equals.</param>
        /// <returns>Le département qui correspond ou null si l'on a rien trouvé.</returns>
        public Departement ObtenirDepartement(Departement unDepartement)
        {
            return listeDepartement.Find(x => x.Equals(unDepartement));
        }

        /// <summary>
        /// Méthode de service permettant de vérifier si un département est présent dans la liste.
        /// </summary>
        /// <param name="unDepartement">Le département que l'on cherche. (Information du Equals)</param>
        /// <returns>Vrai si le département est trouvé, Faux sinon...</returns>
        public bool SiDepartementPresent(Departement unDepartement)
        {
            return listeDepartement.Contains(unDepartement);
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter un département à la liste.
        /// </summary>
        /// <param name="unDepartement">Le département à ajouter.</param>
        public void AjouterDepartement(Departement unDepartement)
        {
            if (SiDepartementPresent(unDepartement))
                throw new Exception("Erreur - Le département est déjà présent.");
            listeDepartement.Add(unDepartement);
            if (!SiDepartementPresent(unDepartement))
                throw new Exception("Erreur - Problème lors de l'ajout du département.");
        }

        /// <summary>
        /// Méthode de service permettant d'enlever un département à la liste.
        /// </summary>
        /// <param name="unDepartement">Le département à enlever.</param>
        public void EnleverDepartement(Departement unDepartement)
        {
            if (!SiDepartementPresent(unDepartement))
                throw new Exception("Erreur - Le département est déjà absent.");
            listeDepartement.Remove(unDepartement);
            if (SiDepartementPresent(unDepartement))
                throw new Exception("Erreur - Problème lors de l'enlèvement du département.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le nombre de département du Cégep.
        /// </summary>
        /// <returns>Nombre de département.</returns>
        public int ObtenirNombreDepartement()
        {
            return listeDepartement.Count;
        }

        /// <summary>
        /// Méthode de service permettant de savoir si le Cégep a aucun département.
        /// </summary>
        /// <returns>Vrai si aucun département, Faux sinon...</returns>
        public bool SiAucunDepartement()
        {
            return ObtenirNombreDepartement() == 0;
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des département du Cégep.
        /// </summary>
        public void ViderListeDepartement()
        {
            if (ObtenirNombreDepartement() == 0)
                throw new Exception("Erreur - La liste des département est déjà vide.");
            listeDepartement.Clear();
            if (!SiAucunDepartement())
                throw new Exception("Erreur - Problème lors du vidage de la liste des départements.");
        }

        /// <summary>
        /// Méthode de service permettant de calculer la somme des étudiants du Cégep.
        /// </summary>
        /// <returns>Nombre d'étudiants dans le Cégep.</returns>
        public int CalculerSommeEtudiant()
        {
            return ObtenirListeDepartement().Sum(x => x.ObtenirNombreEtudiant());
        }

        /// <summary>
        /// Méthode de service permettant de faire la moyenne des étudiants par département du Cégep.
        /// </summary>
        /// <returns>Moyenne des étudiants par département du Cégep.</returns>
        public double CalculerMoyenneEtudiantDepartement()
        {
            return ObtenirListeDepartement().Average(x => x.ObtenirNombreEtudiant());
        }

        #endregion MethodesService

        #region Overrides

        /// <summary>
        /// Méthode de service permettant d'obternir la version textuelle de l'objet Cegep.
        /// </summary>
        /// <returns>Version textuelle de l'objet Cegep.</returns>
        public override string ToString()
        {
            return Nom + "\n" + Adresse + "\n" + Ville + ", "
                    + Province + "\n" + CodePostal + "\n" + Telephone + "\n" + Courriel;
        }

        /// <summary>
        /// Méthode de service permettant de vérifier l'égalité entre deux objet Cegep.
        /// Deux objets Cegep sont égaux s'ils ont le même nom.
        /// </summary>
        /// <param name="obj">L'objet de comparaison.</param>
        /// <returns>Vrai si égal, Faux sinon...</returns>
        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is Cegep) && Nom.Equals((obj as Cegep).Nom);
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le HashCode de l'objet Cegep.
        /// </summary>
        /// <returns>HashCode de l'objet Cegep.</returns>
        public override int GetHashCode()
        {
            return Nom.Length;
        }

        #endregion Overrides
    }
}
