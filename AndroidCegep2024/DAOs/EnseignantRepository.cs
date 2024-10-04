using Microsoft.Data.SqlClient;
using System.Data;
using AndroidCegep2024.DTOs;
using AndroidCegep2024.Exceptions;

/// <summary>
/// Namespace pour les classe de type DAO.
/// </summary>
namespace AndroidCegep2024.DAOs
{
    /// <summary>
    /// Classe représentant le répository d'un enseignant.
    /// </summary>
    public class EnseignantRepository : Repository
    {
        #region AttributsProprietes

        /// <summary>
        /// Instance unique du repository.
        /// </summary>
        private static EnseignantRepository instance;

        /// <summary>
        /// Propriété permettant d'accèder à l'instance unique de la classe.
        /// </summary>
        public static EnseignantRepository Instance
        {
            get
            {
                //Si l'instance est null...
                if (instance == null)
                {
                    //... on crée l'instance unique...
                    instance = new EnseignantRepository();
                }
                //...on retourne l'instance unique.
                return instance;
            }
        }

        #endregion AttributsProprietes

        #region Constructeurs

        /// <summary>
        /// Constructeur privée du repository.
        /// </summary>
        private EnseignantRepository() :base() {}

        #endregion

        #region MethodesService

        /// <summary>
        /// Méthode de service permettant d'obtenir le ID d'un enseignant selon ses informatiques uniques.
        /// </summary>
        /// <param name="nomCegep">Le nom du Cégep.</param>
        /// <param name="nomDepartement">Le nom du département.</param>
        /// <param name="noEmploye">Le numéro de l'employé.</param>
        /// <returns>Le ID de l'enseignant.</returns>
        public int ObtenirIdEnseignant(string nomCegep, string nomDepartement, int noEmploye)
        {
            SqlCommand command = new SqlCommand(" SELECT Id " +
                                                "   FROM Enseignants " +
                                                "  WHERE noEmploye = @noEmploye " +
                                                "    AND IdDepartement = @idDepartement", connexion);

            SqlParameter noEmployeParam = new SqlParameter("@noEmploye", SqlDbType.Int);
            SqlParameter idDepartementParam = new SqlParameter("@idDepartement", SqlDbType.Int);

            noEmployeParam.Value = noEmploye;
            idDepartementParam.Value = DepartementRepository.Instance.ObtenirIdDepartement(nomCegep, nomDepartement);

            command.Parameters.Add(noEmployeParam);
            command.Parameters.Add(idDepartementParam);

            int id;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                id = reader.GetInt32(0);
                reader.Close();
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'un id de l'enseignant par son numéro d'employé, sont département et son Cégep...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir la liste des enseignants d'un département.
        /// </summary>
        /// <param name="nomCegep">Le nom du Cégep.</param>
        /// <param name="nomDepartement">Le nom du département.</param>
        /// <returns>Liste des départements.</returns>
        public List<EnseignantDTO> ObtenirListeEnseignant(string nomCegep, string nomDepartement)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                "   FROM Enseignants " +
                                                "  WHERE IdDepartement = @idDepartement", connexion);

            SqlParameter idDepartementParam = new SqlParameter("@idDepartement", SqlDbType.Int);

            idDepartementParam.Value = DepartementRepository.Instance.ObtenirIdDepartement(nomCegep, nomDepartement);

            command.Parameters.Add(idDepartementParam);

