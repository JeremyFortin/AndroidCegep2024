
/// <summary>
/// Namespace pour les classes de type Modèle.
/// </summary>
namespace AndroidCegep2024.Modeles
{
    /// <summary>
    /// Classe de type Modele représentant un département.
    /// </summary>
    public class Departement
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant le numéro du département.
        /// </summary
        private string no;
        /// <summary>
        /// Propriété représentant le numéro du département.
        /// </summary>
        public string No
        {
            get { return no; }
            set
            {
                if (value.Length <= 10)
                    no = value;
                else
                    throw new Exception("Le no du département doit avoir un maximum de 10 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant le nom du département.
        /// </summary>
        private string nom;
        /// <summary>
        /// Propriété représentant le nom du département.
        /// </summary>
        public string Nom
        {
            get { return nom; }
            set
            {
                if (value.Length <= 50)
                    nom = value;
                else
                    throw new Exception("Le nom du département doit avoir un maximum de 50 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant la description du département.
        /// </summary>
        private string description;
        /// <summary>
        /// Propriété représentant la description du département.
        /// </summary>
        public string Description
        {
            get { return description; }
            set
            {
                if (value.Length <= 100)
                    description = value;
                else
                    throw new Exception("Le nom du département doit avoir un maximum de 100 caractères.");
            }
        }

        /// <summary>
        /// Attribut représentant la liste des étudiants du département.
        /// </summary>
        private List<Etudiant> listeEtudiant;

        /// <summary>
        /// Attribut représentant la liste des enseignants du département.
        /// </summary>
        public List<Enseignant> listeEnseignant;

        /// <summary>
        /// Attribut représentant la liste des cours du département.
        /// </summary>
        private List<Cours> listeCours;

        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur avec paramètres.
        /// </summary>
        /// <param name="unNo">Numéro du département.</param>
        /// <param name="unNom">Nom du département.</param>
        /// <param name="uneDescription">Description du département.</param>
        public Departement(string unNo="", string unNom="", string uneDescription="")
        {
            No = unNo;
            Nom = unNom;
            Description = uneDescription;
            listeEtudiant = new List<Etudiant>();
            listeEnseignant = new List<Enseignant>();
            listeCours = new List<Cours>();
        }

        #endregion Constructeurs

        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des étudiants sous forme de tableau.
        /// </summary>
        /// <returns>Tableau contenant la liste des étudiants.</returns>
        public Etudiant[] ObtenirListeEtudiant()
        {
            return listeEtudiant.ToArray();
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un étudiant selon ses informations uniques.
        /// </summary>
        /// <param name="unEtudiant">Etudiant contenant les informations uniques.</param>
        /// <returns>L'étudiant complet désiré.</returns>
        public Etudiant ObtenirEtudiant(Etudiant unEtudiant)
        {
            return listeEtudiant.Find(x => x.Equals(unEtudiant));
        }

        /// <summary>
        /// Méthode de service permettant de savoir si un étudiant est présent dans le département.
        /// </summary>
        /// <param name="unEtudiant">Etudiant contenant les informations uniques.</param>
        /// <returns>True si l'étudiant est présent... False sinon...</returns>
        public bool SiEtudiantPresent(Etudiant unEtudiant)
        {
            return listeEtudiant.Contains(unEtudiant);
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter un étudiant au département.
        /// </summary>
        /// <param name="unEtudiant">L'étudiant a ajouter...</param>
        public void AjouterEtudiant(Etudiant unEtudiant)
        {
            if (SiEtudiantPresent(unEtudiant))
                throw new Exception("Erreur - l'étudiant est déjà présent.");
            listeEtudiant.Add(unEtudiant);
            if (!SiEtudiantPresent(unEtudiant))
                throw new Exception("Erreur - Problème lors de l'ajout de l'étudiant.");
        }

        /// <summary>
        /// Méthode de service permettant d'enlever un étudiant du département.
        /// </summary>
        /// <param name="unEtudiant">L'étudiant contenant les informations uniques a enlever...</param>
        public void EnleverEtudiant(Etudiant unEtudiant)
        {
            if (!SiEtudiantPresent(unEtudiant))
                throw new Exception("Erreur - l'étudiant est déjà absent.");
            listeEtudiant.Remove(unEtudiant);
            if (SiEtudiantPresent(unEtudiant))
                throw new Exception("Erreur - Problème lors de l'enlèvement de l'étudiant.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le nombre d'étudiants du département.
        /// </summary>
        /// <returns>Nombre d'étudiants du département.</returns>
        public int ObtenirNombreEtudiant()
        {
            return listeEtudiant.Count;
        }

        /// <summary>
        /// Méthode de service permettant de savoir s'il y a aucun étudiant dans le département.
        /// </summary>
        /// <returns>True si aucun étudiant, False sinon...</returns>
        public bool SiAucunEtudiant()
        {
            return ObtenirNombreEtudiant() == 0;
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des étudiants du département.
        /// </summary>
        public void ViderListeEtudiant()
        {
            if (ObtenirNombreEtudiant() == 0)
                throw new Exception("Erreur - La liste des étudiant du département est déjà vide.");
            listeEtudiant.Clear();
            if (!SiAucunEtudiant())
                throw new Exception("Erreur - Problème lors du vidage de la liste des étudiants du département.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des enseignants sous forme de tableau.
        /// </summary>
        /// <returns>Tableau contenant la liste des enseignants.</returns>
        public Enseignant[] ObtenirListeEnseignant()
        {
            return listeEnseignant.ToArray();
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un enseignants selon ses informations uniques.
        /// </summary>
        /// <param name="unEnseignant">Enseignant contenant les informations uniques.</param>
        /// <returns>L'enseignant complet désiré.</returns>
        public Enseignant ObtenirEnseignant(Enseignant unEnseignant)
        {
            return listeEnseignant.Find(x => x.Equals(unEnseignant));
        }

        /// <summary>
        /// Méthode de service permettant de savoir si un enseignant est présent dans le département.
        /// </summary>
        /// <param name="unEnseignant">Enseignant contenant les informations uniques.</param>
        /// <returns>True si l'enseignant est présent... False sinon...</returns>
        public bool SiEnseignantPresent(Enseignant unEnseignant)
        {
            return listeEnseignant.Contains(unEnseignant);
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter un enseignant au département.
        /// </summary>
        /// <param name="unEnseignant">L'enseignant a ajouter...</param>
        public void AjouterEnseignant(Enseignant unEnseignant)
        {
            if (SiEnseignantPresent(unEnseignant))
                throw new Exception("Erreur - L'enseignant est déjà présent.");
            listeEnseignant.Add(unEnseignant);
            if (!SiEnseignantPresent(unEnseignant))
                throw new Exception("Erreur - Problème lors de l'ajout d'un enseignant.");
        }

        /// <summary>
        /// Méthode de service permettant d'enlever un enseignant du département.
        /// </summary>
        /// <param name="unEnseignant">L'enseignant contenant les informations uniques a enlever...</param>
        public void EnleverEnseignant(Enseignant unEnseignant)
        {
            if (!SiEnseignantPresent(unEnseignant))
                throw new Exception("Erreur - L'enseignant est déjà absent");
            listeEnseignant.Remove(unEnseignant);
            if (SiEnseignantPresent(unEnseignant))
                throw new Exception("Erreur - Problème lors de l'enlèvement de l'enseignant.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le nombre d'enseignant du département.
        /// </summary>
        /// <returns>Nombre d'enseignants du département.</returns>
        public int ObtenirNombreEnseignant()
        {
            return listeEnseignant.Count;
        }

        /// <summary>
        /// Méthode de service permettant de savoir s'il y a aucun enseignant dans le département.
        /// </summary>
        /// <returns>True si aucun enseignant, False sinon...</returns>
        public bool SiAucunEnseignant()
        {
            return ObtenirNombreEnseignant() == 0;
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des enseignants du département.
        /// </summary>
        public void ViderListeEnseignant()
        {
            if (ObtenirNombreEnseignant() == 0)
                throw new Exception("Erreur - La liste des enseignants du département est déjà vide.");
            listeEnseignant.Clear();
            if (!SiAucunEnseignant())
                throw new Exception("Erreur - Problème lors du vidage de la liste des enseignants du département.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des cours sous forme de tableau.
        /// </summary>
        /// <returns>Tableau contenant la liste des cours.</returns>
        public Cours[] ObtenirListeCours()
        {
            return listeCours.ToArray();
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un cours selon ses informations uniques.
        /// </summary>
        /// <param name="unCours">Cours contenant les informations uniques.</param>
        /// <returns>Le cours complet désiré.</returns>
        public Cours ObtenirCours(Cours unCours)
        {
            return listeCours.Find(x => x.Equals(unCours));
        }

        /// <summary>
        /// Méthode de service permettant de savoir si un cours est présent dans le département.
        /// </summary>
        /// <param name="unCours">Cours contenant les informations uniques.</param>
        /// <returns>True si le cours est présent... False sinon...</returns>
        public bool SiCoursPresent(Cours unCours)
        {
            return listeCours.Contains(unCours);
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter un cours au département.
        /// </summary>
        /// <param name="unCours">Le cours a ajouter...</param>
        public void AjouterCours(Cours unCours)
        {
           // if (SiCoursPresent(unCours))
              //  throw new Exception("Erreur - Le cours est déjà présent.");
            listeCours.Add(unCours);
            //if (!SiCoursPresent(unCours))
              //  throw new Exception("Erreur - Problème lors de l'ajout du cours.");
        }

        /// <summary>
        /// Méthode de service permettant d'enlever un cours du département.
        /// </summary>
        /// <param name="unCours">Le cours contenant les informations uniques a enlever...</param>
        public void EnleverCours(Cours unCours)
        {
            if (!SiCoursPresent(unCours))
                throw new Exception("Erreur - Le cours est déjà absent.");
            listeCours.Remove(unCours);
            if(SiCoursPresent(unCours))
                throw new Exception("Erreur - Problème lors de l'enlèvement du cours.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le nombre de cours du département.
        /// </summary>
        /// <returns>Nombre de cours du département.</returns>
        public int ObtenirNombreCours()
        {
            return listeCours.Count;
        }

        /// <summary>
        /// Méthode de service permettant de savoir s'il y a aucun cours dans le département.
        /// </summary>
        /// <returns>True si aucun cours, False sinon...</returns>
        public bool SiAucunCours()
        {
            return ObtenirNombreEnseignant() == 0;
        }

        /// <summary>
        /// Méthode de service permettant de vider la liste des cours du département.
        /// </summary>
        public void ViderListeCours()
        {
            if (ObtenirNombreEnseignant() == 0)
                throw new Exception("Erreur - La liste des cours du département est déjà vide.");
            listeEnseignant.Clear();
            if (!SiAucunEnseignant())
                throw new Exception("Erreur - Problème lors du vidage de la liste des cours du département.");
        }

        #endregion MethodesService

        #region Overrides

        /// <summary>
        /// Méthode de service permettant d'obternir la version textuelle de l'objet Departement.
        /// </summary>
        /// <returns>Version textuelle de l'objet Departement.</returns>
        public override string ToString()
        {
            return Nom;
        }

        /// <summary>
        /// Méthode de service permettant de vérifier l'égalité entre deux objet Departement.
        /// Deux objets Departement sont égaux s'ils ont le même nom.
        /// </summary>
        /// <param name="obj">L'objet de comparaison.</param>
        /// <returns>Vrai si égal, Faux sinon...</returns>
        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is Departement) && Nom.Equals((obj as Departement).Nom);
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le HashCode de l'objet Departement.
        /// </summary>
        /// <returns>HashCode de l'objet Departement.</returns>
        public override int GetHashCode()
        {
            return Nom.Length;
        }

        #endregion Overrides
    }
}
