using AndroidCegep2024.Modeles;
using AndroidCegep2024.DTOs;
using AndroidCegep2024.DAOs;

/// <summary>
/// Namespace pour les classes de type Controleur.
/// </summary>
namespace AndroidCegep2024.Controleurs
{
    /// <summary>
    /// Classe représentant le controleur de l'application.
    /// </summary>
    public class CegepControleur
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant l'instance unique de la classe CegepControleur.
        /// </summary>
        private static CegepControleur instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static CegepControleur Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new CegepControleur();
                }
                //...on retourne l'instance unique.
                return instance;
            }
        }

        #endregion AttributsProprietes

        #region Controleurs

        /// <summary>
        /// Constructeur par défaut de la classe.
        /// </summary>
        private CegepControleur() { }

        #endregion Controleurs

        #region MethodesServices

        #region MethodesCegep

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des départements.
        /// </summary>
        /// <returns>Liste contenant les département.</returns>
        public List<CegepDTO> ObtenirListeCegep()
        {
            List<CegepDTO> listeCegepDTO = CegepRepository.Instance.ObtenirListeCegep();
            List<Cegep> listeCegep = new List<Cegep>();
            foreach (CegepDTO cegep in listeCegepDTO)
            {
                listeCegep.Add(new Cegep(cegep.Nom, cegep.Adresse, cegep.Ville, cegep.Province, cegep.CodePostal, cegep.Telephone, cegep.Courriel));
            }

            if (listeCegep.Count == listeCegepDTO.Count)
                return listeCegepDTO;
            else
                throw new Exception("Erreur lors du chargement des Cégeps, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le Cégep.
        /// </summary>
        /// <param name="nom">Le nom du Cégep.</param>
        /// <returns>Le DTO du Cégep.</returns>
        public CegepDTO ObtenirCegep(string nom)
        {
            CegepDTO cegepDTO = CegepRepository.Instance.ObtenirCegep(nom);
            Cegep cegep = new Cegep(cegepDTO.Nom, cegepDTO.Adresse, cegepDTO.Ville, cegepDTO.Province, cegepDTO.CodePostal, cegepDTO.Telephone, cegepDTO.Courriel);
            return new CegepDTO(cegep);
        }

        /// <summary>
        /// Méthode de service permettant de créer le Cégep.
        /// </summary>
        /// <param name="cegep">Le DTO du Cégep.</param>
        public void AjouterCegep(CegepDTO cegep)
        {
            bool OK = false;
            try
            {
                CegepRepository.Instance.ObtenirIdCegep(cegep.Nom);
            }
            catch (Exception)
            {
                OK = true;
            }

            if (OK)
            {
                Cegep unCegep = new Cegep(cegep.Nom, cegep.Adresse, cegep.Ville, cegep.Province, cegep.CodePostal, cegep.Telephone, cegep.Courriel);
                CegepRepository.Instance.AjouterCegep(cegep);
            }
            else
                throw new Exception("Erreur - Le Cégep est déjà existant.");

        }

        /// <summary>
        /// Méthode de service permettant de modifier le Cégep.
        /// </summary>
        /// <param name="cegep">Le DTO du Cégep.</param>
        public void ModifierCegep(CegepDTO cegepDTO)
        {
            CegepDTO cegepDTOBD = ObtenirCegep(cegepDTO.Nom);
            Cegep cegepBD = new Cegep(cegepDTOBD.Nom, cegepDTOBD.Adresse, cegepDTOBD.Ville, cegepDTOBD.Province, cegepDTOBD.CodePostal, cegepDTOBD.Telephone, cegepDTOBD.Courriel);

            if (cegepDTO.Adresse != cegepBD.Adresse || cegepDTO.Ville != cegepBD.Ville || cegepDTO.Province != cegepBD.Province || cegepDTO.CodePostal != cegepBD.CodePostal || cegepDTO.Telephone != cegepBD.Telephone || cegepDTO.Courriel != cegepBD.Courriel)
                CegepRepository.Instance.ModifierCegep(cegepDTO);
            else
                throw new Exception("Erreur - Veuillez modifier au moins une valeur.");
        }

        /// <summary>
        /// Méthode de service permettant de supprimer le Cégep.
        /// </summary>
        /// <param name="cegep">Le nom du Cégep.</param>
        /// <returns>True si supprimé, False sinon...</returns>
        public void SupprimerCegep(string nom)
        {
            CegepDTO cegepDTOBD = ObtenirCegep(nom);
            CegepRepository.Instance.SupprimerCegep(cegepDTOBD);
        }

        #endregion MethodesCegep

        #region MethodesDepartement

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des départements.
        /// </summary>
        /// <param name="nomCegep">Le nom du Cégep.</param>
        /// <returns>Liste contenant les département.</returns>
        public List<DepartementDTO> ObtenirListeDepartement(string nomCegep)
        {
            CegepDTO cegepDTO = ObtenirCegep(nomCegep);
            Cegep cegep = new Cegep(cegepDTO.Nom, cegepDTO.Adresse, cegepDTO.Ville, cegepDTO.Province, cegepDTO.CodePostal, cegepDTO.Telephone, cegepDTO.Courriel);

            List<DepartementDTO> listeDepartement = DepartementRepository.Instance.ObtenirListeDepartement(nomCegep);
            foreach (DepartementDTO departement in listeDepartement)
            {
                cegep.AjouterDepartement(new Departement(departement.No, departement.Nom, departement.Description));
            }

            if (cegep.ObtenirNombreDepartement() == listeDepartement.Count)
                return listeDepartement;
            else
                throw new Exception("Erreur lors du chargement des départements, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un département.
        /// </summary>
        /// <param name="departement">Le DTO du département désiré. (Informations du Equals nécessaires)</param>
        /// <returns>Le DTO du département désiré.</returns>
        public DepartementDTO ObtenirDepartement(string nomCegep, string nomDepartement)
        {
            DepartementDTO departementDTO = DepartementRepository.Instance.ObtenirDepartement(nomCegep, nomDepartement);

            if (departementDTO.Nom.Equals(nomDepartement))
                return departementDTO;
            else
                throw new Exception("Erreur lors de l'obtention du département, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter un département.
        /// </summary>
        /// <param name="nomCegep">Le nom du Cégep.</param>
        /// <param name="departement">Le DTO du département a ajouter.</param>
        public void AjouterDepartement(string nomCegep, DepartementDTO departement)
        {
            CegepDTO cegepDTO = ObtenirCegep(nomCegep);
            Cegep cegep = new Cegep(cegepDTO.Nom, cegepDTO.Adresse, cegepDTO.Ville, cegepDTO.Province, cegepDTO.CodePostal, cegepDTO.Telephone, cegepDTO.Courriel);
            List<DepartementDTO> listeDepartement = DepartementRepository.Instance.ObtenirListeDepartement(nomCegep);
            foreach (DepartementDTO departementDTO in listeDepartement)
            {
                cegep.AjouterDepartement(new Departement(departementDTO.No, departementDTO.Nom, departementDTO.Description));
            }

            cegep.AjouterDepartement(new Departement(departement.No, departement.Nom, departement.Description));

            DepartementRepository.Instance.AjouterDepartement(nomCegep, departement);
        }

        /// <summary>
        /// Méthode de service permettant de supprimer un département.
        /// </summary>
        /// <param name="nomCegep">Le nom du Cégep.</param> 
        /// <param name="departement">Le DTO du département a supprimer.</param>
        public void SupprimerDepartement(string nomCegep, string nomDepartement)
        {
            CegepDTO cegepDTO = ObtenirCegep(nomCegep);
            Cegep cegep = new Cegep(cegepDTO.Nom, cegepDTO.Adresse, cegepDTO.Ville, cegepDTO.Province, cegepDTO.CodePostal, cegepDTO.Telephone, cegepDTO.Courriel);

            List<DepartementDTO> listeDepartement = DepartementRepository.Instance.ObtenirListeDepartement(nomCegep);
            foreach (DepartementDTO departementDTO in listeDepartement)
            {
                cegep.AjouterDepartement(new Departement(departementDTO.No, departementDTO.Nom, departementDTO.Description));
            }

            cegep.EnleverDepartement(new Departement(unNom: nomDepartement));

            DepartementRepository.Instance.SupprimerDepartement(nomCegep, new DepartementDTO(new Departement(unNom: nomDepartement)));
        }

        #endregion MethodesDepartement

        #region MethodesEnseignant

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des enseignants.
        /// </summary>
        /// <param name="departement">Le DTO du département désiré.</param>
        /// <returns>Liste des enseignants.</returns>
        public List<EnseignantDTO> ObtenirListeEnseignant(string nomCegep, string nomDepartement)
        {
            DepartementDTO departementDTO = DepartementRepository.Instance.ObtenirDepartement(nomCegep, nomDepartement);
            Departement departementModele = new Departement(departementDTO.No, departementDTO.Nom, departementDTO.Description);

            List<EnseignantDTO> listeEnseignant = EnseignantRepository.Instance.ObtenirListeEnseignant(nomCegep, nomDepartement);

            foreach (EnseignantDTO enseignant in listeEnseignant)
            {
                departementModele.AjouterEnseignant(new Enseignant(enseignant.NoEmploye, enseignant.Nom, enseignant.Prenom, enseignant.Adresse, enseignant.Ville, enseignant.Province, enseignant.CodePostal, enseignant.Telephone, enseignant.Courriel));
            }

            if (departementModele.ObtenirNombreEnseignant() == listeEnseignant.Count)
                return listeEnseignant;
            else
                throw new Exception("Erreur lors de l'obtention des enseignants du département, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un enseignant.
        /// </summary>
        /// <param name="departement">Le DTO du département de l'enseignant.</param>
        /// <param name="enseignant">Le DTO de l'enseignant désiré.</param>
        /// <returns>Le DTO de l'enseignant désiré.</returns>
        public EnseignantDTO ObtenirEnseignant(string nomCegep, string nomDepartement, EnseignantDTO enseignant)
        {
            DepartementDTO departementDTO = DepartementRepository.Instance.ObtenirDepartement(nomCegep, nomDepartement);
            Departement departementModele = new Departement(departementDTO.No, departementDTO.Nom, departementDTO.Description);

            EnseignantDTO enseignantDTO = EnseignantRepository.Instance.ObtenirEnseignant(nomCegep, nomDepartement, enseignant.NoEmploye);

            departementModele.AjouterEnseignant(new Enseignant(enseignantDTO.NoEmploye, enseignantDTO.Nom, enseignantDTO.Prenom, enseignantDTO.Adresse, enseignantDTO.Ville, enseignantDTO.Province, enseignantDTO.CodePostal, enseignantDTO.Telephone, enseignantDTO.Courriel));

            if (departementModele.ObtenirNombreEnseignant() == 1)
                return enseignantDTO;
            else
                throw new Exception("Erreur lors de l'obtention d'un enseignant du département, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter un enseignant dans un département.
        /// </summary>
        /// <param name="departement">Le DTO du département dans lequel ajouter l'enseignant.</param>
        /// <param name="enseignant">Le DTO de l'enseignant à ajouter.</param>
        public void AjouterEnseignant(string nomCegep, string nomDepartement, EnseignantDTO enseignant)
        {
            DepartementDTO departementDTO = DepartementRepository.Instance.ObtenirDepartement(nomCegep, nomDepartement);
            Departement departementModele = new Departement(departementDTO.No, departementDTO.Nom, departementDTO.Description);

            List<EnseignantDTO> listeEnseignant = EnseignantRepository.Instance.ObtenirListeEnseignant(nomCegep, nomDepartement);

            foreach (EnseignantDTO enseignantItem in listeEnseignant)
            {
                departementModele.AjouterEnseignant(new Enseignant(enseignantItem.NoEmploye, enseignantItem.Nom, enseignantItem.Prenom, enseignantItem.Adresse, enseignantItem.Ville, enseignantItem.Province, enseignantItem.CodePostal, enseignantItem.Telephone, enseignantItem.Courriel));
            }

            departementModele.AjouterEnseignant(new Enseignant(enseignant.NoEmploye, enseignant.Nom, enseignant.Prenom, enseignant.Adresse, enseignant.Ville, enseignant.Province, enseignant.CodePostal, enseignant.Telephone, enseignant.Courriel));

            EnseignantRepository.Instance.AjouterEnseignant(nomCegep, departementDTO.Nom, enseignant);
        }

        /// <summary>
        /// Méthode de service permettant de modifier un enseignant.
        /// </summary>
        /// <param name="departement">Le DTO du département de l'enseignant.</param>
        /// <param name="enseignant">Le DTO de l'enseignant a modifier.</param>
        public void ModifierEnseignant(string nomCegep, string nomDepartement, EnseignantDTO enseignant)
        {
            EnseignantDTO enseignantDTO = ObtenirEnseignant(nomCegep, nomDepartement, enseignant);
            Enseignant enseignantModele = new Enseignant(enseignantDTO.NoEmploye, enseignantDTO.Prenom, enseignantDTO.Nom, enseignantDTO.Adresse, enseignantDTO.Ville, enseignantDTO.Province, enseignantDTO.CodePostal, enseignantDTO.Telephone, enseignantDTO.Courriel);

            if (enseignant.Nom != enseignantModele.Nom || enseignant.Prenom != enseignantModele.Prenom || enseignant.Adresse != enseignantModele.Adresse || enseignant.Ville != enseignantModele.Ville || enseignant.Province != enseignantModele.Province || enseignant.CodePostal != enseignantModele.CodePostal || enseignant.Telephone != enseignantModele.Telephone || enseignant.Courriel != enseignantModele.Courriel)
                EnseignantRepository.Instance.ModifierEnseignant(nomCegep, nomDepartement, enseignant);
            else
                throw new Exception("Erreur - Veuillez modifier au moins une valeur.");
        }

        /// <summary>
        /// Méthode de service permettant de supprimer un enseignant.
        /// </summary>
        /// <param name="departement">Le DTO du département de l'enseignant.</param>
        /// <param name="enseignant">Le DTO de l'enseignant a supprimer.</param>
        public void SupprimerEnseignant(string nomCegep, string nomDepartement, EnseignantDTO enseignant)
        {
            DepartementDTO departementDTO = DepartementRepository.Instance.ObtenirDepartement(nomCegep, nomDepartement);
            Departement departementModele = new Departement(departementDTO.No, departementDTO.Nom, departementDTO.Description);

            List<EnseignantDTO> listeEnseignant = EnseignantRepository.Instance.ObtenirListeEnseignant(nomCegep, nomDepartement);

            foreach (EnseignantDTO enseignantItem in listeEnseignant)
            {
                departementModele.AjouterEnseignant(new Enseignant(enseignantItem.NoEmploye, enseignantItem.Nom, enseignantItem.Prenom, enseignantItem.Adresse, enseignantItem.Ville, enseignantItem.Province, enseignantItem.CodePostal, enseignantItem.Telephone, enseignantItem.Courriel));
            }

            departementModele.EnleverEnseignant(new Enseignant(enseignant.NoEmploye, enseignant.Nom, enseignant.Prenom, enseignant.Adresse, enseignant.Ville, enseignant.Province, enseignant.CodePostal, enseignant.Telephone, enseignant.Courriel));

            EnseignantRepository.Instance.SupprimerEnseignant(nomCegep, departementDTO.Nom, enseignant);
        }

        #endregion MethodesEnseignant

        #region MethodesCours

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des cours.
        /// </summary>
        /// <param name="departement">Le DTO du département désiré.</param>
        /// <returns>Liste des cours.</returns>
        public List<CoursDTO> ObtenirListeCours(string nomCegep, string nomDepartement)
        {
            DepartementDTO departementDTO = DepartementRepository.Instance.ObtenirDepartement(nomCegep, nomDepartement);
            Departement departementModele = new Departement(departementDTO.No, departementDTO.Nom, departementDTO.Description);

            List<CoursDTO> listeCours = CoursRepository.Instance.ObtenirListeCours(nomCegep, nomDepartement);

            foreach (CoursDTO cours in listeCours)
            {
                departementModele.AjouterCours(new Cours(cours.No, cours.Nom, cours.Description));
            }

            if (departementModele.ObtenirNombreCours() == listeCours.Count)
                return listeCours;
            else
                throw new Exception("Erreur lors de l'obtention des cours du département, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un cours.
        /// </summary>
        /// <param name="departement">Le DTO du département du cours.</param>
        /// <param name="enseignant">Le DTO du cours désiré.</param>
        /// <returns>Le DTO complet du cours désiré.</returns>
        public CoursDTO ObtenirCours(string nomCegep, string nomDepartement, CoursDTO cours)
        {
            DepartementDTO departementDTO = DepartementRepository.Instance.ObtenirDepartement(nomCegep, nomDepartement);
            Departement departementModele = new Departement(departementDTO.No, departementDTO.Nom, departementDTO.Description);

            CoursDTO coursDTO = CoursRepository.Instance.ObtenirCours(nomCegep, nomDepartement, cours.Nom);

            departementModele.AjouterCours(new Cours(coursDTO.No, coursDTO.Nom, coursDTO.Description));

            if (departementModele.ObtenirNombreCours() == 1)
                return coursDTO;
            else
                throw new Exception("Erreur lors de l'obtention d'un cours du département, problème avec l'intégrité des données de la base de données.");
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter un cours dans un département.
        /// </summary>
        /// <param name="departement">Le DTO du département dans lequel ajouter l'enseignant.</param>
        /// <param name="cours">Le DTO du cours à ajouter.</param>
        public void AjouterCours(string nomCegep, string nomDepartement, CoursDTO cours)
        {
            DepartementDTO departementDTO = DepartementRepository.Instance.ObtenirDepartement(nomCegep, nomDepartement);
            Departement departementModele = new Departement(departementDTO.No, departementDTO.Nom, departementDTO.Description);

            List<CoursDTO> listeCours = CoursRepository.Instance.ObtenirListeCours(nomCegep, nomDepartement);

            foreach (CoursDTO coursItem in listeCours)
            {
                departementModele.AjouterCours(new Cours(coursItem.No, coursItem.Nom, coursItem.Description));
            }

            departementModele.AjouterCours(new Cours(cours.No, cours.Nom, cours.Description));

            CoursRepository.Instance.AjouterCours(nomCegep, departementDTO.Nom, cours);
        }

        /// <summary>
        /// Méthode de service permettant de modifier un cours.
        /// </summary>
        /// <param name="departement">Le DTO du département de l'enseignant.</param>
        /// <param name="cours">Le DTO du cours a modifier.</param>
        public void ModifierCours(string nomCegep, string nomDepartement, CoursDTO cours)
        {
            CoursDTO coursDTO = ObtenirCours(nomCegep, nomDepartement, cours);
            Cours coursModele = new Cours(coursDTO.No, coursDTO.Nom, coursDTO.Description);

            if (cours.No != coursModele.No || cours.Description != coursModele.Description)
                CoursRepository.Instance.ModifierCours(nomCegep, nomDepartement, cours);
            else
                throw new Exception("Erreur - Veuillez modifier au moins une valeur.");
        }

        /// <summary>
        /// Méthode de service permettant de supprimer un cours.
        /// </summary>
        /// <param name="departement">Le DTO du département du cours.</param>
        /// <param name="cours">Le DTO du cours a supprimer.</param>
        public void SupprimerCours(string nomCegep, string nomDepartement, CoursDTO cours)
        {
            DepartementDTO departementDTO = DepartementRepository.Instance.ObtenirDepartement(nomCegep, nomDepartement);
            Departement departementModele = new Departement(departementDTO.No, departementDTO.Nom, departementDTO.Description);

            List<CoursDTO> listeCours = CoursRepository.Instance.ObtenirListeCours(nomCegep, nomDepartement);

            foreach (CoursDTO coursItem in listeCours)
            {
                departementModele.AjouterCours(new Cours(coursItem.No, coursItem.Nom, coursItem.Description));
            }

            departementModele.EnleverCours(new Cours(unNom: cours.Nom));

            CoursRepository.Instance.SupprimerCours(nomCegep, departementDTO.Nom, cours);
        }

        #endregion MethodesCours

        #endregion MethodesServices
    }
}