            List<EnseignantDTO> liste = new List<EnseignantDTO>();

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    EnseignantDTO enseignant = new EnseignantDTO(reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9));
                    liste.Add(enseignant);
                }
                reader.Close();
                return liste;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention de la liste des enseignants par le nom du département et le nom du Cégep...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'obtenir un enseignant selon ses informations uniques.
        /// </summary>
        /// <param name="nomCegep">Nom du Cégep.</param>
        /// <param name="nomCegep">Nom du département.</param>
        /// <param name="noEmploye">No de l'employé.</param>
        /// <returns>Le DTO de l'enseignant.</returns>
        public EnseignantDTO ObtenirEnseignant(string nomCegep, string nomDepartement, int noEmploye)
        {
            SqlCommand command = new SqlCommand(" SELECT * " +
                                                " FROM Enseignants " +
                                                " WHERE NoEmploye = @noEmploye " +
                                                "   AND IdDepartement = @idDepartement", connexion);

            SqlParameter noEmployeParam = new SqlParameter("@noEmploye", SqlDbType.Int);
            SqlParameter idDepartementParam = new SqlParameter("@idDepartement", SqlDbType.Int);

            noEmployeParam.Value = noEmploye;
            idDepartementParam.Value = DepartementRepository.Instance.ObtenirIdDepartement(nomCegep, nomDepartement);

            command.Parameters.Add(noEmployeParam);
            command.Parameters.Add(idDepartementParam);

            EnseignantDTO unEnseignant;

            try
            {
                OuvrirConnexion();
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                unEnseignant = new EnseignantDTO(reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9));
                reader.Close();
            return unEnseignant;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'obtention d'un enseignant par son numéro d'employé, son département et son cégep...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant d'ajouter un enseignant.
        /// </summary>
        /// <param name="nomCegep">Le nom du Cégep.</param>
        /// <param name="nomDepartement">Le nom du departement.</param>
        /// <param name="enseignantDTO">Le DTO de l'enseignant.</param>
        public void AjouterEnseignant(string nomCegep, string nomDepartement, EnseignantDTO enseignantDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " INSERT INTO Enseignants (NoEmploye, Nom, Prenom, Adresse, Ville, Province, CodePostal, Telephone, Courriel, IdDepartement) " +
                                  " VALUES (@noEmploye, @nom, @prenom, @adresse, @ville, @province, @codePostal, @telephone, @courriel, @idDepartement) ";

            SqlParameter noEmployeParam = new SqlParameter("@noEmploye", SqlDbType.Int);
            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            SqlParameter prenomParam = new SqlParameter("@prenom", SqlDbType.VarChar, 50);
            SqlParameter adresseParam = new SqlParameter("@adresse", SqlDbType.VarChar, 100);
            SqlParameter villeParam = new SqlParameter("@ville", SqlDbType.VarChar, 100);
            SqlParameter provinceParam = new SqlParameter("@province", SqlDbType.VarChar, 50);
            SqlParameter codePostalParam = new SqlParameter("@codePostal", SqlDbType.VarChar, 7);
            SqlParameter telephoneParam = new SqlParameter("@telephone", SqlDbType.VarChar, 12);
            SqlParameter courrielParam = new SqlParameter("@courriel", SqlDbType.VarChar, 100);
            SqlParameter idDepartementParam = new SqlParameter("@idDepartement", SqlDbType.Int);

            noEmployeParam.Value = enseignantDTO.NoEmploye;
            nomParam.Value = enseignantDTO.Nom;
            prenomParam.Value = enseignantDTO.Prenom;
            adresseParam.Value = enseignantDTO.Adresse;
            villeParam.Value = enseignantDTO.Ville;
            provinceParam.Value = enseignantDTO.Province;
            codePostalParam.Value = enseignantDTO.CodePostal;
            telephoneParam.Value = enseignantDTO.Telephone;
            courrielParam.Value = enseignantDTO.Courriel;
            idDepartementParam.Value = DepartementRepository.Instance.ObtenirIdDepartement(nomCegep, nomDepartement);

            command.Parameters.Add(noEmployeParam);
            command.Parameters.Add(nomParam);
            command.Parameters.Add(prenomParam);
            command.Parameters.Add(adresseParam);
            command.Parameters.Add(villeParam);
            command.Parameters.Add(provinceParam);
            command.Parameters.Add(codePostalParam);
            command.Parameters.Add(telephoneParam);
            command.Parameters.Add(courrielParam);
            command.Parameters.Add(idDepartementParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DBUniqueException("Erreur lors de l'ajout d'un enseignant...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de modifier un enseignant.
        /// </summary>
        /// <param name="nomCegep">Le nom du Cégep.</param>
        /// <param name="nomDepartement">Le nom du département.</param>
        /// <param name="enseignantDTO">Le DTO de l'enseignant.</param>
        public void ModifierEnseignant(string nomCegep, string nomDepartement, EnseignantDTO enseignantDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " UPDATE Enseignants " +
                                     " SET Nom = @nom, " +
                                     "     Prenom = @prenom, " +
                                     "     Adresse = @adresse, " +
                                     "     Ville = @ville, " +
                                     "     Province = @province, " +
                                     "     CodePostal = @codePostal, " +
                                     "     Telephone = @telephone, " +
                                     "     Courriel = @courriel " +
                                   " WHERE NoEmploye = @noEmploye " +
                                   "   AND idDepartement = @idDepartement ";

            SqlParameter noEmployeParam = new SqlParameter("@noEmploye", SqlDbType.Int);
            SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar, 50);
            SqlParameter prenomParam = new SqlParameter("@prenom", SqlDbType.VarChar, 50);
            SqlParameter adresseParam = new SqlParameter("@adresse", SqlDbType.VarChar, 100);
            SqlParameter villeParam = new SqlParameter("@ville", SqlDbType.VarChar, 100);
            SqlParameter provinceParam = new SqlParameter("@province", SqlDbType.VarChar, 50);
            SqlParameter codePostalParam = new SqlParameter("@codePostal", SqlDbType.VarChar, 7);
            SqlParameter telephoneParam = new SqlParameter("@telephone", SqlDbType.VarChar, 12);
            SqlParameter courrielParam = new SqlParameter("@courriel", SqlDbType.VarChar, 100);
            SqlParameter idDepartementParam = new SqlParameter("@idDepartement", SqlDbType.Int);

            noEmployeParam.Value = enseignantDTO.NoEmploye;
            nomParam.Value = enseignantDTO.Nom;
            prenomParam.Value = enseignantDTO.Prenom;
            adresseParam.Value = enseignantDTO.Adresse;
            villeParam.Value = enseignantDTO.Ville;
            provinceParam.Value = enseignantDTO.Province;
            codePostalParam.Value = enseignantDTO.CodePostal;
            telephoneParam.Value = enseignantDTO.Telephone;
            courrielParam.Value = enseignantDTO.Courriel;
            idDepartementParam.Value = DepartementRepository.Instance.ObtenirIdDepartement(nomCegep, nomDepartement);

            command.Parameters.Add(noEmployeParam);
            command.Parameters.Add(nomParam);
            command.Parameters.Add(prenomParam);
            command.Parameters.Add(adresseParam);
            command.Parameters.Add(villeParam);
            command.Parameters.Add(provinceParam);
            command.Parameters.Add(codePostalParam);
            command.Parameters.Add(telephoneParam);
            command.Parameters.Add(courrielParam);
            command.Parameters.Add(idDepartementParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la modification d'un enseignant...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        /// <summary>
        /// Méthode de service permettant de supprimer un enseignant.
        /// </summary>
        /// <param name="nomCegep">Le nom du Cégep.</param>
        /// <param name="nomDepartement">Le nom du département.</param>
        /// <param name="enseignantDTODTO">Le DTO de l'enseignant.</param>
        public void SupprimerEnseignant(string nomCegep, string nomDepartement, EnseignantDTO enseignantDTO)
        {
            SqlCommand command = new SqlCommand(null, connexion);

            command.CommandText = " DELETE " +
                                    " FROM Enseignants " +
                                   " WHERE Id = @id ";

            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);

            idParam.Value = ObtenirIdEnseignant(nomCegep, nomDepartement, enseignantDTO.NoEmploye);

            command.Parameters.Add(idParam);

            try
            {
                OuvrirConnexion();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la supression d'un enseignant...", ex);
            }
            finally
            {
                FermerConnexion();
            }
        }

        #endregion
    }
}
