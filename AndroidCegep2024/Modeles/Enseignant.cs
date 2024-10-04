
/// <summary>
/// Namespace pour les classes de type Modèle.
/// </summary>
namespace AndroidCegep2024.Modeles
{
    /// <summary>
    /// Classe de type Modele représentant un enseignant.
    /// </summary>
    public class Enseignant : Personne
    {
        #region AttributsProprietes

        /// <summary>
        /// Attribut représentant le numéro d'employé de l'enseignant.
        /// </summary>
        private int noEmploye;
        /// <summary>
        /// Propriété représentant le numéro d'employé de l'enseignant.
        /// </summary>
        public int NoEmploye
        {
            get { return noEmploye; }
            set { noEmploye = value; }
        }

        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur avec paramètres.
        /// </summary>
        /// <param name="unNoEmploye">Numéro d'employé de l'enseignant.</param>
        /// <param name="unPrenom">Le prénom d'une personne.</param>
        /// <param name="unNom">Le nom d'une personne.</param>
        /// <param name="uneAdresse">L'adresse d'une personne.</param>
        /// <param name="uneVille">La ville d'une personne.</param>
        /// <param name="uneProvince">La province d'une personne.</param>
        /// <param name="unCodePostal">Le code postal d'une personne.</param>
        /// <param name="unTelephone">Le téléphone d'une personne.</param>
        /// <param name="unCourriel">Le courriel d'une personne.</param>
        public Enseignant(int unNoEmploye=0000000, string unPrenom="", string unNom="", string uneAdresse="", string uneVille="", string uneProvince="", string unCodePostal="", string unTelephone="", string unCourriel="")
        :base(unPrenom, unNom, uneAdresse, uneVille, uneProvince, unCodePostal, unTelephone, unCourriel)
        {
            NoEmploye = unNoEmploye;
        }

        #endregion Constructeurs

        #region Overrides

        /// <summary>
        /// Méthode de service permettant d'obternir la version textuelle de l'objet Enseignant.
        /// </summary>
        /// <returns>Version textuelle de l'objet Enseignant.</returns>
        public override string ToString()
        {
            return Prenom + " " + Nom;
        }

        /// <summary>
        /// Méthode de service permettant de vérifier l'égalité entre deux objet Enseignant.
        /// Deux objets Enseignant sont égaux s'ils ont le même numéro d'employé.
        /// </summary>
        /// <param name="obj">L'objet de comparaison.</param>
        /// <returns>Vrai si égal, Faux sinon...</returns>
        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is Enseignant) && NoEmploye.Equals((obj as Enseignant).NoEmploye);
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir le HashCode de l'objet Enseignant.
        /// </summary>
        /// <returns>HashCode de l'objet Enseignant.</returns>
        public override int GetHashCode()
        {
            return NoEmploye.GetHashCode();
        }

        #endregion Overrides
    }
}
