
/// <summary>
/// Namespace pour les classes de type Modèle.
/// </summary>
namespace AndroidCegep2024.Modeles
{
    /// <summary>
    /// Classe représentant un cours.
    /// </summary>
    public class Cours
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant le numéro du cours.
        /// </summary>
        private string no;
        /// <summary>
        /// Propriété représentant le numéro du cours.
        /// </summary>
        public string No
        {
            get { return no; }
            set
            {
                if (value.Length <= 50)
                    no = value;
                else
                    throw new Exception("Le no du cours doit avoir un maximum de 50 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant le nom du cours.
        /// </summary>
        private string nom;
        /// <summary>
        /// Propriété représentant le nom du cours.
        /// </summary>
        public string Nom
        {
            get { return nom; }
            set
            {
                if (value.Length <= 100)
                    nom = value;
                else
                    throw new Exception("Le nom du cours doit avoir un maximum de 100 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant la description du cours.
        /// </summary>
        private string description;
        /// <summary>
        /// Propriété représentant la description du cours.
        /// </summary>
        public string Description
        {
            get { return description; }
            set
            {
                if (value.Length <= 500)
                    description = value;
                else
                    throw new Exception("La description du cours doit avoir un maximum de 500 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant l'enseignant du cours.
        /// </summary>
        private Enseignant enseignant;

        /// <summary>
        /// Attribut représentant la liste des étudiants du cours.
        /// </summary>
        private List<Etudiant> listeEtudiant;

        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur avec paramètres.
        /// </summary>
        /// <param name="unNo">Numéro du cours.</param>
        /// <param name="unNom">Nom du cours.</param>
        /// <param name="uneDescription">Description du cours.</param>
        public Cours(string unNo="", string unNom="", string uneDescription="")
        {
            No = unNo;
            Nom = unNom;
            Description = uneDescription;
            enseignant = new Enseignant();
            listeEtudiant = new List<Etudiant>();
        }

        #endregion Constructeurs

        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des étudiants du cours.
        /// </summary>
        /// <returns>Tableau contenant la liste des étudiants du cours.</returns>
        public Etudiant[] ObtenirListeEtudiant()
        {
            return listeEtudiant.ToArray();
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un étudiant du cours.
        /// </summary>
        /// <param name="unEtudiant">L'étudiant recherché.</param>
        /// <returns>L'étudiant complet.</returns>
        public Etudiant ObtenirEtudiant(Etudiant unEtudiant)
        {
            return listeEtudiant.Find(x => x.Equals(unEtudiant));
        }

        /// <summary>
        /// Méthode de service permettant de savoir si un étudiant est présent.
        /// </summary>
        /// <param name="unEtudiant">L'étudiant recherché.</param>
        /// <returns>Vrai si présent, Faux sinon...</returns>
        public bool SiEtudiantPresent(Etudiant unEtudiant)
        {
            return listeEtudiant.Contains(unEtudiant);
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter un étudiant.
        /// </summary>
        /// <param name="unEtudiant">L'étudiant a ajouter.</param>
        public void AjouterEtudiant(Etudiant unEtudiant)
        {
            if (SiEtudiantPresent(unEtudiant))
                throw new Exception("Erreur - L'étudiant est déjà présent.");
            listeEtudiant.Add(unEtudiant);
            if (!SiEtudiantPresent(unEtudiant))
                throw new Exception("Erreur - Problème lors de l'ajout de l'étudiant.");
        }

        /// <summary>
        /// Méthode de service permettant d'enlever un étudiant.
        /// </summary>
        /// <param name="unEtudiant">L'étudiant a enlever.</param>
        public void EnleverEtudiant(Etudiant unEtudiant)
        {
            if (!SiEtudiantPresent(unEtudiant))
                throw new Exception("Erreur - L'étudiant est déjà absent.");
            listeEtudiant.Remove(unEtudiant);
            if (SiEtudiantPresent(unEtudiant))
                throw new Exception("Erreur - Problème lors de l'enlèvement de l'étudiant.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le nombre d'étudiant présents dans le cours.
        /// </summary>
        /// <returns>Nombre d'étudiants présents dans le cours.</returns>
        public int ObtenirNombreEtudiant()
        {
            return listeEtudiant.Count;
        }

        /// <summary>
        /// Méthode de service permettant de savoir si aucun étudiant n'est présent dans le cours.
        /// </summary>
        /// <returns>Vrai si aucun étudiant dans le cours, Faux sinon...</returns>
        public bool SiAucunEtudiant()
        {
            return ObtenirNombreEtudiant() == 0;
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des étudiants du cours.
        /// </summary>
        public void ViderListeEtudiant()
        {
            if (ObtenirNombreEtudiant() == 0)
                throw new Exception("Erreur - La liste des étudiants est déjà vide.");
            listeEtudiant.Clear();
            if (!SiAucunEtudiant())
                throw new Exception("Erreur - Problème lors du vidage de la liste des étudiants.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir l'enseignant du cours.
        /// </summary>
        /// <returns>L'enseignant.</returns>
        public Enseignant ObtenirEnseignant()
        {
            if (enseignant != null)
                return enseignant;
            else
                throw new Exception("Erreur - Il n'y a aucun enseignant d'affecté au cours.");
        }

        /// <summary>
        /// Méthode de service permettant d'initialiser l'enseignant du cours.
        /// </summary>
        /// <param name="unEnseignant">L'enseignant a effecter au cours.</param>
        public void InitialiserEnseignant(Enseignant unEnseignant)
        {
            enseignant = unEnseignant;
            if (enseignant == null)
                throw new Exception("Erreur - Problème lors de l'initialisation de l'enseignant.");
        }

        /// <summary>
        /// Méthode de service permettant d'enlever l'enseignant du cours.
        /// </summary>
        /// <param name="unEnseignant">L'enseignant a désaffecter.</param>
        public void EnleverEnseignant(Enseignant unEnseignant)
        {
            enseignant = null;
            if (enseignant != null)
                throw new Exception("Erreur - Problème lors de l'enlèvement de l'enseignant.");
        }

        /// <summary>
        /// Méthode de service permettant de savoir si aucun enseignant est affecté au cours.
        /// </summary>
        /// <returns>Vrai au aucun enseignant affecté, Faux sinon...</returns>
        public bool SiAucunEnseignant()
        {
            return enseignant == null;
        }

        #endregion MethodesService

        #region Overrides

        /// <summary>
        /// Méthode de service permettant d'obtenir la version textuelle de l'objet de type Cours.
        /// </summary>
        /// <returns>La version textuelle de l'objet de type Cours.</returns>
        public override string ToString()
        {
            return Nom;
        }

        /// <summary>
        /// Méthode de service permettant de vérifier l'égalité entre deux objet Cours.
        /// Deux objets Cours sont égaux s'ils ont le même nom.
        /// </summary>
        /// <param name="obj">L'objet de comparaison.</param>
        /// <returns>Vrai si égal, Faux sinon...</returns>
        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is Cours) && Nom.Equals((obj as Cours).Nom);
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le HashCode de l'objet Cours.
        /// </summary>
        /// <returns>HashCode de l'objet Cours.</returns>
        public override int GetHashCode()
        {
            return Nom.Length;
        }

        #endregion Overrides
    }
}
